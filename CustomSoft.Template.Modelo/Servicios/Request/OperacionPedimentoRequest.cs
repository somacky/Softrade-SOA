using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Servicios.Base;

namespace CustomSoft.Template.Modelo.Servicios.Request
{
    [DataContract]
    public class OperacionPedimentoRequest : OperacionRequestBase<EntidadArchivoM>
    {
        //public EnumeradoresPedimento.OrigenPedimento OrigenPedimento { get; set; }

        [DataMember]
        public EnumeradoresPedimento.OperacionPedimento OperacionPedimento { get; set; }
    }
}
