using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JTC_Help.HtmlString
{
    public class PageHelp
    {

    }
    /// <summary>
    /// 用來組頁面html字串
    /// </summary>
    public class ToPage
    {
        public int GetSkipCount(int p,int count, int maxcount)
        {

            int skipCount = ((p - 1) * count);

            if (skipCount < 0)
                skipCount = 0;

            if(skipCount > maxcount)
            {
                skipCount = maxcount;
            }

            return skipCount;
        }
        public int GetPage(int takeCount, string p,int allcount)
        {
            int page = 1;
            int MaxPageCount = GetMaxPageCount(allcount, takeCount);
            if (int.TryParse(p, out page))
            {

            }
            if (page == 0)
            {
                page = 1;
            }
            if (page > MaxPageCount)
            {
                page = MaxPageCount;
            }
            return page;
        }

        public int GetMaxPageCount(int allcount, int maxcount)
        {
            int MaxPageCount = 0;
            if (allcount > 0)
            {
                if (maxcount > 0)
                {
                    MaxPageCount = ((allcount + maxcount) - 1) / (maxcount);
                }
            }
            return MaxPageCount;
        }

        //public int GetTakeCount()
        //{
        //    int takeCount = EndNum - BeginNum + 1;

        //    if (takeCount < 0 || BeginNum <= 0)
        //        takeCount = 0;

        //    return takeCount;
        //}

        public ToPage()
        {

        }

        /// <summary>
        /// 判斷是否為數字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        /// 頁數相關回傳  rowNo,PageSize,NowPageCount,RecordCount,pagehtml
        /// </summary>
        /// <returns></returns>
        public List<string> Pageback(int? page, int PageSize, int RecordCount, string Url, string CssName = "pagination manu")
        {
            List<string> Pagsiz = new List<string>();
            int pages = ((RecordCount + PageSize) - 1) / (PageSize);
            int pp = 0;
            //判斷傳入值
            if (page == null)
            {
                pp = 1;
            }
            else
            {
                if (IsNumeric(page))
                {
                    if ((page != null) & (page > 0) & (page <= pages))
                    {
                        pp = Convert.ToInt32(page);
                    }
                    else
                    {
                        pp = 1;
                    }
                }
                else
                {
                    pp = 1;
                }
            }

            int NowPageCount = 0;
            if (pp > 0)
            {
                NowPageCount = (pp - 1) * PageSize;
            }

            int rowNo = 0;
            string pageHtml = "";

            //處理頁面
            //<div class="text-center">
            //    <ul class="pagination">
            //        <li><a href="#">上一頁</a></li>
            //        <li><a href="OrderHistory?p=1">1</a></li>
            //        <li><a href="OrderHistory?p=2">2</a></li>
            //        <li><a href="OrderHistory?p=3">3</a></li>
            //        <li><a href="OrderHistory?p=4">4</a></li>
            //        <li><a href="OrderHistory?p=5">5</a></li>
            //        <li><a href="#">下一頁</a></li>
            //    </ul>
            //</div>
            if (pages > 0)
            {
                pageHtml = @"<div class='" + CssName + "'><ul>";
                if (pp > 1)   //======== 分頁功能（上一頁 / 下一頁）=========start===
                {
                    //pageHtml += "<li><a href='" + Url + "?p=" + 1 + "'>第一頁</a></li>";
                    pageHtml += "<li><a href='" + Url + "&p=" + (pp - 1) + "'>上一頁</a></li>";

                }
                else
                {
                    // pageHtml += "<li class='disabled'>第一頁</li>";
                    pageHtml += "<li class='disabled'>上一頁</li>";
                }

                for (int i = 1; i <= pages; i++)   //Pages 資料的總頁數
                {
                    if (pp == i)
                    {
                        pageHtml += "<li class='active'><a href='#'>" + pp + "</a></li>&nbsp;&nbsp;";
                        //pageHtml += "<li>" + pp + "</li>&nbsp;&nbsp;";
                    }
                    else
                    {
                        pageHtml += "<li><a href='" + Url + "&p=" + i + "'>" + i + "</a></li>&nbsp;&nbsp;";

                    }
                }
                if (pp < pages)
                {

                    pageHtml += "<li><a href='" + Url + "&p=" + (pp + 1) + "'>下一頁</a></li>";
                    //pageHtml += "<li><a href='" + Url + "?p=" + pages + "'>最後一頁</a></li>";
                }
                else
                {
                    pageHtml += "<li class='disabled'>下一頁</li>";
                    // pageHtml += "<li class='disabled'>最後一頁</li>";
                }

                pageHtml += @"</ul></div>";
            }


            Pagsiz.Add(rowNo.ToString());
            Pagsiz.Add(PageSize.ToString());
            Pagsiz.Add(NowPageCount.ToString());
            Pagsiz.Add(RecordCount.ToString());


            Pagsiz.Add(pageHtml);

            return Pagsiz;
        }
    }

    /// <summary>
    /// 確保html安全
    /// </summary>
    public class ToSafe
    {
        public ToSafe()
        {

        }

        /// <summary>
        /// Html白名單
        /// </summary>
        /// <param name="x">需檢驗字串</param>
        /// <returns></returns>
        public string SafeHtml(string x)
        {
            string filterString = x == string.Empty ? "" : x.Trim();
            if (string.IsNullOrEmpty(filterString) == false)
            {
                Regex regex = new Regex(@"<(?!br|\/?p|\/?a|\/?em|\/?span|\/?img|\/?table|\/?tbody|\/?tr|\/?td|\/?div|\/?u|\/?strong|\/?q|\/?ol|\/?ul|\/?li|\/?sup|\/?sub)[^>]*>");
                filterString = regex.Replace(filterString, "");
            }
            return filterString;
        }
    }
}
