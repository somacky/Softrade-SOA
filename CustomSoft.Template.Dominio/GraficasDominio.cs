using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio
{
    public class GraficasDominio : IGraficasDominio
    {
         public IGraficasRepositorio iGraficasRepositorio = null;

         public GraficasDominio()
        {
            iGraficasRepositorio = FactoryEngine<IGraficasRepositorio>.GetInstance("IGraficasRepositorioConfig");
        }
        public Modelo.Dominio.Entidades.Graficas GetGraficas(Modelo.Dominio.Entidades.Graficas graficas)
        {
            //using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                graficas = iGraficasRepositorio.GenerarGrafica(graficas);
                //transaction.Complete();
            }
            return graficas;
        }

        public void Dispose()
        {
            iGraficasRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
