using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades.Motor;
using CustomSoft.Template.Modelo.Servicios.Base;

namespace CustomSoft.Template.Modelo.Servicios.Response
{
    [DataContract]
    public class OperacionMotorResponse : OperacionResponseBase<EntidadMotor>
    //public class OperacionMotorResponse : OperacionResponseBase<List<ListaPedimentosVUCEM>>
    {
        [DataMember]
        public TipoOperacionMotor OperacionMotor { get; set; }
    }
}
