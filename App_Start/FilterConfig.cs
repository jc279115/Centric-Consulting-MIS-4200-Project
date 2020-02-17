using System.Web;
using System.Web.Mvc;

namespace Centric_Consulting_MIS_4200_Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
