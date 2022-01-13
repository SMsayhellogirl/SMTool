using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;

namespace JTC_Help.FileServer
{
    public class FileHelp
    {
        public class FileHelpModel
        {
            //public int States { get; set; }
            //public string ErrorDesc { get; set; }
            public string FileSaveName { get; set; }
            public string FileOldName { get; set; }
            public string FileMemo { get; set; }
            public string FilePath { get; set; }
            public string FileMIME { get; set; }
            public int FileSize { get; set; }
        }

        protected HttpContext context;
        /// <summary>
        /// 附件檔案管理
        /// </summary>
        public FileHelp(HttpContext context)
        {
            this.context = context;
        }

        protected HttpServerUtility Server
        {
            get { return context.Server; }
        }

        public string GetDirectoryName()
        {
            return string.Format("ckf");
        }
        /// <summary>
        /// 取得附件根目錄的完整路徑
        /// </summary>
        public virtual string GetAttRootDirectoryFullName()
        {
            return Server.MapPath(string.Format("~/{0}", ConfigurationManager.AppSettings["AttRootDir"]));
        }


        public string GetFileFullName(string fileSavedName)
        {
            string website = ConfigurationManager.AppSettings["WebsiteUrl"];

            string fileFullName = string.Format("{0}{1}{2}/{3}", website, ConfigurationManager.AppSettings["AttRootDir"], GetDirectoryName(), fileSavedName);

            return fileFullName;
        }

        public string SaveData(HttpPostedFileBase postedFile)
        {
            var constructorInfo = typeof(HttpPostedFile).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            var obj = (HttpPostedFile)constructorInfo.Invoke(new object[] { postedFile.FileName, postedFile.ContentType, postedFile.InputStream });
            return SaveData(obj);
        }

        /// <summary>
        /// 0: 活動 1:導師 2: 文章 3:廣告 4:派送 5:培訓 6.校園 7:顧問 8:人才培訓 9:顧問培訓 10:門診顧問 11:問卷 12:企業公告
        /// </summary>
        /// <param name="oldpostedFile"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string SaveImageData(HttpPostedFileBase oldpostedFile,int type)
        {
            var constructorInfo = typeof(HttpPostedFile).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            var postedFile = (HttpPostedFile)constructorInfo.Invoke(new object[] { oldpostedFile.FileName, oldpostedFile.ContentType, oldpostedFile.InputStream });
            bool hasFile = (postedFile != null && postedFile.ContentLength > 0);

            string ext = Path.GetExtension(postedFile.FileName);
            string filePath = "defFileDis";
            switch (type)
            {
                case 0:
                    filePath = "ActivityFileDis";
                    break;
                case 1:
                    filePath = "MentorFileDis";
                    break;
                case 2:
                    filePath = "CareerArtcleFileDis";
                    break;
                case 3:
                    filePath = "BannerFileDis";
                    break;
                case 4:
                    filePath = "DeliverFileDis";
                    break;
                case 5:
                    filePath = "TrainingListFileDis";
                    break;
                case 6:
                    filePath = "IndependentPageFileDis";
                    break;

                case 7:
                    filePath = "ConsultantTeamFileDis";
                    break;
                case 8:
                    filePath = "PersonnelTrainingFileDis";
                    break;
                case 9:
                    filePath = "ConsultationTeamFileDis";
                    break;
                case 10:
                    filePath = "ClinicConsultantFileDis";
                    break;
                case 11:
                    filePath = "FormFileDis";
                    break;
                case 12:
                    filePath = "EZAFileDis";
                    break;
                case 13:
                    filePath = "IconFileDis";
                    break;
            }

            string pathDirFullName = GetAttRootDirectoryFullName() + filePath;
            DirectoryInfo diPathDir = new DirectoryInfo(pathDirFullName);

            if (!diPathDir.Exists)
            {
                diPathDir.Create();
            }

            if (ext.StartsWith("."))
            {
                ext = ext.Substring(1);
            }

            if (!IsFileExtValid(ext))
            {
                return "";
            }
            OtherHelp _oh = new OtherHelp();
            Thread.Sleep(200);
            string fileSavedName = string.Format("{0:yyyyMMdd_HHmmssfff}{2}.{1}", DateTime.Now, ext, _oh.randstr(5));
            string fileFullName = pathDirFullName + "\\" + fileSavedName;


            if (!SavePhysicalFileDataAndShrinkImage(postedFile, fileFullName, fileSavedName))
            {
                return "";
            }

            return fileSavedName;
        }

