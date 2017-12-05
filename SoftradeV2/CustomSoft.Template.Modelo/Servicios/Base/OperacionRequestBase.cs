using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Servicios.Base
{
    [DataContract]
    public abstract class OperacionRequestBase<TEntidad> : RequestBase where TEntidad : class 
    {
        [DataMember]
        public TEntidad Item { get; set; }
    }
}
