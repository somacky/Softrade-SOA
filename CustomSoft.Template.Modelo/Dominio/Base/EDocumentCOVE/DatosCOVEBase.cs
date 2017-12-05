using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.EdocumentCOVE
{
    [DataContract]
    public abstract class DatosCOVEBase
    {
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdBitacoraCOVE { get; set; }
     
        public string NombreArchivo { get; set; }
        
        public string PathArchivo { get; set; }
    }
}
