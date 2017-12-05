using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface IArticuloDominio : IDisposable
    {
        ListaArticulos GetListArticulos(ListaArticulos request);
        ListaArticulos InsertListaArticulos(ListaArticulos request);        
        Articulo SubeDocumentoArticulo(Articulo articulo);
    }
}
