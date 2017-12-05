using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using MCS.ApplicationBlock.Logging;
using MCS.ApplicationBlock.Logging.Providers;
using MCS.Factory;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public class CuentaGastoController : IDisposable
    {
        private ICuentaGastoDominio cuentaGastoDominio;

        public CuentaGastoController()
        {
            cuentaGastoDominio = FactoryEngine<ICuentaGastoDominio>.GetInstance("ICuentaGastoDominioConfig");
        }

        /// <summary>
        /// Funcion que dependiendo del tipo de operación inserta, actualiza o regis
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CuentaGastoOperacionResponse ExecuteOperacionCuentaGasto(CuentaGastoOperacionRequest request)
        {
            var response = new CuentaGastoOperacionResponse()
            {
                EjecucionValida = false,
                MensajeError = String.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };
            try
            {
                switch (request.TipoDeOperacion)
                {
                    case TipoOperacion.Insertar:
                        //request.Item.ArchivoFisico = null;
                        response.Item = cuentaGastoDominio.InsertaFactura(request.Item);
                        break;
                    case TipoOperacion.Actualizar:
                        break;                  
                    //case TipoOperacion.EnviarDocumento:                        
                    //    response.Item = cuentaGastoDominio.GuardarDocumento(request.Item);
                    //    break;
                }
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

        /// <summary>
        /// Funcion que dependiendo del tipo de operación inserta, actualiza o regis
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CuentaGastoGetListResponse GetListCuentaGasto(CuentaGastoGetListRequest request)
        {
            var response = new CuentaGastoGetListResponse()
            {
                EjecucionValida = false,
                MensajeError = String.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };
            try
            {
                response.Item = cuentaGastoDominio.GetList(request.Item);
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
            cuentaGastoDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
