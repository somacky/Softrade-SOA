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
    [DataContract]
    public abstract class CFDISATBase
    {
        [DataMember]
        public Comprobante Comprobante { get; set; }
        [DataMember]
        public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
    }
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Comprobante
    {
        public Comprobante()
        {
            this.version = "3.2";
        }

        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public Emisor Emisor { get; set; }

        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public Receptor Receptor { get; set; }

        /// <comentarios/>
        [DataMember, XmlArrayItem("Concepto")]
        public Concepto[] Conceptos { get; set; }

        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public Impuestos Impuestos { get; set; }

        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public ComplementoConcepto Complemento { get; set; }

        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public Addenda Addenda { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string version { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string serie { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string folio { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public DateTime fecha { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string sello { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string formaDePago { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string noCertificado { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string certificado { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string condicionesDePago { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal subTotal { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal descuento { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public bool descuentoSpecified { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string motivoDescuento { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string TipoCambio { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string Moneda { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal total { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public TipoDeComprobante tipoDeComprobante { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string metodoDePago { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string LugarExpedicion { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string NumCtaPago { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string FolioFiscalOrig { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string SerieFolioFiscalOrig { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public DateTime FechaFolioFiscalOrig { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public bool FechaFolioFiscalOrigSpecified { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal MontoFolioFiscalOrig { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public bool MontoFolioFiscalOrigSpecified { get; set; }
    }


    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Emisor
    {
        [DataMember, XmlElement()] private RegimenFiscal[] regimenFiscalField;

        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public t_UbicacionFiscal DomicilioFiscal { get; set; }

        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public t_Ubicacion ExpedidoEn { get; set; }

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
        [DataMember, XmlAttribute()]
        public string rfc { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string nombre { get; set; }
    }


    [DataContract]
    public partial class t_UbicacionFiscal
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string calle { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string noExterior { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string noInterior { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string colonia { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string localidad { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string referencia { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string municipio { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string estado { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string pais { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string codigoPostal { get; set; }
    }

    /// <comentarios/>

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class t_InformacionAduanera
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string numero { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public DateTime fecha { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string aduana { get; set; }
    }


    [DataContract]
    public partial class t_Ubicacion
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string calle { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string noExterior { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string noInterior { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string colonia { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string localidad { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string referencia { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string municipio { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string estado { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string pais { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string codigoPostal { get; set; }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class RegimenFiscal
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string Regimen { get; set; }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Receptor
    {
        /// <comentarios/>
        /// 
        [DataMember, XmlElement()]
        public t_Ubicacion Domicilio { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string rfc { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string nombre { get; set; }
    }

    /// <comentarios/>
    /// 
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Concepto
    {
        /// <comentarios/>


        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal cantidad { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string unidad { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string noIdentificacion { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string descripcion { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal valorUnitario { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal importe { get; set; }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComplementoConcepto
    {
        /// <comentarios/>
        [XmlAnyElement()]
        public XmlElement[] Any { get; set; }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class CuentaPredial
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string numero { get; set; }
    }

    /// <comentarios/>
    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Parte
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public t_InformacionAduanera[] InformacionAduanera { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal cantidad { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string unidad { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string noIdentificacion { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string descripcion { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal valorUnitario { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public bool valorUnitarioSpecified { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal importe { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public bool importeSpecified { get; set; }
    }

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Impuestos
    {
        /// <comentarios/>
        [DataMember]
        public Retencion[] Retenciones { get; set; }

        /// <comentarios/>
        [DataMember, XmlArrayItem("Traslado")]
        public Traslado[] Traslados { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal totalImpuestosRetenidos { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public bool totalImpuestosRetenidosSpecified { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal totalImpuestosTrasladados { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public bool totalImpuestosTrasladadosSpecified { get; set; }
    }

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Retencion
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public RetencionImpuesto impuesto { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal importe { get; set; }
    }

    /// <comentarios/>
    [DataContract]
    public enum RetencionImpuesto
    {
        [EnumMember] /// <comentarios/>
        ISR,

        [EnumMember] /// <comentarios/>
        IVA,
    }

    [DataContract]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Traslado
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public TrasladoImpuesto impuesto { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal tasa { get; set; }

        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public decimal importe { get; set; }
    }

    [DataContract]
    /// <comentarios/>        
    public enum TrasladoImpuesto
    {
        [EnumMember] /// <comentarios/>
        IVA,

        [EnumMember] /// <comentarios/>
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
    [XmlRoot(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Addenda
    {
        /// <comentarios/>
        [DataMember, XmlAttribute()]
        public string Any { get; set; }
    }

    /// <comentarios/>
    [DataContract]
    public enum TipoDeComprobante
    {
        [EnumMember] /// <comentarios/>
        ingreso,

        [EnumMember] /// <comentarios/>
        egreso,

        [EnumMember] /// <comentarios/>
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
