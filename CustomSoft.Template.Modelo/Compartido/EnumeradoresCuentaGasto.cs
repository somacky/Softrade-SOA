using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Compartido
{
    [DataContract]
    public enum EnumeradoresCuentaGasto : byte
    {
        [EnumMember]
        IdPedimento
    }
}
