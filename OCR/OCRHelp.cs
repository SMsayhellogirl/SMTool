using System;
using System.Drawing;
using System.Text;
using System.IO;
using System.Net;
//using tessnet2;

namespace JTC_Help.OCR
{
    public class OCRHelp
    {
        /// <summary>
        /// 從網址取得圖片
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static Image GetImageFromURL(string strUrl)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            Stream srm = null;
            Bitmap bmp = null;

            try
            {
                req = (HttpWebRequest)WebRequest.Create(strUrl);
                res = (HttpWebResponse)req.GetResponse();
                srm = res.GetResponseStream();

                bmp = new Bitmap(srm);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (null != srm)
                    srm.Close();

                if (null != res)
                    res.Close();

                res = null;
                req = null;
            }

            return bmp;
        }

        ///// <summary>
        ///// 對單一圖片進行OCR
        ///// </summary>
        ///// <param name="imgSrc">來源圖片</param>
        ///// <returns></returns>
        //public static string DoOcr(Image imgSrc) { return DoOcr(imgSrc, false); }
        ///// <summary>
        ///// 對單一圖片進行OCR並決定是否只針對數字辨識
        ///// </summary>
        ///// <param name="imgSrc">來源圖片</param>
        ///// <param name="bOnlyNumber">針對數字辨識</param>
        ///// <returns></returns>
        //public static string DoOcr(Image imgSrc, bool bOnlyNumber)
        //{

        //    // 建立回傳值
        //    var sb = new StringBuilder();
        //    // 開始進行OCR相關作業
        //    using (var ocr = new Tesseract())
        //    {
        //        // 設定辨識的相關設定(以下設定為辨識數字)
        //        ocr.SetVariable("tessedit_char_whitelist", "0123456789");
        //        // 樣本資料夾位置
        //        var path = string.Concat(Application.StartupPath, @"\tessdata");
        //        // 設定語系及是否為數字模式
        //        ocr.Init(path, "eng", bOnlyNumber);
        //        // 進行OCR
        //        var result = ocr.DoOCR(new Bitmap(imgSrc), Rectangle.Empty);
        //        // 將辨識結果轉換成字串
        //        result.ForEach(c =>
        //        {
        //            sb.Append(c.Text);
        //        });
        //    }
        //    // 回傳
        //    return sb.ToString();
        //}
    }
}
