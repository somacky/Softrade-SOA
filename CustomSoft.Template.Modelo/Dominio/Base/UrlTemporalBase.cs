using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public abstract class UrlTemporalBase
    {
        [DataMember]
        public int IdUrl { get; set; }
        [DataMember]
        public string GuidUrl { get; set; }
        //[DataMember]
        [DataMember]
        public List<int> Ids { get; set; } 
    }
}
