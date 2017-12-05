using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer.GraficasRepositorio
{
    public class GraficasRepositorio : IGraficasRepositorio
    {
         private SqlHelper helper = null;
        

        public void IniciarConexion()
        {
            //inicializar conexion con SAC
            helper = new SqlHelper(ConfigurationManager.ConnectionStrings["cnSqlServerSac"].ConnectionString);
        }
        public Graficas GenerarGrafica(Graficas graficas)
        {
            //en cada case se pide primero el eje x luego se llenan los datos del eje y
            graficas = CalcularBaseDashboard(graficas);
            switch (graficas.EnumeradoresGraficas)
            {
                case EnumeradoresGraficas.DiasDespachoXAduanaTrimestre:
                    graficas = GenerarEjeXMes(graficas);
                    var diasDespacho = new DiasDespachoXTrimestre();
                    graficas = diasDespacho.GetGrafica(graficas);
                    break;
                case EnumeradoresGraficas.OperacionesXAduanaVsRojo:
                    graficas = GenerarEjeXMes(graficas);
                    var operacionXAduana = new OperacionesXAduanaVsRojo();
                    graficas = operacionXAduana.GetGrafica(graficas);
                    break;
                case EnumeradoresGraficas.IngresoXTrimestreFacturado:
                    graficas = GenerarEjeXMes(graficas);
                    var ingresosTrimestre = new IngresosXTrimestre();
                    graficas = ingresosTrimestre.GetGrafica(graficas);
                    break;
                case EnumeradoresGraficas.IngresoXTrimestreCobrado:
                    break;
                case EnumeradoresGraficas.SaldosPendientes:
                    var saldosPendientes = new SaldosPendientes();
                    graficas = saldosPendientes.GetGrafica(graficas);
                    break;

            }
            return graficas;
        }

        public Graficas GenerarEjeXMes(Graficas graficas)
        {
            graficas.EjeX = new List<string>();
            IniciarConexion();
            var reader = helper.ExecuteReader("[SACsp_SacWeb_Dashboard_DamePeriodoMensual]");
            while (reader.Read())
            {
                graficas.EjeX.Add(reader.GetString(reader.GetOrdinal("Mes")));
            }
            return graficas;
        }

        public Graficas CalcularBaseDashboard(Graficas graficas)
        {
            //checar generacion de log
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.SmallInt, graficas.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pIdCliente", SqlDbType.SmallInt, graficas.IdCliente));
            parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.SmallInt, graficas.IdPatente));
            parametros.Add(new SqlParameterItem("@pIdTipoOperacion  ", SqlDbType.SmallInt, graficas.IdTipoOperacion));
            parametros.Add(new SqlParameterItem("@pDameAvisosConsolidados   ", SqlDbType.Bit, graficas.EsConsolidado));
            parametros.Add(new SqlParameterItem("@pIdAduana", SqlDbType.SmallInt, graficas.IdAduana));
            IniciarConexion();
            //InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));            
            var reader = helper.ExecuteNonQuery("SACsp_SacWeb_CalculaDashboardOp", parametros);
            return graficas;
        }
        public void Dispose()
        {            
            if(helper == null)
                helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
