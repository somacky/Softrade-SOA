using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface ICatalogoEspecificoRepositorio : IDisposable
    {
        List<CatalogoEspecifico> ExtraerCatalogoEspecifico(CatalogoEspecifico catalogo);
    }
}
