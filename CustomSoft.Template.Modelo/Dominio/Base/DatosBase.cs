﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public abstract class DatosBase
    {

        //[DataMember]
        //public string NombreORazonSocial { get; set; }

        [DataMember]
        public int Id { get; set; }
    }
}
