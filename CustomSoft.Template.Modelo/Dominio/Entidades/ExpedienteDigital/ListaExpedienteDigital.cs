using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base.ExpedienteDigital;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital
{
    [DataContract]
    public class ListaExpedienteDigital : FiltroExpedienteDigital
    {
        //[DataMember]
        //public TipoExtraccion DatosAExtraer { get; set; }
        [DataMember]
        public List<ExpedienteDigital> ListaDocumentos { get; set; }
        [DataMember]
        public Paginacion ListaPaginacion { get; set; }
        [DataMember]
        public Expediente ExpedienteExtraer { get; set; }
    }
}
