using System.Web;
using System.Web.Mvc;

namespace ASP.NET_WEB_API_FOR_CRUD_OPERATION
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
