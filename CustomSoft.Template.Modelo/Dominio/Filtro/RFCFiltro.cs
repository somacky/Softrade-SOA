using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Modelo.Dominio.Filtro
{    
    [DataContract]
    public abstract class RFCFiltro<TEntidadFiltro> : RFC where TEntidadFiltro : class
    {
        [DataMember]
        public TipoRFC TipoDeRFC { get; set; }
        [DataMember]
        public TEntidadFiltro Item { get; set; }
    }
}
