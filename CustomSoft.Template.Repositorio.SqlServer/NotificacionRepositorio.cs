﻿using System;
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
    public class NotificacionRepositorio : INotificacionRepositorio
    {
        private SqlHelper helper = null;
        private string baseDatos;
        //public NotificacionRepositorio()
        //{
        //    helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));
        //}

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

        #region Metodos Publicos
        public ListNotificaciones UltimasNotificaciones(ListNotificaciones notificacion)
        {
            switch (notificacion.TipoDeNotificacion)
            {
                case TipoNotificacion.Pedimento:
                    return NotificacionesDePedimento(notificacion);
                case TipoNotificacion.FacturaPropia:
                    return NotificacionesDeFacturaPropia(notificacion);
                case TipoNotificacion.FacturaTerceros:
                    return NotificacionesDeFacturaTerceros(notificacion);
            }
            return null;
        }

        public ListNotificaciones MarcarNotificacionesVistas(ListNotificaciones notificacion)
        {
            switch (notificacion.TipoDeNotificacion)
            {
                case TipoNotificacion.Pedimento:
                    return MarcarPedimentosVistos(notificacion);
                case TipoNotificacion.FacturaPropia:
                    return MarcarPropiosComoVistos(notificacion);
                case TipoNotificacion.FacturaTerceros:
                    return MarcarTercerosComoVistos(notificacion);
            }
            return null;
        }
        #endregion

        #region NotificacionDePEdimento
        private ListNotificaciones NotificacionesDePedimento(ListNotificaciones listNotificaciones)
        {
            var listaNotificaciones = new List<Notificacion>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.SmallInt, listNotificaciones.IdUsuario));
            parametros.Add(new SqlParameterItem("@pPagina", SqlDbType.SmallInt, listNotificaciones.ListaPaginacion.Pagina));
            parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.SmallInt, listNotificaciones.ListaPaginacion.Registros));
            parametros.Add(new SqlParameterItem("@pTotal", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));            
            var reader = helper.ExecuteReader("usp_Pedimento_DameListaXVisto", parametros);
            while (reader.Read())
            {
                listaNotificaciones.Add(new Notificacion()
                {
                    IdNotificacion = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    Identificador = reader.GetString(reader.GetOrdinal("Pedimento")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    Visto = reader.GetBoolean(reader.GetOrdinal("Visto"))
                });
            }            
            reader.Close();
            listNotificaciones.ListaPaginacion.TotalRegistros = Convert.ToInt16(helper.GetParameterOutput("@pTotal"));
            listNotificaciones.ListaDeNotificaciones = listaNotificaciones;            
            return listNotificaciones;
        }

        private int TotalesNoVistosPedimento(ListNotificaciones listNotificaciones)
        {
            var listaNotificaciones = new List<Notificacion>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, listNotificaciones.IdUsuario));
            parametros.Add(new SqlParameterItem("@pTotal", SqlDbType.Int, ParameterDirection.Output));
            InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));                       
            var reader = helper.ExecuteReader("usp_Pedimento_DameTotalXVisto", parametros);
            int totalRegistros = 0;
            while (reader.Read())
            {
                totalRegistros = reader.GetInt32((reader.GetOrdinal("Conteo")));
            }
            reader.Close();
            return totalRegistros;
        }

        #endregion

        #region Notificacion Cuenta Gasto Propias

        private ListNotificaciones NotificacionesDeFacturaPropia(ListNotificaciones listNotificaciones)
        {
            var listaNotificaciones = new List<Notificacion>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.SmallInt, listNotificaciones.IdUsuario));
            parametros.Add(new SqlParameterItem("@pPagina", SqlDbType.SmallInt, listNotificaciones.ListaPaginacion.Pagina));
            parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.SmallInt, listNotificaciones.ListaPaginacion.Registros));
            parametros.Add(new SqlParameterItem("@pTotal", SqlDbType.SmallInt, 0, ParameterDirection.Output));
            InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));            
            var reader = helper.ExecuteReader("usp_CuentaGasto_DameListaPropiasXVisto", parametros);
            while (reader.Read())
            {
                listaNotificaciones.Add(new Notificacion()
                {
                    IdNotificacion = reader.GetInt32(reader.GetOrdinal("IdCuentaGasto")),
                    Identificador = reader.GetString(reader.GetOrdinal("NumeroFactura")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    Visto = reader.GetBoolean(reader.GetOrdinal("Visto"))
                });
            }
            reader.Close();
            listNotificaciones.ListaPaginacion.TotalRegistros = Convert.ToInt16(helper.GetParameterOutput("@pTotal"));
            listNotificaciones.ListaDeNotificaciones = listaNotificaciones;
            return listNotificaciones;
        }

        private int TotalesNoVistosCuentaGasto(ListNotificaciones listNotificaciones)
        {
            var listaNotificaciones = new List<Notificacion>();
            var parametros = new SqlParameterItem("@pIdUsuario", SqlDbType.Int, listNotificaciones.IdUsuario);
            InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));                       
            var reader = helper.ExecuteReader("[usp_CuentaGasto_DameTotalPropiasXVisto]", parametros);
            int totalRegistros = 0;
            while (reader.Read())
            {
                totalRegistros = reader.GetInt32((reader.GetOrdinal("Total")));
            }
            reader.Close();
            return totalRegistros;
        }        
        #endregion

        #region Notificacion Cuenta Gasto Terceros

        private ListNotificaciones NotificacionesDeFacturaTerceros(ListNotificaciones listNotificaciones)
        {
            var listaNotificaciones = new List<Notificacion>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.SmallInt, listNotificaciones.IdUsuario));
            parametros.Add(new SqlParameterItem("@pPagina", SqlDbType.SmallInt, listNotificaciones.ListaPaginacion.Pagina));
            parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.SmallInt, listNotificaciones.ListaPaginacion.Registros));
            parametros.Add(new SqlParameterItem("@pTotal", SqlDbType.SmallInt, 0, ParameterDirection.Output));
            InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));            
            var reader = helper.ExecuteReader("usp_CuentaGasto_DameListaTercerosXVisto", parametros);
            while (reader.Read())
            {
                listaNotificaciones.Add(new Notificacion()
                {
                    IdNotificacion = reader.GetInt32(reader.GetOrdinal("IdCuentaGasto")),
                    Identificador = reader.GetString(reader.GetOrdinal("NumeroFactura")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    Visto = reader.GetBoolean(reader.GetOrdinal("Visto"))
                });
            }
            reader.Close();
            listNotificaciones.ListaPaginacion.TotalRegistros = Convert.ToInt16(helper.GetParameterOutput("@pTotal"));
            listNotificaciones.ListaDeNotificaciones = listaNotificaciones;
            return listNotificaciones;
        }

        private int TotalesNoVistosCuentaGastoTerceros(ListNotificaciones listNotificaciones)
        {
            var listaNotificaciones = new List<Notificacion>();
            var parametros = new SqlParameterItem("@pIdUsuario", SqlDbType.Int, listNotificaciones.IdUsuario);
            InicializaConexion(listNotificaciones.IdEmpresa);
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));                       
            var reader = helper.ExecuteReader("[usp_CuentaGasto_DameTotalTercerosXVisto]", parametros);
            int totalRegistros = 0;
            while (reader.Read())
            {
                totalRegistros = reader.GetInt32((reader.GetOrdinal("Total")));
            }
            reader.Close();
            return totalRegistros;
        }
        #endregion

        #region Marcar Notificacion Vista
        private ListNotificaciones MarcarPropiosComoVistos(ListNotificaciones listNotificaciones)
        {
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));                       
            InicializaConexion(listNotificaciones.IdEmpresa); 
            helper.ExecuteNonQuery("usp_CuentaGasto_MarcaPropiosVisto");            
            return listNotificaciones;
        }

        private ListNotificaciones MarcarTercerosComoVistos(ListNotificaciones listNotificaciones)
        {
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));                       
            InicializaConexion(listNotificaciones.IdEmpresa); 
            helper.ExecuteNonQuery("usp_CuentaGasto_MarcaTercerosVisto");
            return listNotificaciones;
        }

        private ListNotificaciones MarcarPedimentosVistos(ListNotificaciones listNotificaciones)
        {
            //parametros.Add(new SqlParameterItem("@Visto", SqlDbType.Bit, ParameterDirection.ReturnValue));                       
            InicializaConexion(listNotificaciones.IdEmpresa);
            helper.ExecuteNonQuery("usp_Pedimento_MarcarPedimentosVistos");
            return listNotificaciones;
        }

        #endregion
        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
