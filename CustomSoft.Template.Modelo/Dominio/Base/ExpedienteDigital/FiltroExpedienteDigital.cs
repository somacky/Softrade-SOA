﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.ExpedienteDigital
{
    [DataContract]
    public abstract class FiltroExpedienteDigital
    {
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdArticulo { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public string Pedimento { get; set; }
        [DataMember]
        public int IdAduana { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
        [DataMember]
        public DateTime? FechaEntrada { get; set; }
        [DataMember]
        public DateTime? FechaPago { get; set; }
        [DataMember]
        public string Guia { get; set; }
        [DataMember]
        public string Contenedor { get; set; }
        [DataMember]
        public int IdFraccion { get; set; }
        [DataMember]
        public int IdIdentificador { get; set; }
        [DataMember]
        public int IdPermiso { get; set; }
        [DataMember]
        public string Proveedor { get; set; }
        [DataMember]
        public string FacturaPedimento { get; set; }
    }
}
