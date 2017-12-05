using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.Pedimento
{
    [DataContract]
    public class DatosReg801FinArchivo
    {
        [DataMember]
        public string NombreArchivo { get; set; }
        [DataMember]
        public int CantidadPedimentos { get; set; }
        [DataMember]
        public int CantidadRegistros { get; set; }
        [DataMember]
        public string ClavePrevalidador { get; set; }
    }
}
