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
    public class EstadoClimaController : IDisposable
    {
        public IEstadoClimaDominio iClimaDominio = null;

        public EstadoClimaController()
        {
            iClimaDominio = FactoryEngine<IEstadoClimaDominio>.GetInstance("IEstadoClimaDominioConfig");
        }

        public EstadoClimaResponse GetEstadoClima(EstadoClimaRequest request)
        {
            var response = new EstadoClimaResponse()
            {
                EjecucionValida = false,
                MensajeError = string.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };

            try
            {
                response.Item = iClimaDominio.GetEstadoClima(request.Item);
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
            //iTasaCambioDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
