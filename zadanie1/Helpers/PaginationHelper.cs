using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace zadanie1.Helpers
{
    public static class PaginationHelper
    {
        public static MvcHtmlString SelectMaxRow(this HtmlHelper html, string[] items,string scriptName)
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", scriptName+"(item)");
                a.SetInnerText(item);
                li.InnerHtml += a.ToString();
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }

        public static MvcHtmlString Pagination(this HtmlHelper html, int maxrow, int selectrow, string scriptName)
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            for (int i =1;i<=maxrow;i++)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", scriptName+"(i)");
                a.SetInnerText(i.ToString());
                li.InnerHtml += a.ToString();
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }


    }
}
