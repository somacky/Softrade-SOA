using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Compartido
{
    [DataContract]
    public enum TipoUrlTemporal : byte
    {
        [EnumMember]
        CambioPassword,
        [EnumMember]
        ExpedienteDigital
    }

    [DataContract]
    public enum OperacionUrlTemporal : byte
    {
        [EnumMember]
        GenerarUrlTemporal,
        [EnumMember]
        ComprobarUrl
    }
}
