﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CustomSoft.Template.Modelo.Compartido
{
    [DataContract]
    public enum TipoFiltroUsuario :byte
    {
        [EnumMember]
        ByLogin,

        [EnumMember]
        ByNombre,
        
        [EnumMember]
        ByCorreo
    }

    [DataContract]
    public enum TipoOperacion : byte
    {

        [EnumMember]
        Actualizar,

        [EnumMember]
        Insertar
    }

    [DataContract]
    public enum TipoBaseDatos : byte
    {
        [EnumMember]
        Catalogos,
        [EnumMember]
        Softrade,
        [EnumMember]
        MainSoft
    }
}
