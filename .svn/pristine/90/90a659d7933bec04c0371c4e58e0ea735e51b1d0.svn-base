using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class DocumentoExpedienteDigitalRepositorio : IDocumentoExpedienteDigitalRepositorio
    {
        private SqlHelper helper = null;

        //public void InicializarConexion(TipoBaseDatos baseDatos)
        //{
        //    helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        //}

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
        public Archivo DameItemXIdExpedienteDigital(int idExpedienteDigital, int idEmpresa)
        {
            var item = new Archivo();
            var parametros = new SqlParameterItem("@pIdExpedienteDigital", SqlDbType.Int, idExpedienteDigital);            
            InicializaConexion(idEmpresa);            
            var reader = helper.ExecuteReader("usp_ExpedienteDigital_DameListaXId", parametros);
            while (reader.Read())
            {
                item = new Archivo()
                {
                    IdArchivo = reader.GetInt32(reader.GetOrdinal("IdExpedienteDigital")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    NombreArchivo = reader.GetString(reader.GetOrdinal("NombreOrigen")),
                    NuevoNombreArchivo = reader.GetString(reader.GetOrdinal("NombreDestino")),
                    PathDestino = reader.GetString(reader.GetOrdinal("Path"))                                     
                };
                item.PathDestino = item.PathDestino.Replace("\\", "/");
            }
            return item;
        }

        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
