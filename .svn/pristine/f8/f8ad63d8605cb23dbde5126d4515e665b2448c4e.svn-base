using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class TasaCambio : TasaCambioBase
    {
        [DataMember]
        public bool EsFix { get; set; }
        [DataMember]
        public DateTime FechaCambio { get; set; }

        public int IdMoneda { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public EnumeradoresTipoCambio EnumeradoresTipoCambio { get; set; }
    }

    [DataContract]
    public class ListaTasaCambio
    {
        [DataMember]
        public List<TasaCambio> ListaTasaCambios { get; set; } 
    }
}
