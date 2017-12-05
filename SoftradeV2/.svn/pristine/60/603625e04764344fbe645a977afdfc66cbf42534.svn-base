using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Servicios.Base
{
    [DataContract]
    public abstract class OperacionResponseBase<TEntidad> :ResponseBase where TEntidad:class 
    {
        [DataMember]
        public TEntidad Item { get; set; }
    }
}
