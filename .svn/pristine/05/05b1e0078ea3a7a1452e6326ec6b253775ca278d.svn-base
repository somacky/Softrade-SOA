using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class ArchivoMRepositorio : IArchivoMRepositorio
    {
        private SqlHelper helper = null;

        public void InicializarConexion(TipoBaseDatos baseDatos)
        {
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        }    

        /// <summary>
        /// Inserta Registro 500, 501, 800 y 801 devolviendo el IdPedimento correspondiente
        /// </summary>
        /// <param name="pedimento"></param>
        /// <param name="IdUsuarioEjecucion"></param>
        /// <param name="NombreArchivo"></param>
        /// <param name="numerooperacion"></param>
        /// <returns></returns>
        public ArchivoM InsertaPedimento(ArchivoM pedimento)
        {
           
                //hasta aqui me quede
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdTipoMovimientoVW", SqlDbType.Int, pedimento.IdTipoMovimiento));
                parametros.Add(new SqlParameterItem("@pPedimento", SqlDbType.VarChar, 10, pedimento.NumeroPedimento));
                parametros.Add(new SqlParameterItem("@pIdAduanaSeccionVW", SqlDbType.Int, pedimento));
                parametros.Add(new SqlParameterItem("@pIdTipoOperacionVW", SqlDbType.Int, pedimento.IdTipoOperacion));
                parametros.Add(new SqlParameterItem("@pIdClavePedimentoVW", SqlDbType.Int, pedimento.IdTipoPedimento));
                parametros.Add(new SqlParameterItem("@pIdAduanaSeccionESVW", SqlDbType.Int, pedimento.IdCLaveAduanaSeccionEntradaSalida));
                parametros.Add(new SqlParameterItem("@pIdTransporteSalidaVW", SqlDbType.Int, pedimento.IdClaveMedioTrasporteSalidaAduana));
                parametros.Add(new SqlParameterItem("@pIdTransporteArriboVW", SqlDbType.Int, pedimento.IdClaveMedioTrasporteArriboAduana));
                parametros.Add(new SqlParameterItem("@pIdTransporteNacionalVW", SqlDbType.Int, pedimento.IdCLaveAduanaSeccionEntradaSalida));//duda
                parametros.Add(new SqlParameterItem("@pTipoCambio", SqlDbType.Float, pedimento.TipoCambio));
                parametros.Add(new SqlParameterItem("@pPesoBruto", SqlDbType.Float, pedimento.PesoBruto));
                parametros.Add(new SqlParameterItem("@pValorAduana", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pValorUSD", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pValorMXP", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pFletes", SqlDbType.Float, pedimento.ImporteFletes));
                parametros.Add(new SqlParameterItem("@pSeguros", SqlDbType.Float, pedimento.ImporteSeguros));
                parametros.Add(new SqlParameterItem("@pEmbalajes", SqlDbType.Float, pedimento.ImporteEmbalajes));
                parametros.Add(new SqlParameterItem("@pOtros", SqlDbType.Float, pedimento.ImporteOtrosIncrementables));
                parametros.Add(new SqlParameterItem("@pClavePrevalidador", SqlDbType.VarChar, 5, pedimento.FinArchivo.ClavePrevalidador));
                parametros.Add(new SqlParameterItem("@pIdPatenteVW", SqlDbType.Int, pedimento.IdPatente));
                parametros.Add(new SqlParameterItem("@pIdEmpresaVW", SqlDbType.Int, pedimento.IdEmpresa));
                parametros.Add(new SqlParameterItem("@pAcuseValidacion", SqlDbType.VarChar, 8, pedimento.Acusevalidacion));
                parametros.Add(new SqlParameterItem("@pIdDestinoVW", SqlDbType.Int, pedimento.IdClaveDestinoMercancia));
                parametros.Add(new SqlParameterItem("@pIdTipoFiguraVW", SqlDbType.Int, pedimento.TipoFigura));
                parametros.Add(new SqlParameterItem("@pFirmaElectronica", SqlDbType.VarChar, 2500, pedimento.FirmaElectronicaAvanzada));
                parametros.Add(new SqlParameterItem("@pNoSerieCertificadoFEA", SqlDbType.VarChar, 3, pedimento.NumeroSerieCertificadoFEA));
                parametros.Add(new SqlParameterItem("@pNombreArchivo", SqlDbType.VarChar, 12, pedimento.NombreArchivo));
                parametros.Add(new SqlParameterItem("@pNoPedimentos", SqlDbType.Int, pedimento.FinArchivo.CantidadPedimentos));
                parametros.Add(new SqlParameterItem("@pCantidadRegistros", SqlDbType.Int, pedimento.FinArchivo.CantidadRegistros));
                parametros.Add(new SqlParameterItem("@pConfimardo", SqlDbType.Bit, false));
                parametros.Add(new SqlParameterItem("@pIdUsuarioCreacion", SqlDbType.Int, pedimento.IdUsuarioEjecucion));
                parametros.Add(new SqlParameterItem("@pNumeroOperacionVUCEM", SqlDbType.Float, pedimento.NoOperacion));//duda solo de vucem
                parametros.Add(new SqlParameterItem("@pInactivo", SqlDbType.Bit, false));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                InicializarConexion(TipoBaseDatos.Softrade);
                helper.ExecuteNonQuery("usp_Pedimento_Inserta", parametros);
                pedimento.IdPedimento = Convert.ToInt16(helper.GetParameterOutput("@pID"));
                return pedimento;            
        }

        public Archivo InsertaExpedienteDigital(Archivo archivo, int idUsuario)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresaVW", SqlDbType.Int, archivo.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pIdCuentaGasto", SqlDbType.Int, 0));
            parametros.Add(new SqlParameterItem("@pNombreOrigen", SqlDbType.VarChar, 100, archivo.NombreArchivo));
            parametros.Add(new SqlParameterItem("@pNombreDestino", SqlDbType.VarChar, 100, archivo.NuevoNombreArchivo));
            parametros.Add(new SqlParameterItem("@pPath", SqlDbType.VarChar, 300, archivo.PathDestino));
            parametros.Add(new SqlParameterItem("@pIdTipoDocumentoVW", SqlDbType.Int, archivo.IdTipoDocumento));
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, idUsuario));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializarConexion(TipoBaseDatos.Softrade);
            helper.ExecuteNonQuery("usp_ExpedienteDigital_Inserta", parametros);
            archivo.IdArchivo = Convert.ToInt16(helper.GetParameterOutput("@pID"));
            return archivo;
        }

        public bool InsertaGrupoArchivo(int idPedimento,Archivo archivo)
        {
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, idPedimento));
            parametros.Add(new SqlParameterItem("@pIdExpedienteDigital", SqlDbType.Int, archivo.IdArchivo));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output));
            InicializarConexion(TipoBaseDatos.Softrade);
            helper.ExecuteNonQuery("usp_ExpedienteDigital_Inserta", parametros);
            return Convert.ToBoolean(helper.GetParameterOutput("@pResultado"));
        }

        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
