using System.Web;
using System.Web.Mvc;

namespace DBProgramming_Class_I
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
