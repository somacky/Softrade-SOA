using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Compartido
{
    [DataContract]
    public enum EnumeradoresGetArticulo : byte
    {
        [EnumMember]
        Fraccion,
        [EnumMember]
        Empresa,
        [EnumMember]
        Clave
    }

    [DataContract]
    public enum OperacionArticulo : byte
    {
        [EnumMember]
        GetList,
        [EnumMember]
        Inserta,        
    }
}
