
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Filtro;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface  IUsuarioDominio :IDisposable
    {
        Usuario InsertaUsuario(Usuario item, int idUsuarioCreacion);
        Usuario Actualizar(Usuario item);
        Usuario GetEntidad(UsuarioFiltro filtro);
        Usuario UpdatePassword(UsuarioFiltro item);
        //IEnumerable<Usuario> GetLista(UsuarioFiltro filtro, ref Paginacion paginacion);
    }
}
