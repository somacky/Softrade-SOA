using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public abstract class EstadoClimaBase 
    {
        [DataMember]
        public int IdEstadoClima { get; set; }
        
        [DataMember]
        public string Clima { get; set; }
    }
}
