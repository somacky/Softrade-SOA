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
    public class SaldosPendientes : IDisposable
    {
          private SqlHelper Helper = null;

        public SaldosPendientes()
        {
            Helper = new SqlHelper(ConfigurationManager.ConnectionStrings["cnSqlServerSac"].ConnectionString);
        }

        public Graficas GetGrafica(Graficas graficas)
        {
            graficas.ListEjeY = new List<EjeY>();
            var parametro = new SqlParameterItem("@pIdEmpresa ", SqlDbType.Int, graficas.IdEmpresa);
            var reader = Helper.ExecuteReader("[SACsp_SacWeb_CalculaDashboardSaldos]", parametro);           
            while (reader.Read())
            {
                var valores = new List<float>               
                {
                    (float)reader.GetDouble(reader.GetOrdinal("SaldoPendiente")),
                };
                graficas.ListEjeY.Add(new EjeY()
                {
                    Nombre = reader.GetString(reader.GetOrdinal("NombreClienteFactura")),
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
