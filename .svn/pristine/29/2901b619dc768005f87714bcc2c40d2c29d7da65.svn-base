using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer.GraficasRepositorio
{
    public class IngresosXTrimestre : IDisposable
    {
         private SqlHelper Helper = null;

         public IngresosXTrimestre()
        {
            Helper = new SqlHelper(ConfigurationManager.ConnectionStrings["cnSqlServerSac"].ConnectionString);
        }

        public Graficas GetGrafica(Graficas graficas)
        {
            graficas.ListEjeY = new List<EjeY>();
            ////var items = new List<CatalogoEspecifico>();            
            ////var items = new List<CatalogoEspecifico>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa ", SqlDbType.Int, graficas.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pIdCliente ", SqlDbType.Int, graficas.IdCliente));
            var reader = Helper.ExecuteReader("SACsp_SacWeb_CalculaDashboarIngresos", parametros);
            while (reader.Read())
            {
                var valores = new List<float>               
                {
                    (float)reader.GetDouble(reader.GetOrdinal("Primer")),
                    (float)reader.GetDouble(reader.GetOrdinal("Segundo")),
                    (float)reader.GetDouble(reader.GetOrdinal("Tercero")),
                    (float)reader.GetDouble(reader.GetOrdinal("Cuarto"))
                };
                graficas.ListEjeY.Add(new EjeY()
                {
                    Nombre = Convert.ToString(reader.GetInt32(reader.GetOrdinal("Ano"))),
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
