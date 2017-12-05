using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Servicios.Request;
using MCS.Factory;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public static class Util
    {
        public static Paginacion ConfiguracionPaginacionDefault(this Paginacion paginacionRequest)
        {
            if (paginacionRequest == null || paginacionRequest.Pagina == 0)
            {
                paginacionRequest = new Paginacion()
                {
                    Pagina = Convert.ToInt16(ConfigurationManager.AppSettings["paginaActualDefault"]),
                    Registros = Convert.ToInt16(ConfigurationManager.AppSettings["paginaRegistrosDefault"])
                };
            }
            else
            {
                paginacionRequest = new Paginacion()
                {
                    Pagina = paginacionRequest.Pagina,
                    Registros = Convert.ToInt16(ConfigurationManager.AppSettings["paginaRegistrosDefault"])
                };
            }
            return paginacionRequest;
        }

        public static Paginacion ConfiguracionPaginacionTop5(this Paginacion paginacionRequest)
        {
            if (paginacionRequest == null || paginacionRequest.Pagina == 0)
            {
                paginacionRequest = new Paginacion()
                {
                    Pagina = Convert.ToInt16(ConfigurationManager.AppSettings["paginaActualDefault"]),
                    Registros = Convert.ToInt16(ConfigurationManager.AppSettings["paginaRegistrosTop5"])
                };
            }
            else
            {
                paginacionRequest = new Paginacion()
                {
                    Pagina = paginacionRequest.Pagina,
                    Registros = Convert.ToInt16(ConfigurationManager.AppSettings["paginaRegistrosDefault"])
                };
            }
            return paginacionRequest;
        }

        public static Paginacion ConfiguracionPaginacionNotificacion(this Paginacion paginacionRequest)
        {
            if (paginacionRequest == null || paginacionRequest.Pagina == 0)
            {
                paginacionRequest = new Paginacion()
                {
                    Pagina = Convert.ToInt16(ConfigurationManager.AppSettings["paginaActualDefault"]),
                    Registros = Convert.ToInt16(ConfigurationManager.AppSettings["paginaRegistrosNotificacion"])
                };
            }
            else
            {
                paginacionRequest = new Paginacion()
                {
                    Pagina = paginacionRequest.Pagina,
                    Registros = Convert.ToInt16(ConfigurationManager.AppSettings["paginaRegistrosNotificacion"])
                };
            }
            return paginacionRequest;
        }

        public static Token ComprobarToken(Token token)
        {
            var controller = new TokenController();
            var request = new TokenRequest()
            {
                Item = token,
                TipoLlamado = EnumeradorToken.BuscarToken
            };        
            var response = controller.OperacionToken(request);
            if (!response.Item.TokenValido)
            {
                throw new TokenExpirado();
            }
            return response.Item;
        }
    }
    public class TokenExpirado : ApplicationException
    {
        public override string Message
        {
            get
            {
                return ConfigurationManager.AppSettings["tokenExpirado"];
            }
        }
    }
}