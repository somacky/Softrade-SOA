using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.Pedimento
{
    [DataContract]
    public class DatosReg358ObservacionesNPedComplementario
    {
        [DataMember]
        public int NumeroDocumento { get; set; }
        [DataMember]
        public string ClavePaisDestino { get; set; }
        [DataMember]
        public int IdClavePaisDestino { get; set; }
        [DataMember]
        public int FraccionArancelaria { get; set; }
        [DataMember]
        public int IdFraccionArancelaria { get; set; }
        [DataMember]
        public int NumeroSecuencialPartida { get; set; }
        [DataMember]
        public int NumeroConsecutivoObservacion { get; set; }
        [DataMember]
        public string Observaciones { get; set; }
    }
}
