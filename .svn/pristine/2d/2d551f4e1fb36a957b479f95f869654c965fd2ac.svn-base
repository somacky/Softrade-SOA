using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer.GraficasRepositorio
{
    public class ClientesBaja : IDisposable
    {

        private SqlHelper Helper = null;

        public ClientesBaja()
        {
            Helper = new SqlHelper(ConfigurationManager.ConnectionStrings["cnSqlServerSac"].ConnectionString);
        }

        public Graficas GetGrafica(Graficas graficas)
        {
            graficas.ListEjeY = new List<EjeY>();
            ////var items = new List<CatalogoEspecifico>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.SmallInt, graficas.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pIdCliente", SqlDbType.SmallInt, graficas.IdCliente));
            parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.SmallInt, graficas.IdPatente));
            parametros.Add(new SqlParameterItem("@pIdAduana", SqlDbType.SmallInt, graficas.IdAduana));            
            //InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));            
            var reader = Helper.ExecuteReader("SACsp_SacWeb_CalculaDashboardClientesBaja", parametros);                  
            while (reader.Read())
            {
                var valores = new List<float>
                {
                    reader.GetInt32(reader.GetOrdinal("TotalAnterior")),
                    reader.GetInt32(reader.GetOrdinal("TotalActual")),
                    reader.GetInt32(reader.GetOrdinal("VariacionMismos")),
                    reader.GetInt32(reader.GetOrdinal("PorcVariacionMismos")),
                    reader.GetInt32(reader.GetOrdinal("TotalNuevos")),
                    reader.GetInt32(reader.GetOrdinal("PorcNuevo")),
                    reader.GetInt32(reader.GetOrdinal("TotalPerdidos")),
                    reader.GetInt32(reader.GetOrdinal("PorcPerdido"))
                };
                graficas.ListEjeY.Add(new EjeY()
                {
                    Nombre = "Bajas",
                    Valores = new List<float>(valores)
                });
            }
            reader.Close();
            return graficas;
        }
     
        public void Dispose()
        {
            Helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
