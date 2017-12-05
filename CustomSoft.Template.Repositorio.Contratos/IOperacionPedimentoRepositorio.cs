﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.VUCEMService;
using ArchivoM = CustomSoft.Template.Modelo.Dominio.Entidades.ArchivoM;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IOperacionPedimentoRepositorio : IDisposable
    {
        bool RegistraPedimentoBD(ArchivoM pedimento);
        Archivo InsertaExpedienteDigital(Archivo archivo, int idCuentaGasto, int idUsuario);
        int DameIdAduanaXClave(ArchivoM pedimento);
        int DameIdPatenteXNumeroPatente(ArchivoM pedimento);
        bool InsertaGrupoArchivos(int idPedimento, int idExpedienteDigital);
        ArchivoM DameIdPedimentoXPedimento(ArchivoM pedimento);
        ArchivoM DameIdPedimentoXPedimentoYOrigen(ArchivoM pedimento);
        int DameIdPartidaXIdPedimentoYNoSecuencia(int pNumeroPartida, int pIdPedimento, int pIdEmpresa);
        int RegistraPartidaBD(Modelo.VUCEMService.DatosReg551Partidas pPartida, int pIdPedimento, int pIdEmpresa);
        List<ArchivoM> DameListaXPedimento(ArchivoM pedimento);
        ArchivoM InactivaPedimentoVUCEM(ArchivoM pedimento);
        //NEW
        //int RegistraPartidaBD(DatosReg551Partidas pPartida, int pIdPedimento, int pIdEmpresa);
    }
}
