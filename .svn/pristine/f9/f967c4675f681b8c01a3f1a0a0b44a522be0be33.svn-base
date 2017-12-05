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
    public class UrlTemporal : UrlTemporalBase
    {
        public DateTime FechaExpiracion { get; set; }

        public int NumeroIntentos { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public TipoUrlTemporal TipoUrlTemporal { get; set; } 
    }
}
