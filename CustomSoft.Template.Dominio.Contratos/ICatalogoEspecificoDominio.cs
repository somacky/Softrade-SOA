using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface ICatalogoEspecificoDominio : IDisposable
    {
        List<CatalogoEspecifico> ExtraerListaCatalogoEspecifico(CatalogoEspecifico catalogoEspecifico);
    }
}