        /// <summary>
        /// 0: 活動
        /// 1: 文章(職涯好文)
        /// 2: 電子書
        /// 3: 派送
        /// 4: 顧問培訓
        /// 5:花絮
        /// 6:企業專區
        /// 7:企業公告
        /// 8:門診諮詢PDF
        /// 9:門診名單
        /// </summary>
        /// <param name="oldpostedFile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public FileHelpModel SaveOtherData(HttpPostedFileBase oldpostedFile, int type)
        {
            FileHelpModel returnModel = new FileHelpModel();
            var constructorInfo = typeof(HttpPostedFile).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            var postedFile = (HttpPostedFile)constructorInfo.Invoke(new object[] { oldpostedFile.FileName, oldpostedFile.ContentType, oldpostedFile.InputStream });
            bool hasFile = (postedFile != null && postedFile.ContentLength > 0);
            returnModel.FileSize = postedFile.ContentLength;
            returnModel.FileOldName = postedFile.FileName;
            string ext = Path.GetExtension(postedFile.FileName);
            
            string filePath = "defFileDis";
            switch (type)
            {
                case 0:
                    filePath = "ActivityAttachFile";
                    break;
                case 1:
                    filePath = "CareerArtcleAttachFile";
                    break;
                case 2:
                    filePath = "EbookAttachFile";
                    break;
                case 3:
                    filePath = "DeliverFile";
                    break;
                case 4:
                    filePath = "ConsultationTeamFile";
                    break;
                case 5:
                    filePath = "HighLightsFile";
                    break;
                case 6:
                    filePath = "EnterpriseZoneFile";
                    break;
                case 7:
                    filePath = "EZAFile";
                    break;
                case 8:
                    filePath = "ClinicContentPdfFile";
                    break;
                case 9:
                    filePath = "ClinicContentFile";
                    break;
            }

            string pathDirFullName = GetAttRootDirectoryFullName() + filePath;
            DirectoryInfo diPathDir = new DirectoryInfo(pathDirFullName);

            if (!diPathDir.Exists)
            {
                diPathDir.Create();
            }

            if (ext.StartsWith("."))
            {
                ext = ext.Substring(1);
            }
            returnModel.FileMIME = ext;
            if (!IsALLFileExtValid(ext))
            {
                return null;
            }
            Thread.Sleep(200);
            var fileSavedName = string.Format("{0:yyyyMMdd_HHmmssfff}.{1}", DateTime.Now, ext);
            var fileFullName = pathDirFullName + "\\" + fileSavedName;
            returnModel.FileSaveName = fileSavedName;
            returnModel.FilePath = fileFullName;


            if (!SavePhysicalFileDataAndShrinkImage(postedFile, fileFullName, fileSavedName))
            {
                return null;
            }

            return returnModel;
        }

        /// <summary>
        /// 檢查副檔名是否允許
        /// </summary>
        protected bool IsFileExtValid(string ext)
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

