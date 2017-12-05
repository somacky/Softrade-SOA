using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.Pedimento
{
    //Registros Datos 500 y 501
    [DataContract]
    public abstract class DatosBasePedimento : PedimentoBase
    {
        //registro 500
        [DataMember]
        public int IdTipoMovimiento { get; set; }//antes tipo movimiento, este se incluye directamente
        //[DataMember]
        //public int NumeroPatente { get; set; }
        //[DataMember]
        //public int NumeroDocumento { get; set; }
        //[DataMember]
        //public int ClaveAduanaSeccion { get; set; }
        [DataMember]
        public string Acusevalidacion { get; set; }

        //Registro 501
        [DataMember]
        public int ClaveTipoOperacion { get; set; }
        [DataMember]
        public int IdTipoOperacion { get; set; }
        [DataMember]
        public string TipoPedimento { get; set; }//antes clavetramiteaduanero
        [DataMember]
        public int IdTipoPedimento { get; set; }
        [DataMember]
        public int CLaveAduanaSeccionEntradaSalida { get; set; }
        [DataMember]
        public int IdCLaveAduanaSeccionEntradaSalida { get; set; }
        [DataMember]
        public string CURPCausante { get; set; }
        [DataMember]
        public string RFCCausante { get; set; }
        [DataMember]
        public string CurpAgente { get; set; }
        [DataMember]
        public float TipoCambio { get; set; }
        [DataMember]
        public float ImporteFletes { get; set; }
        [DataMember]
        public float ImporteSeguros { get; set; }
        [DataMember]
        public float ImporteEmbalajes { get; set; }
        [DataMember]
        public float ImporteOtrosIncrementables { get; set; }
        [DataMember]
        public float PesoBruto { get; set; }
        [DataMember]
        public int ClaveMedioTrasporteSalidaAduana { get; set; }
        [DataMember]
        public int IdClaveMedioTrasporteSalidaAduana { get; set; }
        [DataMember]
        public int ClaveMedioTrasporteArriboAduana { get; set; }
        [DataMember]
        public int IdClaveMedioTrasporteArriboAduana { get; set; }
        [DataMember]
        public int ClaveMedioTrasporteEntradaSalidaMercancia { get; set; }
        [DataMember]
        public int IdClaveMedioTrasporteEntradaSalidaMercancia { get; set; }
        [DataMember]
        public int ClaveDestinoMercancia { get; set; }
        [DataMember]
        public int IdClaveDestinoMercancia { get; set; }
        [DataMember]
        public string NombreImportador { get; set; }
        [DataMember]
        public string CalleDomicilioIE { get; set; }
        [DataMember]
        public string NumeroInteriorIE { get; set; }
        [DataMember]
        public string NumeroExteriorIE { get; set; }
        [DataMember]
        public string CodigoPostalIE { get; set; }
        [DataMember]
        public string MunicipioIE { get; set; }
        [DataMember]
        public string EntidadFederativaIE { get; set; }
        [DataMember]
        public string PaisDomicilioFiscalIE { get; set; }
        [DataMember]
        public string RFCAgenteAduanal { get; set; }

        //Registro 800
        [DataMember]
        public int TipoFigura { get; set; }
        [DataMember]
        public int IdTipoFigura { get; set; }
        [DataMember]
        public string FirmaElectronicaAvanzada { get; set; }
        [DataMember]
        public string NumeroSerieCertificadoFEA { get; set; }

        //NumeroOperacion
        [DataMember]
        public long NoOperacion { get; set; }//Numero operacion de Archivo M

    }
}
