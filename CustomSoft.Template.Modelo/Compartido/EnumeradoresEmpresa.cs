﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Compartido
{
    [DataContract]
    public enum OperacionEmpresa : byte
    {
        [EnumMember]
        DameBDXId,

        [EnumMember]
        DameListaEmpresas
    }

    [DataContract]
    public enum OperacionEmpresaItem : byte
    {
        //[EnumMember]
        //DameBDXIdEmpresa,
        [EnumMember]
        DameDatosEmpresaXId,
        //ValidaDatosRequestId
        [EnumMember]
        DameDatosPatenteXId,
        [EnumMember]
        DameDatosPatenteXNoPatente
    }

    [DataContract]
    public enum OperacionEmpresaLista : byte
    {
        [EnumMember]
        DameListaEmpresas,
        [EnumMember]
        DameListaEmpresaXIdPatente,
        [EnumMember]
        DameListaEmpresaXIdUsuario
        //[EnumMember]
        //DameDatosEmpresaXId
        //ValidaDatosRequestId
    }   
}