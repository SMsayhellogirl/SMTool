using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JTC_Help.Apply
{
    /// <summary>
    /// 專屬於報名系統的下拉選單(目前還有CBMC的影子 要刪 2020/07/28)
    /// </summary>
    public class DdlHelp
    {
        /// <summary>
        /// 轉換類型 QuestType 1:簡答 2:段落 3:選擇題 4:核取方塊 5:下拉式選單 6:日期
        /// </summary>
        /// <param name="qt"></param>
        /// <returns></returns>
        public string getStrQuestType(int qt)
        {
            string name = "";

            switch (qt)
            {
                case 1:
                    name = "簡答";
                    break;
                case 2:
                    name = "段落";
                    break;
                case 3:
                    name = "選擇題";
                    break;
                case 4:
                    name = "核取方塊";
                    break;
                case 5:
                    name = "下拉式選單";
                    break;
                case 6:
                    name = "日期";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 類型 QuestType 下拉選單  filed / val
        /// </summary>
        /// <returns></returns>
        public List<ddliTypeModel> getQuestTypeList()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            {
                new ddliTypeModel(){ filed = "簡答", val = 1},
                new ddliTypeModel(){ filed = "段落", val = 2},
                new ddliTypeModel(){ filed = "選擇題", val = 3},
                new ddliTypeModel(){ filed = "核取方塊", val = 4},
                new ddliTypeModel(){ filed = "下拉式選單", val = 5},
                new ddliTypeModel(){ filed = "日期", val = 6}
            };
            return ddl;
        }

        //識別項  1:姓名 2:email 3:市話 4:手機 5:地址 6:身分字號 7:生日 8:分會 9: 金流
        //20200215 姓名、性別、護照英文名、生日、身分證、手機、E-mail、地址、學歷、公司名稱、職稱、所屬教會、分會
        /// <summary>
        /// 轉換識別項 可不選 QuestSpot 1:姓名 2:email 3:市話 4:手機 5:地址 6:身分字號 7:生日 8:分會 9: 金流 10:性別 11:護照英文名 12:學歷 13:公司名稱 14:職稱 15:所屬教會
        /// </summary>
        /// <param name="qt"></param>
        /// <returns></returns>
        public string getStrQuestSpot(int? qt)
        {
            string name = "";

            if (qt.HasValue)
            {
                switch (qt)
                {
                    case 1:
                        name = "姓名";
                        break;
                    case 2:
                        name = "Email";
                        break;
                    case 3:
                        name = "市話";
                        break;
                    case 4:
                        name = "手機";
                        break;
                    case 5:
                        name = "地址";
                        break;
                    case 6:
                        name = "身分證字號";
                        break;
                    case 7:
                        name = "生日";
                        break;
                    case 8:
                        name = "CBMC分會";
                        break;
                    case 9:
                        name = "金流";
                        break;
                    case 10:
                        name = "性別";
                        break;
                    case 11:
                        name = "護照英文名";
                        break;
                    case 12:
                        name = "學歷";
                        break;
                    case 13:
                        name = "公司名稱";
                        break;
                    case 14:
                        name = "職稱";
                        break;
                    case 15:
                        name = "所屬教會";
                        break;
                }
            }
            return name;
        }

        /// <summary>
        /// 類型 QuestSpot 下拉選單all  filed / val
        /// </summary>
        /// <returns></returns>
        public List<ddliTypeModel> getQuestSpotListAll()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            {
                new ddliTypeModel(){ filed = "姓名", val = 1},
                new ddliTypeModel(){ filed = "Email", val = 2},
                new ddliTypeModel(){ filed = "市話", val = 3},
                new ddliTypeModel(){ filed = "手機", val = 4},
                new ddliTypeModel(){ filed = "地址", val = 5},
                new ddliTypeModel(){ filed = "身分證字號", val = 6},
                new ddliTypeModel(){ filed = "生日", val = 7},
                new ddliTypeModel(){ filed = "CBMC分會", val = 8},
                 new ddliTypeModel(){ filed = "金流", val = 9},
                 new ddliTypeModel(){ filed = "性別", val = 10},
                 new ddliTypeModel(){ filed = "護照英文名", val = 11},
                 new ddliTypeModel(){ filed = "學歷", val = 12},
                 new ddliTypeModel(){ filed = "公司名稱", val = 13},
                 new ddliTypeModel(){ filed = "職稱", val = 14},
                 new ddliTypeModel(){ filed = "所屬教會", val = 15}
            };
            return ddl;
        }



        /// <summary>
        /// 類型 QuestSpot 下拉選單 簡答專用  filed / val
        /// </summary>
        /// <returns></returns>
        public List<ddliTypeModel> getQuestSpotListonly1(List<QuestSpotModel> have, int now = 0)
        {
            List<ddliTypeModel> ddlnew = new List<ddliTypeModel>();
            bool val1 = true;
            bool val2 = true;
            bool val3 = true;
            bool val4 = true;
            bool val5 = true;
            bool val6 = true;
            bool val11 = true;
            bool val12 = true;
            bool val13 = true;
            bool val14 = true;
            //bool val15 = true;

            foreach (var a in have)
            {
                switch (a.QuestSpot)
                {
                    case 1:
                        val1 = false;
                        break;
                    case 2:
                        val2 = false;
                        break;
                    case 3:
                        val3 = false;
                        break;
                    case 4:
                        val4 = false;
                        break;
                    case 5:
                        val5 = false;
                        break;
                    case 6:
                        val6 = false;
                        break;
                    case 11:
                        val11 = false;
                        break;
                    case 12:
                        val12 = false;
                        break;
                    case 13:
                        val13 = false;
                        break;
                    case 14:
                        val14 = false;
                        break;
                    //case 15:
                    //    val15 = false;
                    //    break;
                }
            }

            if (now != 0)
            {
                switch (now)
                {
                    case 1:
                        val1 = true;
                        break;
                    case 2:
                        val2 = true;
                        break;
                    case 3:
                        val3 = true;
                        break;
                    case 4:
                        val4 = true;
                        break;
                    case 5:
                        val5 = true;
                        break;
                    case 6:
                        val6 = true;
                        break;
                    case 11:
                        val11 = true;
                        break;
                    case 12:
                        val12 = true;
                        break;
                    case 13:
                        val13 = true;
                        break;
                    case 14:
                        val14 = true;
                        break;
                    //case 15:
                    //    val15 = true;
                    //    break;
                }
            }

            if (val1)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "姓名", val = 1 });
            }
            if (val2)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "Email", val = 2 });
            }
            if (val3)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "市話", val = 3 });
            }
            if (val4)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "手機", val = 4 });
            }
            if (val5)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "地址", val = 5 });
            }
            if (val6)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "身分證字號", val = 6 });
            }
            if (val11)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "護照英文名", val = 11 });
            }
            if (val12)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "學歷", val = 12 });
            }
            if (val13)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "公司名稱", val = 13 });
            }
            if (val14)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "職稱", val = 14 });
            }
            //if (val15)
            //{
            //    ddlnew.Add(new ddliTypeModel() { filed = "所屬教會", val = 15 });
            //}


            //List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            //{
            //    new ddliTypeModel(){ filed = "姓名", val = 1},
            //    new ddliTypeModel(){ filed = "Email", val = 2},
            //    new ddliTypeModel(){ filed = "市話", val = 3},
            //    new ddliTypeModel(){ filed = "手機", val = 4},
            //    new ddliTypeModel(){ filed = "地址", val = 5},
            //    new ddliTypeModel(){ filed = "身分證字號", val = 6}
            //};



            return ddlnew;
        }

        /// <summary>
        /// 類型 QuestSpot 下拉選單 選擇題專用  filed / val
        /// </summary>
        /// <returns></returns>
        public List<ddliTypeModel> getQuestSpotListonly3(List<QuestSpotModel> have, int now = 0)
        {
            List<ddliTypeModel> ddlnew = new List<ddliTypeModel>();
            bool val9 = true;
            bool val10 = true;
            foreach (var a in have)
            {
                if (a.QuestSpot == 9)
                {
                    val9 = false;
                    break;
                }
                if (a.QuestSpot == 10)
                {
                    val10 = false;
                    break;
                }
            }
            if (now != 0)
            {
                if (now == 9)
                {
                    val9 = true;
                }
                if (now == 10)
                {
                    val10 = true;
                }
            }
            if (val9)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "金流", val = 9 });
            }
            if (val10)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "性別", val = 10 });
            }
            return ddlnew;
        }

        /// <summary>
        /// 類型 QuestSpot 下拉選單 下拉選單專用  filed / val
        /// </summary>
        /// <returns></returns>
        public List<ddliTypeModel> getQuestSpotListonly5(List<QuestSpotModel> have, int now = 0)
        {
            List<ddliTypeModel> ddlnew = new List<ddliTypeModel>();
            bool val8 = true;
            foreach (var a in have)
            {
                if (a.QuestSpot == 8)
                {
                    val8 = false;
                    break;
                }
            }
            if (now != 0)
            {
                if (now == 8)
                {
                    val8 = true;
                }
            }
            if (val8)
            {
                //ddlnew.Add(new ddliTypeModel() { filed = "CBMC分會", val = 8 });
            }

            //List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            //{
            //    new ddliTypeModel(){ filed = "CBMC分會", val = 8}
            //};
            return ddlnew;
        }

        /// <summary>
        /// 類型 QuestSpot 下拉選單 日期專用  filed / val
        /// </summary>
        /// <returns></returns>
        public List<ddliTypeModel> getQuestSpotListonly6(List<QuestSpotModel> have, int now = 0)
        {
            List<ddliTypeModel> ddlnew = new List<ddliTypeModel>();
            bool val7 = true;
            foreach (var a in have)
            {
                if (a.QuestSpot == 7)
                {
                    val7 = false;
                    break;
                }
            }
            if (now != 0)
            {
                if (now == 7)
                {
                    val7 = true;
                }
            }
            if (val7)
            {
                ddlnew.Add(new ddliTypeModel() { filed = "生日", val = 7 });
            }

            //List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            //{
            //    new ddliTypeModel(){ filed = "生日", val = 7}
            //};
            return ddlnew;
        }

        public string getStrisForB(int isForB)
        {
            string name = "";

            switch (isForB)
            {
                case 1:
                    name = "前";
                    break;
                case 2:
                    name = "後";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 確認選項是否為使用者可建  可:true 不可:false
        /// </summary>
        /// <param name="spot"></param>
        /// <returns></returns>
        public bool getSpotIsOk(int spot)
        {
            if (spot == 8 || spot == 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    /// filed val   int
    /// </summary>
    public class ddliTypeModel
    {
        public string filed { get; set; }

        public int val { get; set; }
    }

    /// <summary>
    /// filed val   string
    /// </summary>
    public class ddlsTypeModel
    {
        public string filed { get; set; }

        public string val { get; set; }
    }

    /// <summary>
    /// 判斷識別向用
    /// </summary>
    public class QuestSpotModel
    {
        public int QuestSpot { get; set; }

    }
}
