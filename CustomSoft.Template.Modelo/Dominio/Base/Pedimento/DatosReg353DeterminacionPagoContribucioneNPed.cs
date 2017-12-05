using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.Pedimento
{
    [DataContract]
    public class DatosReg353DeterminacionPagoContribucioneNPed
    {
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string FraccionAracelaria { get; set; }
        [DataMember]
        public int IdFraccionAracelariaPagoContribucion { get; set; }
        [DataMember]
        public int NumeroSecuencialPartida { get; set; }
        [DataMember]
        public float ValorMercanciaNoOriginaria { get; set; }
        [DataMember]
        public float MontoIGI { get; set; }
    }
}
