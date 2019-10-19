﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TreinaWeb.Musica.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PesquisaAlbuns",
                url: "Albuns/PesquisaPorNome/{pesquisa}",
                defaults: new { controller = "Albuns", action = "FiltrarPorNome", pesquisa = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PesquisaMusicas",
                url: "Musicas/PesquisaPorNome/{pesquisa}",
                defaults: new { controller = "Musicas", action = "FiltrarPorNome", pesquisa = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuarios", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
