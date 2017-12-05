using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.ExpedienteDigital;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio
{
    public class CatalogoEspecificoDominio : ICatalogoEspecificoDominio
    {
        private ICatalogoEspecificoRepositorio iCatalogoEspecificoRepositorio = null;

        public CatalogoEspecificoDominio()
        {
            iCatalogoEspecificoRepositorio =
                FactoryEngine<ICatalogoEspecificoRepositorio>.GetInstance("ICatalogoEspecificoRepositorioConfig");
        }

        public List<CatalogoEspecifico> ExtraerListaCatalogoEspecifico(CatalogoEspecifico catalogoEspecifico)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                var listaCatalogoEspecifico =
                    iCatalogoEspecificoRepositorio.ExtraerCatalogoEspecifico(catalogoEspecifico);            
                transaction.Complete();
                return listaCatalogoEspecifico; 
            }                       
        }

        public void Dispose()
        {
            iCatalogoEspecificoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
