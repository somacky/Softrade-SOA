using System.ServiceModel;
using CustomSoft.Template.Dominio.Excepciones.Archivo;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Dominio
{
    partial class PedimentoDominio
    {
        #region Privados

        private void ValidarPedimento(Pedimento pedimento)
        {
            //TODO:Agregar otras validaciones a funcion validar pedimento
            if (pedimento.ArchivoFisico.LongitudArchivo != pedimento.ArchivoFisico.ArchivoBytes.Length)
            {
                throw new ArchivoCorruptoException();
            }
        }

        private Archivo ConvertirArchivo(Pedimento archivo)
        {
            var request = new Archivo()
            {
                ArchivoBytes = archivo.ArchivoFisico.ArchivoBytes,
                TipoArchivoFiltro = TipoArchivo.ArchivoM,
                ExtensionArchivo = archivo.ArchivoFisico.ExtensionArchivo,
                FechaSubida = archivo.ArchivoFisico.FechaSubida,
                LongitudArchivo = archivo.ArchivoFisico.LongitudArchivo,
                NombreCompletoArchivo = archivo.ArchivoFisico.NombreCompletoArchivo,
                Patente = archivo.ArchivoFisico.Patente,
                ExtensionData = archivo.ArchivoFisico.ExtensionData,
                IdCliente = archivo.ArchivoFisico.IdCliente
            };
            return request;
        }

        public FTPSeguridadServiceClient ConsultarPedimentoCompletoWS()
        {
            //var basicHttpBinding = new WSHttpBinding(SecurityMode.Transport);
            var basicHttpBinding = new BasicHttpBinding()
            {
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            //basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            var endpoint =
                new EndpointAddress(
                    "http://192.168.2.160:8090/FTPService.svc");
            var servicioConsultarPedimento = new FTPSeguridadServiceClient(basicHttpBinding, endpoint);
            //if (servicioConsultarPedimento.ClientCredentials != null)
            //{
            //    servicioConsultarPedimento.ClientCredentials.UserName.UserName = "VECM6011173A2";
            //    servicioConsultarPedimento.ClientCredentials.UserName.Password = "rJ6/wsPzE4AWCNo9NhKEaQGUQkJl7RZQAJBeOAtqKajjR63zhEalSf/asMBZ1J4R";
            //}
            return servicioConsultarPedimento;
        }

        #endregion
    }
}
