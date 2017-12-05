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
    public class Articulo : ArticuloBase
    {
        [DataMember]
        public List<IdentificadorXArticulo> IdentificadorArticulo { get; set; }
        [DataMember]
        public List<PermisoXArticulo> PermisoArticulo { get; set; }
        [DataMember]
        public DocumentoExpedienteDigital DocumentoExpediente { get; set; }        
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdCliente { get; set; }
    }

    [DataContract]
    public class ListadoArticulos
    {
        [DataMember]
        public List<Articulo> ListaArticulos { get; set; }
    }

    [DataContract]
    public class ListaArticulos: ListadoArticulos
    {
        [DataMember]
        public EnumeradoresGetArticulo TipoGetArticulo { get; set; }
        [DataMember]
        public Paginacion Paginas { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdFraccion { get; set; }
    }
}
