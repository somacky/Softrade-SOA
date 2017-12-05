using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CustomSoft.Template.Modelo.Compartido;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public static class Util
    {
        public static Paginacion ConfiguracionPaginacionDefault(this Paginacion paginacionRequest)
        {
            if (paginacionRequest == null)
            {
                paginacionRequest = new Paginacion()
                {
                    Pagina = Convert.ToInt16(ConfigurationManager.AppSettings["paginaActualDefault"]),
                    Registros = Convert.ToInt16(ConfigurationManager.AppSettings["paginaRegistrosDefault"])
                };
            }
            return paginacionRequest;
        }
        
    }
}