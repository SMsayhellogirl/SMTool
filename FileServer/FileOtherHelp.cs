using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JTC_Help.FileServer
{
    public class FileOtherHelp
    {
        protected HttpContext context;
        /// <summary>
        /// 附件檔案管理
        /// </summary>
        public FileOtherHelp(HttpContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// 檢查副檔名是否允許
        /// </summary>
        public bool IsImgFileExtValid(string ext)
        {
            var fileExtLimitations = new List<string>();
            var fileMimeLimitations = new List<string>();

            fileExtLimitations.Add("jpg");
            fileExtLimitations.Add("jpeg");
            fileMimeLimitations.Add("image/jpeg");

            fileExtLimitations.Add("gif");
            fileMimeLimitations.Add("image/gif");

            fileExtLimitations.Add("png");
            fileMimeLimitations.Add("image/png");

            fileExtLimitations.Add("bmp");
            fileMimeLimitations.Add("image/bmp");

            if (fileExtLimitations == null)
                return true;

            bool isValid = false;

            foreach (string validFileExt in fileExtLimitations)
            {
                if (string.Compare(ext, validFileExt, true) == 0)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }
    }
}
