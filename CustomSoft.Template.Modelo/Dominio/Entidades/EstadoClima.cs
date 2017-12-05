using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Base;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class EstadoClima : EstadoClimaBase
    {
        [DataMember]
        public int IdEntidadFederativa { get; set; }
        [DataMember]
        public string EntidadFederativa { get; set; }

        public int IdClima { get; set; }
        [DataMember]
        public double TemperaturaMaxima { get; set; }
        [DataMember]
        public double TemperaturaMinima { get; set; }
        [DataMember]
        public double VelocidadViento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
    }
}
