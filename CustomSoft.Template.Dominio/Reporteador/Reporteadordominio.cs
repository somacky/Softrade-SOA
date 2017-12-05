using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.Reporteador;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio.Reporteador
{
    public partial class ReporteadorDominio : IReporteadorDominio
    {
        //Intancia para repositorio (BD)
        private IReporteadorRepositorio reporteadorRepositorio;

        //Conexion con BD
        public ReporteadorDominio()
        {
            reporteadorRepositorio = FactoryEngine<IReporteadorRepositorio>.GetInstance("IReporteadorRepositorioConfig");
        }

        #region Metodos Publicos

        private void ValidaDatosRequest(string pWhere)
        {
            if (string.IsNullOrEmpty(pWhere))
            {
                throw new WhereVacioException();
            }
        }
        #endregion

        #region Metodos Privados

        public ReporteadorEntidad DameInformacionReportePagoNPartida(ReporteadorEntidad request)
        {
            //COMENTADO POR PRUEBAS
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            //ejecuto funcion
            var response = new ReporteadorEntidad();
            request.Where = CrearWherePedimento(request.FiltroPedimento);
            
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteIvaNPartida(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReportePagoNPedimento(ReporteadorEntidad request)
        {
            //COMENTADO POR PRUEBAS
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            //ejecuto funcion
            var response = new ReporteadorEntidad();
            request.Where = CrearWherePedimento(request.FiltroPedimento);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteIvaNPedimento(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteOperacionesNPartida(ReporteadorEntidad request)
        {
            //COMENTADO POR PRUEBAS
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            //ejecuto funcion
            
            var response = new ReporteadorEntidad();
            request.WherePedimento = CrearWherePedimento(request.FiltroPedimento);            
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {                
                response = reporteadorRepositorio.DameDatosReporteOperNPartida(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteOperacionesNPedimento(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            request.WherePedimento = CrearWherePedimento(request.FiltroPedimento);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                //reporteadorRepositorio.EjecutarFiltroPedimento(request);
                response = reporteadorRepositorio.DameDatosReporteOperNPedimento(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteResumenOperaciones(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion            
            var response = new ReporteadorEntidad();
            request.Where = CrearWherePedimento(request.FiltroPedimento);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteResumenOper(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteCuentaGastosDetallado(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            request.WherePedimento = CrearWherePedimento(request.FiltroPedimento);
            ValidaDatosRequest(request.WherePedimento);
            request.WhereCuentaGasto = CrearWhereCuentaGasto(request.FiltroCuentaGasto);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteCGDetallado(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteCuentaGastosTotalizado(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            request.WherePedimento = CrearWherePedimento(request.FiltroPedimento);
            ValidaDatosRequest(request.WherePedimento);
            request.WhereCuentaGasto = CrearWhereCuentaGasto(request.FiltroCuentaGasto);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteCGTotalizado(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteDiasDespacho(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            request.WherePedimento = CrearWherePedimento(request.FiltroPedimento);
            ValidaDatosRequest(request.WherePedimento);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteDiasDespacho(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteCuentaGastoAA(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            request.Where = CrearWherePedimento(request.FiltroPedimento);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteCGAgenteAduanal(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteAnexo9(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteAnexo9(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteAnexo18(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            request.WherePedimento = CrearWherePedimento(request.FiltroPedimento);
            ValidaDatosRequest(request.WherePedimento);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReportaAnexo18(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteEstatusExpedienteDigital(ReporteadorEntidad request)
        {
            ////Valido datos de entrada
            //ValidaDatosRequest(request);
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteEstatusExpedienteDigital(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteConstribucionesMis7(ReporteadorEntidad request)
        {
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteContribucionesMis7(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteDiasDespachoMis7(ReporteadorEntidad request)
        {
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteDiasDespachoMis7(request);
                //transaction.Complete();
            }
            return response;
        }

        public ReporteadorEntidad DameInformacionReporteOperacionesMis7(ReporteadorEntidad request)
        {
            ////ejecuto funcion
            var response = new ReporteadorEntidad();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = reporteadorRepositorio.DameDatosReporteOperacionesMis7(request);
                //transaction.Complete();
            }
            return response;
        }


        #endregion

        public void Dispose()
        {
            reporteadorRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
