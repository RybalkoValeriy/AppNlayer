using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using App.BLL.Infrastructure;

namespace App.WEB.Filters
{
    sealed class CultureFilterAttribute : FilterAttribute, IActionFilter
    {
        private readonly Culture culture = new Culture();

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            string cookieLang = HttpContext.Current.Request.Cookies["lang-port"]?.Value;
            string context = HttpContext.Current.Request.Path;
            string lang = "ru";
            if (cookieLang == null)
            {
                // 3
                // Для входа без get параметров языка, язык берем из HTTP контекста 
                lang = HttpContext.Current.Request.UserLanguages != null &&
                HttpContext.Current.Request.UserLanguages.Length != 0
                ? HttpContext.Current.Request.UserLanguages[0].Substring(0, 2).ToLower() : "ru";
            }
            else
            {
                if (culture.SerachLang(cookieLang))
                {
                    // 2
                    lang = cookieLang;
                }

                var collection = context.Split(new char[] { '/' });
                foreach (var item in collection)
                {
                    if (culture.SerachLang(item))
                    {
                        // 1
                        lang = item;
                        break;
                    }
                }
            }
            // Задаим куки
            HttpContext.Current.Response.Cookies["lang-port"].Value = lang;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}