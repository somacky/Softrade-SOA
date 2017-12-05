﻿using System;
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
    public class GraficasController : IDisposable
    {
        public IGraficasDominio iGraficasDominio = null;

        public GraficasController()
        {
            iGraficasDominio = FactoryEngine<IGraficasDominio>.GetInstance("IGraficasDominioConfig");
        }

        public OperacionesGraficasResponse GetGraficasDominio(OperacionesGraficasRequest request)
        {
            var response = new OperacionesGraficasResponse()
            {
                EjecucionValida = false,
                MensajeError = ""
            };
            try
            {
                response.Item = iGraficasDominio.GetGraficas(request.Item);
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
            iGraficasDominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
