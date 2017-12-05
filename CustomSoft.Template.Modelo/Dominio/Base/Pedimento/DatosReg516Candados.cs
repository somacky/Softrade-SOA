using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public class DatosReg516Candados
    {
        [DataMember]
        public int NumeroDocumento { get; set; }
        [DataMember]
        public string IdentificadorTransporte { get; set; }
        [DataMember]
        public string NumeroCandado { get; set; }
    }
}
