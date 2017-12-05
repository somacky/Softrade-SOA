using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public abstract class DigitalizacionVUCEMBase
    {
        [DataMember]
        public int IdBitacoraEdocumentVUCEM { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdPedimento { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
        //[DataMember]
        //public int IdEmpresa { get; set; }
        //[DataMember]
        //public int IdEmpresa { get; set; }
        //[DataMember]
        //public int IdEmpresa { get; set; }
    }
}
