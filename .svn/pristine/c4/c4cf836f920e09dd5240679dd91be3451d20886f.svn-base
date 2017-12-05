using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.CatalogosService;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.Pedimento;
//using CustomSoft.Template.Dominio.VUCEMService;
using CustomSoft.Template.Dominio.Excepciones.Token;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.VUCEMService;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;
using ArchivoM = CustomSoft.Template.Modelo.Dominio.Entidades.ArchivoM;
using DatosReg801FinArchivo = CustomSoft.Template.Modelo.Dominio.Base.Pedimento.DatosReg801FinArchivo;

namespace CustomSoft.Template.Dominio.OperacionPedimento
{
    partial class OperacionPedimentoDominio : IOperacionPedimentoDominio
    {
        private IOperacionPedimentoRepositorio iOperacionPedimentoRepositorioRepositorio = null;        

        public OperacionPedimentoDominio()
        {
            iOperacionPedimentoRepositorioRepositorio =
                FactoryEngine<IOperacionPedimentoRepositorio>.GetInstance("IPedimentoRepositorioConfig");            
        }

        #region Metodos Privados

        private VucemOperacionPedimentoCompletoRequest NormalizaDatosRequestVucem()
        {
            VucemOperacionPedimentoCompletoRequest reques = new VucemOperacionPedimentoCompletoRequest()
            {
                Consulta = TipoConsultaPedimento.PedimentoCompleto,
                Entidad = new RequestVUCEM()
                {

                }
            };
            return reques;
        }


        #endregion

        public EntidadArchivoM RegistraPedimento(EntidadArchivoM pedimento, Token token)
        {
            //TODO:Implementar token de seguridad
            token = Util.ComprobarToken(token);            

            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.Serializable;
            transactionOptions.Timeout = new TimeSpan(3000000000);            
            //using (
            //    TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions)
            //    )
            {
                try
                {
                    pedimento.ArchivoM = PedimentoExisteDeArchivoM(pedimento.ArchivoM);
                    if (pedimento.ArchivoM.IdPedimento == 0)
                    {
                        iOperacionPedimentoRepositorioRepositorio.RegistraPedimentoBD(pedimento.ArchivoM);
                        GuardarEnFTPInsertaExpedienteDigital(pedimento.ArchivoFisico, pedimento.IdUsuario,
                            pedimento.ArchivoM.IdPedimento);
                        //transaction.Complete();
                        pedimento.ArchivoSubido = true;
                        iOperacionPedimentoRepositorioRepositorio.InactivaPedimentoVUCEM(pedimento.ArchivoM);
                    }
                    return pedimento;
                }
                catch (Exception e)
                {
                    throw new FallaInsercionPedimentoException();
                }
            }
        }

        public ListadoArchivoM GetListadoArchivoM(EntidadArchivoM item)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.Serializable;
            transactionOptions.Timeout = new TimeSpan(3000000000);
            //using (
            //    TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions)
            //    )
            {
                try
                {
                    var listado = new ListadoArchivoM();
                        listado.ListadoPedimento = iOperacionPedimentoRepositorioRepositorio.DameListaXPedimento(item.ArchivoM);
                    return listado;
                }
                catch (Exception e)
                {
                    throw new FallaInsercionPedimentoException();
                }
            }
            return null;
        }

        private ArchivoM PedimentoExiste(ArchivoM pedimento)
        {
            //pedimento.IdAduanaSeccionVW = iOperacionPedimentoRepositorioRepositorio.DameIdAduanaXClave(pedimento);
            pedimento.IdPatente = iOperacionPedimentoRepositorioRepositorio.DameIdPatenteXNumeroPatente(pedimento);
            return iOperacionPedimentoRepositorioRepositorio.DameIdPedimentoXPedimento(pedimento);
        }

        private ArchivoM PedimentoExisteDeArchivoM(ArchivoM pedimento)
        {
            pedimento.IdPatente = iOperacionPedimentoRepositorioRepositorio.DameIdPatenteXNumeroPatente(pedimento);
            return iOperacionPedimentoRepositorioRepositorio.DameIdPedimentoXPedimentoYOrigen(pedimento);
        }

