﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;

namespace CustomSoft.Template.Modelo.Dominio.Entidades.Empresa
{
    [DataContract]
    public class EntidadEmpresa
    {
        //[DataMember]
        //public string BaseDatos { get; set; }

        [DataMember]
        public Empresa DatosEmpresa { get; set; }

        //[DataMember]
        //public int IdPatente { get; set; }

        //[DataMember]
        //public int IdCliente { get; set; }

        [DataMember]
        public bool Inactivo { get; set; }
        
        [DataMember]
        public OperacionEmpresaItem OperacionEspecifica { get; set; }

        [DataMember]
        public Patente DatosPatente { get; set; }
        
    }
}