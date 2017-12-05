﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Filtro;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IUsuarioRepositorio :IDisposable
    {
        Usuario InsertaUsuario(Usuario item);
        bool Actualizar(Usuario item);
        Usuario GetEntidad(UsuarioFiltro filtro);
        Usuario InsertaUsuarioXEmpresa(Usuario item, int idUsuarioCreacion);
        /// <summary>
        /// para los datos del sql paginar la informacion
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="paginacion"></param>
        /// <returns></returns>
        IEnumerable<Usuario> GetLista(UsuarioFiltro filtro, ref Paginacion paginacion);
        //Usuario UpdatePassword(Usuario usuario);
    }
}