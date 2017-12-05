﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface ICuentaGastoRepositorio : IDisposable
    {
        CuentaGasto InsertaFactura(CuentaGasto cfdi);
        CuentaGasto GetFactura(CuentaGasto cfdi);
        ListadoCuentaGasto GetList(ListadoCuentaGasto cfdi);
        ListaImpuestos InsertaImpuestosRetencion(ListaImpuestos impuestos, int idCuentaGasto, int idEmpresa);
        DetalleCuentaGasto InsertaDetalleCuentaGasto(DetalleCuentaGasto detalleCuentaGasto, int idEmpresa);
        Archivo InsertaExpedienteDigital(Archivo archivo, int idCuentaGasto, int idUsuario);
        CuentaGasto DameIdCuentaGastoExistente(CuentaGasto cuentaGasto);
    }
}