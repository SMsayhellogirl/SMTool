using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JTC_Help.Apply
{
    /// <summary>
    /// 專屬於報名系統的CSV 匯出 (目前還有CBMC的影子 要刪 2020/07/28)
    /// </summary>
    public class CsvHelp
    {
        public StringBuilder ExpoCsv(List<dynamic> Qlist, string tit, List<GraceJMModel> gmlist, StringBuilder sb)
        {
            //20191230 增加會員
            //tit = tit + ",是否為會員,會員姓名,會員手機號碼,會員Email";
            tit = tit + ",是否為會員,報名日期";
            sb.AppendLine(tit);
            foreach (var q in Qlist)
            {
                GraceJMModel gmm = null;
                string val = "";
                int qleng = ((System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>)q).Count;
                for (int i = 0; i < qleng; i++)
                {
                    if (val == "")
                    {
                        val = safecsv(((object[])((System.Collections.Generic.IDictionary<string, object>)q).Values)[i]);
                        //第一個是編號ApmId
                        if (((object[])((System.Collections.Generic.IDictionary<string, object>)q).Values)[i] != null)
                        {
                            long amid = 0;
                            if (long.TryParse(((object[])((System.Collections.Generic.IDictionary<string, object>)q).Values)[i].ToString(), out amid))
                            {
                                gmm = gmlist.Where(e => e.ApmId == amid).FirstOrDefault();
                            }
                        }
                    }
                    else
                    {
                        val += "," + safecsv(((object[])((System.Collections.Generic.IDictionary<string, object>)q).Values)[i]);
                    }
                }
                if (gmm != null)
                {
                    //if (gmm.CellPhone != null)
                    //{
                    //    val += ",是" + "," + safecsv(gmm.Name) + "," + safecsv(gmm.CellPhone) + "," + safecsv(gmm.Email);
                    //}
                    //else
                    //{
                    //    val += ",否" + "," + "," + ",";
                    //}

                    if (gmm.CellPhone != null)
                    {
                        if (gmm.ApplyDate.HasValue)
                        {
                            val += ",是" + "," + safecsv(gmm.ApplyDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            val += ",是" + ", ";
                        }
                    }
                    else
                    {
                        if (gmm.ApplyDate.HasValue)
                        {
                            val += ",否" + "," + safecsv(gmm.ApplyDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            val += ",否" + ", ";
                        }
                    }
                }
                //else
                //{
                //    val += "," + "," + "," + ",";
                //}

                sb.AppendLine(val);
            }

            //for (int i = 0; i < customers.Count; i++)
            //{
            //    string[] customer = (string[])customers[i];
            //    for (int j = 0; j < customer.Length; j++)
            //    {
            //        //Append data with separator.
            //        sb.Append(customer[j] + ',');
            //    }

            //    //Append new line character.
            //    sb.Append("\r\n");
            //}
            return sb;
        }

        public string safecsv(object val)
        {
            string str = "";
            if (val != null)
            {
                str = val.ToString().Replace(",", "，");
                if (str.Length > 255)
                {

                    str = string.Format("{0}", str.Replace(",", "，").Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\"", "＂").Trim());
                }
                else
                {
                    str = string.Format("=\"{0}\"", str.Replace(",", "，").Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\"", "＂").Trim());
                }
            }
            return str;
        }
    }
    public class GraceJMModel
    {
        public long ApmId { get; set; }
        public System.Guid GraceId { get; set; }
        public string Name { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> ApplyDate { get; set; }
    }
}
