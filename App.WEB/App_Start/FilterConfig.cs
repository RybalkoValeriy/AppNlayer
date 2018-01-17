using System.Web;
using System.Web.Mvc;
using App.WEB.Filters;

namespace App.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CultureFilterAttribute());
        }
    }
}
