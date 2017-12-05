using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Base.MotorBase;

namespace CustomSoft.Template.Modelo.Dominio.Entidades.Motor
{
    [DataContract]
    public class ListadoPedimentosXProcesar : PedimentosPendientesBase
    {
        //[DataMember]
        //public int IdListadoPedimento { get; set; }

        [DataMember]
        public string NumeroPedimento { get; set; }

        [DataMember]
        public string NumeroPatente { get; set; }

        //[DataMember]
        //public decimal NumeroOperacion { get; set; }
    }
}
