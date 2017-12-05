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
    public class ListaEmpresa
    {
        [DataMember]
        public List<Empresa> DatosEmpresa { get; set; }

        [DataMember]
        public int IdABuscar { get; set; }

        //[DataMember]
        //public int IdUsuario { get; set; }

        [DataMember]
        public bool Inactivo { get; set; }        
        
        [DataMember]
        public OperacionEmpresaLista OperacionEspecifica { get; set; }
    }
}
