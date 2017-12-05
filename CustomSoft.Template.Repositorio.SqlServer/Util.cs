﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades.Empresa;
using CustomSoft.Template.Modelo.Servicios.Request;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    /// <summary>
    /// clase que implementa el metodo general para la recuperar la cadena de conexion 
    /// </summary>
    public class Util : IDisposable
    {
        private SqlConnection cn;

        /// <summary>
        /// cadena de conexion?
        /// </summary>
        /// <returns></returns>
        public static string ConexionSqlServer(TipoBaseDatos BaseDatosSoftrade)
        {
            switch (BaseDatosSoftrade)
            {                
                case TipoBaseDatos.Softrade:
                    return ConfigurationManager.ConnectionStrings["cnSqlServerSoftTrade"].ConnectionString;
                case TipoBaseDatos.MainSoft:
                    return ConfigurationManager.ConnectionStrings["cnSqlServerMainSoft"].ConnectionString;
            }            
            return null;
        }
      

        public static string DameBDxIdEmpresa(int idEmpresa)
        {
          
                var x = new OperacionEmpresaRepositorio();
                var request = new EntidadEmpresa()
                {
                    DatosEmpresa = new Empresa()
                    {
                        IdEmpresaVw = idEmpresa
                    },
                    //OperacionEspecifica = OperacionEmpresaItem.DameBDXIdEmpresa
                };
                var response = x.DameBaseDatosEmpresaXId(request);
                x.Dispose();
                return response;
                    
        }


        public IEnumerable<UsuarioXEmpresa> DameIdEmpresaXUsuario(int idUsuario, SqlHelper Helper)
        {
            var items = new List<UsuarioXEmpresa>();
            var parametro = new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output);
            var reader = Helper.ExecuteReader("usp_UsuarioXEmpresa_DameListaXIdUsuario", parametro);
            while (reader.Read())
            {
                items.Add(new UsuarioXEmpresa()
                {
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresa")),
                    IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                    RazonSocial = reader.GetString(reader.GetOrdinal("RazonSocial"))

                });
            }
            reader.Close();
            return items;
        }

        public void Dispose()
        {
            if (cn != null)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }    
}