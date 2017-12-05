﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.Empresa;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface IOperacionEmpresaDominio : IDisposable
    {
        EntidadEmpresa OperacionEmpresaItem(EntidadEmpresa entidad);
        ListaEmpresa OperacionListaEmpresa(ListaEmpresa request);
        //EntidadEmpresa DameDatosPatenteXId(EntidadEmpresa request);
    }
}
