﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Compartido
{
    [DataContract]
    public enum TipoOperacionMotor : byte
    {
        [EnumMember]
        DiaEjecucion,

        [EnumMember]
        ListadoPedimentosPendientesAConsultar,

        [EnumMember]
        ListadoPedimentosVucem,

        [EnumMember]
        InsertaBulk,

        [EnumMember]
        CierraListadoPedimento,

        [EnumMember]
        ConsultaListadoPedimentosBd,

        [EnumMember]
        ConsultaPedimentoVucem,

        [EnumMember]
        ConsultaPartidaBdYVucem,

        [EnumMember]
        RegistraToken,

        [EnumMember]
        CierraPedimento,

        [EnumMember]
        ListadoCoveAConsultar,

        [EnumMember]
        ListadoEdocumentAConsultar
    }
}