        private void GuardarEnFTPInsertaExpedienteDigital(Archivo archivo, int idUsuario, int idPedimento)
        {
            try
            {
                var request = new RecibeArchivoRequest()
                {
                    Item = archivo,
                    UsuarioEjecucion = "",
                    Operacion = TipoOperacionArchivo.Insertar
                };
                //hago llamado a NAS  
                var ftp = Util.ServicioFTPSoftrade();
                var response = ftp.OperacionArchivo(request);
                //TODO: calcular idTipoDocumento a CatalogosService
                var catalogos = Util.ServicioCatalogos();
                var responseCatalogos =
                    catalogos.ExtraerCatalogoItem(RequestTipoDocumentoXAbreviatura("num", idUsuario));
                archivo = response.Item;
                archivo.IdTipoDocumento = responseCatalogos.Item.Id;
                //Aquí se hace la inserción a la tabla expediente digital
                archivo = iOperacionPedimentoRepositorioRepositorio.InsertaExpedienteDigital(archivo, 0, idUsuario);
                iOperacionPedimentoRepositorioRepositorio.InsertaGrupoArchivos(idPedimento, archivo.IdArchivo);
                response.Item.IdArchivo = archivo.IdArchivo;
            }
            catch (Exception ex)
            {

                throw new ErrorArchivoFisico();
            }
        }

        /// <summary>
        /// Funcion que insertar partida a BD para la EntidadArchivoM SIN TERMINAR
        /// </summary>
        /// <param name="partida"></param>
        /// <returns></returns>
        public EntidadArchivoM RegistraPartida(EntidadArchivoM partida)
        {
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            //{
            try
            {
                partida.ArchivoM.IdPartida = PartidaExiste(partida.ArchivoM.Partidas[0].NumeroPartida,
                    partida.ArchivoM.IdPedimento, partida.ArchivoM.IdEmpresa);
                if (partida.ArchivoM.IdPartida == 0)
                {
                    //iOperacionPedimentoRepositorioRepositorio.RegistraPartidaBD(partida.ArchivoM);
                }
                //transaction.Complete();
                return partida;
            }
            catch (Exception)
            {
                throw new FallaInsercionPartidaException();
            }
            //}
        }

        public void ConsultaPedimentoCompletoVucem(EntidadArchivoM request)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {

                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        /// <summary>
        /// Funcion que inserta partida de motor
        /// </summary>
        /// <param name="partida"></param>
        /// <param name="pPartida"></param>
        /// <param name="pIdPedimento"></param>
        /// <param name="pIdEmpresa"></param>
        /// <returns></returns>
        //public ArchivoM RegistraPartidaVUCEM(ArchivoM partida)
        public int RegistraPartidaVucem(List<DatosReg551Partidas> pPartida, int pIdPedimento, int pIdEmpresa)
        {
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            //{
            try
            {
                //partida.IdPartida = PartidaExiste(partida.Partidas[0].NumeroPartida, partida.IdPedimento, partida.IdEmpresa);
                //if (partida.IdPartida == 0)
                //{
                return iOperacionPedimentoRepositorioRepositorio.RegistraPartidaBD(pPartida[0], pIdPedimento, pIdEmpresa);
                //}
                //transaction.Complete();
                //return partida;
            }
            catch (Exception)
            {
                throw new FallaInsercionPartidaException();
            }
            //}
        }

        public int PartidaExiste(int pNoPartida, int pIdPedimento, int pIdEmpresa)
        {
            //ya no se ocupa puesto que ya se calcula al pedir los catalogos
            //pedimento.IdAduanaSeccionVW = iOperacionPedimentoRepositorioRepositorio.DameIdAduanaXClave(pedimento);
            //se comenta para pruebas
            //pedimento.IdPatente = iOperacionPedimentoRepositorioRepositorio.DameIdPatenteXNumeroPatente(pedimento);
            return iOperacionPedimentoRepositorioRepositorio.DameIdPartidaXIdPedimentoYNoSecuencia(pNoPartida,
                pIdPedimento, pIdEmpresa);
        }

        public void Dispose()
        {
            iOperacionPedimentoRepositorioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Inserta Pedimento de Origen VUCEM
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EntidadArchivoM RegistraPedimentoVucem(EntidadArchivoM pedimento)
        {
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            //{
            try
            {
                pedimento.ArchivoM = PedimentoExiste(pedimento.ArchivoM);
                if (pedimento.ArchivoM.IdPedimento == 0)
                {
                    ////INICIALIZO VARIABLES QUE NO SE OCUPARON PARA EVITAR ERRORES EN INSERCION
                    pedimento.ArchivoM.FinArchivo = new DatosReg801FinArchivo();
                    pedimento.ArchivoM.EsPedimentoVUCEM = true;
                    iOperacionPedimentoRepositorioRepositorio.RegistraPedimentoBD(pedimento.ArchivoM);
                    //GuardarEnFTPInsertaExpedienteDigital(pedimento.ArchivoFisico, pedimento.IdUsuario, pedimento.ArchivoM.IdPedimento, pedimento.IdEmpresa);
                    pedimento.ArchivoSubido = false;
                    //transaction.Complete();
                }
                return pedimento;
            }
            catch (Exception e)
            {
                throw new FallaInsercionPedimentoVucem();
            }
            //}

        }


   
    }
}
