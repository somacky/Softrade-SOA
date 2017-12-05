using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using MCS.ApplicationBlock.Logging;
using MCS.ApplicationBlock.Logging.Providers;
using MCS.Factory;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    class DigitalizacionVUCEMController: IDisposable{
        private IDigitalizacionVUCEMDominio iDigitalizacionVUCEMDominio = null;

        public DigitalizacionVUCEMController()
        {
            iDigitalizacionVUCEMDominio = FactoryEngine<IDigitalizacionVUCEMDominio>.GetInstance("IDigitalizacionVUCEMDominioConfig");
        }

        public DigitalizacionVUCEMResponse GetDigitalizacionVUCEM(DigitalizacionVUCEMRequest request)
        {
            var response = new DigitalizacionVUCEMResponse()
            {
                EjecucionValida = false,
                MensajeError = "",
                Item = new DigitalizacionVUCEM()
            };
            try
            {
                response.Item = iDigitalizacionVUCEMDominio.GetDigitalizacionVUCEM(request.Item);
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
            iDigitalizacionVUCEMDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
