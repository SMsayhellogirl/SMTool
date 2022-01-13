using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace JTC_Help.HtmlString
{
    public static class HtmlHelperTemp
    {
        public static MvcHtmlString EditorForMany<TModel, TValue>(
           this HtmlHelper<TModel> html,
           Expression<Func<TModel, IEnumerable<TValue>>> expression,
           string htmlFieldName = null) where TModel : class
        {
            var items = expression.Compile()(html.ViewData.Model);
            var sb = new StringBuilder();
            var hasPrefix = false;

            if (String.IsNullOrEmpty(htmlFieldName))
            {
                var prefix = html.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
                hasPrefix = !String.IsNullOrEmpty(prefix);
                htmlFieldName = (prefix.Length > 0 ? (prefix + ".") : String.Empty) + ExpressionHelper.GetExpressionText(expression);
            }

            if (items != null)
            {
                foreach (var item in items)
                {
                    var dummy = new { Item = item };
                    var guid = Guid.NewGuid().ToString();

                    var memberExp = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
                    var singleItemExp = Expression.Lambda<Func<TModel, TValue>>(memberExp, expression.Parameters);

                    sb.Append(String.Format(@"<input type=""hidden"" name=""{0}.Index"" value=""{1}"" />", htmlFieldName, guid));
                    sb.Append(html.EditorFor(singleItemExp, null, String.Format("{0}[{1}]", hasPrefix ? ExpressionHelper.GetExpressionText(expression) : htmlFieldName, guid)));
                }
            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}
