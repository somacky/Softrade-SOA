using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Servicios.Base
{
    [DataContract]
    public abstract class ResponseBase : RequestBase
    {
        [DataMember]
        public bool EjecucionValida { get; set; }
        [DataMember]
        public string MensajeError { get; set; }
    }
}
