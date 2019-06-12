using System.Web;
using System.Web.Mvc;

namespace CrudMvc_Uow_Onetable_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
