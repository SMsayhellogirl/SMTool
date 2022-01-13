using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JTC_Help.Local
{
    /// <summary>
    /// 產生mvc使用下拉選單
    /// </summary>
    public class DropdownHelp
    {
        /// <summary>
        /// 性別下拉選單
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> SexSelectListItems()
        {
            List<SelectListItem> SexList = new List<SelectListItem>();
            SexList.Add(new SelectListItem { Text = "女性", Value = "0" });
            SexList.Add(new SelectListItem { Text = "男性", Value = "1" });
            SexList.Add(new SelectListItem { Text = "未知", Value = "2" });
            return new SelectList(SexList, "Value", "Text");
        }

        /// <summary>
        /// 使用者推播裝置類型
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> UserPushDeviceTypeSelectListItems()
        {
            List<SelectListItem> UserPushDeviceType = new List<SelectListItem>();
            UserPushDeviceType.Add(new SelectListItem { Text = "Android", Value = "0" });
            UserPushDeviceType.Add(new SelectListItem { Text = "iOS", Value = "1" });
            UserPushDeviceType.Add(new SelectListItem { Text = "Windows8", Value = "2" });
            UserPushDeviceType.Add(new SelectListItem { Text = "WindowsPhone", Value = "3" });
            return new SelectList(UserPushDeviceType, "Value", "Text");
        }

        /// <summary>
        /// 民國年下拉選單
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YearSelectListItems(int addYear = 0)
        {
            List<SelectListItem> YearList = new List<SelectListItem>();
            YearList.Add(new SelectListItem { Text = "1930年以前(民國20年前)", Value = "0" });
            int nowDayadd = DateTime.Now.AddYears(addYear).Year;
            for (int i = 1931; i <= nowDayadd; i++)
            {
                YearList.Add(new SelectListItem { Text = i.ToString() + "年" + "(民國" + (i - 1911).ToString() + "年)", Value = i.ToString() });
            }
            return YearList.Select(year => new SelectListItem { Selected = (year.Value == "1980"), Text = year.Text, Value = year.Value });
        }

        /// <summary>
        /// 月下拉選單
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> MonthSelectListItems()
        {
            List<SelectListItem> MonthList = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    MonthList.Add(new SelectListItem { Text = "0" + i.ToString(), Value = "0" + i.ToString() });
                }
                else
                {
                    MonthList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                }
            }
            return new SelectList(MonthList, "Value", "Text");
        }

        /// <summary>
        /// 日下拉選單
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> DaySelectListItems(int mon = 0)
        {
            int howDay = 31;
            switch (mon)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    howDay = 31;
                    break;
                case 2:
                    howDay = 29;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    howDay = 30;
                    break;
            }

            List<SelectListItem> DayList = new List<SelectListItem>();
            for (int i = 1; i <= howDay; i++)
            {
                if (i < 10)
                {
                    DayList.Add(new SelectListItem { Text = "0" + i.ToString(), Value = "0" + i.ToString() });
                }
                else
                {
                    DayList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                }
            }
            return new SelectList(DayList, "Value", "Text");
        }

        /// <summary>
        /// 方便時段下拉選單
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ConvenientTimeSlotSelectListItems()
        {
            List<SelectListItem> TimeList = new List<SelectListItem>();
            TimeList.Add(new SelectListItem { Text = "早上", Value = "早上" });
            TimeList.Add(new SelectListItem { Text = "下午", Value = "下午" });
            TimeList.Add(new SelectListItem { Text = "晚上", Value = "晚上" });
            return new SelectList(TimeList, "Value", "Text");
        }

        /// <summary>
        /// 台灣鄉鎮縣市字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetTaiwanCity()
        {
            var city = new Dictionary<string, string>();
            city.Add("1630", "台北市");
            city.Add("2650", "新北市");
            city.Add("31000", "宜蘭縣");
            city.Add("41000", "桃園縣");
            city.Add("51001", "新竹市");
            city.Add("61000", "新竹縣");
            city.Add("71000", "苗栗縣");
            city.Add("81000", "彰化縣");
            city.Add("96600", "臺中市");
            city.Add("101000", "南投縣");
            city.Add("111000", "雲林縣");
            city.Add("121002", "嘉義市");
            city.Add("131001", "嘉義縣");
            city.Add("146700", "臺南市");
            city.Add("15640", "高雄市");
            city.Add("161001", "屏東縣");
            city.Add("171001", "臺東縣");
            city.Add("181001", "花蓮縣");
            city.Add("191001", "澎湖縣");
            city.Add("201001", "基隆市");
            city.Add("219007", "連江縣");
            city.Add("22902", "金門縣");
            return city;
        }

        /// <summary>
        /// 台灣鄉鎮縣市分區列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetTaiwanArea()
        {
            var o = new Dictionary<string, string>();

            #region 臺北市
            o.Add("16300100", "松山區");
            o.Add("16300200", "信義區");
            o.Add("16300400", "中山區");
            o.Add("16300300", "大安區");
            o.Add("16300500", "中正區");
            o.Add("16300600", "大同區");
            o.Add("16300700", "萬華區");
            o.Add("16300800", "文山區");
            o.Add("16300900", "南港區");
            o.Add("16301000", "內湖區");
            o.Add("16301100", "士林區");
            o.Add("16301200", "北投區");
            #endregion

            #region 新北市
            o.Add("26500001", "板橋區");
            o.Add("26500002", "三重區");
            o.Add("26500003", "中和區");
            o.Add("26500004", "永和區");
            o.Add("26500005", "新莊區");
            o.Add("26500006", "新店區");
            o.Add("26500007", "樹林區");
            o.Add("26500008", "鶯歌區");
            o.Add("26500009", "三峽區");
            o.Add("26500010", "淡水區");
            o.Add("26500011", "汐止區");
            o.Add("26500012", "瑞芳區");
            o.Add("26500013", "土城區");
            o.Add("26500014", "蘆洲區");
            o.Add("26500015", "五股區");
            o.Add("26500016", "泰山區");
            o.Add("26500017", "林口區");
            o.Add("26500018", "深坑區");
            o.Add("26500019", "石碇區");
            o.Add("26500020", "坪林區");
            o.Add("26500021", "三芝區");
            o.Add("26500022", "石門區");
            o.Add("26500023", "八里區");
            o.Add("26500024", "平溪區");
            o.Add("26500025", "雙溪區");
            o.Add("26500026", "貢寮區");
            o.Add("26500027", "金山區");
            o.Add("26500028", "萬里區");
            o.Add("26500029", "烏來區");
            #endregion

            #region 宜蘭縣
            o.Add("31000201", "宜蘭市");
            o.Add("31000202", "羅東鎮");
            o.Add("31000203", "蘇澳鎮");
            o.Add("31000204", "頭城鎮");
            o.Add("31000205", "礁溪鄉");
            o.Add("31000206", "壯圍鄉");
            o.Add("31000207", "員山鄉");
            o.Add("31000208", "冬山鄉");
            o.Add("31000209", "五結鄉");
            o.Add("31000210", "三星鄉");
            o.Add("31000211", "大同鄉");
            o.Add("31000212", "南澳鄉");
            #endregion

            #region 桃園縣
            o.Add("41000301", "桃園市");
            o.Add("41000302", "中壢市");
            o.Add("41000303", "大溪鎮");
            o.Add("41000304", "楊梅市");
            o.Add("41000305", "蘆竹鄉");
            o.Add("41000306", "大園鄉");
            o.Add("41000307", "龜山鄉");
            o.Add("41000308", "八德市");
            o.Add("41000309", "龍潭鄉");
            o.Add("41000310", "平鎮市");
            o.Add("41000311", "新屋鄉");
            o.Add("41000312", "觀音鄉");
            o.Add("41000313", "復興鄉");
            #endregion

            #region 新竹市
            o.Add("51001801", "東區");
            o.Add("51001802", "北區");
            o.Add("51001803", "香山區");
            #endregion

            #region 新竹縣
            o.Add("61000401", "竹北市");
            o.Add("61000402", "竹東鎮");
            o.Add("61000403", "新埔鎮");
            o.Add("61000404", "關西鎮");
            o.Add("61000405", "湖口鄉");
            o.Add("61000406", "新豐鄉");
            o.Add("61000407", "芎林鄉");
            o.Add("61000408", "橫山鄉");
            o.Add("61000409", "北埔鄉");
            o.Add("61000410", "寶山鄉");
            o.Add("61000411", "峨眉鄉");
            o.Add("61000412", "尖石鄉");
            o.Add("61000413", "五峰鄉");
            #endregion

            #region 苗栗縣
            o.Add("71000501", "苗栗市");
            o.Add("71000502", "苑裡鎮");
            o.Add("71000503", "通霄鎮");
            o.Add("71000504", "竹南鎮");
            o.Add("71000505", "頭份鎮");
            o.Add("71000506", "後龍鎮");
            o.Add("71000507", "卓蘭鎮");
            o.Add("71000508", "大湖鄉");
            o.Add("71000509", "公館鄉");
            o.Add("71000510", "銅鑼鄉");
            o.Add("71000511", "南庄鄉");
            o.Add("71000512", "頭屋鄉");
            o.Add("71000513", "三義鄉");
            o.Add("71000514", "西湖鄉");
            o.Add("71000515", "造橋鄉");
            o.Add("71000516", "三灣鄉");
            o.Add("71000517", "獅潭鄉");
            o.Add("71000518", "泰安鄉");
            #endregion

            #region 彰化縣
            o.Add("81000701", "彰化市");
            o.Add("81000702", "鹿港鎮");
            o.Add("81000703", "和美鎮");
            o.Add("81000704", "線西鄉");
            o.Add("81000705", "伸港鄉");
            o.Add("81000706", "福興鄉");
            o.Add("81000707", "秀水鄉");
            o.Add("81000708", "花壇鄉");
            o.Add("81000709", "芬園鄉");
            o.Add("81000710", "員林鎮");
            o.Add("81000711", "溪湖鎮");
            o.Add("81000712", "田中鎮");
            o.Add("81000713", "大村鄉");
            o.Add("81000714", "埔鹽鄉");
            o.Add("81000715", "埔心鄉");
            o.Add("81000716", "永靖鄉");
            o.Add("81000717", "社頭鄉");
            o.Add("81000718", "二水鄉");
            o.Add("81000719", "北斗鎮");
            o.Add("81000720", "二林鎮");
            o.Add("81000721", "田尾鄉");
            o.Add("81000722", "埤頭鄉");
            o.Add("81000723", "芳苑鄉");
            o.Add("81000724", "大城鄉");
            o.Add("81000725", "竹塘鄉");
            o.Add("81000726", "溪州鄉");
            #endregion

            #region 臺中市
            o.Add("96600001", "中區");
            o.Add("96600002", "東區");
            o.Add("96600003", "南區");
            o.Add("96600004", "西區");
            o.Add("96600005", "北區");
            o.Add("96600006", "西屯區");
            o.Add("96600007", "南屯區");
            o.Add("96600008", "北屯區");
            o.Add("96600009", "豐原區");
            o.Add("96600010", "東勢區");
            o.Add("96600011", "大甲區");
            o.Add("96600012", "清水區");
            o.Add("96600013", "沙鹿區");
            o.Add("96600014", "梧棲區");
            o.Add("96600015", "后里區");
            o.Add("96600016", "神岡區");
            o.Add("96600017", "潭子區");
            o.Add("96600018", "大雅區");
            o.Add("96600019", "新社區");
            o.Add("96600020", "石岡區");
            o.Add("96600021", "外埔區");
            o.Add("96600022", "大安區");
            o.Add("96600023", "烏日區");
            o.Add("96600024", "大肚區");
            o.Add("96600025", "龍井區");
            o.Add("96600026", "霧峰區");
            o.Add("96600027", "太平區");
            o.Add("96600028", "大里區");
            o.Add("96600029", "和平區");
            #endregion

            #region 南投縣
            o.Add("101000801", "南投市");
            o.Add("101000802", "埔里鎮");
            o.Add("101000803", "草屯鎮");
            o.Add("101000804", "竹山鎮");
            o.Add("101000805", "集集鎮");
            o.Add("101000806", "名間鄉");
            o.Add("101000807", "鹿谷鄉");
            o.Add("101000808", "中寮鄉");
            o.Add("101000809", "魚池鄉");
            o.Add("101000810", "國姓鄉");
            o.Add("101000811", "水里鄉");
            o.Add("101000812", "信義鄉");
            o.Add("101000813", "仁愛鄉");
            #endregion

            #region 雲林縣
            o.Add("111000901", "斗六市");
            o.Add("111000902", "斗南鎮");
            o.Add("111000903", "虎尾鎮");
            o.Add("111000904", "西螺鎮");
            o.Add("111000905", "土庫鎮");
            o.Add("111000906", "北港鎮");
            o.Add("111000907", "古坑鄉");
            o.Add("111000908", "大埤鄉");
            o.Add("111000909", "莿桐鄉");
            o.Add("111000910", "林內鄉");
            o.Add("111000911", "二崙鄉");
            o.Add("111000912", "崙背鄉");
            o.Add("111000913", "麥寮鄉");
            o.Add("111000914", "東勢鄉");
            o.Add("111000915", "褒忠鄉");
            o.Add("111000916", "臺西鄉");
            o.Add("111000917", "元長鄉");
            o.Add("111000918", "四湖鄉");
            o.Add("111000919", "口湖鄉");
            o.Add("111000920", "水林鄉");
            #endregion

            #region 嘉義市
            o.Add("121002001", "東區");
            o.Add("121002002", "西區");
            #endregion

            #region 嘉義縣
            o.Add("131001001", "太保市");
            o.Add("131001002", "朴子市");
            o.Add("131001003", "布袋鎮");
            o.Add("131001004", "大林鎮");
            o.Add("131001005", "民雄鄉");
            o.Add("131001006", "溪口鄉");
            o.Add("131001007", "新港鄉");
            o.Add("131001008", "六腳鄉");
            o.Add("131001009", "東石鄉");
            o.Add("131001010", "義竹鄉");
            o.Add("131001011", "鹿草鄉");
            o.Add("131001012", "水上鄉");
            o.Add("131001013", "中埔鄉");
            o.Add("131001014", "竹崎鄉");
            o.Add("131001015", "梅山鄉");
            o.Add("131001016", "番路鄉");
            o.Add("131001017", "大埔鄉");
            o.Add("131001018", "阿里山鄉");
            #endregion

            #region 臺南市
            o.Add("146700001", "新營區");
            o.Add("146700002", "鹽水區");
            o.Add("146700003", "白河區");
            o.Add("146700004", "柳營區");
            o.Add("146700005", "後壁區");
            o.Add("146700006", "東山區");
            o.Add("146700007", "麻豆區");
            o.Add("146700008", "下營區");
            o.Add("146700009", "六甲區");
            o.Add("146700010", "官田區");
            o.Add("146700011", "大內區");
            o.Add("146700012", "佳里區");
            o.Add("146700013", "學甲區");
            o.Add("146700014", "西港區");
            o.Add("146700015", "七股區");
            o.Add("146700016", "將軍區");
            o.Add("146700017", "北門區");
            o.Add("146700018", "新化區");
            o.Add("146700019", "善化區");
            o.Add("146700020", "新市區");
            o.Add("146700021", "安定區");
            o.Add("146700022", "山上區");
            o.Add("146700023", "玉井區");
            o.Add("146700024", "楠西區");
            o.Add("146700025", "南化區");
            o.Add("146700026", "左鎮區");
            o.Add("146700027", "仁德區");
            o.Add("146700028", "歸仁區");
            o.Add("146700029", "關廟區");
            o.Add("146700030", "龍崎區");
            o.Add("146700031", "永康區");
            o.Add("146700032", "東區");
            o.Add("146700033", "南區");
            o.Add("146700034", "北區");
            o.Add("146700037", "中西區");
            o.Add("146700035", "安南區");
            o.Add("146700036", "安平區");
            #endregion

            #region 高雄市
            o.Add("156400100", "鹽埕區");
            o.Add("156400200", "鼓山區");
            o.Add("156400300", "左營區");
            o.Add("156400400", "楠梓區");
            o.Add("156400500", "三民區");
            o.Add("156400600", "新興區");
            o.Add("156400700", "前金區");
            o.Add("156400800", "苓雅區");
            o.Add("156400900", "前鎮區");
            o.Add("156401000", "旗津區");
            o.Add("156401100", "小港區");
            o.Add("156400012", "鳳山區");
            o.Add("156400013", "林園區");
            o.Add("156400014", "大寮區");
            o.Add("156400015", "大樹區");
            o.Add("156400016", "大社區");
            o.Add("156400017", "仁武區");
            o.Add("156400018", "鳥松區");
            o.Add("156400019", "岡山區");
            o.Add("156400020", "橋頭區");
            o.Add("156400021", "燕巢區");
            o.Add("156400022", "田寮區");
            o.Add("156400023", "阿蓮區");
            o.Add("156400024", "路竹區");
            o.Add("156400025", "湖內區");
            o.Add("156400026", "茄萣區");
            o.Add("156400027", "永安區");
            o.Add("156400028", "彌陀區");
            o.Add("156400029", "梓官區");
            o.Add("156400030", "旗山區");
            o.Add("156400031", "美濃區");
            o.Add("156400032", "六龜區");
            o.Add("156400033", "甲仙區");
            o.Add("156400034", "杉林區");
            o.Add("156400035", "內門區");
            o.Add("156400036", "茂林區");
            o.Add("156400037", "桃源區");
            o.Add("156400038", "那瑪夏區");
            #endregion

            #region 屏東縣
            o.Add("161001301", "屏東市");
            o.Add("161001302", "潮州鎮");
            o.Add("161001303", "東港鎮");
            o.Add("161001304", "恆春鎮");
            o.Add("161001305", "萬丹鄉");
            o.Add("161001306", "長治鄉");
            o.Add("161001307", "麟洛鄉");
            o.Add("161001308", "九如鄉");
            o.Add("161001309", "里港鄉");
            o.Add("161001310", "鹽埔鄉");
            o.Add("161001311", "高樹鄉");
            o.Add("161001312", "萬巒鄉");
            o.Add("161001313", "內埔鄉");
            o.Add("161001314", "竹田鄉");
            o.Add("161001315", "新埤鄉");
            o.Add("161001316", "枋寮鄉");
            o.Add("161001317", "新園鄉");
            o.Add("161001318", "崁頂鄉");
            o.Add("161001319", "林邊鄉");
            o.Add("161001320", "南州鄉");
            o.Add("161001321", "佳冬鄉");
            o.Add("161001322", "琉球鄉");
            o.Add("161001323", "車城鄉");
            o.Add("161001324", "滿州鄉");
            o.Add("161001325", "枋山鄉");
            o.Add("161001326", "三地門鄉");
            o.Add("161001327", "霧臺鄉");
            o.Add("161001328", "瑪家鄉");
            o.Add("161001329", "泰武鄉");
            o.Add("161001330", "來義鄉");
            o.Add("161001331", "春日鄉");
            o.Add("161001332", "獅子鄉");
            o.Add("161001333", "牡丹鄉");
            #endregion

            #region 臺東縣
            o.Add("171001401", "臺東市");
            o.Add("171001402", "成功鎮");
            o.Add("171001403", "關山鎮");
            o.Add("171001404", "卑南鄉");
            o.Add("171001405", "鹿野鄉");
            o.Add("171001406", "池上鄉");
            o.Add("171001407", "東河鄉");
            o.Add("171001408", "長濱鄉");
            o.Add("171001409", "太麻里鄉");
            o.Add("171001410", "大武鄉");
            o.Add("171001411", "綠島鄉");
            o.Add("171001412", "海端鄉");
            o.Add("171001413", "延平鄉");
            o.Add("171001414", "金峰鄉");
            o.Add("171001415", "達仁鄉");
            o.Add("171001416", "蘭嶼鄉");
            #endregion

            #region 花蓮縣
            o.Add("181001501", "花蓮市");
            o.Add("181001502", "鳳林鎮");
            o.Add("181001503", "玉里鎮");
            o.Add("181001504", "新城鄉");
            o.Add("181001505", "吉安鄉");
            o.Add("181001506", "壽豐鄉");
            o.Add("181001507", "光復鄉");
            o.Add("181001508", "豐濱鄉");
            o.Add("181001509", "瑞穗鄉");
            o.Add("181001510", "富里鄉");
            o.Add("181001511", "秀林鄉");
            o.Add("181001512", "萬榮鄉");
            o.Add("181001513", "卓溪鄉");
            #endregion

            #region 澎湖縣
            o.Add("191001601", "馬公市");
            o.Add("191001602", "湖西鄉");
            o.Add("191001603", "白沙鄉");
            o.Add("191001604", "西嶼鄉");
            o.Add("191001605", "望安鄉");
            o.Add("191001606", "七美鄉");
            #endregion

            #region 基隆市
            o.Add("201001701", "中正區");
            o.Add("201001702", "七堵區");
            o.Add("201001703", "暖暖區");
            o.Add("201001704", "仁愛區");
            o.Add("201001705", "中山區");
            o.Add("201001706", "安樂區");
            o.Add("201001707", "信義區");
            #endregion

            #region 連江縣
            o.Add("21900701", "南竿鄉");
            o.Add("21900702", "北竿鄉");
            o.Add("21900703", "莒光鄉");
            o.Add("21900704", "東引鄉");
            #endregion

            #region 金門縣
            o.Add("22902001", "金城鎮");
            o.Add("22902002", "金沙鎮");
            o.Add("22902003", "金湖鎮");
            o.Add("22902004", "金寧鄉");
            o.Add("22902005", "烈嶼鄉");
            o.Add("22902006", "烏坵鄉");
            #endregion

            return o;
        }

        public class Address
        {
            public string City { get; set; }
            public string Dist { get; set; }
            public string Part { get; set; }
            public short? Zipcode { get; set; }

            public static bool TryParseZipCode(Address address, out short? Zip)
            {
                Zip = null;
                ZipMap.InitRepository();
                var zip = from map in ZipMap.ZipRepository
                          where map.City == address.City.Trim() && map.Dist == address.Dist.Trim()
                          select map.Zip;
                Zip = zip.FirstOrDefault();
                return (null != Zip);
            }
        }

        /// <summary>
        /// 取得郵遞區號
        /// </summary>
        /// <param name="City">城市</param>
        /// <param name="Area">區域</param>
        /// <returns>郵遞區號</returns>
        public static string GetZipCode(string City, string Area)
        {
            string sRet = "";

            Address a = new Address() { City = City, Dist = Area };
            short? zip;
            if (Address.TryParseZipCode(a, out zip))
            {
                a.Zipcode = zip;
            }

            if (a.Zipcode > 0)
            {
                sRet = a.Zipcode.ToString();
            }

            return sRet;
        }

        public class ZipMap
        {
            internal string City { get; set; }
            internal string Dist { get; set; }
            internal short Zip { get; set; }
            internal static List<ZipMap> ZipRepository = null;
            internal static void InitRepository()
            {
                if (null == ZipRepository)
                    ZipRepository = new List<ZipMap>
           {
               new ZipMap() { City = "基隆市", Dist = "仁愛區", Zip = 200 },
               new ZipMap() { City = "基隆市", Dist = "信義區", Zip = 201 },
               new ZipMap() { City = "基隆市", Dist = "中正區", Zip = 202 },
               new ZipMap() { City = "基隆市", Dist = "中山區", Zip = 203 },
               new ZipMap() { City = "基隆市", Dist = "安樂區", Zip = 204 },
               new ZipMap() { City = "基隆市", Dist = "暖暖區", Zip = 205 },
               new ZipMap() { City = "基隆市", Dist = "七堵區", Zip = 206 },

               new ZipMap() { City = "台北市", Dist = "中正區", Zip = 100 },
               new ZipMap() { City = "台北市", Dist = "大同區", Zip = 103 },
               new ZipMap() { City = "台北市", Dist = "中山區", Zip = 104 },
               new ZipMap() { City = "台北市", Dist = "松山區", Zip = 105 },
               new ZipMap() { City = "台北市", Dist = "大安區", Zip = 106 },
               new ZipMap() { City = "台北市", Dist = "萬華區", Zip = 108 },
               new ZipMap() { City = "台北市", Dist = "信義區", Zip = 110 },
               new ZipMap() { City = "台北市", Dist = "士林區", Zip = 111 },
               new ZipMap() { City = "台北市", Dist = "北投區", Zip = 112 },
               new ZipMap() { City = "台北市", Dist = "內湖區", Zip = 114 },
               new ZipMap() { City = "台北市", Dist = "南港區", Zip = 115 },
               new ZipMap() { City = "台北市", Dist = "文山區", Zip = 116 },

               new ZipMap() { City = "新北市", Dist = "萬里區", Zip = 207 },
               new ZipMap() { City = "新北市", Dist = "金山區", Zip = 208 },
               new ZipMap() { City = "新北市", Dist = "板橋區", Zip = 220 },
               new ZipMap() { City = "新北市", Dist = "汐止區", Zip = 221 },
               new ZipMap() { City = "新北市", Dist = "深坑區", Zip = 222 },
               new ZipMap() { City = "新北市", Dist = "石碇區", Zip = 223 },
               new ZipMap() { City = "新北市", Dist = "瑞芳區", Zip = 224 },
               new ZipMap() { City = "新北市", Dist = "平溪區", Zip = 226 },
               new ZipMap() { City = "新北市", Dist = "雙溪區", Zip = 227 },
               new ZipMap() { City = "新北市", Dist = "貢寮區", Zip = 228 },
               new ZipMap() { City = "新北市", Dist = "新店區", Zip = 231 },
               new ZipMap() { City = "新北市", Dist = "坪林區", Zip = 232 },
               new ZipMap() { City = "新北市", Dist = "烏來區", Zip = 233 },
               new ZipMap() { City = "新北市", Dist = "永和區", Zip = 234 },
               new ZipMap() { City = "新北市", Dist = "中和區", Zip = 235 },
               new ZipMap() { City = "新北市", Dist = "土城區", Zip = 236 },
               new ZipMap() { City = "新北市", Dist = "三峽區", Zip = 237 },
               new ZipMap() { City = "新北市", Dist = "樹林區", Zip = 238 },
               new ZipMap() { City = "新北市", Dist = "鶯歌區", Zip = 239 },
               new ZipMap() { City = "新北市", Dist = "三重區", Zip = 241 },
               new ZipMap() { City = "新北市", Dist = "新莊區", Zip = 242 },
               new ZipMap() { City = "新北市", Dist = "泰山區", Zip = 243 },
               new ZipMap() { City = "新北市", Dist = "林口區", Zip = 244 },
               new ZipMap() { City = "新北市", Dist = "蘆洲區", Zip = 247 },
               new ZipMap() { City = "新北市", Dist = "五股區", Zip = 248 },
               new ZipMap() { City = "新北市", Dist = "八里區", Zip = 249 },
               new ZipMap() { City = "新北市", Dist = "淡水區", Zip = 251 },
               new ZipMap() { City = "新北市", Dist = "三芝區", Zip = 252 },
               new ZipMap() { City = "新北市", Dist = "石門區", Zip = 253 },

               new ZipMap() { City = "桃園縣", Dist = "中壢市", Zip = 320 },
               new ZipMap() { City = "桃園縣", Dist = "平鎮市", Zip = 324 },
               new ZipMap() { City = "桃園縣", Dist = "龍潭鄉", Zip = 325 },
               new ZipMap() { City = "桃園縣", Dist = "楊梅市", Zip = 326 },
               new ZipMap() { City = "桃園縣", Dist = "新屋鄉", Zip = 327 },
               new ZipMap() { City = "桃園縣", Dist = "觀音鄉", Zip = 328 },
               new ZipMap() { City = "桃園縣", Dist = "桃園市", Zip = 330 },
               new ZipMap() { City = "桃園縣", Dist = "龜山鄉", Zip = 333 },
               new ZipMap() { City = "桃園縣", Dist = "八德市", Zip = 334 },
               new ZipMap() { City = "桃園縣", Dist = "大溪鎮", Zip = 335 },
               new ZipMap() { City = "桃園縣", Dist = "復興鄉", Zip = 336 },
               new ZipMap() { City = "桃園縣", Dist = "大園鄉", Zip = 337 },
               new ZipMap() { City = "桃園縣", Dist = "蘆竹鄉", Zip = 338 },

               new ZipMap() { City = "桃園市", Dist = "中壢區", Zip = 320 },
               new ZipMap() { City = "桃園市", Dist = "平鎮區", Zip = 324 },
               new ZipMap() { City = "桃園市", Dist = "龍潭區", Zip = 325 },
               new ZipMap() { City = "桃園市", Dist = "楊梅區", Zip = 326 },
               new ZipMap() { City = "桃園市", Dist = "新屋區", Zip = 327 },
               new ZipMap() { City = "桃園市", Dist = "觀音區", Zip = 328 },
               new ZipMap() { City = "桃園市", Dist = "桃園區", Zip = 330 },
               new ZipMap() { City = "桃園市", Dist = "龜山區", Zip = 333 },
               new ZipMap() { City = "桃園市", Dist = "八德區", Zip = 334 },
               new ZipMap() { City = "桃園市", Dist = "大溪區", Zip = 335 },
               new ZipMap() { City = "桃園市", Dist = "復興區", Zip = 336 },
               new ZipMap() { City = "桃園市", Dist = "大園區", Zip = 337 },
               new ZipMap() { City = "桃園市", Dist = "蘆竹區", Zip = 338 },

               new ZipMap() { City = "新竹縣", Dist = "竹北市", Zip = 302 },
               new ZipMap() { City = "新竹縣", Dist = "湖口鄉", Zip = 303 },
               new ZipMap() { City = "新竹縣", Dist = "新豐鄉", Zip = 304 },
               new ZipMap() { City = "新竹縣", Dist = "新埔鎮", Zip = 305 },
               new ZipMap() { City = "新竹縣", Dist = "關西鎮", Zip = 306 },
               new ZipMap() { City = "新竹縣", Dist = "芎林鄉", Zip = 307 },
               new ZipMap() { City = "新竹縣", Dist = "寶山鄉", Zip = 308 },
               new ZipMap() { City = "新竹縣", Dist = "竹東鎮", Zip = 310 },
               new ZipMap() { City = "新竹縣", Dist = "五峰鄉", Zip = 311 },
               new ZipMap() { City = "新竹縣", Dist = "橫山鄉", Zip = 312 },
               new ZipMap() { City = "新竹縣", Dist = "尖石鄉", Zip = 313 },
               new ZipMap() { City = "新竹縣", Dist = "北埔鄉", Zip = 314 },
               new ZipMap() { City = "新竹縣", Dist = "峨眉鄉", Zip = 315 },

               new ZipMap() { City = "苗栗縣", Dist = "竹南鎮", Zip = 350 },
               new ZipMap() { City = "苗栗縣", Dist = "頭份鎮", Zip = 351 },
               new ZipMap() { City = "苗栗縣", Dist = "三灣鄉", Zip = 352 },
               new ZipMap() { City = "苗栗縣", Dist = "南庄鄉", Zip = 353 },
               new ZipMap() { City = "苗栗縣", Dist = "獅潭鄉", Zip = 354 },
               new ZipMap() { City = "苗栗縣", Dist = "後龍鎮", Zip = 356 },
               new ZipMap() { City = "苗栗縣", Dist = "通霄鎮", Zip = 357 },
               new ZipMap() { City = "苗栗縣", Dist = "苑裡鎮", Zip = 358 },
               new ZipMap() { City = "苗栗縣", Dist = "苗栗市", Zip = 360 },
               new ZipMap() { City = "苗栗縣", Dist = "造橋鄉", Zip = 361 },
               new ZipMap() { City = "苗栗縣", Dist = "頭屋鄉", Zip = 362 },
               new ZipMap() { City = "苗栗縣", Dist = "公館鄉", Zip = 363 },
               new ZipMap() { City = "苗栗縣", Dist = "大湖鄉", Zip = 364 },
               new ZipMap() { City = "苗栗縣", Dist = "泰安鄉", Zip = 365 },
               new ZipMap() { City = "苗栗縣", Dist = "銅鑼鄉", Zip = 366 },
               new ZipMap() { City = "苗栗縣", Dist = "三義鄉", Zip = 367 },
               new ZipMap() { City = "苗栗縣", Dist = "西湖鄉", Zip = 368 },
               new ZipMap() { City = "苗栗縣", Dist = "卓蘭鎮", Zip = 369 },

               new ZipMap() { City = "臺中市", Dist = "中區", Zip = 400  },
               new ZipMap() { City = "臺中市", Dist = "東區", Zip = 401  },
               new ZipMap() { City = "臺中市", Dist = "南區", Zip = 402  },
               new ZipMap() { City = "臺中市", Dist = "西區", Zip = 403  },
               new ZipMap() { City = "臺中市", Dist = "北區", Zip = 404  },
               new ZipMap() { City = "臺中市", Dist = "北屯區", Zip = 406  },
               new ZipMap() { City = "臺中市", Dist = "西屯區", Zip = 407  },
               new ZipMap() { City = "臺中市", Dist = "南屯區", Zip = 408  },
               new ZipMap() { City = "臺中市", Dist = "太平區", Zip = 411  },
               new ZipMap() { City = "臺中市", Dist = "大里區", Zip = 412  },
               new ZipMap() { City = "臺中市", Dist = "霧峰區", Zip = 413  },
               new ZipMap() { City = "臺中市", Dist = "烏日區", Zip = 414  },
               new ZipMap() { City = "臺中市", Dist = "豐原區", Zip = 420  },
               new ZipMap() { City = "臺中市", Dist = "后里區", Zip = 421  },
               new ZipMap() { City = "臺中市", Dist = "石岡區", Zip = 422  },
               new ZipMap() { City = "臺中市", Dist = "東勢區", Zip = 423  },
               new ZipMap() { City = "臺中市", Dist = "和平區", Zip = 424  },
               new ZipMap() { City = "臺中市", Dist = "新社區", Zip = 426  },
               new ZipMap() { City = "臺中市", Dist = "潭子區", Zip = 427  },
               new ZipMap() { City = "臺中市", Dist = "大雅區", Zip = 428  },
               new ZipMap() { City = "臺中市", Dist = "神岡區", Zip = 429  },
               new ZipMap() { City = "臺中市", Dist = "大肚區", Zip = 432  },
               new ZipMap() { City = "臺中市", Dist = "沙鹿區", Zip = 433  },
               new ZipMap() { City = "臺中市", Dist = "龍井區", Zip = 434  },
               new ZipMap() { City = "臺中市", Dist = "梧棲區", Zip = 435  },
               new ZipMap() { City = "臺中市", Dist = "清水區", Zip = 436  },
               new ZipMap() { City = "臺中市", Dist = "大甲區", Zip = 437  },
               new ZipMap() { City = "臺中市", Dist = "外埔區", Zip = 438  },
               new ZipMap() { City = "臺中市", Dist = "大安區", Zip = 439  },

               new ZipMap() { City = "彰化縣", Dist = "彰化市", Zip = 500 },
               new ZipMap() { City = "彰化縣", Dist = "芬園鄉", Zip = 502 },
               new ZipMap() { City = "彰化縣", Dist = "花壇鄉", Zip = 503 },
               new ZipMap() { City = "彰化縣", Dist = "秀水鄉", Zip = 504 },
               new ZipMap() { City = "彰化縣", Dist = "鹿港鎮", Zip = 505 },
               new ZipMap() { City = "彰化縣", Dist = "福興鄉", Zip = 506 },
               new ZipMap() { City = "彰化縣", Dist = "線西鄉", Zip = 507 },
               new ZipMap() { City = "彰化縣", Dist = "和美鎮", Zip = 508 },
               new ZipMap() { City = "彰化縣", Dist = "伸港鄉", Zip = 509 },
               new ZipMap() { City = "彰化縣", Dist = "員林鎮", Zip = 510 },
               new ZipMap() { City = "彰化縣", Dist = "社頭鄉", Zip = 511 },
               new ZipMap() { City = "彰化縣", Dist = "永靖鄉", Zip = 512 },
               new ZipMap() { City = "彰化縣", Dist = "埔心鄉", Zip = 513 },
               new ZipMap() { City = "彰化縣", Dist = "溪湖鎮", Zip = 514 },
               new ZipMap() { City = "彰化縣", Dist = "大村鄉", Zip = 515 },
               new ZipMap() { City = "彰化縣", Dist = "埔鹽鄉", Zip = 516 },
               new ZipMap() { City = "彰化縣", Dist = "田中鎮", Zip = 520 },
               new ZipMap() { City = "彰化縣", Dist = "北斗鎮", Zip = 521 },
               new ZipMap() { City = "彰化縣", Dist = "田尾鄉", Zip = 522 },
               new ZipMap() { City = "彰化縣", Dist = "埤頭鄉", Zip = 523 },
               new ZipMap() { City = "彰化縣", Dist = "溪州鄉", Zip = 524 },
               new ZipMap() { City = "彰化縣", Dist = "竹塘鄉", Zip = 525 },
               new ZipMap() { City = "彰化縣", Dist = "二林鎮", Zip = 526 },
               new ZipMap() { City = "彰化縣", Dist = "大城鄉", Zip = 527 },
               new ZipMap() { City = "彰化縣", Dist = "芳苑鄉", Zip = 528 },
               new ZipMap() { City = "彰化縣", Dist = "二水鄉", Zip = 530 },

               new ZipMap() { City = "南投縣", Dist = "南投市", Zip = 540 },
               new ZipMap() { City = "南投縣", Dist = "中寮鄉", Zip = 541 },
               new ZipMap() { City = "南投縣", Dist = "草屯鎮", Zip = 542 },
               new ZipMap() { City = "南投縣", Dist = "國姓鄉", Zip = 544 },
               new ZipMap() { City = "南投縣", Dist = "埔里鎮", Zip = 545 },
               new ZipMap() { City = "南投縣", Dist = "仁愛鄉", Zip = 546 },
               new ZipMap() { City = "南投縣", Dist = "名間鄉", Zip = 551 },
               new ZipMap() { City = "南投縣", Dist = "集集鎮", Zip = 552 },
               new ZipMap() { City = "南投縣", Dist = "水里鄉", Zip = 553 },
               new ZipMap() { City = "南投縣", Dist = "魚池鄉", Zip = 555 },
               new ZipMap() { City = "南投縣", Dist = "信義鄉", Zip = 556 },
               new ZipMap() { City = "南投縣", Dist = "竹山鎮", Zip = 557 },
               new ZipMap() { City = "南投縣", Dist = "鹿谷鄉", Zip = 558 },

               new ZipMap() { City = "雲林縣", Dist = "斗南鎮", Zip = 630 },
               new ZipMap() { City = "雲林縣", Dist = "大埤鄉", Zip = 631 },
               new ZipMap() { City = "雲林縣", Dist = "虎尾鎮", Zip = 632 },
               new ZipMap() { City = "雲林縣", Dist = "土庫鎮", Zip = 633 },
               new ZipMap() { City = "雲林縣", Dist = "褒忠鄉", Zip = 634 },
               new ZipMap() { City = "雲林縣", Dist = "東勢鄉", Zip = 635 },
               new ZipMap() { City = "雲林縣", Dist = "台西鄉", Zip = 636 },
               new ZipMap() { City = "雲林縣", Dist = "崙背鄉", Zip = 637 },
               new ZipMap() { City = "雲林縣", Dist = "麥寮鄉", Zip = 638 },
               new ZipMap() { City = "雲林縣", Dist = "斗六市", Zip = 640 },
               new ZipMap() { City = "雲林縣", Dist = "林內鄉", Zip = 643 },
               new ZipMap() { City = "雲林縣", Dist = "古坑鄉", Zip = 646 },
               new ZipMap() { City = "雲林縣", Dist = "莿桐鄉", Zip = 647 },
               new ZipMap() { City = "雲林縣", Dist = "西螺鎮", Zip = 648 },
               new ZipMap() { City = "雲林縣", Dist = "二崙鄉", Zip = 649 },
               new ZipMap() { City = "雲林縣", Dist = "北港鎮", Zip = 651 },
               new ZipMap() { City = "雲林縣", Dist = "水林鄉", Zip = 652 },
               new ZipMap() { City = "雲林縣", Dist = "口湖鄉", Zip = 653 },
               new ZipMap() { City = "雲林縣", Dist = "四湖鄉", Zip = 654 },
               new ZipMap() { City = "雲林縣", Dist = "元長鄉", Zip = 655 },

               new ZipMap() { City = "嘉義縣", Dist = "番路鄉", Zip = 602 },
               new ZipMap() { City = "嘉義縣", Dist = "梅山鄉", Zip = 603 },
               new ZipMap() { City = "嘉義縣", Dist = "竹崎鄉", Zip = 604 },
               new ZipMap() { City = "嘉義縣", Dist = "阿里山鄉", Zip = 605 },
               new ZipMap() { City = "嘉義縣", Dist = "中埔鄉", Zip = 606 },
               new ZipMap() { City = "嘉義縣", Dist = "大埔鄉", Zip = 607 },
               new ZipMap() { City = "嘉義縣", Dist = "水上鄉", Zip = 608 },
               new ZipMap() { City = "嘉義縣", Dist = "鹿草鄉", Zip = 611 },
               new ZipMap() { City = "嘉義縣", Dist = "太保市", Zip = 612 },
               new ZipMap() { City = "嘉義縣", Dist = "朴子市", Zip = 613 },
               new ZipMap() { City = "嘉義縣", Dist = "東石鄉", Zip = 614 },
               new ZipMap() { City = "嘉義縣", Dist = "六腳鄉", Zip = 615 },
               new ZipMap() { City = "嘉義縣", Dist = "新港鄉", Zip = 616 },
               new ZipMap() { City = "嘉義縣", Dist = "民雄鄉", Zip = 621 },
               new ZipMap() { City = "嘉義縣", Dist = "大林鎮", Zip = 622 },
               new ZipMap() { City = "嘉義縣", Dist = "溪口鄉", Zip = 623 },
               new ZipMap() { City = "嘉義縣", Dist = "義竹鄉", Zip = 624 },
               new ZipMap() { City = "嘉義縣", Dist = "布袋鎮", Zip = 625 },

               new ZipMap() { City = "臺南市", Dist = "中西區", Zip =  700 },
               new ZipMap() { City = "臺南市", Dist = "東區", Zip =  701 },
               new ZipMap() { City = "臺南市", Dist = "南區", Zip =  702 },
               new ZipMap() { City = "臺南市", Dist = "北區", Zip =  704 },
               new ZipMap() { City = "臺南市", Dist = "安平區", Zip = 708 },
               new ZipMap() { City = "臺南市", Dist = "安南區", Zip = 709 },
               new ZipMap() { City = "臺南市", Dist = "永康區", Zip = 710 },
               new ZipMap() { City = "臺南市", Dist = "歸仁區", Zip = 711 },
               new ZipMap() { City = "臺南市", Dist = "新化區", Zip = 712 },
               new ZipMap() { City = "臺南市", Dist = "左鎮區", Zip = 713 },
               new ZipMap() { City = "臺南市", Dist = "玉井區", Zip = 714 },
               new ZipMap() { City = "臺南市", Dist = "楠西區", Zip = 715 },
               new ZipMap() { City = "臺南市", Dist = "南化區", Zip = 716 },
               new ZipMap() { City = "臺南市", Dist = "仁德區", Zip = 717 },
               new ZipMap() { City = "臺南市", Dist = "關廟區", Zip = 718 },
               new ZipMap() { City = "臺南市", Dist = "龍崎區", Zip = 719 },
               new ZipMap() { City = "臺南市", Dist = "官田區", Zip = 720 },
               new ZipMap() { City = "臺南市", Dist = "麻豆區", Zip = 721 },
               new ZipMap() { City = "臺南市", Dist = "佳里區", Zip = 722 },
               new ZipMap() { City = "臺南市", Dist = "西港區", Zip = 723 },
               new ZipMap() { City = "臺南市", Dist = "七股區", Zip = 724 },
               new ZipMap() { City = "臺南市", Dist = "將軍區", Zip = 725 },
               new ZipMap() { City = "臺南市", Dist = "學甲區", Zip = 726 },
               new ZipMap() { City = "臺南市", Dist = "北門區", Zip = 727 },
               new ZipMap() { City = "臺南市", Dist = "新營區", Zip = 730 },
               new ZipMap() { City = "臺南市", Dist = "後壁區", Zip = 731 },
               new ZipMap() { City = "臺南市", Dist = "白河區", Zip = 732 },
               new ZipMap() { City = "臺南市", Dist = "東山區", Zip = 733 },
               new ZipMap() { City = "臺南市", Dist = "六甲區", Zip = 734 },
               new ZipMap() { City = "臺南市", Dist = "下營區", Zip = 735 },
               new ZipMap() { City = "臺南市", Dist = "柳營區", Zip = 736 },
               new ZipMap() { City = "臺南市", Dist = "鹽水區", Zip = 737 },
               new ZipMap() { City = "臺南市", Dist = "善化區", Zip = 741 },
               new ZipMap() { City = "臺南市", Dist = "大內區", Zip = 742 },
               new ZipMap() { City = "臺南市", Dist = "山上區", Zip = 743 },
               new ZipMap() { City = "臺南市", Dist = "新市區", Zip = 744 },
               new ZipMap() { City = "臺南市", Dist = "安定區", Zip = 745 },

               new ZipMap() { City = "高雄市", Dist = "新興區", Zip = 800 },
               new ZipMap() { City = "高雄市", Dist = "前金區", Zip = 801 },
               new ZipMap() { City = "高雄市", Dist = "苓雅區", Zip = 802 },
               new ZipMap() { City = "高雄市", Dist = "鹽埕區", Zip = 803 },
               new ZipMap() { City = "高雄市", Dist = "鼓山區", Zip = 804 },
               new ZipMap() { City = "高雄市", Dist = "旗津區", Zip = 805 },
               new ZipMap() { City = "高雄市", Dist = "前鎮區", Zip = 806 },
               new ZipMap() { City = "高雄市", Dist = "三民區", Zip = 807 },
               new ZipMap() { City = "高雄市", Dist = "楠梓區", Zip = 811 },
               new ZipMap() { City = "高雄市", Dist = "小港區", Zip = 812 },
               new ZipMap() { City = "高雄市", Dist = "左營區", Zip = 813 },
               new ZipMap() { City = "高雄市", Dist = "仁武區", Zip = 814 },
               new ZipMap() { City = "高雄市", Dist = "大社區", Zip = 815 },
               new ZipMap() { City = "高雄市", Dist = "岡山區", Zip = 820 },
               new ZipMap() { City = "高雄市", Dist = "路竹區", Zip = 821 },
               new ZipMap() { City = "高雄市", Dist = "阿蓮區", Zip = 822 },
               new ZipMap() { City = "高雄市", Dist = "田寮區", Zip = 823 },
               new ZipMap() { City = "高雄市", Dist = "燕巢區", Zip = 824 },
               new ZipMap() { City = "高雄市", Dist = "橋頭區", Zip = 825 },
               new ZipMap() { City = "高雄市", Dist = "梓官區", Zip = 826 },
               new ZipMap() { City = "高雄市", Dist = "彌陀區", Zip = 827 },
               new ZipMap() { City = "高雄市", Dist = "永安區", Zip = 828 },
               new ZipMap() { City = "高雄市", Dist = "湖內區", Zip = 829 },
               new ZipMap() { City = "高雄市", Dist = "鳳山區", Zip = 830 },
               new ZipMap() { City = "高雄市", Dist = "大寮區", Zip = 831 },
               new ZipMap() { City = "高雄市", Dist = "林園區", Zip = 832 },
               new ZipMap() { City = "高雄市", Dist = "鳥松區", Zip = 833 },
               new ZipMap() { City = "高雄市", Dist = "大樹區", Zip = 840 },
               new ZipMap() { City = "高雄市", Dist = "旗山區", Zip = 842 },
               new ZipMap() { City = "高雄市", Dist = "美濃區", Zip = 843 },
               new ZipMap() { City = "高雄市", Dist = "六龜區", Zip = 844 },
               new ZipMap() { City = "高雄市", Dist = "內門區", Zip = 845 },
               new ZipMap() { City = "高雄市", Dist = "杉林區", Zip = 846 },
               new ZipMap() { City = "高雄市", Dist = "甲仙區", Zip = 847 },
               new ZipMap() { City = "高雄市", Dist = "桃源區", Zip = 848 },
               new ZipMap() { City = "高雄市", Dist = "那瑪夏區", Zip = 849 },
               new ZipMap() { City = "高雄市", Dist = "茂林區", Zip = 851 },
               new ZipMap() { City = "高雄市", Dist = "茄萣區", Zip = 852 },

               new ZipMap() { City = "屏東縣", Dist = "屏東市", Zip = 900 },
               new ZipMap() { City = "屏東縣", Dist = "三地門鄉", Zip = 901 },
               new ZipMap() { City = "屏東縣", Dist = "霧台鄉", Zip = 902 },
               new ZipMap() { City = "屏東縣", Dist = "瑪家鄉", Zip = 903 },
               new ZipMap() { City = "屏東縣", Dist = "九如鄉", Zip = 904 },
               new ZipMap() { City = "屏東縣", Dist = "里港鄉", Zip = 905 },
               new ZipMap() { City = "屏東縣", Dist = "高樹鄉", Zip = 906 },
               new ZipMap() { City = "屏東縣", Dist = "鹽埔鄉", Zip = 907 },
               new ZipMap() { City = "屏東縣", Dist = "長治鄉", Zip = 908 },
               new ZipMap() { City = "屏東縣", Dist = "麟洛鄉", Zip = 909 },
               new ZipMap() { City = "屏東縣", Dist = "竹田鄉", Zip = 911 },
               new ZipMap() { City = "屏東縣", Dist = "內埔鄉", Zip = 912 },
               new ZipMap() { City = "屏東縣", Dist = "萬丹鄉", Zip = 913 },
               new ZipMap() { City = "屏東縣", Dist = "潮州鎮", Zip = 920 },
               new ZipMap() { City = "屏東縣", Dist = "泰武鄉", Zip = 921 },
               new ZipMap() { City = "屏東縣", Dist = "來義鄉", Zip = 922 },
               new ZipMap() { City = "屏東縣", Dist = "萬巒鄉", Zip = 923 },
               new ZipMap() { City = "屏東縣", Dist = "崁頂鄉", Zip = 924 },
               new ZipMap() { City = "屏東縣", Dist = "新埤鄉", Zip = 925 },
               new ZipMap() { City = "屏東縣", Dist = "南州鄉", Zip = 926 },
               new ZipMap() { City = "屏東縣", Dist = "林邊鄉", Zip = 927 },
               new ZipMap() { City = "屏東縣", Dist = "東港鎮", Zip = 928 },
               new ZipMap() { City = "屏東縣", Dist = "琉球鄉", Zip = 929 },
               new ZipMap() { City = "屏東縣", Dist = "佳冬鄉", Zip = 931 },
               new ZipMap() { City = "屏東縣", Dist = "新園鄉", Zip = 932 },
               new ZipMap() { City = "屏東縣", Dist = "枋寮鄉", Zip = 940 },
               new ZipMap() { City = "屏東縣", Dist = "枋山鄉", Zip = 941 },
               new ZipMap() { City = "屏東縣", Dist = "春日鄉", Zip = 942 },
               new ZipMap() { City = "屏東縣", Dist = "獅子鄉", Zip = 943 },
               new ZipMap() { City = "屏東縣", Dist = "車城鄉", Zip = 944 },
               new ZipMap() { City = "屏東縣", Dist = "牡丹鄉", Zip = 945 },
               new ZipMap() { City = "屏東縣", Dist = "恆春鎮", Zip = 946 },
               new ZipMap() { City = "屏東縣", Dist = "滿州鄉", Zip = 947 },

               new ZipMap() { City = "臺東縣", Dist = "台東市", Zip = 950 },
               new ZipMap() { City = "臺東縣", Dist = "綠島鄉", Zip = 951 },
               new ZipMap() { City = "臺東縣", Dist = "蘭嶼鄉", Zip = 952 },
               new ZipMap() { City = "臺東縣", Dist = "延平鄉", Zip = 953 },
               new ZipMap() { City = "臺東縣", Dist = "卑南鄉", Zip = 954 },
               new ZipMap() { City = "臺東縣", Dist = "鹿野鄉", Zip = 955 },
               new ZipMap() { City = "臺東縣", Dist = "關山鎮", Zip = 956 },
               new ZipMap() { City = "臺東縣", Dist = "海端鄉", Zip = 957 },
               new ZipMap() { City = "臺東縣", Dist = "池上鄉", Zip = 958 },
               new ZipMap() { City = "臺東縣", Dist = "東河鄉", Zip = 959 },
               new ZipMap() { City = "臺東縣", Dist = "成功鎮", Zip = 961 },
               new ZipMap() { City = "臺東縣", Dist = "長濱鄉", Zip = 962 },
               new ZipMap() { City = "臺東縣", Dist = "太麻里鄉", Zip = 963 },
               new ZipMap() { City = "臺東縣", Dist = "金峰鄉", Zip = 964 },
               new ZipMap() { City = "臺東縣", Dist = "大武鄉", Zip = 965 },
               new ZipMap() { City = "臺東縣", Dist = "達仁鄉", Zip = 966 },

               new ZipMap() { City = "花蓮縣", Dist = "花蓮市", Zip = 970 },
               new ZipMap() { City = "花蓮縣", Dist = "新城鄉", Zip = 971 },
               new ZipMap() { City = "花蓮縣", Dist = "秀林鄉", Zip = 972 },
               new ZipMap() { City = "花蓮縣", Dist = "吉安鄉", Zip = 973 },
               new ZipMap() { City = "花蓮縣", Dist = "壽豐鄉", Zip = 974 },
               new ZipMap() { City = "花蓮縣", Dist = "鳳林鎮", Zip = 975 },
               new ZipMap() { City = "花蓮縣", Dist = "光復鄉", Zip = 976 },
               new ZipMap() { City = "花蓮縣", Dist = "豐濱鄉", Zip = 977 },
               new ZipMap() { City = "花蓮縣", Dist = "瑞穗鄉", Zip = 978 },
               new ZipMap() { City = "花蓮縣", Dist = "萬榮鄉", Zip = 979 },
               new ZipMap() { City = "花蓮縣", Dist = "玉里鎮", Zip = 981 },
               new ZipMap() { City = "花蓮縣", Dist = "卓溪鄉", Zip = 982 },
               new ZipMap() { City = "花蓮縣", Dist = "富里鄉", Zip = 983 },

               new ZipMap() { City = "新竹縣", Dist = "新竹市", Zip = 300 },
               new ZipMap() { City = "新竹市", Dist = "", Zip = 300 },
               new ZipMap() { City = "新竹市", Dist = "東區", Zip =300 },
               new ZipMap() { City = "新竹市", Dist = "北區", Zip =300 },
               new ZipMap() { City = "新竹市", Dist = "香山區", Zip =300 },

               new ZipMap() { City = "嘉義縣", Dist = "嘉義市", Zip = 600 },
               new ZipMap() { City = "嘉義市", Dist = "", Zip = 600 },
               new ZipMap() { City = "嘉義市", Dist = "東區", Zip = 600 },
               new ZipMap() { City = "嘉義市", Dist = "西區", Zip = 600 },

               new ZipMap() { City = "澎湖縣", Dist = "馬公市", Zip = 880 },
               new ZipMap() { City = "澎湖縣", Dist = "湖西鄉", Zip = 885 },
               new ZipMap() { City = "澎湖縣", Dist = "白沙鄉", Zip = 884 },
               new ZipMap() { City = "澎湖縣", Dist = "西嶼鄉", Zip = 881 },
               new ZipMap() { City = "澎湖縣", Dist = "望安鄉", Zip = 882 },
               new ZipMap() { City = "澎湖縣", Dist = "七美鄉", Zip = 883 },

               new ZipMap() { City = "連江縣", Dist = "南竿鄉", Zip = 209 },
               new ZipMap() { City = "連江縣", Dist = "北竿鄉", Zip = 210 },
               new ZipMap() { City = "連江縣", Dist = "莒光鄉", Zip = 211 },
               new ZipMap() { City = "連江縣", Dist = "東引鄉", Zip = 212 },

               new ZipMap() { City = "金門縣", Dist = "金城鎮", Zip = 893 },
               new ZipMap() { City = "金門縣", Dist = "金沙鎮", Zip = 890 },
               new ZipMap() { City = "金門縣", Dist = "金湖鎮", Zip = 891 },
               new ZipMap() { City = "金門縣", Dist = "金寧鄉", Zip = 892 },
               new ZipMap() { City = "金門縣", Dist = "烈嶼鄉", Zip = 894 },
               new ZipMap() { City = "金門縣", Dist = "烏坵鄉", Zip = 896 }
           };
            }
        }







    }
}
