using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface ICuentaGastoRepositorio : IDisposable
    {
        CuentaGasto InsertaFactura(CuentaGasto cfdi);
        CuentaGasto GetFactura(CuentaGasto cfdi);
        IEnumerable<CuentaGasto> GetList(CuentaGasto cfdi);
        ListaImpuestos InsertaImpuestosRetencion(ListaImpuestos impuestos, int idCuentaGasto);        
    }
}
