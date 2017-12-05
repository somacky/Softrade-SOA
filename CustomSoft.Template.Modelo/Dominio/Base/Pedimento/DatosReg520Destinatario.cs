using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public class DatosReg520Destinatario
    {
        [DataMember]
        public int NumeroDocumento { get; set; }
        [DataMember]
        public string ClaveIdentificadorFiscalDestinatario { get; set; }
        [DataMember]
        public string Destinatario { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string NumeroInterior { get; set; }
        [DataMember]
        public string NumeroExterior { get; set; }
        [DataMember]
        public string CodigoPostal { get; set; }
        [DataMember]
        public string MunicipioCiudad { get; set; }
        [DataMember]
        public string PaisDestinatario { get; set; }
        [DataMember]
        public int IdPaisDestinatario { get; set; }

    }
}
