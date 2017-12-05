using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CustomSoft.Template.Modelo.Dominio.Base
{    
    public abstract class CFDISATBase
    {        
        public Comprobante Comprobante { get; set; }     
        public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
    }
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Comprobante
    {

        private Emisor emisorField;

        private Receptor receptorField;

        private Concepto[] conceptosField;

        private Impuestos impuestosField;

        private ComplementoConcepto complementoField;

        private Addenda addendaField;

        private string versionField;

        private string serieField;

        private string folioField;

        private System.DateTime fechaField;

        private string selloField;

        private string formaDePagoField;

        private string noCertificadoField;

        private string certificadoField;

        private string condicionesDePagoField;

        private decimal subTotalField;

        private decimal descuentoField;

        private bool descuentoFieldSpecified;

        private string motivoDescuentoField;

        private string tipoCambioField;

        private string monedaField;

        private decimal totalField;

        private TipoDeComprobante tipoDeComprobanteField;

        private string metodoDePagoField;

        private string lugarExpedicionField;

        private string numCtaPagoField;

        private string folioFiscalOrigField;

        private string serieFolioFiscalOrigField;

        private System.DateTime fechaFolioFiscalOrigField;

        private bool fechaFolioFiscalOrigFieldSpecified;

        private decimal montoFolioFiscalOrigField;

        private bool montoFolioFiscalOrigFieldSpecified;

        public Comprobante()
        {
            this.versionField = "3.2";
        }

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public Emisor Emisor
        {
            get
            {
                return this.emisorField;
            }
            set
            {
                this.emisorField = value;
            }
        }

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public Receptor Receptor
        {
            get
            {
                return this.receptorField;
            }
            set
            {
                this.receptorField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlArrayItemAttribute("Concepto")]
        public Concepto[] Conceptos
        {
            get
            {
                return this.conceptosField;
            }
            set
            {
                this.conceptosField = value;
            }
        }

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public Impuestos Impuestos
        {
            get
            {
                return this.impuestosField;
            }
            set
            {
                this.impuestosField = value;
            }
        }

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public ComplementoConcepto Complemento
        {
            get
            {
                return this.complementoField;
            }
            set
            {
                this.complementoField = value;
            }
        }

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public Addenda Addenda
        {
            get
            {
                return this.addendaField;
            }
            set
            {
                this.addendaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string folio
        {
            get
            {
                return this.folioField;
            }
            set
            {
                this.folioField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public System.DateTime fecha
        {
            get
            {
                return this.fechaField;
            }
            set
            {
                this.fechaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string sello
        {
            get
            {
                return this.selloField;
            }
            set
            {
                this.selloField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string formaDePago
        {
            get
            {
                return this.formaDePagoField;
            }
            set
            {
                this.formaDePagoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string noCertificado
        {
            get
            {
                return this.noCertificadoField;
            }
            set
            {
                this.noCertificadoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string certificado
        {
            get
            {
                return this.certificadoField;
            }
            set
            {
                this.certificadoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string condicionesDePago
        {
            get
            {
                return this.condicionesDePagoField;
            }
            set
            {
                this.condicionesDePagoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal subTotal
        {
            get
            {
                return this.subTotalField;
            }
            set
            {
                this.subTotalField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal descuento
        {
            get
            {
                return this.descuentoField;
            }
            set
            {
                this.descuentoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public bool descuentoSpecified
        {
            get
            {
                return this.descuentoFieldSpecified;
            }
            set
            {
                this.descuentoFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string motivoDescuento
        {
            get
            {
                return this.motivoDescuentoField;
            }
            set
            {
                this.motivoDescuentoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string TipoCambio
        {
            get
            {
                return this.tipoCambioField;
            }
            set
            {
                this.tipoCambioField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string Moneda
        {
            get
            {
                return this.monedaField;
            }
            set
            {
                this.monedaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public TipoDeComprobante tipoDeComprobante
        {
            get
            {
                return this.tipoDeComprobanteField;
            }
            set
            {
                this.tipoDeComprobanteField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string metodoDePago
        {
            get
            {
                return this.metodoDePagoField;
            }
            set
            {
                this.metodoDePagoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string LugarExpedicion
        {
            get
            {
                return this.lugarExpedicionField;
            }
            set
            {
                this.lugarExpedicionField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string NumCtaPago
        {
            get
            {
                return this.numCtaPagoField;
            }
            set
            {
                this.numCtaPagoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string FolioFiscalOrig
        {
            get
            {
                return this.folioFiscalOrigField;
            }
            set
            {
                this.folioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string SerieFolioFiscalOrig
        {
            get
            {
                return this.serieFolioFiscalOrigField;
            }
            set
            {
                this.serieFolioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public System.DateTime FechaFolioFiscalOrig
        {
            get
            {
                return this.fechaFolioFiscalOrigField;
            }
            set
            {
                this.fechaFolioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public bool FechaFolioFiscalOrigSpecified
        {
            get
            {
                return this.fechaFolioFiscalOrigFieldSpecified;
            }
            set
            {
                this.fechaFolioFiscalOrigFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal MontoFolioFiscalOrig
        {
            get
            {
                return this.montoFolioFiscalOrigField;
            }
            set
            {
                this.montoFolioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public bool MontoFolioFiscalOrigSpecified
        {
            get
            {
                return this.montoFolioFiscalOrigFieldSpecified;
            }
            set
            {
                this.montoFolioFiscalOrigFieldSpecified = value;
            }
        }
    }


    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Emisor
    {

        private t_UbicacionFiscal domicilioFiscalField;

        private t_Ubicacion expedidoEnField;

        private RegimenFiscal[] regimenFiscalField;

        private string rfcField;

        private string nombreField;

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public t_UbicacionFiscal DomicilioFiscal
        {
            get
            {
                return this.domicilioFiscalField;
            }
            set
            {
                this.domicilioFiscalField = value;
            }
        }

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public t_Ubicacion ExpedidoEn
        {
            get
            {
                return this.expedidoEnField;
            }
            set
            {
                this.expedidoEnField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlElementAttribute()]
        public RegimenFiscal[] RegimenFiscal
        {
            get
            {
                return this.regimenFiscalField;
            }
            set
            {
                this.regimenFiscalField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string rfc
        {
            get
            {
                return this.rfcField;
            }
            set
            {
                this.rfcField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }


    [DataContract]
    public partial class t_UbicacionFiscal
    {

        private string calleField;

        private string noExteriorField;

        private string noInteriorField;

        private string coloniaField;

        private string localidadField;

        private string referenciaField;

        private string municipioField;

        private string estadoField;

        private string paisField;

        private string codigoPostalField;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string calle
        {
            get
            {
                return this.calleField;
            }
            set
            {
                this.calleField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string noExterior
        {
            get
            {
                return this.noExteriorField;
            }
            set
            {
                this.noExteriorField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string noInterior
        {
            get
            {
                return this.noInteriorField;
            }
            set
            {
                this.noInteriorField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string colonia
        {
            get
            {
                return this.coloniaField;
            }
            set
            {
                this.coloniaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string referencia
        {
            get
            {
                return this.referenciaField;
            }
            set
            {
                this.referenciaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string municipio
        {
            get
            {
                return this.municipioField;
            }
            set
            {
                this.municipioField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string pais
        {
            get
            {
                return this.paisField;
            }
            set
            {
                this.paisField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string codigoPostal
        {
            get
            {
                return this.codigoPostalField;
            }
            set
            {
                this.codigoPostalField = value;
            }
        }
    }

    /// <comentarios/>

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class t_InformacionAduanera
    {

        private string numeroField;

        private System.DateTime fechaField;

        private string aduanaField;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public System.DateTime fecha
        {
            get
            {
                return this.fechaField;
            }
            set
            {
                this.fechaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string aduana
        {
            get
            {
                return this.aduanaField;
            }
            set
            {
                this.aduanaField = value;
            }
        }
    }


    [DataContract]
    public partial class t_Ubicacion
    {

        private string calleField;

        private string noExteriorField;

        private string noInteriorField;

        private string coloniaField;

        private string localidadField;

        private string referenciaField;

        private string municipioField;

        private string estadoField;

        private string paisField;

        private string codigoPostalField;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string calle
        {
            get
            {
                return this.calleField;
            }
            set
            {
                this.calleField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string noExterior
        {
            get
            {
                return this.noExteriorField;
            }
            set
            {
                this.noExteriorField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string noInterior
        {
            get
            {
                return this.noInteriorField;
            }
            set
            {
                this.noInteriorField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string colonia
        {
            get
            {
                return this.coloniaField;
            }
            set
            {
                this.coloniaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string referencia
        {
            get
            {
                return this.referenciaField;
            }
            set
            {
                this.referenciaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string municipio
        {
            get
            {
                return this.municipioField;
            }
            set
            {
                this.municipioField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string pais
        {
            get
            {
                return this.paisField;
            }
            set
            {
                this.paisField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string codigoPostal
        {
            get
            {
                return this.codigoPostalField;
            }
            set
            {
                this.codigoPostalField = value;
            }
        }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class RegimenFiscal
    {

        private string regimenField;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string Regimen
        {
            get
            {
                return this.regimenField;
            }
            set
            {
                this.regimenField = value;
            }
        }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Receptor
    {

        private t_Ubicacion domicilioField;

        private string rfcField;

        private string nombreField;

        /// <comentarios/>
        /// 
        [DataMember]
        [XmlElementAttribute()]
        public t_Ubicacion Domicilio
        {
            get
            {
                return this.domicilioField;
            }
            set
            {
                this.domicilioField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string rfc
        {
            get
            {
                return this.rfcField;
            }
            set
            {
                this.rfcField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <comentarios/>
    /// 
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Concepto
    {

        private decimal cantidadField;

        private string unidadField;

        private string noIdentificacionField;

        private string descripcionField;

        private decimal valorUnitarioField;

        private decimal importeField;

        /// <comentarios/>


        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal cantidad
        {
            get
            {
                return this.cantidadField;
            }
            set
            {
                this.cantidadField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string unidad
        {
            get
            {
                return this.unidadField;
            }
            set
            {
                this.unidadField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string noIdentificacion
        {
            get
            {
                return this.noIdentificacionField;
            }
            set
            {
                this.noIdentificacionField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal valorUnitario
        {
            get
            {
                return this.valorUnitarioField;
            }
            set
            {
                this.valorUnitarioField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComplementoConcepto
    {

        private System.Xml.XmlElement[] anyField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class CuentaPredial
    {

        private string numeroField;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Parte
    {

        private t_InformacionAduanera[] informacionAduaneraField;

        private decimal cantidadField;

        private string unidadField;

        private string noIdentificacionField;

        private string descripcionField;

        private decimal valorUnitarioField;

        private bool valorUnitarioFieldSpecified;

        private decimal importeField;

        private bool importeFieldSpecified;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public t_InformacionAduanera[] InformacionAduanera
        {
            get
            {
                return this.informacionAduaneraField;
            }
            set
            {
                this.informacionAduaneraField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal cantidad
        {
            get
            {
                return this.cantidadField;
            }
            set
            {
                this.cantidadField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string unidad
        {
            get
            {
                return this.unidadField;
            }
            set
            {
                this.unidadField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string noIdentificacion
        {
            get
            {
                return this.noIdentificacionField;
            }
            set
            {
                this.noIdentificacionField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal valorUnitario
        {
            get
            {
                return this.valorUnitarioField;
            }
            set
            {
                this.valorUnitarioField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public bool valorUnitarioSpecified
        {
            get
            {
                return this.valorUnitarioFieldSpecified;
            }
            set
            {
                this.valorUnitarioFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public bool importeSpecified
        {
            get
            {
                return this.importeFieldSpecified;
            }
            set
            {
                this.importeFieldSpecified = value;
            }
        }
    }

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Impuestos
    {

        private Retencion[] retencionesField;

        private Traslado[] trasladosField;

        private decimal totalImpuestosRetenidosField;

        private bool totalImpuestosRetenidosFieldSpecified;

        private decimal totalImpuestosTrasladadosField;

        private bool totalImpuestosTrasladadosFieldSpecified;

        /// <comentarios/>
        [DataMember]
        public Retencion[] Retenciones
        {
            get
            {
                return this.retencionesField;
            }
            set
            {
                this.retencionesField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlArrayItemAttribute("Traslado")]
        public Traslado[] Traslados
        {
            get
            {
                return this.trasladosField;
            }
            set
            {
                this.trasladosField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal totalImpuestosRetenidos
        {
            get
            {
                return this.totalImpuestosRetenidosField;
            }
            set
            {
                this.totalImpuestosRetenidosField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public bool totalImpuestosRetenidosSpecified
        {
            get
            {
                return this.totalImpuestosRetenidosFieldSpecified;
            }
            set
            {
                this.totalImpuestosRetenidosFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal totalImpuestosTrasladados
        {
            get
            {
                return this.totalImpuestosTrasladadosField;
            }
            set
            {
                this.totalImpuestosTrasladadosField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public bool totalImpuestosTrasladadosSpecified
        {
            get
            {
                return this.totalImpuestosTrasladadosFieldSpecified;
            }
            set
            {
                this.totalImpuestosTrasladadosFieldSpecified = value;
            }
        }
    }

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Retencion
    {

        private RetencionImpuesto impuestoField;

        private decimal importeField;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public RetencionImpuesto impuesto
        {
            get
            {
                return this.impuestoField;
            }
            set
            {
                this.impuestoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <comentarios/>

    public enum RetencionImpuesto
    {

        /// <comentarios/>
        ISR,

        /// <comentarios/>
        IVA,
    }

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Traslado
    {

        private TrasladoImpuesto impuestoField;

        private decimal tasaField;

        private decimal importeField;

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public TrasladoImpuesto impuesto
        {
            get
            {
                return this.impuestoField;
            }
            set
            {
                this.impuestoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal tasa
        {
            get
            {
                return this.tasaField;
            }
            set
            {
                this.tasaField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        [XmlAttributeAttribute()]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <comentarios/>
    public enum TrasladoImpuesto
    {

        /// <comentarios/>
        IVA,

        /// <comentarios/>
        IEPS,
    }

    /*
    /// <comentarios/>
  [DataContract]
  [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Complemento
    {

        private TimbreFiscalDigital timbre;


        public TimbreFiscalDigital TimbreFiscalDigital
        {
            get
            {
                return this.timbre;
            }
            set
            {
                this.timbre =value ;
            }
        }
    }
*/
    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Addenda
    {

        private string anyField;

        /// <comentarios/>

        [DataMember]
        [XmlAttributeAttribute()]
        public string Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <comentarios/>

    public enum TipoDeComprobante
    {

        /// <comentarios/>
        ingreso,

        /// <comentarios/>
        egreso,

        /// <comentarios/>
        traslado,
    }
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable = false)]

    [DataContract]
    public class TimbreFiscalDigital
    {
        [DataMember, XmlElement()]
        private string versionField;
        [DataMember, XmlElement()]
        private string uUIDField;
        [DataMember, XmlElement()]
        private System.DateTime fechaTimbradoField;
        [DataMember, XmlElement()]
        private string selloCFDField;
        [DataMember, XmlElement()]
        private string noCertificadoSATField;
        [DataMember, XmlElement()]
        private string selloSATField;


        public TimbreFiscalDigital()
        {
            this.versionField = "1.0";
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string UUID
        {
            get
            {
                return this.uUIDField;
            }
            set
            {
                this.uUIDField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public System.DateTime FechaTimbrado
        {
            get
            {
                return this.fechaTimbradoField;
            }
            set
            {
                this.fechaTimbradoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string selloCFD
        {
            get
            {
                return this.selloCFDField;
            }
            set
            {
                this.selloCFDField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noCertificadoSAT
        {
            get
            {
                return this.noCertificadoSATField;
            }
            set
            {
                this.noCertificadoSATField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string selloSAT
        {
            get
            {
                return this.selloSATField;
            }
            set
            {
                this.selloSATField = value;
            }
        }
    }
    /*
        [DataContract]
        [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital"), ]
        public partial class TimbreFiscalDigital
        {
            private string version1;
            private string uuid;
            private System.DateTime fechaTimbrado;
            private string selloCFD1;
            private string noCertificadoSAT1;
            private string selloSAT1;

            [DataMember]
            [XmlAttributeAttribute()]
            public string version
            {
                get
                {
                    return this.version1;
                }
                set
                {
                    this.version1 = value;
                }
            }

            [DataMember]
            [XmlAttributeAttribute()]
            public string UUID
            {
                get
                {
                    return this.uuid;
                }
                set
                {
                    this.uuid = value;
                }
            }
            [DataMember]
            [XmlAttributeAttribute()]
            public System.DateTime FechaTimbrado
            {
                get
                {
                    return this.fechaTimbrado;
                }
                set
                {
                    this.fechaTimbrado = value;
                }
            }
            [DataMember]
            [XmlAttributeAttribute()]
            public string selloCFD
            {
                get
                {
                    return this.selloCFD1;
                }
                set
                {
                    this.selloCFD1 = value;
                }
            }
            [DataMember]
            [XmlAttributeAttribute()]
            public string noCertificadoSAT
            {
                get
                {
                    return this.noCertificadoSAT1;
                }
                set
                {
                    this.noCertificadoSAT1 = value;
                }
            }
            [DataMember]
            [XmlAttributeAttribute()]
            public string selloSAT
            {
                get
                {
                    return this.selloSAT1;
                }
                set
                {
                    this.selloSAT1 = value;
                }
            }   

        }
         */


}
