using System;
using System.Collections.Generic;
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
    public class EstadoClimaRepositorio : IEstadoClimaRepositorio
    {
        private SqlHelper helper = null;

        public void InicializarConexion(TipoBaseDatos baseDatos)
        {
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        }    
        public EstadoClima InsertarEstadoClima(EstadoClima item)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdClima", SqlDbType.Int, item.IdClima));
            parametros.Add(new SqlParameterItem("@pTemperaturaMaxima", SqlDbType.Float, item.TemperaturaMaxima));
            parametros.Add(new SqlParameterItem("@pTemperaturaMinima", SqlDbType.Float, item.TemperaturaMinima));
            parametros.Add(new SqlParameterItem("@pVelocidadViento", SqlDbType.Float, item.VelocidadViento));
            parametros.Add(new SqlParameterItem("@pIdEntidadFederativaVW", SqlDbType.Float, item.IdEntidadFederativa));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializarConexion(TipoBaseDatos.MainSoft);
            helper.ExecuteNonQuery("[usp_EstadoClima_Inserta]", parametros);
            item.IdEstadoClima = Convert.ToInt16(helper.GetParameterOutput("@pID"));
            return item;
        }

        public EstadoClima GetEstadoClimaActual(EstadoClima item)
        {                       
            InicializarConexion(TipoBaseDatos.MainSoft);
            var reader = helper.ExecuteReader("[usp_EstadoClima_DameEstadoClima]");            
            //float x;
            while (reader.Read())
            {
                item.IdEstadoClima = reader.GetInt32(reader.GetOrdinal("IdEstadoClima"));
                item.Clima = reader.GetString(reader.GetOrdinal("Clima"));
                item.TemperaturaMinima = reader.GetDouble(reader.GetOrdinal("TemperaturaMinima"));
                item.TemperaturaMaxima = reader.GetDouble(reader.GetOrdinal("TemperaturaMaxima"));
                item.Fecha = reader.GetDateTime(reader.GetOrdinal("TimeStamp"));
            }
            
                //var x = reader.GetDateTime(reader.GetOrdinal("FechaCambio"));            
            reader.Close();
            return item;
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            if(helper != null)
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
