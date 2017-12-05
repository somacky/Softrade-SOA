using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface  ITasaCambioRepositorio : IDisposable
    {
        TasaCambio InsertarTasaCambio(TasaCambio item);
        ListaTasaCambio GetListaTasaCambio(TasaCambio item);
    }
}
