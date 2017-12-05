using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.VUCEMService;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class DigitalizacionVUCEM : DigitalizacionVUCEMBase
    {
        ////[DataMember]
        public int IdCliente { get; set; }
        //[DataMember]
        //public int IdEmpresa { get; set; }
        //[DataMember]
        //public int IdPatente { get; set; }

        public string Patente { get; set; }
        [DataMember]
        public DocumentoVUCEM Documento { get; set; }
        [DataMember]
        public Archivo ArchivoFisico { get; set; }
    }
}

