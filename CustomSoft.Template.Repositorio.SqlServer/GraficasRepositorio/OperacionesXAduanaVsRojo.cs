using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer.GraficasRepositorio
{
    public class OperacionesXAduanaVsRojo: IDisposable
    {
         private SqlHelper Helper = null;

         public OperacionesXAduanaVsRojo()
        {
            Helper = new SqlHelper(ConfigurationManager.ConnectionStrings["cnSqlServerSac"].ConnectionString);
        }

        public Graficas GetGrafica(Graficas graficas)
        {
            graficas.ListEjeY = new List<EjeY>();
            ////var items = new List<CatalogoEspecifico>();            
            ////var items = new List<CatalogoEspecifico>();
            //var parametro = new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output);
            var reader = Helper.ExecuteReader("[SACsp_SacWeb_OperacionVsRojo]");
            while (reader.Read())
            {
                var valores = new List<float>               
                {
                    reader.GetInt32(reader.GetOrdinal("Primero")),
                    reader.GetInt32(reader.GetOrdinal("Segundo")),
                    reader.GetInt32(reader.GetOrdinal("Tercero")),
                    reader.GetInt32(reader.GetOrdinal("Cuarto"))
                };
                graficas.ListEjeY.Add(new EjeY()
                {
                    Agrupador = reader.GetString(reader.GetOrdinal("NombreAduana")),
                    Valores = new List<float>(valores),
                    Nombre = Convert.ToString(reader.GetInt32(reader.GetOrdinal("Orden")))
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
