using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class DigitalizacionVUCEMRepositorio : IDigitalizacionVUCEMRepositorio
    {
        private SqlHelper helper = null;
        private string baseDatos = string.Empty;

        public SqlHelper InicializaConexion(int pIdEmpresa)
        {
            baseDatos = Util.DameBDxIdEmpresa(pIdEmpresa);
            //pBaseDatos = "BASFPrueba";
            //return new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));

            //Leo la conexion que se tiene en el WEbconfig
            var conexion = ConfigurationManager.ConnectionStrings["cnSqlServerEmpresas"].ConnectionString;

            //sustituyo el parametro por la base de datos a pegarle
            var conexionparametrizada = string.Format(conexion, baseDatos);
            helper = new SqlHelper(conexionparametrizada);
            return helper;
        }

        public bool InsertaGrupoArchivo(int idPedimento, int idExpedienteDigital, int idEmpresa)
        {
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, idPedimento));
            parametros.Add(new SqlParameterItem("@pIdExpedienteDigital", SqlDbType.Int, idExpedienteDigital));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, 0, ParameterDirection.Output));
            helper = InicializaConexion(idEmpresa);
            helper.ExecuteNonQuery("[usp_GrupoArchivo_Inserta]", parametros);
            return Convert.ToBoolean(helper.GetParameterOutput("@pResultado"));
        }

        #region CambiosEdocument
        public bool CierraEdocument(int pIdEmpresa, int pIdBitacoraEdocumentVUCEM, int pIdPedimento)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdBitacoraEdocumentVUCEM", SqlDbType.SmallInt, pIdBitacoraEdocumentVUCEM));
            parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Bit, pIdPedimento));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, false, ParameterDirection.Output));
            var vHelper = InicializaConexion(pIdEmpresa);
            var res = vHelper.ExecuteNonQuery("spCierraEdocumentBitacora", parametros);
            return res;
        }
        #endregion

        public void Dispose()
        {
            if (helper != null) helper.Dispose();
            GC.SuppressFinalize(this);
        }

        public DigitalizacionVUCEM GetDocumentFromVUCEM(DigitalizacionVUCEM digitalizacion)
        {
            throw new NotImplementedException();
        }
    }
}
