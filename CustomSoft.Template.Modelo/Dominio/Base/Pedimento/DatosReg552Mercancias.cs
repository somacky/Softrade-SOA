using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public class DatosReg552Mercancias
    {
        [DataMember]
        public int NumeroDocumento { get; set; }
        [DataMember]
        public string FraccionAracelaria { get; set; }
        [DataMember]
        public int NumeroPartida { get; set; }
        [DataMember]
        public string NumeroIdentificacionVehicular { get; set; }
        [DataMember]
        public long KilometrajeVehiculo { get; set; }
    }
}
