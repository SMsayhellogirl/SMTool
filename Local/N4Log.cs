using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help.Local
{
    public class N4Log
    {
        protected ILog Logger
        {
            get;
            set;
        }
        public void SetLog4Error(string Description, Exception exception)
        {
            Logger = LogManager.GetLogger(this.GetType());
            Logger.Error("<<<<<<<<<<=======================================================================================================" + Environment.NewLine);
            Logger.Error(Description, exception);
            Logger.Error("=======================================================================================================>>>>>>>>>>" + Environment.NewLine);
        }
    }
}
