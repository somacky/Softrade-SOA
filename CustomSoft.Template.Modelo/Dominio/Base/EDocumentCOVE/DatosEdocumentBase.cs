using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.EDocumentCOVE
{
    [DataContract]
    public abstract class DatosEdocumentBase
    {
        [DataMember]
        public int IdBitacoraEdocumentVUCEM { get; set; }
        [DataMember]
        public string NoEdocument { get; set; }
        [DataMember]
        public int IdPedimento { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
    }
}
