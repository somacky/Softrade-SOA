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
using MCS.Factory.Configuration;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public class OperacionesEdocumentCOVEController : IDisposable
    {
        private IOperacionesEdocumentCOVEDominio iOperacionesEdocumentCOVEDominio = null;

        public OperacionesEdocumentCOVEController()
        {
            iOperacionesEdocumentCOVEDominio = FactoryEngine<IOperacionesEdocumentCOVEDominio>.GetInstance("IOperacionesEdocumentCOVEDominioConfig");
        }

        public DatosCOVEResponse GetCOVE(DatosCOVERequest request)
        {
            var response = new DatosCOVEResponse()
            {
                EjecucionValida = false,
                MensajeError = ""
            };
            try
            {
                response.Item = iOperacionesEdocumentCOVEDominio.GetDataCOVE(request.Item);
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
            iOperacionesEdocumentCOVEDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
