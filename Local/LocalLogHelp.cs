using System;
using System.IO;
using System.Text;

namespace JTC_Help.Local
{
    public class LocalLogHelp
    {
        public LocalLogHelp()
        {

        }

        /// <summary>
        /// 存入預設位置的LOG
        /// </summary>
        /// <param name="ex">Exception</param>
        public void fun_ErrorLog(Exception ex)
        {
            funWriteErrorLogToFile(@"D:\LogData\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", ex.Source + " " + ex.Message + "\r\n" + ex.StackTrace);
        }

        /// <summary>
        /// 存入預設位置的LOG
        /// </summary>
        /// <param name="errLog">err字串</param>
        public void fun_ErrorLog(string errLog)
        {
            funWriteErrorLogToFile(@"D:\LogData\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", errLog);
        }

        /// <summary>
        /// 存入指定位置的LOG
        /// </summary>
        /// <param name="filePath">EX:D:\LogData\Log_20170119.txt</param>
        /// <param name="ex">Exception</param>
        public void fun_ErrorLogToFile(string filePath, Exception ex)
        {
            funWriteErrorLogToFile(filePath, ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        /// <summary>
        /// 存入指定位置的LOG
        /// </summary>
        /// <param name="filePath">EX:D:\LogData\Log_20170119.txt</param>
        /// <param name="errLog">err字串</param>
        public void fun_ErrorLogToFile(string filePath, string errLog)
        {
            funWriteErrorLogToFile(filePath, errLog);
        }

        /// <summary>
        /// 執行寫入動作
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="errLog"></param>
        public static void funWriteErrorLogToFile(string filePath, string errLog)
        {
            Encoding big5 = Encoding.GetEncoding("Big5");

            if (!File.Exists(filePath))
            {
                FileStream filestream = new FileInfo(filePath).Create();
                filestream.Close();
            }
            StreamWriter sw = new StreamWriter(filePath, true, big5);
            sw.WriteLine("== 發生時間 " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " =============================================================================================================");
            sw.WriteLine(errLog);
            sw.Close();
        }

        public bool Save_Log(Exception ex)
        {
            return Save_Log(ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        public static bool Save_Log(string message)
        {
            bool rBet = false;
            string Logpath = System.Environment.CurrentDirectory;
            string Today = DateTime.Now.ToString("yyyy-MM-dd");
            string Day_Time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            try
            {
                if (!Directory.Exists(Logpath + "\\Log\\" + Today))
                {
                    //新增資料夾
                    Directory.CreateDirectory(Logpath + "\\Log\\" + Today);
                }
                File.AppendAllText(Logpath + "\\Log\\" + Today + "\\Log.txt", "\r\n" + Day_Time + " ：\r\n  " + message + "\r\n ");
                rBet = true;
            }
            catch (Exception ex)
            {
                if (!Directory.Exists(Logpath + "\\Log\\" + Today))
                {
                    //新增資料夾
                    Directory.CreateDirectory(Logpath + "\\Log\\" + Today);
                }

                File.AppendAllText(Logpath + "\\Log\\" + Today + "\\Log.txt", "\r\n" + Day_Time + " ：\r\n SaveLog failed ， Exception : " + ex + "\r\n ");
                rBet = true;
            }
            return rBet;
        }
    }
}
