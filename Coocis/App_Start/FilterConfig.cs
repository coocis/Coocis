using System.Web;
using System.Web.Mvc;

namespace Coocis
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            //加了下面这行的话http://是无法访问的，VS调试无法访问
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}
