﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.Empresa;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IOperacionEmpresaRepositorio : IDisposable
    {
        string DameBaseDatosEmpresaXId(EntidadEmpresa request);
        //EntidadEmpresa DameBaseDatosEmpresaXId(EntidadEmpresa request);
        ListaEmpresa DameListaEmpresas(ListaEmpresa request);
        //EntidadEmpresa DameDatosEmpresaXId(EntidadEmpresa request);
        ListaEmpresa DameListaEmpresaXIdPatente(ListaEmpresa request);
        Empresa DameDatosEmpresaXId(Empresa request);
        ListaEmpresa DameListaEmpresaXIdUsuario(ListaEmpresa request);
        EntidadEmpresa DameDatosPatenteXId(EntidadEmpresa request);
        EntidadEmpresa DameDatosPatenteXNoPatente(EntidadEmpresa request); //new 29-10-15
    }
}
