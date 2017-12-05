using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Dominio.Reporteador
{
    public partial class ReporteadorDominio
    {

        public static string CrearWhere(FiltroReporte reporte)
        {
            var and = false;
            var where = "WHERE ";            
            if (reporte.FechaEntrada1 != null)
            {
                //var vFechaPagoParseo = DateTime.ParseExact(vFechaPago, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None);
                where += " FXEntrada.Fecha Between '" + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada1.Value) + "' AND '"
                      + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada2.Value) + "'";
                and = true;
            }
            if (reporte.FechaPago1 != null)
            {
                if (and)
                    where += " AND ";
                //var vFechaPagoParseo = DateTime.ParseExact(vFechaPago, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None);
                where += " FXPago.Fecha Between '" + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada1.Value) + "' AND '"
                      + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada2.Value) + "'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.Pedimento))
            {

                if (and)
                    where += " AND ";
                where += "Ped.Pedimento like '%" + reporte.Pedimento + "%'";
                and = true;
            }            
            if (reporte.IdTipoOperacion != 0)
            {
                if (and)
                    where += " AND ";
                where += " Ped.IdTipoOperacionVW = " + reporte.IdTipoOperacion;
                and = true;
            }
            if (reporte.IdClavePedimento != 0)
            {
                if (and)
                    where += " AND ";
                //var vFechaPagoParseo = DateTime.ParseExact(vFechaPago, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None);
                where += " Ped.ClavePedimento = '" + reporte.IdClavePedimento;
                and = true;
            }
            if (reporte.IdPatente != 0)
            {
                if (and)
                    where += " AND ";
                where += " Ped.IdPatenteVW = " + reporte.IdPatente;
                and = true;
            }
            if (reporte.IdEmpresa != 0)
            {
                if (and)
                    where += " AND ";
                where += "Ped.IdEmpresaVW = " + reporte.IdEmpresa;
                and = true;
            }
            if (reporte.IdFraccion != 0)
            {
                if (and)
                    where += " AND ";
                where += " Par.IdFraccionVW = " + reporte.IdFraccion;
            }
            if (reporte.IdVinculacionVW != 0)
            {
                if (and)
                    where += " AND ";
                where += " Par.IdVinculacionVW = " + reporte.IdVinculacionVW;
                and = true;
            }
            if (reporte.FechaFacturacion1!= null)
            {
                if (and)
                    where += " AND ";
                where += " FXPago.Fecha Between '" + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada1.Value) + "' AND '"
                      + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada2.Value) + "'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.NumeroFactura))
            {
                if (and)
                    where += " AND ";
                where += " Fac.NumeroFactura like '%" + reporte.NumeroFactura + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.NumeroCove))
            {
                if (and)
                    where += " AND ";
                where += " Fac.NoCOVE like '%" + reporte.NumeroCove + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.NombreProveedor))
            {
                if (and)
                    where += " AND ";
                where += " Fac.NombreProveedorComprador like '%" + reporte.NombreProveedor + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.Guia))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " Gui.GuiaEmbarque like '%" + reporte.Guia + "%'";
                and = true;
            }
           
            if (!string.IsNullOrEmpty(reporte.NumeroContenedor))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " Con.NumeroContenedor like '%" + reporte.NumeroContenedor + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.IdentificadorNivelPartida))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " IdePartida.ClaveIdentificador like '%" + reporte.IdentificadorNivelPartida + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.IdentificadorNivelPedimento))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " IdePedimento.ClaveIdentificador like '%" + reporte.IdentificadorNivelPedimento + "%'";
                and = true;
            }
            if (reporte.IdPermiso != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += "Per.IdPermisoVW = " + reporte.IdPermiso;
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.NumeroCove))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " Cove.NoCOVE like '%" + reporte.NumeroCove + "%'";
                and = true;
            }
            if (reporte.IdAduanaSeccion != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += "Ped.IdAduanaSeccionVW = " + reporte.IdAduanaSeccion;
                and = true;
            }
           
            if (reporte.CertificadoOrigen)
            {
                if (and)
                    where += " AND ";
                where += " Ped.CertificadoOrigen = '" + 1;
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.Descripcion))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " Cove.Descripcion like '%" + reporte.Descripcion + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.ClaveArticulo))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " Cove.ClaveArticulo like '%" + reporte.ClaveArticulo + "%'";
                and = true;
            }
           
            if (!string.IsNullOrEmpty(reporte.NumeroFactura))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " CG.NumeroFactura like '%" + reporte.NumeroFactura + "%'";
                and = true;
            }
            if (reporte.IdMoneda != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += "CG.IdMonedaVW = " + reporte.IdMoneda;
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.UUID))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " CG.UUID like '%" + reporte.UUID + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.RFCEmisor))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " Cove.RFCEmisor like '%" + reporte.RFCEmisor + "%'";
                and = true;
            }
            if (and)
                return where;
            else
            {
                return "";
            }
        }

        public static string CrearWherePedimento(FiltroPedimento reporte)
        {
            var and = false;
            var where = "WHERE ";
            if (reporte.FechaEntrada1 != null)
            {
                //var vFechaPagoParseo = DateTime.ParseExact(vFechaPago, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None);
                where += " FEntrada.Fecha Between '" + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada1.Value) + "' AND '"
                      + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada2.Value) + "'";
                and = true;
            }
            if (reporte.FechaPago1 != null)
            {
                if (and)
                    where += " AND ";
                //var vFechaPagoParseo = DateTime.ParseExact(vFechaPago, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None);
                where += " FPago.Fecha Between '" + string.Format("{0:yyyy-MM-dd}", reporte.FechaPago1.Value) + "' AND '"
                      + string.Format("{0:yyyy-MM-dd}", reporte.FechaPago2.Value) + "'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.Pedimento))
            {

                if (and)
                    where += " AND ";
                where += "Ped.Pedimento like '%" + reporte.Pedimento + "%'";
                and = true;
            }
            if (reporte.IdTipoOperacion != 0)
            {
                if (and)
                    where += " AND ";
                where += " Ped.IdTipoOperacionVW = " + reporte.IdTipoOperacion;
                and = true;
            }
            if (reporte.IdClavePedimento != 0)
            {
                if (and)
                    where += " AND ";
                //var vFechaPagoParseo = DateTime.ParseExact(vFechaPago, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None);
                where += " Ped.ClavePedimento = '" + reporte.IdClavePedimento;
                and = true;
            }
            if (reporte.IdPatente != 0)
            {
                if (and)
                    where += " AND ";
                where += " Ped.IdPatenteVW = " + reporte.IdPatente;
                and = true;
            }
            if (reporte.IdEmpresa != 0)
            {
                if (and)
                    where += " AND ";
                where += "Ped.IdEmpresaVW = " + reporte.IdEmpresa;
                and = true;
            }
            if (reporte.IdFraccion != 0)
            {
                if (and)
                    where += " AND ";
                where += " Par.IdFraccionVW = " + reporte.IdFraccion;
            }
            if (reporte.IdVinculacionVW != 0)
            {
                if (and)
                    where += " AND ";
                where += " Par.IdVinculacionVW = " + reporte.IdVinculacionVW;
                and = true;
            }
            if (reporte.FechaFacturacion1 != null)
            {
                if (and)
                    where += " AND ";
                where += " FXPago.Fecha Between '" + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada1.Value) + "' AND '"
                      + string.Format("{0:yyyy-MM-dd}", reporte.FechaEntrada2.Value) + "'";
                and = true;
            }    
            if (!string.IsNullOrEmpty(reporte.Guia))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " Gui.GuiaEmbarque like '%" + reporte.Guia + "%'";
                and = true;
            }

            if (!string.IsNullOrEmpty(reporte.NumeroContenedor))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " C.NumeroContenedor like '%" + reporte.NumeroContenedor + "%'";
                and = true;
            }
            if (reporte.IdIdentificadorNivelPartida != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " IPar.ClaveIdentificador =" + reporte.IdIdentificadorNivelPartida;
                and = true;
            }
            if (reporte.IdIdentificadorNivelPedimento != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " IPed.ClaveIdentificador = " + reporte.IdIdentificadorNivelPedimento;
                and = true;
            }        
            if (reporte.IdAduanaSeccion != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += "Ped.IdAduanaSeccionVW = " + reporte.IdAduanaSeccion;
                and = true;
            }          
            if (and)
                return where;
            else
            {
                return "";
            }
        }

        public static string CrearWhereCove(FiltroCove reporte)
        {
            var and = false;
            var where = "WHERE ";
            if (reporte.IdPatente != 0)
            {                                    
                where += " C.IdPatenteVW = " + reporte.IdPatente;
                and = true;
            }
            if (reporte.IdEmpresa != 0)
            {
                if (and)
                    where += " AND ";
                where += "C.IdEmpresaVW = " + reporte.IdEmpresa;
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.NumeroCove))
            {
                if (and)
                    where += " AND ";
                where += " FC.NoCOVE like '%" + reporte.NumeroCove + "%'";
                and = true;
            }         
            if (reporte.CertificadoOrigen)
            {
                if (and)
                    where += " AND ";
                where += " FC.CertificadoOrigen = '" + 1;
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.Descripcion))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " DFC.DescripcionGenerica like '%" + reporte.Descripcion + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.ClaveArticulo))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " DFC.ClaveArticulo like '%" + reporte.ClaveArticulo + "%'";
                and = true;
            }
            if (reporte.IdMoneda != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += "DFC.IdMonedaVW = " + reporte.IdMoneda;
                and = true;
            }
            if (and)
                return where;
            else
            {
                return "";
            }
        }

        public static string CrearWhereCuentaGasto(FiltroCuentaGasto reporte)
        {
            var and = false;
            var where = "WHERE ";         
            if (reporte.IdEmpresa != 0)
            {
                if (and)
                    where += " AND ";
                where += "Ped.IdEmpresaVW = " + reporte.IdEmpresa;
                and = true;
            }           
            if (!string.IsNullOrEmpty(reporte.NumeroFactura))
            {
                if (and)
                    where += " AND ";
                where += " CG.NumeroFactura like '%" + reporte.NumeroFactura + "%'";
                and = true;
            }      
            if (!string.IsNullOrEmpty(reporte.Descripcion))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " DCG.Descripcion like '%" + reporte.Descripcion + "%'";
                and = true;
            }                    
            if (reporte.IdMoneda != 0)
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += "CG.IdMonedaVW = " + reporte.IdMoneda;
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.UUID))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " CG.UUID like '%" + reporte.UUID + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(reporte.RFCEmisor))
            {
                //pendiente
                if (and)
                    where += " AND ";
                where += " CG.RFCEmisor like '%" + reporte.RFCEmisor + "%'";
                and = true;
            }
            if (and)
                return where;
            else
            {
                return "";
            }
        }
    }
}
