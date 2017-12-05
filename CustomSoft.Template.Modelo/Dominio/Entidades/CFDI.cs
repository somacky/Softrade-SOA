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
    
    public class CFDI : CFDISATBase 
    {        
        public int IdEmpresa { get; set; }
     
        public int IdPedimento { get; set; }
     
        public Archivo ArchivoFisico { get; set; }          
     
        public int IdUsuario { get; set; }        
    }
}
