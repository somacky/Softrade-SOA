using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface IPedimentoDominio : IDisposable
    {
        Pedimento InsertarPedimento(Pedimento pedimento);
        IEnumerable<Pedimento> TraerPedimentos(Pedimento pedimento , ref Paginacion paginacion);
    }
}
