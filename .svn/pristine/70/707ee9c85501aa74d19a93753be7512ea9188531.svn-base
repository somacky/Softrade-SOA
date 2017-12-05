using System;
using System.Collections.Generic;
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
    public class UrlTemporalController : IDisposable
    {
        private IUrlTemporalDominio iUrlTemporalDominio = null;

        public UrlTemporalController()
        {
            iUrlTemporalDominio = FactoryEngine<IUrlTemporalDominio>.GetInstance("IUrlTemporalDominioConfig");
        }

        public UrlTemporalResponse OperacionUrlTemporal(UrlTemporalRequest request)
        {
            var response = new UrlTemporalResponse()
            {
                EjecucionValida = false,
                MensajeError = string.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };

            try
            {
                switch (request.OperacionUrl)
                {
                    case Modelo.Compartido.OperacionUrlTemporal.ComprobarUrl:
                        response.Item = iUrlTemporalDominio.ComprobarUrlTemporal(request.Item);
                        break;
                    case Modelo.Compartido.OperacionUrlTemporal.GenerarUrlTemporal:
                        response.Item = iUrlTemporalDominio.GenerarUrlTemporal(request.Item);
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

        public void Dispose()
        {
            iUrlTemporalDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
