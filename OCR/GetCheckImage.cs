using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JTC_Help.OCR
{
    public class GetCheckImage
    {
        /// <summary>
        /// 生成圖片驗證碼
        /// </summary>
        public static class CreateCheckCodeImage
        {
            /// <summary>
            /// 在記憶體中生成一個驗證圖片
            /// </summary>
            /// <returns>System.IO.MemoryStream</returns>
            public static MemoryStream Production(string StrCode)
            {
                MemoryStream ms = new MemoryStream();
                if (string.Equals(StrCode, string.Empty))
                {
                    return ms;
                }

                Bitmap image = new Bitmap((int)System.Math.Ceiling(StrCode.Length * 16.5), 22);
                Graphics g = Graphics.FromImage(image);

                try
                {
                   System.Random random = new Random();
                    g.Clear(System.Drawing.Color.White);

                    //生成背景干擾點
                    for (int i = 0; i < 25; i++)
                    {
                        int x1 = random.Next(image.Width);
                        int x2 = random.Next(image.Width);
                        int y1 = random.Next(image.Height);
                        int y2 = random.Next(image.Height);
                        g.DrawLine(new Pen(System.Drawing.Color.Silver), x1, x2, y1, y2);
                    }

                    //生成驗證字元
                    Font font = new System.Drawing.Font("Arial", 16, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                    System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Color.Blue, System.Drawing.Color.DarkRed, 1.2f, true);
                    g.DrawString(StrCode, font, brush, 2, 1);

                    //生成前景干擾點
                    for (int i = 0; i < 100; i++)
                    {
                        int x1 = random.Next(image.Width);
                        int y1 = random.Next(image.Height);

                        image.SetPixel(x1, y1, System.Drawing.Color.FromArgb(random.Next()));
                    }

                    //化圖片的邊框
                    g.DrawRectangle(new Pen(System.Drawing.Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                    //TwisImaige
                    //TwisImaige(image, true,2.5, 0.2).Save(ms,ImageFormat.Gif);    //目前沒有使用
                    image.Save(ms, ImageFormat.Gif);

                    return ms;
                }
                finally
                {
                    g.Dispose();
                    image.Dispose();
                }
            }

            /// <summary>
            /// 隨即生成一段字串，用作生成隨即圖片 預設是五碼
            /// </summary>
            /// <returns>string</returns>
            public static string GenerateCheckCode(int num = 5)
            {
                int number;
                char code;
                string CheckCode = string.Empty;
                System.Random random = new System.Random();
                for (int i = 0; i < num; i++)
                {
                    number = random.Next();
                    if (number % 2 == 0)
                    {
                        code = (char)('0' + (char)(number % 10));
                    }
                    else
                    {
                        code = (char)('A' + (char)(number % 26));
                    }
                    CheckCode += code.ToString();
                }
                CheckCode = CheckCode.Replace("0", "Y");
                CheckCode = CheckCode.Replace("O", "Y");
                return CheckCode;
            }

            /// <summary>
            /// 正弦曲線Wave扭曲圖片
            /// </summary>
            /// <param name="srcBmp">圖片</param>
            /// <param name="bXDir">如果扭曲選擇為True</param>
            /// <param name="dMultValue">波形的幅度倍數，越大扭曲的程度越高，一般為3</param>
            /// <param name="dPhase">波形的起始位置，取值區間[0.2*PI]</param>
            /// <returns></returns>
            private static Bitmap TwisImaige(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
            {
                const double PI2 = 3.14 * 2;
                Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
                Graphics g = Graphics.FromImage(destBmp);
                g.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
                g.Dispose();

                double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;
                try
                {
                    for (int i = 0; i < destBmp.Width; i++)
                    {
                        for (int j = 0; j < destBmp.Height; j++)
                        {
                            double dx = 0;
                            dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                            dx += dPhase;
                            double dy = System.Math.Sin(dx);

                            //取得當前點的顏色
                            int nOldX = 0, nOldY = 0;
                            nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                            nOldY = bXDir ? j + (int)(dy * dMultValue) : j;

                            System.Drawing.Color color = srcBmp.GetPixel(i, j);
                            if (nOldX >= 0 && nOldX < destBmp.Width && nOldY >= 0 && nOldY < destBmp.Height)
                            {
                                destBmp.SetPixel(nOldX, nOldY, color);
                            }
                        }
                    }
                    return destBmp;
                }
                catch (Exception e)
                {
                    string eStr = e.Message;
                    return destBmp;
                }
            }
        }
    }
}
