using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.ExpedienteDigital
{
    [DataContract]
    public abstract class ExpedienteDigitalBase
    {
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdCuentaGasto { get; set; }
        [DataMember]
        public int IdExpedienteDigital { get; set; }
        [DataMember]
        public int IdArticulo { get; set; }     
        [DataMember]
        public string NombreOrigen { get; set; }
        [DataMember]
        public string NombreDestino { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public int IdTipoDocumento { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
    }
}
