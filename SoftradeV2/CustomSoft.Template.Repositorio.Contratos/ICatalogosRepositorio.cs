using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface ICatalogosRepositorio : IDisposable
    {
        BuscarCatalogo ExtraerIdMonedaXAbreviatura(BuscarCatalogo abreviaturaMoneda);
        BuscarCatalogo ExtraerIdTipoComprobanteXNombreComprobante(BuscarCatalogo nombreComprobante);
    }
}
