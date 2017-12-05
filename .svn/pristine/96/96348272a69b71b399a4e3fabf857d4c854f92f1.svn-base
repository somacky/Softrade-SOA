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
    public class DocumentoExpedienteDigitalController : IDisposable
    {
        private IDocumentoExpedienteDigitalDominio iCatalogoEspecificoDominio;

        public DocumentoExpedienteDigitalController()
        {
            iCatalogoEspecificoDominio = FactoryEngine<IDocumentoExpedienteDigitalDominio>.GetInstance("IDocumentoExpedienteDigitalDominioConfig");
        }

        /// <summary>
        /// Funcion que dependiendo del tipo de operación inserta, actualiza o regis
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DocumentoExpedienteDigitalResponse ExtraerDocumentoExpedienteDigital(DocumentoExpedienteDigitalRequest request)
        {
            var response = new DocumentoExpedienteDigitalResponse()
            {
                EjecucionValida = false,
                MensajeError = String.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };
            try
            {
                response.Item = iCatalogoEspecificoDominio.ExtraerDocumentoExpedienteDigital(request.Item);
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
            iCatalogoEspecificoDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
