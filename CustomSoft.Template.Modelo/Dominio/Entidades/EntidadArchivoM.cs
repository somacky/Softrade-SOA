﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class EntidadArchivoM 
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public ArchivoM ArchivoM { get; set; }
        [DataMember]
        public Archivo ArchivoFisico { get; set; }   
        [DataMember]
        public bool ArchivoSubido { get; set; }        
    }

    [DataContract]
    public class ListadoArchivoM
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public IEnumerable<ArchivoM> ListadoPedimento { get; set; } 

    }
}
