using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class CFDI : CFDISATBase 
    {
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdPedimento { get; set; }
        [DataMember]
        public Archivo ArchivoFisico { get; set; }          
        [DataMember]
        public int IdUsuario { get; set; }        
    }
}
