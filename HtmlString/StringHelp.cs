using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JTC_Help.HtmlString
{
    /// <summary>
    /// 字串處理
    /// </summary>
    public class StringHelp
    {
        protected StringHelp()
        {
        }

        /// <summary>
        /// 移除文字裡的所有 Html 標籤
        /// </summary>
        public static string RemoveHtmlTag(string html)
        {
            HtmlTextHandlerHelp textHandler = new HtmlTextHandlerHelp();

            return textHandler.StripTagsCharArray(html);
        }

        /// <summary>
        /// 移除文字裡的所有 Html 標籤與空白換行
        /// </summary>
        public static string RemoveHtmlTagWoEmptyLines(string html)
        {
            HtmlTextHandlerHelp textHandler = new HtmlTextHandlerHelp();
            string result = textHandler.StripTagsCharArray(html);

            //拿掉換行符號,開頭,間隔的一堆空白
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ");

            return result;
        }

        /// <summary>
        /// 移除文字裡的所有 Html 標籤,並截短內文
        /// </summary>
        public static string RemoveHtmlTagToShortContext(string context, int maxLength)
        {
            //移除Html碼
            string shortArticleContext = RemoveHtmlTagWoEmptyLines(context);

            //節錄為簡介
            if (shortArticleContext.Length > maxLength)
                shortArticleContext = shortArticleContext.Remove(maxLength, shortArticleContext.Length - maxLength) + "...";

            return shortArticleContext;
        }

        /// <summary>
        /// 設定網址中的參數值
        /// </summary>
        public static string SetParaValueInUrl(string url, string paraName, string paraValue)
        {
            StringBuilder sbResult = new StringBuilder();
            //檢查原內容是否有帶參數
            bool HasPara = false;
            if (url.IndexOf("?") != -1)
                HasPara = true;

            if (HasPara)
            {
                //檢查原內容是否有指定參數
                int SplitterIndexOfPara = url.ToLower().IndexOf("?" + paraName.ToLower() + "=");
                //第一個不是,再找之後的
                if (SplitterIndexOfPara == -1)
                    SplitterIndexOfPara = url.ToLower().IndexOf("&" + paraName.ToLower() + "=");

                if (SplitterIndexOfPara != -1)
                {
                    //已有指定參數
                    int startIndex = SplitterIndexOfPara + 1;
                    int NextSplitterIndex = url.ToLower().IndexOf("&", startIndex);

                    if (NextSplitterIndex == -1)
                    {
                        //原指定參數是最後一個
                        //移掉原指定參數,重加
                        sbResult.Append(url);
                        sbResult.Remove(startIndex, sbResult.Length - startIndex);
                        sbResult.AppendFormat("{0}={1}", paraName, paraValue);
                    }
                    else
                    {
                        //原指定參數在中間
                        //先加前面的部分
                        sbResult.Append(url.Substring(0, SplitterIndexOfPara + paraName.Length + 2/*p的前後符號*/));
                        //再加指定參數
                        sbResult.Append(paraValue);
                        //再加後面部分
                        sbResult.Append(url.Substring(NextSplitterIndex));
                    }
                }
                else
                {
                    //沒有指定參數
                    sbResult.AppendFormat("{0}&{1}={2}", url, paraName, paraValue);
                }
            }
            else
            {
                //原內容沒參數
                sbResult.AppendFormat("{0}?{1}={2}", url, paraName, paraValue);
            }

            return sbResult.ToString();
        }

        /// <summary>
        /// 加入時間冒號
        /// </summary>
        public static string InsertTimeColon(string hourMinSec)
        {
            string result = "";
            //HHmm HHmmss
            int iHourColon = 2;
            //Hmm Hmmss
            if (hourMinSec.Length % 2 != 0)
                iHourColon = 1;

            if (hourMinSec.Length >= iHourColon)
                result = hourMinSec.Insert(iHourColon, ":");

            if (hourMinSec.Length > iHourColon + 2)
                result = result.Insert(iHourColon + 2 + 1, ":");

            return result;
        }

        public static string GenerateCaptchaCodeNum(int length)
        {
            int number;
            StringBuilder sbCaptchaCode = new StringBuilder(length);

            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < length; i++)
            {
                number = random.Next();

                sbCaptchaCode.Append((number % 10).ToString());
            }

            return sbCaptchaCode.ToString();
        }

        public static string GenerateCaptchaCode(int length)
        {
            int number;
            char tempCode;
            StringBuilder sbCaptchaCode = new StringBuilder(length);

            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < length; i++)
            {
                number = random.Next();

                if (random.Next() % 2 == 0)
                {
                    //number
                    tempCode = (char)('1' + (char)(number % 9));
                }
                else
                {
                    //letter
                    tempCode = (char)('A' + (char)(number % 26));
                }

                sbCaptchaCode.Append(tempCode);
            }

            return sbCaptchaCode.ToString();
        }

        /// <summary>
        /// 產生寛鬆規則的密碼值
        /// </summary>
        public static string GenerateLoosePasswordValue(int length)
        {
            int number;
            char tempCode;
            StringBuilder sbCaptchaCode = new StringBuilder(length);

            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < length; i++)
            {
                number = random.Next();

                if (random.Next() % 2 == 0)
                {
                    //number
                    tempCode = (char)('1' + (char)(number % 9));
                }
                else
                {
                    //letter
                    tempCode = (char)('A' + (char)(number % 26));
                }

                sbCaptchaCode.Append(tempCode);
            }

            return sbCaptchaCode.ToString();
        }

        /// <summary>
        /// 產生嚴格規則的密碼值
        /// </summary>
        public static string GenerateStrictPasswordValue(int length)
        {
            string symbols = "!@#$%^&*";
            int number;
            char tempCode;
            StringBuilder sbCaptchaCode = new StringBuilder(length);

            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < length; i++)
            {
                number = random.Next();

                if (random.Next() % 2 == 0)
                {
                    //number
                    tempCode = (char)('1' + (char)(number % 9));
                }
                else
                {
                    //letter
                    tempCode = (char)('A' + (char)(number % 26));
                }

                sbCaptchaCode.Append(tempCode);
            }

            int symbolIndex = random.Next() % symbols.Length;
            char symbol = symbols[symbolIndex];
            char lowerCaseLetter = (char)('a' + (char)(random.Next() % 26));

            sbCaptchaCode[0] = symbol;
            sbCaptchaCode[sbCaptchaCode.Length - 1] = lowerCaseLetter;

            return sbCaptchaCode.ToString();
        }

        /// <summary>
        /// 取得簡單密碼規則的規則運算式
        /// </summary>
        public static string GetPswSimpleRuleValidationExpression()
        {
            return @"[a-zA-Z0-9`~!@#\$%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\.\?/]{6,50}";
        }

        /// <summary>
        /// 從網址找出 Youtube 影片代碼
        /// </summary>
        public static string GetYoutubeIdFromUrl(string url)
        {
            string youtubeId = "";
            string source = url;

            if (source.Contains("youtube.com"))
            {
                if (source.Contains("v="))
                {
                    //e.g., https://www.youtube.com/watch?v=FrM22iqsdpE

                    source = source.Split(new string[] { "v=" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    youtubeId = source;
                }
                else if (source.Contains("/embed/"))
                {
                    //e.g., https://www.youtube.com/embed/FrM22iqsdpE

                    string[] tokens = source.Split('/');
                    source = tokens[tokens.Length - 1];
                    youtubeId = source;
                }
            }
            else if (source.Contains("youtu.be"))
            {
                //e.g., https://youtu.be/FrM22iqsdpE

                string[] tokens = source.Split('/');
                source = tokens[tokens.Length - 1];
                youtubeId = source;
            }

            if (source.Contains("?") || source.Contains("&") || source.Contains("#"))
            {
                //e.g., https://www.youtube.com/watch?v=FrM22iqsdpE&feature=youtu.be&t=150
                //e.g., https://www.youtube.com/embed/FrM22iqsdpE?start=120
                //e.g., https://youtu.be/FrM22iqsdpE?t=150

                source = source.Split('?', '&', '#')[0];
                youtubeId = source;
            }

            return youtubeId;
        }

        /// <summary>
        /// 國字轉數字 EX 七 => 7
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string CNumbertoENumber(string txt)
        {
            Dictionary<string, long> digit = new Dictionary<string, long>()
            { { "一", 1 },
              { "二", 2 },
              { "三", 3 },
              { "四", 4 },
              { "五", 5 },
              { "六", 6 },
              { "七", 7 },
              { "八", 8 },
              { "九", 9 } };
            Dictionary<string, long> word = new Dictionary<string, long>()
            { { "百", 100 },
              { "千", 1000 },
              { "萬", 10000 },
              { "億", 100000000 },
              { "兆", 1000000000000 } };

            Dictionary<string, long> ten = new Dictionary<string, long>()
            { { "十", 10 } };

            long iResult = 0;

            txt = txt.Replace("零", "");
            int index = 0;
            long t_l = 0, _t_l = 0;
            string t_s;

            while (txt.Length > index)
            {
                t_s = txt.Substring(index++, 1);

                // 數字
                if (digit.ContainsKey(t_s))
                {
                    _t_l += digit[t_s];
                }
                // 十
                else if (ten.ContainsKey(t_s))
                {
                    _t_l = _t_l == 0 ? 10 : _t_l * 10;
                }
                // 百、千、億、兆 
                else if (word.ContainsKey(t_s))
                {
                    // 碰到千位則使 _t_l 與 t_l 相加乘上目前讀到的數字，
                    // 並將輸出結果累加。
                    if (word[t_s] > word["千"])
                    {
                        iResult += (t_l + _t_l) * word[t_s];
                        t_l = 0;
                        _t_l = 0;

                        continue;
                    }
                    _t_l = _t_l * word[t_s];
                    t_l += _t_l;

                    _t_l = 0;
                }


            }
            // 將殘餘值累加至輸出結果
            iResult += t_l;
            iResult += _t_l;

            return Convert.ToString(iResult);


            //char[] cs = txt.ToArray();
            //string value = "";

            //foreach (char c in cs)
            //{
            //    switch (c)
            //    {
            //        case '一': value += "1"; break;
            //        case '二': value += "2"; break;
            //        case '三': value += "3"; break;
            //        case '四': value += "4"; break;
            //        case '五': value += "5"; break;
            //        case '六': value += "6"; break;
            //        case '七': value += "7"; break;
            //        case '八': value += "8"; break;
            //        case '九': value += "9"; break;
            //        default: value += c.ToString(); break;
            //    }
            //}

            //return value;
        }

        /// <summary>
        /// 檢查是否有無意義的字 , 若資料只有無意義的字則視為無資料
        /// </summary>
        /// <param name="obj_text"></param>
        /// <param name="strText">return string</param>
        /// <returns>bool</returns>
        public static bool TryGetUsefulWords(string obj_text, out string strText)
        {
            strText = "";

            if (obj_text == null)
            {
                return false;
            }

            strText = obj_text.Trim();
            strText = strText.Trim(',');
            strText = strText.Replace(",,", ",");
            strText = strText.Replace("<br />", "\n");
            strText = strText.Replace("\r\n", "\n");
            strText = strText.Replace("\\r\\n", "\n");

            string strChk = strText
                        .Replace("無", "")
                        .Replace(",", "")
                        .Replace(".", "")
                        .Replace("。", "")
                        .Replace("，", "")
                        .Replace("、", "")
                        .Replace("　", "")
                        .Replace(" ", "")
                        .Replace("x", "")
                        .Replace("X", "")
                        .Replace("\t", "");

            if (strChk != string.Empty)
            {
                return true;
            }

            return false;
        }


        public static string GetUsefulWords(string txt)
        {
            string temp_str = "";
            if (TryGetUsefulWords(txt, out temp_str))
                return temp_str;
            else
                return txt;


        }

        /// <summary>
        /// 部分字樣從簡體轉成繁體
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string CNtoTW(string s)
        {
            return s.Replace("国", "國").Replace("亚", "亞").Replace("湾", "灣")
                      .Replace("台", "臺").Replace("东", "東").Replace("县", "縣")
                      .Replace("莲", "蓮").Replace("连", "連").Replace("区", "區")
                      .Replace("顿", "頓").Replace("欧", "歐").Replace("门", "門")
                      .Replace("厦", "廈").Replace("广", "廣").Replace("网", "網")
                      .Replace("机", "機").Replace("页", "頁").Replace("兰", "蘭")
                      .Replace("妈", "媽").Replace("马", "馬").Replace("来", "來")
                      .Replace("叶", "葉").Replace("业", "業").Replace("园", "園")
                      .Replace("云", "雲").Replace("义", "義").Replace("长", "長")
                      .Replace("爱", "愛").Replace("岛", "島").Replace("关", "關")
                      .Replace("泻", "潟").Replace("冈", "岡").Replace("贺", "賀")
                      .Replace("库", "庫").Replace("华", "華").Replace("苏", "蘇")
                      .Replace("庆", "慶").Replace("辖", "轄").Replace("陕", "陜")
                      .Replace("贵", "貴").Replace("龙", "龍").Replace("辽", "遼")
                      .Replace("宁", "寧").Replace("维", "維").Replace("尔", "爾")
                      .Replace("壮", "壯").Replace("肃", "肅").Replace("联", "聯")
                      .Replace("伦", "倫").Replace("罗", "羅").Replace("达", "達")
                      .Replace("刚", "剛").Replace("萨", "薩").Replace("纳", "納")
                      .Replace("腊", "臘").Replace("韩", "韓").Replace("劳", "勞")
                      .Replace("动", "動").Replace("叙", "敘").Replace("乌", "烏")
                      .Replace("莱", "萊").Replace("缅", "緬").Replace("麦", "麥")
                      .Replace("济", "濟").Replace("买", "買").Replace("卢", "盧")
                      .Replace("宾", "賓").Replace("绍", "紹").Replace("颠", "顛")
                      .Replace("纽", "紐").Replace("约", "約").Replace("矶", "磯")
                      .Replace("圣", "聖").Replace("扬", "揚").Replace("迈", "邁")
                      .Replace("凤", "鳳").Replace("图", "圖").Replace("温", "溫")
                      .Replace("会", "會").Replace("绘", "繪").Replace("画", "畫")
                      .Replace("峡", "峽").Replace("电", "電").Replace("闪", "閃")
                      .Replace("闭", "閉").Replace("发", "發").Replace("楼", "樓")
                      .Replace("几", "幾").Replace("阳", "陽").Replace("开", "開")
                      .Replace("点", "點").Replace("费", "費").Replace("离", "離")
                      .Replace("币", "幣").Replace("贴", "貼").Replace("顾", "顧")
                      .Replace("选", "選").Replace("乐", "樂").Replace("观", "觀")
                      .Replace("场", "場").Replace("态", "態").Replace("戏", "戲")
                      .Replace("时", "時").Replace("宝", "寶").Replace("间", "間")
                      .Replace("盖", "蓋").Replace("经", "經").Replace("单", "單")
                      .Replace("闲", "閒").Replace("远", "遠").Replace("种", "種")
                      .Replace("学", "學").Replace("补", "補").Replace("尽", "盡")
                      .Replace("帮", "幫").Replace("觉", "覺").Replace("计", "計")
                      .Replace("现", "現").Replace("张", "張").Replace("双", "雙")
                      .Replace("实", "實").Replace("尘", "塵").Replace("还", "還")
                      .Replace("团", "團").Replace("员", "員").Replace("梦", "夢")
                      .Replace("医", "醫").Replace("占", "佔").Replace("优", "優")
                      .Replace("质", "質").Replace("体", "體").Replace("驾", "駕")
                      .Replace("为", "為").Replace("仅", "僅").Replace("书", "書")
                      .Replace("价", "價").Replace("适", "適").Replace("帮", "幫")
                      .Replace("顶", "頂").Replace("华", "華").Replace("记", "記")
                      .Replace("两", "兩").Replace("读", "讀").Replace("设", "設")
                      .Replace("毕", "畢").Replace("资", "資").Replace("奋", "奮")
                      .Replace("万", "萬").Replace("当", "當").Replace("报", "報")
                      .Replace("过", "過").Replace("头", "頭").Replace("兴", "興")
                      .Replace("统", "統").Replace("测", "測").Replace("垦", "墾")
                      .Replace("营", "營").Replace("对", "對").Replace("个", "個")
                      .Replace("认", "認").Replace("说", "說").Replace("坜", "壢")
                      .Replace("该", "該").Replace("让", "讓").Replace("卖", "賣")
                      .Replace("这", "這").Replace("愿", "願").Replace("无", "無")
                      .Replace("摊", "攤").Replace("则", "則").Replace("数", "數")
                      .Replace("样", "樣").Replace("块", "塊").Replace("猪", "豬")
                      .Replace("边", "邊").Replace("灵", "靈").Replace("调", "調")
                      .Replace("没", "沒").Replace("讲", "講").Replace("难", "難")
                      .Replace("萝", "蘿").Replace("战", "戰").Replace("线", "線")
                      .Replace("么", "麼").Replace("从", "從").Replace("声", "聲")
                      .Replace("听", "聽").Replace("变", "變").Replace("铁", "鐵");
        }

    }
}
