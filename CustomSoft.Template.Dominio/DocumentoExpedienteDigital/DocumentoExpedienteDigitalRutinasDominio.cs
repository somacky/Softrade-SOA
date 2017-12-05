using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Dominio.DocumentoExpedienteDigital
{
    partial class DocumentoExpedienteDigitalDominio
    {
        public FTPSeguridadServiceClient ServicioFTPSoftrade()
        {
            var ftpService = System.Configuration.ConfigurationSettings.AppSettings.Get("FTPService");
            var basicHttpBinding = new BasicHttpBinding()
            {
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            var endpoint =
                new EndpointAddress(
                   ftpService);
            var servicioConsultarPedimento = new FTPSeguridadServiceClient(basicHttpBinding, endpoint);
            return servicioConsultarPedimento;
        }
    }
}
