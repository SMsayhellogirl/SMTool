using JTC_Help.Apply;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help
{
    public class OtherHelp
    {
        public string GetSixUrl(string fullPath, string nowpage)
        {
            string back_page = "";
            if (fullPath.Contains("career1"))
            {
                back_page = nowpage + "1";
            }
            else if (fullPath.Contains("career2"))
            {
                back_page = nowpage + "2";
            }
            else if (fullPath.Contains("career3"))
            {
                back_page = nowpage + "3";
            }
            else if (fullPath.Contains("career4"))
            {
                back_page = nowpage + "4";
            }
            else if (fullPath.Contains("career5"))
            {
                back_page = nowpage + "5";
            }
            else if (fullPath.Contains("career6"))
            {
                back_page = nowpage + "6";
            }
            else
            {
                back_page = nowpage;
            }

            return back_page;
        }

        /// <summary>
        /// 取得亂數
        /// </summary>
        /// <param name="num">個數</param>
        /// <returns></returns>
        public string randstr(int num)
        {
            Random ra = new Random();
            string str = @"0123456789abcdefghigklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ";
            string restr = "";
            try
            {
                for (int i = 0; i < num; i++)
                {
                    restr += str.Substring(ra.Next((str.Length - 1)), 1);
                }
            }
            catch
            {

            }
            return restr.PadLeft(num, 'y');
        }

        public string GetDescription(Enum value)
        {
            Type type = value.GetType();

            //// 利用反射找出相對應的欄位
            var field = type.GetField(value.ToString());
            //// 取得欄位設定DescriptionAttribute的值
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            //// 無設定Description Attribute, 回傳Enum欄位名稱
            if (customAttribute == null || customAttribute.Length == 0)
            {
                return value.ToString();
            }

            //// 回傳Description Attribute的設定
            return ((DescriptionAttribute)customAttribute[0]).Description;
        }

        public string GetBannerStatus(int status)
        {
            string back = "未知";
            switch (status)
            {
                case 0:
                    back = "未申請";
                    break;
                case 1:
                    back = "待審核";
                    break;
                case 2:
                    back = "未派送";
                    break;
                case 3:
                    back = "退回";
                    break;
                case 4:
                    back = "已派送";
                    break;
                case 5:
                    back = "強制下架";
                    break;
            }
            return back;
        }
        public string GetBannerAction(int status)
        {
            string back = "未知";
            switch (status)
            {
                case 0:
                    back = "儲存";
                    break;
                case 1:
                    back = "申請";
                    break;
                case 2:
                    back = "審核";
                    break;
                case 3:
                    back = "退回";
                    break;
                case 4:
                    back = "派送";
                    break;
                case 5:
                    back = "強制下架";
                    break;
            }
            return back;
        }

        public string GetLectureTyep(int type)
        {
            string back = "未知";
            switch (type)
            {
                case 0:
                    back = "未選";
                    break;
                case 1:
                    back = "CPAS團體解析";
                    break;
                case 2:
                    back = "職涯規劃/職涯探索";
                    break;
                case 3:
                    back = "人際溝通";
                    break;
                case 4:
                    back = "情緒管理與壓力調適";
                    break;
                case 5:
                    back = "時間管理";
                    break;
                case 6:
                    back = "團隊合作";
                    break;
                case 7:
                    back = "履歷撰寫";
                    break;
                case 8:
                    back = "面試技巧";
                    break;
                case 9:
                    back = "職場禮儀";
                    break;
                case 10:
                    back = "勞動權益";
                    break;
                case 11:
                    back = "就業趨勢/科系出路";
                    break;
                case 12:
                    back = "學生職涯諮詢";
                    break;
                case 13:
                    back = "履歷健診";
                    break;
                case 14:
                    back = "面試模擬";
                    break;
                case 15:
                    back = "職輔人員/教師研習課程(教職員培訓)";
                    break;
                case 16:
                    back = "校園職涯諮詢師培訓課程(教職員培訓)";
                    break;
                case 17:
                    back = "家長/親職講座";
                    break;
                case 99:
                    back = "其他";
                    break;
            }
            return back;
        }

        public List<ddliTypeModel> GetLectureTyepList()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            {
                new ddliTypeModel(){ filed = "CPAS團體解析", val = 1},
                new ddliTypeModel(){ filed = "職涯規劃/職涯探索	", val = 2},
                new ddliTypeModel(){ filed = "人際溝通", val = 3},
                new ddliTypeModel(){ filed = "情緒管理與壓力調適", val = 4},
                new ddliTypeModel(){ filed = "時間管理", val = 5},
                new ddliTypeModel(){ filed = "團隊合作", val = 6},
                new ddliTypeModel(){ filed = "履歷撰寫", val = 7},
                new ddliTypeModel(){ filed = "面試技巧", val = 8},
                new ddliTypeModel(){ filed = "職場禮儀", val = 9},
                new ddliTypeModel(){ filed = "勞動權益", val = 10},
                new ddliTypeModel(){ filed = "就業趨勢/科系出路", val = 11},
                new ddliTypeModel(){ filed = "學生職涯諮詢", val = 12},
                new ddliTypeModel(){ filed = "履歷健診", val = 13},
                new ddliTypeModel(){ filed = "面試模擬", val = 14},
                new ddliTypeModel(){ filed = "職輔人員/教師研習課程(教職員培訓)", val = 15},
                new ddliTypeModel(){ filed = "校園職涯諮詢師培訓課程(教職員培訓)", val = 16},
                new ddliTypeModel(){ filed = "家長/親職講座", val = 17},
                new ddliTypeModel(){ filed = "其他", val = 99}
            };
            return ddl;
        }
        public string GetLectureStatus(int status)
        {
            string back = "待處理";
            switch (status)
            {
                case 1:
                    back = "處理中";
                    break;
                case 2:
                    back = "已處理";
                    break;
                case 3:
                    back = "取消";
                    break;
            }
            return back;
        }
        public List<ddliTypeModel> GetLectureStatusList()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            {
                new ddliTypeModel(){ filed = "待處理", val = 0},
                new ddliTypeModel(){ filed = "處理中", val = 1},
                new ddliTypeModel(){ filed = "已處理", val = 2},
                new ddliTypeModel(){ filed = "取消", val = 3}
            };
            return ddl;
        }
        public string GetLectureWaysToWrite(int status)
        {
            string back = "未知";
            switch (status)
            {
                case 1:
                    back = "依交通票據實報實銷，現金支付講師";
                    break;
                case 2:
                    back = "依交通票據實報實銷，事後匯款給講師（備銀行帳戶資料）";
                    break;
                case 3:
                    back = "Career開立發票給學校，款項匯入career帳戶。";
                    break;
            }
            return back;
        }
        public List<ddliTypeModel> GetLectureWaysToWriteList()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            {
                new ddliTypeModel(){ filed = "依交通票據實報實銷，現金支付講師", val = 1},
                new ddliTypeModel(){ filed = "依交通票據實報實銷，事後匯款給講師（備銀行帳戶資料）", val = 2},
                new ddliTypeModel(){ filed = "Career開立發票給學校，款項匯入career帳戶。", val = 3}
            };
            return ddl;
        }
        public string GetLectureOpen(int open)
        {
            string back = "無";
            switch (open)
            {
                case 1:
                    back = "二聯式";
                    break;
                case 2:
                    back = "三聯式";
                    break;
            }
            return back;
        }
        public List<ddliTypeModel> GetLectureOpenList()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>()
            {
                new ddliTypeModel(){ filed = "二聯式", val = 1},
                new ddliTypeModel(){ filed = "三聯式", val = 2}
            };
            return ddl;
        }

        public List<ddliTypeModel> GetTimeHourList()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>();
            for (int hour = 0; hour <= 23; hour++)
            {
                string text = hour.ToString("00");
                ddl.Add(new ddliTypeModel() { filed = text, val = hour });
            }
            return ddl;
        }
        public List<ddliTypeModel> GetTimeMinList()
        {
            List<ddliTypeModel> ddl = new List<ddliTypeModel>();
            for (int min = 0; min <= 59; min++)
            {
                string text = min.ToString("00");
                ddl.Add(new ddliTypeModel() { filed = text, val = min });
            }
            return ddl;
        }
        public string getPoubUrlString(string conller)
        {
            string back = "";
            switch (conller)
            {
                case "CareerActivities":
                    back = "職涯活動";
                    break;
                case "CareerNews":
                    back = "職涯智庫";
                    break;
                case "Talent":
                    back = "人才徵聘";
                    break;
                case "PersonnelTraning":
                    back = "人才培訓";
                    break;
                case "CampusArea":
                    back = "校園專區";
                    break;
                case "CareerClinic":
                    back = "職涯門診";
                    break;
            }
            return back;
        }
        /// <summary>
        /// type 0: (一) 1:一
        /// </summary>
        /// <param name="day"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string getDateDay(DayOfWeek day,int type = 0)
        {
            string back = "";
            try
            {
                string[] Day = new string[] { "日", "一", "二", "三", "四", "五", "六" };
                switch (type)
                {
                    case 0:
                        back = "(" + Day[Convert.ToInt16(day)] + ")";
                        break;
                    case 1:
                        back = Day[Convert.ToInt16(day)];
                        break;
                }
                return back;
            }
            catch
            {
                
            }
            return back;
        }
        /// <summary>
        /// 確認圖在不在
        /// </summary>
        /// <returns></returns>
        public bool GetUrlError(string curl)
        {
            bool isok = true;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(curl));
            ServicePointManager.Expect100Continue = false;
            try
            {
                ((HttpWebResponse)request.GetResponse()).Close();
            }
            catch (WebException exception)
            {
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    return false;
                }
                if (exception.Message.IndexOf("500 ") > 0)
                {
                    return false;
                }
                if (exception.Message.IndexOf("401 ") > 0)
                {
                    return false;
                }
                if (exception.Message.IndexOf("404") > 0)
                {
                    isok = false;
                }
            }
            return isok;
        }

        public class YtNeesModels
        {
            public bool Isok { get; set; }
            public string YoutubeId { get; set; }
            public string MqDefault { get; set; }
            public string MaxresDefault { get; set; }

        }

        public YtNeesModels getYtNeed(string url)
        {
            YtNeesModels reback = new YtNeesModels()
            {
                Isok = false
            };

            if (string.IsNullOrEmpty(url))
            {
                return reback;
            }

            if (url.Contains("?v="))
            {
                if (url.Contains("&"))
                {
                    int UrlLegth = url.IndexOf("&") - (url.IndexOf("?v=") + 3);
                    reback.YoutubeId = url.Substring(url.IndexOf("?v=") + 3, UrlLegth);
                }
                else
                {
                    reback.YoutubeId = url.Substring(url.IndexOf("?v=") + 3);
                }
            }
            else if (url.Contains("https://youtu.be/"))
            {
                reback.YoutubeId = url.Replace("https://youtu.be/", "");
            }
            else if (url.Contains("http://youtu.be/"))
            {
                reback.YoutubeId = url.Replace("http://youtu.be/", "");
            }

            if (!string.IsNullOrEmpty(reback.YoutubeId))
            {
                string MqDefault = "https://i.ytimg.com/vi/" + reback.YoutubeId + "/mqdefault.jpg";
                string MaxresDefault = "https://i.ytimg.com/vi/" + reback.YoutubeId + "/maxresdefault.jpg";
                reback.Isok = true;

                bool RetrunMqdefault = GetUrlError(MqDefault);
                if (RetrunMqdefault)
                    reback.MqDefault = MqDefault;

                bool RetrunMaxresdefault = GetUrlError(MaxresDefault);
                if (RetrunMaxresdefault)
                    reback.MaxresDefault = MaxresDefault;
            }

            return reback;
        }
        public int GetAgeByBirthdate(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }

        public string GetIntFomat(string value)
        {
            string strva = value;
            int iva = 0;
            if (int.TryParse(value, out iva))
            {
                strva = string.Format("{0:N0}", iva);
            }
            return strva;
        }
    }
}