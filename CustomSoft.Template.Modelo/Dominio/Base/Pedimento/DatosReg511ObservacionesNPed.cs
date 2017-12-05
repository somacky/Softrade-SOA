using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public class DatosReg511ObservacionesNPed
    {
        [DataMember]
        public string NumeroDocumento { get; set; }
        //public int ClaveContribucion { get; set; }
        [DataMember]
        public int Consecutivo { get; set; }
        [DataMember]
        public string ObservacionesNivelPedimento { get; set; }
    }
}
