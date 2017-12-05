using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.Pedimento
{
    [DataContract]
    public class DatosReg302PruebaSuficiente
    {
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string ClavePais { get; set; }
        [DataMember]
        public int IdClavePais { get; set; }
        [DataMember]
        public string NumeroPedimentoEUACAN { get; set; }
        [DataMember]
        public string PruebaSuficiente { get; set; }
        [DataMember]
        public int IdPruebaSuficiente { get; set; }
        [DataMember]
        public DateTime FechaDocumento { get; set; }
    }
}
