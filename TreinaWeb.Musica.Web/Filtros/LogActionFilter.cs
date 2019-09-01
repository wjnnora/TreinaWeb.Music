using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinaWeb.Musica.Web.Filtros
{
    public class LogActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string mensagem = $"[{DateTime.Now.ToString()}] FINALIZOU: " +
                $"{filterContext.RouteData.Values["Controller"].ToString()}" +
                $"{filterContext.RouteData.Values["Action"].ToString()}";

            Debug.WriteLine(mensagem);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string mensagem = $"[{DateTime.Now.ToString()}] INICIOU: " +
                $"{filterContext.RouteData.Values["Controller"].ToString()}" +
                $"{filterContext.RouteData.Values["Action"].ToString()}";

            Debug.WriteLine(mensagem);
        }
    }
}