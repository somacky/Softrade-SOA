using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.Pedimento
{
    [DataContract]
    public class DatosReg505Facturas
    {
        [DataMember]
        public int NumeroDocumento { get; set; }

        [DataMember]
        public DateTime FechaFacturacion { get; set; }

        [DataMember]
        public string NumeroFactura { get; set; }

        [DataMember]
        public string ClaveTerminoFactura { get; set; }

        [DataMember]
        public int IdTerminoFactura { get; set; }

        [DataMember]
        public string MonedaFacturacion { get; set; }

        [DataMember]
        public int IdMonedaFacturacion { get; set; }

        [DataMember]
        public float ValorMercanciaDolares { get; set; }

        [DataMember]
        public float ValorMercanciaAsentadaEnFactura { get; set; }

        [DataMember]
        public string PaisFacturacion { get; set; }

        [DataMember]
        public int IdPaisFacturacion { get; set; }

        [DataMember]
        public string EntidadFederativaFacturacion { get; set; }

        [DataMember]
        public int IdEntidadFederativaFacturacion { get; set; }

        [DataMember]
        public string ClaveIdentificacionFiscalProveedor { get; set; }

        [DataMember]
        public string NombreProveedorOComprador { get; set; }

        [DataMember]
        public string CallePC { get; set; }

        [DataMember]
        public string NumeroInterioPC { get; set; }

        [DataMember]
        public string NumeroExteriorPC { get; set; }

        [DataMember]
        public string CodigoPostalPC { get; set; }

        [DataMember]
        public string MunicipioPC { get; set; }

    }
}
