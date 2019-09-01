using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musica.Web.Filtros;

namespace TreinaWeb.Musica.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogActionFilter());
            filters.Add(new LogResultFilter());
        }
    }
}
