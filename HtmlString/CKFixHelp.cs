using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help.HtmlString
{
    public class CKFixHelp
    {
        public string FixCK(string ckstring)
        {
            //return ckstring.Replace("\r\n", "").Replace("<p>&nbsp;</p>", "");
            return ckstring.Replace("\r\n", "");
        }



    }
}
