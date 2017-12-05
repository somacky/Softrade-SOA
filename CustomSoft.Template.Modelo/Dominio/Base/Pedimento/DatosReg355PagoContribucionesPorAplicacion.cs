using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.Pedimento
{
    [DataContract]
    public class DatosReg355PagoContribucionesPorAplicacion
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
        public int IdFraccionAracelariaPagoContribucion { get; set; }
        [DataMember]
        public string NumeroSecuencialPartida { get; set; }
        [DataMember]
        public int ClaveGravamen { get; set; }
        [DataMember]
        public int IdClaveGravamen { get; set; }
        [DataMember]
        public float FormaPago { get; set; }
        [DataMember]
        public int IdFormaPago { get; set; }
        [DataMember]
        public float ImportePago { get; set; }
    }
}
