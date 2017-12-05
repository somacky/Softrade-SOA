using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio.DocumentoExpedienteDigital
{
    partial class DocumentoExpedienteDigitalDominio : IDocumentoExpedienteDigitalDominio
    {
        private IDocumentoExpedienteDigitalRepositorio iDocumentoExpedienteDigitalRepositorio;
        public DocumentoExpedienteDigitalDominio()
        {
            iDocumentoExpedienteDigitalRepositorio = FactoryEngine<IDocumentoExpedienteDigitalRepositorio>.GetInstance("IDocumentoExpedienteDigitalRepositorioConfig");     
        }
        public Modelo.Dominio.Entidades.DocumentoExpedienteDigital ExtraerDocumentoExpedienteDigital(Modelo.Dominio.Entidades.DocumentoExpedienteDigital documento)
        {
            var archivo = iDocumentoExpedienteDigitalRepositorio.DameItemXIdExpedienteDigital(documento.IdExpedienteDigital, documento.IdEmpresa);

            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                //Generamos el request del archivo que vamos a recibir para regresarlo al usuario
                var request = new RecibeArchivoRequest()
                {                    
                    Item = archivo,                    
                    UsuarioEjecucion = "",
                    Operacion = TipoOperacionArchivo.Extraer
                };
                //hago llamado a NAS  
                var ftp = Util.ServicioFTPSoftrade();
                var response = ftp.OperacionArchivo(request);
                //TODO: calcular idTipoDocumento a CatalogosService
                documento.ArchivoFisico = response.Item;
                transaction.Complete();
            }
            return documento;
        }

        public void Dispose()
        {
            iDocumentoExpedienteDigitalRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
