using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Servicios.Base;
using CustomSoft.Template.Modelo.VUCEMService;

namespace CustomSoft.Template.Modelo.Servicios.Response
{
    [DataContract]
    public class TasaCambioResponse : OperacionResponseBase<ListaTasaCambio>
    {
    }
}