        protected bool IsALLFileExtValid(string ext)
        {
            var fileExtLimitations = new List<string>();
            var fileMimeLimitations = new List<string>();

            //doc
            fileExtLimitations.Add("doc");
            fileMimeLimitations.Add("application/msword");
            fileExtLimitations.Add("docx");
            fileMimeLimitations.Add("application/vnd.openxmlformats-officedocument.wordprocessingml.document");

            fileExtLimitations.Add("xls");
            fileMimeLimitations.Add("application/vnd.ms-excel");
            fileExtLimitations.Add("xlsx");
            fileMimeLimitations.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            fileExtLimitations.Add("ppt");
            fileExtLimitations.Add("pps");
            fileMimeLimitations.Add("application/vnd.ms-powerpoint");
            fileExtLimitations.Add("pptx");
            fileMimeLimitations.Add("application/vnd.openxmlformats-officedocument.presentationml.presentation");
            fileExtLimitations.Add("ppsx");
            fileMimeLimitations.Add("application/vnd.openxmlformats-officedocument.presentationml.slideshow");

            fileExtLimitations.Add("odt");
            fileMimeLimitations.Add("application/vnd.oasis.opendocument.text");

            fileExtLimitations.Add("ods");
            fileMimeLimitations.Add("application/vnd.oasis.opendocument.spreadsheet");

            fileExtLimitations.Add("odp");
            fileMimeLimitations.Add("application/vnd.oasis.opendocument.presentation");

            fileExtLimitations.Add("pdf");
            fileMimeLimitations.Add("application/pdf");

            fileExtLimitations.Add("txt");
            fileMimeLimitations.Add("text/plain");

            fileExtLimitations.Add("csv");
            fileMimeLimitations.Add("text/csv");

            //graphic
            fileExtLimitations.Add("jpg");
            fileExtLimitations.Add("jpeg");
            fileMimeLimitations.Add("image/jpeg");

            fileExtLimitations.Add("gif");
            fileMimeLimitations.Add("image/gif");

            fileExtLimitations.Add("png");
            fileMimeLimitations.Add("image/png");

            fileExtLimitations.Add("bmp");
            fileMimeLimitations.Add("image/bmp");

            //compression
            fileExtLimitations.Add("zip");
            fileMimeLimitations.Add("application/x-zip-compressed");

            fileExtLimitations.Add("rar");
            fileMimeLimitations.Add("application/x-rar-compressed");

            //audio
            //fileExtLimitations.Add("wav");
            //fileMimeLimitations.Add("audio/wav");

            //fileExtLimitations.Add("mp3");
            //fileMimeLimitations.Add("audio/mpeg");

            //fileExtLimitations.Add("wma");
            //fileMimeLimitations.Add("audio/x-ms-wma");

            //video: avi, mov, mp4, wmv
            //fileExtLimitations.Add("avi");
            //fileMimeLimitations.Add("video/avi");

            //fileExtLimitations.Add("mov");
            //fileMimeLimitations.Add("video/quicktime");

            //fileExtLimitations.Add("mp4");
            //fileMimeLimitations.Add("video/mp4");

            //fileExtLimitations.Add("wmv");
            //fileMimeLimitations.Add("video/x-ms-wmv");

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

        /// <summary>
        /// 允許名單
        /// </summary>
        public List<string> getFileExtValid()
        {
            var fileMimeLimitations = new List<string>();

            fileMimeLimitations.Add("image/jpeg");

            fileMimeLimitations.Add("image/gif");

            fileMimeLimitations.Add("image/png");

            fileMimeLimitations.Add("image/bmp");

            return fileMimeLimitations;
        }

        /// <summary>
        /// 1:圖片 2:圖片+文件 3:圖片+文件+壓縮檔 4:圖片+文件+壓縮檔+影片+mp3
        /// 先湊合著用
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> getALLFileExtValid(int type = 1)
        {
            var fileMimeLimitations = new List<string>();

            if(type > 0){
                fileMimeLimitations.Add("jpg");
                fileMimeLimitations.Add("jpeg");
                fileMimeLimitations.Add("gif");
                fileMimeLimitations.Add("png");
                fileMimeLimitations.Add("bmp");
                fileMimeLimitations.Add("tiff");
            }
            if (type > 1)
            {
                //doc
                fileMimeLimitations.Add("doc");
                fileMimeLimitations.Add("docx");
                fileMimeLimitations.Add("xls");
                fileMimeLimitations.Add("xlsx");
                fileMimeLimitations.Add("ppt");
                fileMimeLimitations.Add("pps");
                fileMimeLimitations.Add("pptx");
                fileMimeLimitations.Add("ppsx");
                fileMimeLimitations.Add("odt");
                fileMimeLimitations.Add("ods");
                fileMimeLimitations.Add("odp");
                fileMimeLimitations.Add("pdf");
                fileMimeLimitations.Add("txt");
                fileMimeLimitations.Add("csv");
            }
            if(type > 2)
            {
                fileMimeLimitations.Add("zip");
                fileMimeLimitations.Add("rar");
            }
            if (type > 3)
            {
                fileMimeLimitations.Add("wav");
                fileMimeLimitations.Add("mp3");
                fileMimeLimitations.Add("wma");
                fileMimeLimitations.Add("avi");
                fileMimeLimitations.Add("mov");
                fileMimeLimitations.Add("mp4");
                fileMimeLimitations.Add("wmv");
            }

            return fileMimeLimitations;
        }

        public List<string> getEXCELFileExtValid()
        {
            var fileMimeLimitations = new List<string>();
            fileMimeLimitations.Add("xls");
            return fileMimeLimitations;
        }

        public string SaveData(HttpPostedFile postedFile)
        {
            bool hasFile = (postedFile != null && postedFile.ContentLength > 0);

            string ext = Path.GetExtension(postedFile.FileName);
            var filePath = GetDirectoryName();
            string pathDirFullName = GetAttRootDirectoryFullName() + filePath;
            DirectoryInfo diPathDir = new DirectoryInfo(pathDirFullName);

            if (!diPathDir.Exists)
            {
                diPathDir.Create();
            }

            if (ext.StartsWith("."))
            {
                ext = ext.Substring(1);
            }

            if (!IsFileExtValid(ext))
            {
                return "";
            }

            var fileSavedName = string.Format("{0:yyyyMMdd_HHmmssfff}.{1}", DateTime.Now, ext);
            var fileFullName = pathDirFullName + "\\" + fileSavedName;


            if (!SavePhysicalFileDataAndShrinkImage(postedFile, fileFullName, fileSavedName))
            {
                return "";
            }

            return fileSavedName;
        }

        /// <summary>
        /// 儲存實體檔案(視條件縮圖)
        /// </summary>
        protected virtual bool SavePhysicalFileDataAndShrinkImage(HttpPostedFile postedFile, string fileFullName, string fileSavedName)
        {
            try
            {
                string fileExt = Path.GetExtension(fileSavedName);
                string contentType = "application/octet-stream";
                ImageFormat contentImageFormat = ImageFormat.Jpeg;

                switch (fileExt.ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        contentType = "image/jpeg";
                        contentImageFormat = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        contentType = "image/bmp";
                        contentImageFormat = ImageFormat.Bmp;
                        break;
                    case ".gif":
                        contentType = "image/gif";
                        contentImageFormat = ImageFormat.Gif;
                        break;
                    case ".png":
                        contentType = "image/png";
                        contentImageFormat = ImageFormat.Png;
                        break;
                    case ".tiff":
                    case ".tif":
                        contentType = "image/tiff";
                        contentImageFormat = ImageFormat.Tiff;
                        break;
                }

                if (contentType == "application/octet-stream")
                {
                    // save normal file
                    postedFile.SaveAs(fileFullName);
                    return true;
                }

                //載入圖片,檢查是否需要縮圖
                System.Drawing.Image img = System.Drawing.Image.FromStream(postedFile.InputStream);

                int maxWidth = 1920;
                int maxHeight = 1440;
                bool isHeightMoreThanWidth = false;
                bool needsToShrink = false;

                if (img.Height > img.Width)
                {
                    isHeightMoreThanWidth = true;
                }

                if (img.Width * img.Height > maxWidth * maxHeight)
                {
                    needsToShrink = true;
                }

                if (needsToShrink)
                {
                    //等比例縮圖
                    float widthRate, heightRate;

                    if (isHeightMoreThanWidth)
                    {
                        widthRate = img.Width / (float)maxHeight;
                        heightRate = img.Height / (float)maxWidth;
                    }
                    else
                    {
                        widthRate = img.Width / (float)maxWidth;
                        heightRate = img.Height / (float)maxHeight;
                    }

                    int fitWidth, fitHeight;

                    if (widthRate > heightRate)
                    {
                        fitWidth = Convert.ToInt32(img.Width / widthRate);
                        fitHeight = Convert.ToInt32(img.Height / widthRate);
                    }
                    else
                    {
                        fitWidth = Convert.ToInt32(img.Width / heightRate);
                        fitHeight = Convert.ToInt32(img.Height / heightRate);
                    }

                    System.Drawing.Image imgFit = new Bitmap(img, new Size(fitWidth, fitHeight));

                    //還原旋轉方向
                    // reference: https://forums.asp.net/t/2016582.aspx?Resize+script+is+rotating+image+sometimes+
                    if (new List<int>(img.PropertyIdList).Contains(0x112))
                    {
                        PropertyItem prop = img.GetPropertyItem(0x112);

                        if (prop.Type == 3 && prop.Len == 2)
                        {
                            UInt16 orientationExif = BitConverter.ToUInt16(prop.Value, 0);

                            switch (orientationExif)
                            {
                                case 8:
                                    imgFit.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    break;
                                case 3:
                                    imgFit.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    break;
                                case 6:
                                    imgFit.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    break;
                            }
                        }
                    }

                    imgFit.Save(fileFullName, contentImageFormat);
                    imgFit.Dispose();
                    img.Dispose();
                }
                else
                {
                    //不用縮圖,直接存檔
                    postedFile.SaveAs(fileFullName);
                    img.Dispose();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
