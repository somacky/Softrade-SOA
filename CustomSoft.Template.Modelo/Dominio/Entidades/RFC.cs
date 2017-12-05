using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class RFC : RFCBase
    {        
        [DataMember]
        public int IdRFC { get; set; }
        [DataMember]
        public TipoRFC TipoDeRFC { get; set; }
    }
}
