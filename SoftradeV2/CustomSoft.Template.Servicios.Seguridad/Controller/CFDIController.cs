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
    public class CFDIController : IDisposable
    {
        private ICFDIDominio cfdiDominio;

        public CFDIController()
        {
            cfdiDominio = FactoryEngine<ICFDIDominio>.GetInstance("ICFDIDominioConfig");
        }

        /// <summary>
        /// Funcion que dependiendo del tipo de operación inserta, actualiza o regis
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CFDIOperacionResponse ExecuteOperacionCFDI(CFDIOperacionRequest request)
        {
            var response = new CFDIOperacionResponse()
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
                        response.Item = cfdiDominio.InsertaFactura(request.Item);
                        break;
                    case TipoOperacion.Actualizar:
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
            return null;
        }


        public void Dispose()
        {
            cfdiDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
