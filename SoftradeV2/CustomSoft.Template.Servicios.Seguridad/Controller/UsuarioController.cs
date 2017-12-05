using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using MCS.ApplicationBlock.Logging;
using MCS.ApplicationBlock.Logging.Providers;
using MCS.Factory;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public class UsuarioController :IDisposable
    {
        private IUsuarioDominio usuarioDominio;

        public UsuarioController()
        {
            try
            {
                usuarioDominio = FactoryEngine<IUsuarioDominio>.GetInstance("IUsuarioDominioConfig");
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public UsuarioOperacionResponse ExecuteOperacion(UsuarioOperacionRequest request)
        {
            //Inicializa el response
            UsuarioOperacionResponse response = new UsuarioOperacionResponse()
            {
                EjecucionValida = false,
                MensajeError = string.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };

            try
            {
                switch (request.Operacion)
                {

                    case TipoOperacion.Insertar:
                        {
                            response.Item = usuarioDominio.InsertaUsuario(request.Item);
                        }
                        break;
                   
                    
                    case TipoOperacion.Actualizar:
                    {
                        response.Item = usuarioDominio.Actualizar(request.Item);
                    }
                    break;
                }
                response.EjecucionValida = true;

            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                using (LoggingHelper helper = new LoggingHelper(TipoRepositorio.Xml))
                {
                    helper.Registrar(ex);
                    
                }
            }
            return response;

        }
        
        /// <summary>
        /// funcion de dispose agregar al final de todo el menu
        /// </summary>
         public void Dispose()
         {
            usuarioDominio.Dispose();
            GC.SuppressFinalize(this);
         }
    }

}