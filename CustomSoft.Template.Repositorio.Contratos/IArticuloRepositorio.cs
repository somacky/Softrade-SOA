using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IArticuloRepositorio : IDisposable
    {
        ListaArticulos DameListaArticulosXEmpresa(ListaArticulos item);
        ListaArticulos InsertaListaArticulos(ListaArticulos item);
        ListaArticulos DameListaArticulosXClave(ListaArticulos item);
        ListaArticulos DameListaArticulosXFraccion(ListaArticulos item);
    }
}
