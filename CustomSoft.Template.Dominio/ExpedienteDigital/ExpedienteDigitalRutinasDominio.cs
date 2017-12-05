﻿using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital;

namespace CustomSoft.Template.Dominio.ExpedienteDigital
{
    public sealed class ExpedienteDigitalRutinasDominio
    {
        public static string CrearWhere(ListaExpedienteDigital listaExpedienteDigital)
        {
            var and = false;
            var where = "WHERE ";
            if (!string.IsNullOrEmpty(listaExpedienteDigital.Pedimento))
            {
                where += "Ped.Pedimento like '%" + listaExpedienteDigital.Pedimento + "%'";
                and = true;
            }
            if (listaExpedienteDigital.IdArticulo != 0)
            {
                if (and)
                    where += " AND ";
                where += " ED.IdArticulo = " + listaExpedienteDigital.IdArticulo;
                and = true;
            }
            if (listaExpedienteDigital.IdAduana != 0)
            {
                if (and)
                    where += " AND ";
                where += " Ped.IdAduanaSeccionVW = "  + listaExpedienteDigital.IdAduana;
                and = true;
            }
            if (listaExpedienteDigital.IdPatente != 0)
            {
                if (and)
                    where += " AND ";
                where += " Ped.IdPAtenteVW = "  + listaExpedienteDigital.IdPatente;
                and = true;
            }
            if (listaExpedienteDigital.FechaEntrada != null)
            {
                if (and)
                    where += " AND ";
                //var vFechaPagoParseo = DateTime.ParseExact(vFechaPago, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None);
                where += " FEntrada.Fecha = '" +  string.Format("{0:yyyy-MM-dd}", listaExpedienteDigital.FechaEntrada.Value) + "'";
                and = true;
            }
            if (listaExpedienteDigital.FechaPago != null)
            {
                if (and)
                    where += " AND ";
                where += " FPago.Fecha = '" + string.Format("{0:yyyy-MM-dd}", listaExpedienteDigital.FechaPago.Value) + "'";
                and = true;
            }
            if (listaExpedienteDigital.Guia != null)
            {
                if (and)
                    where += " AND ";
                where += " G.GuiaEmbarque like %' " + listaExpedienteDigital.Guia + "'";
                and = true;
            }
            if (!string.IsNullOrEmpty(listaExpedienteDigital.Contenedor))
            {
                if (and)
                    where += " AND ";
                where += " C.NumeroContenedor like %' " + listaExpedienteDigital.Contenedor + "'";
                and = true;
            }
            if (listaExpedienteDigital.IdFraccion != 0)
            {
                if (and)
                    where += " AND ";
                where += " Par.IdFraccionVW = " + listaExpedienteDigital.IdFraccion;
                and = true;
            }
            if (listaExpedienteDigital.IdIdentificador != 0)
            {
                if (and)
                    where += " AND ";
                where += " INP.IdIdentificadorVW = " + listaExpedienteDigital.IdIdentificador;
                and = true;
            }
            if (listaExpedienteDigital.IdPermiso != 0)
            {
                if (and)
                    where += " AND ";
                where += " PNP.IdPermisoVW = " + listaExpedienteDigital.IdPermiso;
                and = true;
            }
            if (!string.IsNullOrEmpty(listaExpedienteDigital.Proveedor))
            {
                if (and)
                    where += " AND ";
                where += " Fac.NombreProveedorComprador like '% " + listaExpedienteDigital.IdPermiso + "%'";
                and = true;
            }
            if (!string.IsNullOrEmpty(listaExpedienteDigital.FacturaPedimento))
            {
                if (and)
                    where += " AND ";
                where += " Fac.NumeroFactura like '% " + listaExpedienteDigital.FacturaPedimento + "%'";
                and = true;
            }
            if(and)
            return where;
            else
            {
                return "";
            }
        }
    }
}