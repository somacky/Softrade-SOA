using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.Servicios.Base;

namespace CustomSoft.Template.Modelo.Servicios.Response
{
    [DataContract]
    public class CFDIOperacionResponse : OperacionResponseBase<CuentaGasto>
    {
    }
}
