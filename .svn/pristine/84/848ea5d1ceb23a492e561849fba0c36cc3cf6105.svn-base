using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using MCS.ApplicationBlock.Logging;
using MCS.ApplicationBlock.Logging.Providers;
using MCS.Factory;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public class NotificacionController : IDisposable
    {
        private INotificacionDominio iNotificacionDominio = null;

        public NotificacionController()
        {
            iNotificacionDominio = FactoryEngine<INotificacionDominio>.GetInstance("INotificacionDominioConfig");
        }

        public NotificacionResponse OperacionNotificacion(NotificacionRequest request)
        {
            var response = new NotificacionResponse()
            {
                EjecucionValida = false,
                MensajeError = String.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };
            try
            {
                request.Item.IdUsuario = request.IdUsuarioEjecucion;
                request.Item.ListaPaginacion = request.Item.ListaPaginacion.ConfiguracionPaginacionNotificacion();
                response.Item = iNotificacionDominio.OperacionNotificacion(request.Item);
                response.Item.ListaPaginacion.PaginasTotales = (response.Item.ListaPaginacion.TotalRegistros /
                                                                        Convert.ToInt16(
                                                                            ConfigurationManager.AppSettings[
                                                                                "paginaRegistrosNotificacion"]) + 1);
                response.EjecucionValida = true;
                return response;
            }
            catch (Exception ex)
            {
                //TODO: Debe procurar dar un mejor tratamiento a los mensajes de error
                //que serán retornados a la aplicación cliente
                response.MensajeError = ex.Message;
                using (LoggingHelper helper = new LoggingHelper(TipoRepositorio.Xml))
                {
                    helper.Registrar(ex);
                }
            }
            return null;
        }

        public void Dispose()
        {
            iNotificacionDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
