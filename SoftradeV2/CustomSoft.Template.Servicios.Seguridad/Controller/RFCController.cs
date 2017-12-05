using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using MCS.ApplicationBlock.Logging;
using MCS.ApplicationBlock.Logging.Providers;
using MCS.Factory;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public class RFCController : IDisposable
    {
        private IRFCDominio extraeRFCDominio;

        public RFCController()
        {
            extraeRFCDominio = FactoryEngine<IRFCDominio>.GetInstance("IRFCDominioConfig");
        }

        public RFCResponse ExtraeRFC(RFCRequest request)
        {
            var response = new RFCResponse()
            {
                EjecucionValida = false,
                MensajeError = string.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion               
            };
            try
            {
                response.Item = extraeRFCDominio.ExtraeRFC(request.Item);
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
                return null;
            }            
        }

        public void Dispose()
        {
            extraeRFCDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
