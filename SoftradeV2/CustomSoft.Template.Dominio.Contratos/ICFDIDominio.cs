using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface  ICFDIDominio : IDisposable
    {
        CuentaGasto InsertaFactura(CFDI cfdi);
        CuentaGasto GetFactura(CuentaGasto cfdi);
        IEnumerable<CuentaGasto> GetList(CuentaGasto cfdi);
    }
}
