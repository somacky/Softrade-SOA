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
    public class OperacionPedimentoController : IDisposable
    {
        private IOperacionPedimentoDominio operacionPedimentoDominioDominio;

        public OperacionPedimentoController()
        {
            operacionPedimentoDominioDominio = FactoryEngine<IOperacionPedimentoDominio>.GetInstance("IPedimentoDominioConfig");
        }

        public OperacionPedimentoResponse ExecuteOperacion(OperacionPedimentoRequest request)
        {
            var response = new OperacionPedimentoResponse()
            {
                EjecucionValida = false,
                MensajeError = "",
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };
            try
            {
                switch (request.OperacionPedimento)
                {
                    //case EnumeradoresPedimento.OperacionPedimento.InsertaPedimentoBD:
                    //    {
                    //        response.Item = operacionPedimentoDominioDominio.RegistraPedimento(request.Item);
                    //    }
                    //    break;

                    //case EnumeradoresPedimento.OperacionPedimento.ConsultaPedimentoCompletoVUCEM:
                    //    {
                    //        operacionPedimentoDominioDominio.ConsultaPedimentoCompletoVucem(request.Item);
                    //    }
                    //    break;
                    case EnumeradoresPedimento.OperacionPedimento.InsertaPedimentoBD:
                        {
                            response.Item = operacionPedimentoDominioDominio.RegistraPedimento(request.Item,request.Token);
                        }
                        break;
                    //Funcion que inserta el Pedimento de origen VUCEM
                    case EnumeradoresPedimento.OperacionPedimento.InsertaPedimentoVUCEM:
                        {
                            response.Item = operacionPedimentoDominioDominio.RegistraPedimentoVucem(request.Item);
                        }
                        break;
                    case EnumeradoresPedimento.OperacionPedimento.InsertaPartidaBD:
                        {
                            operacionPedimentoDominioDominio.RegistraPartida(request.Item);
                        }
                        break;

                }
                response.EjecucionValida = true;
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
            return response;
        }


        public OperacionListaPedimentoResponse ExecuteOperacionListadoPedimentos(OperacionPedimentoRequest request)
        {
            var response = new OperacionListaPedimentoResponse()
            {
                EjecucionValida = false,
                MensajeError = "",
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };
            try
            {
                response.Item = operacionPedimentoDominioDominio.GetListadoArchivoM(request.Item);
                response.EjecucionValida = true;
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
            return response;
        }

        public void Dispose()
        {
            operacionPedimentoDominioDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
