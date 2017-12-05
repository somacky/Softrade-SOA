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
    public class TasaCambioController : IDisposable
    {
        public ITasaCambioDominio iTasaCambioDominio = null;

        public TasaCambioController()
        {
            iTasaCambioDominio = FactoryEngine<ITasaCambioDominio>.GetInstance("ITasaCambioDominioConfig");
        }

        public TasaCambioResponse OperacionArticulo(TasaCambioRequest request)
        {
            var response = new TasaCambioResponse()
            {
                EjecucionValida = false,
                MensajeError = string.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };

            try
            {
                response.Item = iTasaCambioDominio.GetListTasaCambio(request.Item);
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
            iTasaCambioDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
