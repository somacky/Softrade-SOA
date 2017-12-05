using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public abstract class NotificacionBase
    {
        [DataMember]
        public int IdNotificacion { get; set; }
        [DataMember]
        public string NumeroPatente { get; set; }
        [DataMember]
        public string Identificador { get; set; }
        [DataMember]
        public bool Visto { get; set; }
    }
}
