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
    public class Graficas : GraficasBase
    {
        [DataMember]
        public EnumeradoresGraficas EnumeradoresGraficas { get; set; }
        [DataMember]
        public List<string> EjeX { get; set; } 
        [DataMember]
        public List<EjeY> ListEjeY { get; set; } 
    }

    [DataContract]
    public class EjeY
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public List<float> Valores { get; set; } 
        [DataMember]
        public string Agrupador { get; set; }
    }
}

