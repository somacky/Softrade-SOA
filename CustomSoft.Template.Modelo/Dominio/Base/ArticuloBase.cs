using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public class ArticuloBase
    {
        [DataMember]
        public int IdArticulo { get; set; }        
        [DataMember]
        public string ClaveArticulo { get; set; }
        [DataMember]
        public string Articulo { get; set; }
        [DataMember]
        public int IdFraccion { get; set; }
        [DataMember]
        public int IdUnidadMedidaComercial { get; set; }   
        [DataMember]
        public string UnidadMedidaComercial { get; set; }
        [DataMember]
        public int IdUnidadMedidaFactura { get; set; }
        [DataMember]
        public string UnidadMedidaFactura { get; set; }
        [DataMember]
        public int AdValorem { get; set; }
        [DataMember]
        public int IVA { get; set; }
        [DataMember]
        public int IdUsuarioCreacion { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; } 
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string Fraccion { get; set; }
    }

    [DataContract]
    public class IdentificadorXArticulo
    {
        [DataMember]
        public int IdIdentificadorXArticulo { get; set; }
        [DataMember]
        public int IdArticulo { get; set; }
        [DataMember]
        public int IdIdentificadorVW { get; set; }
        [DataMember]
        public string Complemento { get; set; }
    }

    [DataContract]
    public class PermisoXArticulo
    {
        [DataMember]
        public int IdPermisoXArticulo { get; set; }
        [DataMember]
        public int IdArticulo { get; set; }
        [DataMember]
        public int IdPermisoVW { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string FirmaDescargo { get; set; }
        [DataMember]
        public string ValorComercialUSD { get; set; }
        [DataMember]
        public string CantidadUMT { get; set; }
    }
}
