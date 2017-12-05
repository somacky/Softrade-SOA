using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class UrlTemporalRepositorio : IUrlTemporalRepositorio
    {
        private SqlHelper helper = new SqlHelper("");
        private string baseDatos;
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

        public UrlTemporal EsUrlValida(UrlTemporal url)
        {            
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pUrl", SqlDbType.VarChar, 13, url.GuidUrl));
            parametros.Add(new SqlParameterItem("@pErrores", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializaConexion(url.IdEmpresa);            
            var reader = helper.ExecuteReader("usp_Url_DameListaXUrl", parametros);

            while (reader.Read())
            {
                url.IdUrl = reader.GetInt32(reader.GetOrdinal("IdUrl"));
                url.FechaExpiracion = reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                url.GuidUrl = reader.GetString(reader.GetOrdinal("Url"));
                url.NumeroIntentos = reader.GetInt32(reader.GetOrdinal("NumeroEjecucion"));
            };            
            return url;
            //StoredProdcedure que verifica que url.GuidUrl exista y regresa los datos de esa url
            //con fechaExpiración y numero de intentos
        }


        public UrlTemporal InsertarUrlTemporal(UrlTemporal url)
        {

            var parametros = new List<SqlParameterItem>();
            switch (url.TipoUrlTemporal)
            {
                case TipoUrlTemporal.CambioPassword:
                    parametros.Add(new SqlParameterItem("@pIdTipoUrl", SqlDbType.Int, 1));
                    break;
                case TipoUrlTemporal.ExpedienteDigital:
                    parametros.Add(new SqlParameterItem("@pIdTipoUrl", SqlDbType.Int, 2));
                    break;
            }
            parametros.Add(new SqlParameterItem("@pUrl", SqlDbType.VarChar, 200, url.GuidUrl));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializaConexion(url.IdEmpresa);
            helper.ExecuteNonQuery("[usp_Url_Inserta]", parametros, false);
            url.IdUrl = Convert.ToInt16(helper.GetParameterOutput("@pID"));
            return url;
        }

        public UrlTemporal InactivarUrl(UrlTemporal url)
        {
            var parametros = new SqlParameterItem("@pIdUrl", SqlDbType.VarChar, 200, url.IdUrl);
            //parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, 0, ParameterDirection.Output));
            InicializaConexion(url.IdEmpresa);
            helper.ExecuteNonQuery("[usp_Url_InactivarUrl]", parametros, false);
            //url.IdUrl = Convert.ToInt16(helper.GetParameterOutput("@pID"));
            return url;
        }


        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
