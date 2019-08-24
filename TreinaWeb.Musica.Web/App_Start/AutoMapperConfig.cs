using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.Musica.Web.AutoMapper;

namespace TreinaWeb.Musica.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configurar()
        {
            new Map().InitializeMapper();
        }
    }
}