using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using CustomSoft.Template.Repositorio.SqlServer.CatalogosEspecificos;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class CatalogoEspecificoRepositorio : ICatalogoEspecificoRepositorio
    {

        public List<CatalogoEspecifico> ExtraerCatalogoEspecifico(CatalogoEspecifico catalogo)
        {
            switch (catalogo.CatalogoALlamar)
            {
                    case TipoCatalogoEspecifico.Patente:
                    var patente = new PatenteRepositorio();
                    return patente.DameListaPatente();
            }
            return null;
        }

        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
