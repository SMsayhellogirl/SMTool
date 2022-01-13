using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help.JTC_DateTime
{
    static class TaiwanDateExtensionHelp
    {
        /// <summary>
        /// To the full taiwan date.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns></returns>
        public static string ToFullTaiwanDate(this DateTime datetime)
        {

            if (datetime == null)
                return "";

            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();

            return string.Format("民國{0}年{1}月{2}日",
                taiwanCalendar.GetYear(datetime),
                datetime.Month,
                datetime.Day);
        }

        /// <summary>
        /// To the simple taiwan date.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns></returns>
        public static string ToSimpleTaiwanDate(this DateTime datetime)
        {

            if (datetime == null)
                return "";

            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();



            return string.Format("{0:000}/{1:00}/{2:00}",
                taiwanCalendar.GetYear(datetime),
                datetime.Month,
                datetime.Day);
        }

        /// <summary>
        /// 將時間做 加一天剪一豪秒的處理
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static DateTime ToSearchEndDateTime(this DateTime dt)
        {
            return dt.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// 計算時間差
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小時" + ts.Minutes.ToString() + "分鐘" + ts.Seconds.ToString() + "秒";
            return dateDiff;
        }
    }
}
