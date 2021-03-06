﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades.Empresa;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class OperacionEmpresaRepositorio : IOperacionEmpresaRepositorio
    {
        private SqlHelper helper = null;

        public OperacionEmpresaRepositorio()
        {
            helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.MainSoft));
        }

        #region Metodos Privados

        /// <summary>
        /// Funcion que devuelve la BD de la Empresa consultada en el request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string DameBaseDatosEmpresaXIdBD(EntidadEmpresa request)
        {
            var empresa = string.Empty;
            //empresa.DatosEmpresa = new List<Empresa>();
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, request.DatosEmpresa.IdEmpresaVw));
            parametros.Add(new SqlParameterItem("@pBD", SqlDbType.VarChar, 50, "", ParameterDirection.Output));
            helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.MainSoft));
            helper.ExecuteNonQuery("usp_Empresa_DameBDXID", parametros);
            empresa = Convert.ToString(helper.GetParameterOutput("@pBD"));
            helper.CloseConnection();
            return empresa;
        }        

        /// <summary>
        /// Funcion que obtiene el listado de las empresas activas/inactivas segun sea el request DATOS INCOMPLETOS 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private ListaEmpresa DameListaEmpresaBD(ListaEmpresa request)
        {
            var empresa = new ListaEmpresa();
            empresa.DatosEmpresa = new List<Empresa>();
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pPagina", SqlDbType.SmallInt, 1));
            parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.SmallInt, 100));
            parametros.Add(new SqlParameterItem("@pTotalRegistros", SqlDbType.SmallInt, 0));
            parametros.Add(new SqlParameterItem("@pInactivo", SqlDbType.Bit, request.Inactivo));
            var reader = helper.ExecuteReader("usp_Empresa_DameLista", parametros);
            while (reader.Read())
            {
                empresa.DatosEmpresa.Add(new Empresa()
                {
                    IdEmpresaVw = reader.GetInt32(reader.GetOrdinal("IdEmpresa")),
                    NombreBD = reader.GetString(reader.GetOrdinal("NombreBaseDatos"))
                });

            }
            reader.Close();
            return empresa;
        }

        private ListaEmpresa DameListaIdEmpresaXIdPatente(ListaEmpresa request)
         {
            var empresa = new ListaEmpresa();
            empresa.DatosEmpresa = new List<Empresa>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.SmallInt, request.IdABuscar));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.SmallInt, ParameterDirection.Output));
            var reader = helper.ExecuteReader("[usp_EmpresaXPatente_DameListaXIdPatente]", parametros);
            while (reader.Read())
            {
                empresa.DatosEmpresa.Add(new Empresa()
                {
                    IdEmpresaVw = reader.GetInt32(reader.GetOrdinal("IdEmpresa"))                    
                });

            }
            reader.Close();
            return empresa;
        }

        private ListaEmpresa DameListaIdEmpresaXIdUsuario(ListaEmpresa request)
        {
            var empresa = new ListaEmpresa();
            empresa.DatosEmpresa = new List<Empresa>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.SmallInt, request.IdABuscar));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.SmallInt, ParameterDirection.Output));
            var reader = helper.ExecuteReader("[usp_UsuarioXEmpresa_DameListaXIdUsuario]", parametros);
            while (reader.Read())
            {
                empresa.DatosEmpresa.Add(new Empresa()
                {
                    IdEmpresaVw = reader.GetInt32(reader.GetOrdinal("IdEmpresa"))
                });

            }
            reader.Close();
            return empresa;
        }
        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Funcion que devuelve la BD de la Empresa consultada en el request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Empresa DameDatosEmpresaXId(Empresa request)
        {
            var empresa = new Empresa();
            //empresa.DatosEmpresa = new List<Empresa>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.SmallInt, request.IdEmpresaVw));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output));
            helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.MainSoft));
            var reader = helper.ExecuteReader("usp_Empresa_DameListaXIdEmpresa", parametros);
            //empresa.BaseDatos = Convert.ToString(helper.GetParameterOutput("@pBD"));
            while (reader.Read())
            {
                if(!reader.IsDBNull(0))
                empresa = new Empresa()
                {

                    IdEmpresaVw = reader.GetInt32(reader.GetOrdinal("IdEmpresa")),
                    IdClienteVw = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                    RazonSocial = reader.GetString(reader.GetOrdinal("RazonSocial")),
                    RFC = reader.GetString(reader.GetOrdinal("RFC")),
                    CURP = reader.GetString(reader.GetOrdinal("CURP")),
                    Calle = reader.GetString(reader.GetOrdinal("Calle")),
                    NoExterior = reader.GetString(reader.GetOrdinal("NoExterior")),
                    NoInterior = reader.GetString(reader.GetOrdinal("NoInterior")),
                    Colonia = reader.GetString(reader.GetOrdinal("Colonia")),
                    Localidad = reader.GetString(reader.GetOrdinal("Localidad")),
                    Municipio = reader.GetString(reader.GetOrdinal("Municipio")),
                    CodigoPostal = reader.GetString(reader.GetOrdinal("CodigoPostal")),
                    PathCertificado = reader.GetString(reader.GetOrdinal("PathCertificado")),
                    Nombrecertificado = reader.GetString(reader.GetOrdinal("NombreCertificado")),
                    PathKey = reader.GetString(reader.GetOrdinal("PathKey")),
                    NombreKey = reader.GetString(reader.GetOrdinal("NombreKey")),
                    InicioVigenciaCerDateTime = reader.GetDateTime(reader.GetOrdinal("InicioVigenciaCer")),
                    FinVigenciaCerDateTime = reader.GetDateTime(reader.GetOrdinal("FinVigenciaCer")),
                    Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    URL = reader.GetString(reader.GetOrdinal("URL")),
                    FechaInicioServicio = reader.GetDateTime(reader.GetOrdinal("FechaInicioServicio")),
                    FechaVencimientoPago = reader.GetDateTime(reader.GetOrdinal("FechaVencimientoPago")),
                    PasswordCertificado = reader.GetString(reader.GetOrdinal("PasswordCertificado")),
                    Suspendido = reader.GetBoolean(reader.GetOrdinal("Suspendido")),
                    PasswordDescarga = reader.GetString(reader.GetOrdinal("PasswordDescarga")),
                    Inactivo = reader.GetBoolean(reader.GetOrdinal("Inactivo")),
                    WebKeyVUCEM = reader.GetString(reader.GetOrdinal("WebKeyVUCEM")),
                    EsCertificada = reader.GetBoolean(reader.GetOrdinal("EsCertificada")),
                    NombreBD = reader.GetString(reader.GetOrdinal("NombreBaseDatos")),
                    Alias = reader.GetString(reader.GetOrdinal("Alias"))
                };
            }
            helper.CloseConnection();
            return empresa;
        }
        public string DameBaseDatosEmpresaXId(EntidadEmpresa request)
        {
            var res = DameBaseDatosEmpresaXIdBD(request);
            return res;
        }


        public ListaEmpresa DameListaEmpresaXIdPatente(ListaEmpresa request)
        {
            var listadoEmpresa = DameListaIdEmpresaXIdPatente(request);
            request.DatosEmpresa = new List<Empresa>();            
            foreach (var VARIABLE in listadoEmpresa.DatosEmpresa)
            {
                request.DatosEmpresa.Add(DameDatosEmpresaXId(VARIABLE));
            }
            return request;
        }


        public ListaEmpresa DameListaEmpresaXIdUsuario(ListaEmpresa request)
        {
            var listadoEmpresa = DameListaIdEmpresaXIdUsuario(request);
            request.DatosEmpresa = new List<Empresa>();
            foreach (var VARIABLE in listadoEmpresa.DatosEmpresa)
            {
                request.DatosEmpresa.Add(DameDatosEmpresaXId(VARIABLE));
            }
            return request;
        }

        public ListaEmpresa DameListaEmpresas(ListaEmpresa request)
        {
            var res = DameListaEmpresaBD(request);
            return res;
        }

        public EntidadEmpresa DameDatosPatenteXId(EntidadEmpresa request)
        {
            var empresa = new EntidadEmpresa();
            //empresa.DatosEmpresa = new List<Empresa>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.SmallInt, request.DatosPatente.IdPatente));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output));
            helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.MainSoft));
            var reader = helper.ExecuteReader("[usp_Patente_DameListaXIdPatente]", parametros);
            while (reader.Read())
            {
                empresa.DatosPatente = new Patente()
                {
                    IdPatente = reader.GetInt32(reader.GetOrdinal("IdPatente")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("NombreAgente")),
                    Inactivo = reader.GetBoolean(reader.GetOrdinal("Inactivo")),
                    CURP = reader.GetString(reader.GetOrdinal("CURP")),
                    RFC = reader.GetString(reader.GetOrdinal("RFC")),
                    ArchivoCer = reader.GetString(reader.GetOrdinal("ArchivoCer")),
                    ArchivoKey = reader.GetString(reader.GetOrdinal("ArchivoKey")),
                    PasswordKey = reader.GetString(reader.GetOrdinal("PasswordKey")),
                    InicioVigenciaCer = reader.GetDateTime(reader.GetOrdinal("InicioVigenciaCer")),
                    FinVigenciaCer = reader.GetDateTime(reader.GetOrdinal("FinVigenciaCer")),
                    WebKeyVUCEM = reader.GetString(reader.GetOrdinal("WebKeyVUCEM")),
                };
            }
            helper.CloseConnection();
            return empresa;
        }

        public EntidadEmpresa DameDatosPatenteXNoPatente(EntidadEmpresa request)
        {
            var empresa = new EntidadEmpresa();
            //empresa.DatosEmpresa = new List<Empresa>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pNumeroPatente", SqlDbType.VarChar, 4, request.DatosPatente.NumeroPatente));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output));
            helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.MainSoft));
            var reader = helper.ExecuteReader("[usp_Patente_DameListaPatenteXNoPatente]", parametros);
            while (reader.Read())
            {
                empresa.DatosPatente = new Patente()
                {
                    IdPatente = reader.GetInt32(reader.GetOrdinal("IdPatente")),
                    //NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("NombreAgente")),
                    Inactivo = reader.GetBoolean(reader.GetOrdinal("Inactivo")),
                    CURP = reader.GetString(reader.GetOrdinal("CURP")),
                    RFC = reader.GetString(reader.GetOrdinal("RFC")),
                    ArchivoCer = reader.GetString(reader.GetOrdinal("ArchivoCer")),
                    ArchivoKey = reader.GetString(reader.GetOrdinal("ArchivoKey")),
                    PasswordKey = reader.GetString(reader.GetOrdinal("PasswordKey")),
                    InicioVigenciaCer = reader.GetDateTime(reader.GetOrdinal("InicioVigenciaCer")),
                    FinVigenciaCer = reader.GetDateTime(reader.GetOrdinal("FinVigenciaCer")),
                    WebKeyVUCEM = reader.GetString(reader.GetOrdinal("WebKeyVUCEM")),
                };
            }
            helper.CloseConnection();
            return empresa;
        }

        #endregion

        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}
