using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IReporteadorRepositorio : IDisposable
    {
        ReporteadorEntidad DameDatosReporteIvaNPartida(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteIvaNPedimento(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteOperNPartida(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteOperNPedimento(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteResumenOper(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteCGDetallado(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteCGTotalizado(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteDiasDespacho(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteCGAgenteAduanal(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReportaAnexo18(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteAnexo9(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteEstatusExpedienteDigital(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteContribucionesMis7(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteDiasDespachoMis7(ReporteadorEntidad pWhere);
        ReporteadorEntidad DameDatosReporteOperacionesMis7(ReporteadorEntidad pWhere);        
    }
}