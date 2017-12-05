﻿using System;
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
    /// <summary>
    /// implementacion de las operacion CRUD (Create, Read, update, delete)
    /// </summary>
    public class UsuarioRepositorio:IUsuarioRepositorio
    {

        private SqlHelper helper = null;

        public void InicializarConexion(TipoBaseDatos baseDatos)
        {
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        }    

        //no tengo los metodos privados

        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
        

        public Usuario Actualizar(Usuario item)
        {
            throw new NotImplementedException();
        }

        public Usuario GetEntidad(Usuario filtro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetLista(Modelo.Dominio.Filtro.UsuarioFiltro filtro, ref Modelo.Compartido.Paginacion paginacion)
        {
            throw new NotImplementedException();
        }

        #region Metodos publicos

        public Usuario InsertaUsuario(Usuario item)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int,item.IdTabla, ParameterDirection.Output));
            parametros.Add(new SqlParameterItem("@pIdRol", SqlDbType.Int, item.IdRol));
            parametros.Add(new SqlParameterItem("@pIdCliente", SqlDbType.Int, item.IdCliente));
            parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.Int, item.IdPatente));
            parametros.Add(new SqlParameterItem("@pIdIdioma", SqlDbType.Int, item.IdIdioma));
            parametros.Add(new SqlParameterItem("@pIdPreguntaSecreta", SqlDbType.Int, item.IdPreguntaSecreta));
            parametros.Add(new SqlParameterItem("@pNombre", SqlDbType.VarChar, 80, item.NombreORazonSocial));
            parametros.Add(new SqlParameterItem("@pApellidoPaterno", SqlDbType.VarChar, 80, item.ApellidoPaterno));
            parametros.Add(new SqlParameterItem("@pApellidoMaterno", SqlDbType.VarChar, 80, item.ApellidoMaterno));
            parametros.Add(new SqlParameterItem("@pNombreCompleto", SqlDbType.VarChar, 240, item.NombreORazonSocial +" "+  item.ApellidoPaterno +" "+ item.ApellidoMaterno));
            parametros.Add(new SqlParameterItem("@pUsuario", SqlDbType.VarChar, 30, item.Login));
            parametros.Add(new SqlParameterItem("@pPass", SqlDbType.VarChar, 255, item.Pass));
            parametros.Add(new SqlParameterItem("@pCorreoElectronico", SqlDbType.VarChar, 80, item.CorreoElectronico));
            parametros.Add(new SqlParameterItem("@pInactivo", SqlDbType.Bit, item.Inactivo));
            parametros.Add(new SqlParameterItem("@pRespuestaPreguntaSecreta", SqlDbType.VarChar, 250, item.RespuestaPreguntaSecreta));
            parametros.Add(new SqlParameterItem("@pActivo", SqlDbType.Bit, 80, item.Activo));

            helper.ExecuteNonQuery("spInsertaUsuario", parametros);
            return item;
        }

        #endregion

    }
}
