using System;
using System.Collections.Generic;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio
{
    partial class PedimentoDominio : IPedimentoDominio
    {
        private IPedimentoRepositorio pedimentoRepositorio;
        public PedimentoDominio()
        {
            pedimentoRepositorio = FactoryEngine<IPedimentoRepositorio>.GetInstance("IPedimentoRepositorioConfig");
        }

        /// <summary>
        /// Rutina que inserta en base de datos primero los datos del archivo M
        /// posteriormente manda al FTP el archivo M, 
        /// al final también registra en el expediente digital el nombre del archivo y el path
        /// </summary>
        /// <param name="pedimento">Contiene datos y archivo M</param>
        /// <returns></returns>
        public Pedimento InsertarPedimento(Pedimento pedimento)
        {            
            ValidarPedimento(pedimento);
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                //    //primero inserto a la base de datos
                //pedimentoRepositorio.InsertarPedimento();
                //    //crear request de NAS para posterior envío archivo al servidor NAS
                var request = new RecibeArchivoRequest()
                {
                    EjecucionValida = false,                    
                    Item = ConvertirArchivo(pedimento),
                    MensajeError = "",
                    UsuarioEjecucion = ""
                };
                //    //hago llamado a NAS                     
                var ftp = ConsultarPedimentoCompletoWS();
                var response = ftp.OperacionArchivo(request);
                //    //Guardo en Base de datos tabla expediente
                //    pedimentoRepositorio.InsertarExpedienteDigital();
                //    //Guardo también la relación entre expediente y pedimento
                //    pedimentoRepositorio.InsertarAsociacionPedimentoExpediente();
                transaction.Complete();
                return null;
            }
        }        


        public IEnumerable<Pedimento> TraerPedimentos(Pedimento pedimento, ref Modelo.Compartido.Paginacion paginacion)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            pedimentoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
