using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinaWeb.Musica.Web.Filtros
{
    public class LogResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string mensagem = $"[{DateTime.Now.ToString()}] RESULTADO: " +
                $"{filterContext.RouteData.Values["Controller"].ToString()}" +
                $"{filterContext.RouteData.Values["Action"].ToString()}" +
                $"{filterContext.Result.ToString()}";

            Debug.WriteLine(mensagem);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string mensagem = $"[{DateTime.Now.ToString()}] PROCESSANDO: " +
                $"{filterContext.RouteData.Values["Controller"].ToString()}" +
                $"{filterContext.RouteData.Values["Action"].ToString()}";
        }
    }
}