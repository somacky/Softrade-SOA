﻿using System;
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
    public class PedimentoController : IDisposable
    {
        private IPedimentoDominio pedimentoDominio;
        public PedimentoController()
        {
            pedimentoDominio = FactoryEngine<IPedimentoDominio>.GetInstance("IPedimentoDominioConfig");
        }


        /// <summary>
        /// Esta función espera recibir un request de pedimento para insertarlo y guardar el archivo m en el FTP
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PedimentoOperacionResponse ExecuteOperacionPedimento(PedimentoOperacionRequest request)
        {
            var response = new PedimentoOperacionResponse()
            {
                EjecucionValida = false,
                MensajeError = String.Empty,
                IdUsuarioEjecucion = request.IdUsuarioEjecucion
            };
            try
            {
                switch (request.Operacion)
                {
                        case TipoOperacion.Insertar:
                        response.Item = pedimentoDominio.InsertarPedimento(request.Item);
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
            pedimentoDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}