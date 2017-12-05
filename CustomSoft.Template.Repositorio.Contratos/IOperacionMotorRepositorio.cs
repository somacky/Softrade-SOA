﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.Motor;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IOperacionMotorRepositorio : IDisposable
    {
        bool DiaEjecucion(DateTime pFechaInicio);
        List<ListadoPedimentosPendientes> ListadoPedimentosPendientesMotor(int pIdEmpresa);
        int InsertaListadoBulk(int pIdBitacoraSinc, int pIdEmpresa, string pNombreAduana, int pNumeroAduana, string pNumeroPedimento, string pPatente, string pBaseDatos);
        bool CierraListadoPedimento(int pIdBitacoraSinc);
        bool RegistraToken(int pIdListadoPedimento, string pNumeroOperacion, string pBaseDatos, int pNoPartidas, int pIdPedimento);
        bool CierraPedimento(int pIdListadoPedimento, int pIdPedimento, string pBaseDatos);
        List<ListadoPedimentosXProcesar> ListadoPedimentosXProcesar(string pBaseDatos);
        List<BitacoraCOVE> DameListaCOVEConsulta(int pIdEmpresa);
        List<BitacoraEdocument> DameListaEdocumentConsulta(int pIdEmpresa);

    }
}
