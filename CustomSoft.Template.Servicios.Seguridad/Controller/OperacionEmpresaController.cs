using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using MCS.ApplicationBlock.Logging;
using MCS.ApplicationBlock.Logging.Providers;
using MCS.Factory;

namespace CustomSoft.Template.Servicios.Seguridad.Controller
{
    public class OperacionEmpresaController : IDisposable
    {
        private IOperacionEmpresaDominio operacionEmpresaDominio;

        public OperacionEmpresaController()
        {
            operacionEmpresaDominio = FactoryEngine<IOperacionEmpresaDominio>.GetInstance("IOperacionEmpresaDominioConfig");
        }

        public OperacionEmpresaItemResponse ExecuteOperacionEmpresaItem(OperacionEmpresaItemRequest request)
        {
            var response = new OperacionEmpresaItemResponse()
            {
                EjecucionValida = false,
                Item = null,
                MensajeError = string.Empty
            };
            try
            {
                response.Item = operacionEmpresaDominio.OperacionEmpresaItem(request.Item);
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

        public OperacionEmpresaListaResponse ExecuteOperacionEmpresaLista(OperacionEmpresaListaRequest request)
        {
            var response = new OperacionEmpresaListaResponse()
            {
                EjecucionValida = false,
                Item = null,
                MensajeError = string.Empty
            };
            try
            {
                response.Item = operacionEmpresaDominio.OperacionListaEmpresa(request.Item);
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
            operacionEmpresaDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}