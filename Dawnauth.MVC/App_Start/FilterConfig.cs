using System.Web;
using System.Web.Mvc;
using DawnXZ.Dawnauth.MVC.Filters;

namespace DawnXZ.Dawnauth.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionExecutFilter());
            filters.Add(new ExceptionFilter());
            filters.Add(new AuthorizeFilter());
        }
    }
}