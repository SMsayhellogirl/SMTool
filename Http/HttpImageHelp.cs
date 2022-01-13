using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help.Http
{
    public class HttpImageHelp
    {
        //youtube
        //JPEG 格式的版本
        //解析度 320×180 的版本
        //https://i.ytimg.com/vi/<YouTube影片ID>/mqdefault.jpg
        //解析度 480×360 的版本
        //https://i.ytimg.com/vi/<YouTube影片ID>/hqdefault.jpg
        //解析度 640×480 的版本
        //https://i.ytimg.com/vi/<YouTube影片ID>/sddefault.jpg
        //解析度 1280×720 的版本（目前最大的尺寸）
        //https://i.ytimg.com/vi/<YouTube影片ID>/maxresdefault.jpg

        /// <summary>
        /// 從後端判斷圖片連結是否存在
        /// </summary>
        /// <param name="curl"></param>
        /// <returns></returns>
        public bool GetImageUrlError(string curl)
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

        /// <summary>
        /// 取得圖片 type 0:預設 不限制 1:1280×720 320×180 2:640×480 480×360
        /// </summary>
        /// <param name="ytId"></param>
        /// <returns></returns>
        public string GetYTImage(string ytId,int type = 0)
        {
            List<string> imaglist = new List<string>();
            string ytimgstr = "";
            switch (type)
            {
                case 0:
                default:
                    if (imaglist.Count == 0)
                    {
                        imaglist.Add("https://img.youtube.com/vi/{0}/maxresdefault.jpg");
                        imaglist.Add("https://img.youtube.com/vi/{0}/sddefault.jpg");
                        imaglist.Add("https://img.youtube.com/vi/{0}/hqdefault.jpg");
                        imaglist.Add("https://img.youtube.com/vi/{0}/mqdefault.jpg");
                    }
                    ytimgstr = string.Format("https://img.youtube.com/vi/{0}/maxresdefault.jpg", ytId);
                    break;
                case 1:
                    if (imaglist.Count == 0)
                    {
                        imaglist.Add("https://img.youtube.com/vi/{0}/maxresdefault.jpg");
                        imaglist.Add("https://img.youtube.com/vi/{0}/mqdefault.jpg");
                    }
                    ytimgstr = string.Format("https://img.youtube.com/vi/{0}/maxresdefault.jpg", ytId);
                    break;
                case 2:
                    if (imaglist.Count == 0)
                    {
                        imaglist.Add("https://img.youtube.com/vi/{0}/sddefault.jpg");
                        imaglist.Add("https://img.youtube.com/vi/{0}/hqdefault.jpg");
                    }
                    ytimgstr = string.Format("https://img.youtube.com/vi/{0}/hqdefault.jpg", ytId);
                    break;
            }
            foreach (var st in imaglist)
            {
                string sts = string.Format(st, ytId);
                if (GetImageUrlError(sts))
                {
                    ytimgstr = sts;
                    break;
                }
            }
            return ytimgstr;
        }
    }
}
