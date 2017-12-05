using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public abstract class ReporteadorBase
    {
        //[DataMember]
        //public string Where { get; set; }
        [DataMember]
        public int IdPedimento { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public string Empresa { get; set; }
        [DataMember]
        public string NumeroPedimentoCompleto { get; set; }
        [DataMember]
        public string NumeroPedimento { get; set; }
        [DataMember]
        public DateTime FechaPago { get; set; }
        [DataMember]
        public DateTime FechaEntrada { get; set; }
        [DataMember]
        public string Aduana { get; set; }
        [DataMember]
        public int IdAduanaSeccion { get; set; }
        [DataMember]
        public string ClavePedimento { get; set; }
        [DataMember]
        public string NumeroPatente { get; set; }
        [DataMember]
        public string NumeroPatenteYNombreAgente { get; set; }
        [DataMember]
        public string NombreAgente { get; set; }
        [DataMember]
        public bool Rectificado { get; set; }
        [DataMember]
        public int IdPartida { get; set; }
        [DataMember]
        public int NumeroPartidas { get; set; }
        [DataMember]
        public int SecuenciaPartida { get; set; }
        [DataMember]
        public string Fraccion { get; set; }
        [DataMember]
        public string DescripcionMercancia { get; set; }
        [DataMember]
        public string Proveedor { get; set; }
        [DataMember]
        public string ClavePaisOrigen { get; set; }
        [DataMember]
        public string ClavePaisOrigenDestino { get; set; }
        [DataMember]
        public string ClavePaiCompradorVendedor { get; set; }
        [DataMember]
        public string PaisOrigen { get; set; }
        [DataMember]
        public decimal ValorAduana { get; set; }
        [DataMember]
        public decimal ValorAduanaPartida { get; set; }
        [DataMember]
        public decimal IvaEfectivo0 { get; set; }
        [DataMember]
        public decimal IvaDepositoCuentaAduanera4 { get; set; }
        [DataMember]
        public decimal IvaPendientePago6 { get; set; }
        [DataMember]
        public decimal IvaCuentaAduaneraGarantia15 { get; set; }
        [DataMember]
        public decimal IvaCreditoIvaeps21 { get; set; }
        [DataMember]
        public decimal IvaGarantiaIvaIeps22 { get; set; }
        [DataMember]
        public decimal ValorDolares { get; set; }
        [DataMember]
        public decimal ValorDolaresPartida { get; set; }
        [DataMember]
        public decimal ValorMXP { get; set; }
        [DataMember]
        public double TipoCambio { get; set; }
        [DataMember]
        public double PesoBruto { get; set; }
        [DataMember]
        public decimal Fletes { get; set; }
        [DataMember]
        public decimal Seguros { get; set; }
        [DataMember]
        public decimal Embalajes { get; set; }
        [DataMember]
        public decimal OtrosIncrementables { get; set; }
        [DataMember]
        public string ClavePrevalidador { get; set; }
        [DataMember]
        public string AcuseValidacion { get; set; }
        [DataMember]
        public string FirmaElectronica { get; set; }
        [DataMember]
        public string FEA { get; set; }
        [DataMember]
        public string NombreArchivo { get; set; }
        [DataMember]
        public int NumeroPedimentos { get; set; }
        [DataMember]
        public int CantidadRegistros { get; set; }
        [DataMember]
        public bool Confirmado { get; set; }
        [DataMember]
        public decimal NumeroOperacionVUCEM { get; set; }
        [DataMember]
        public string TipoMovimiento { get; set; }
        [DataMember]
        public string ClaveAduanaSeccion { get; set; }
        [DataMember]
        public int TipoOperacion { get; set; }
        [DataMember]
        public string ClaveAduanaEntrada { get; set; }
        [DataMember]
        public string AduanaEntrada { get; set; }
        [DataMember]
        public int TransporteSalida { get; set; }
        [DataMember]
        public int TransporteArribo { get; set; }
        [DataMember]
        public int TransporteNacional { get; set; }
        [DataMember]
        public string Destino { get; set; }
        [DataMember]
        public string TipoFigura { get; set; }
        [DataMember]
        public double CantidadUMC { get; set; }
        [DataMember]
        public int ClaveUMC { get; set; }
        [DataMember]
        public string DescripcionClaveUMC { get; set; }
        [DataMember]
        public double CantidadUMT { get; set; }
        [DataMember]
        public int ClaveUMT { get; set; }
        [DataMember]
        public string DescripcionClaveUMT { get; set; }
        [DataMember]
        public string Vinculacion { get; set; }
        [DataMember]
        public string MetodoValoracion { get; set; }
        [DataMember]
        public string ListadoIdentificador { get; set; }
        [DataMember]
        public string ListadoComplemento { get; set; }
        [DataMember]
        public string ListadoPermiso { get; set; }
        [DataMember]
        public string ListadoNumeroPermiso { get; set; }
        //contribuciones
        [DataMember]
        public decimal PRV { get; set; }
        [DataMember]
        public decimal CNT { get; set; }
        [DataMember]
        public decimal DTA { get; set; }
        [DataMember]
        public decimal CC { get; set; }
        [DataMember]
        public decimal IVA { get; set; }
        [DataMember]
        public decimal ISAN { get; set; }
        [DataMember]
        public decimal IEPS { get; set; }
        [DataMember]
        public decimal IGIE { get; set; }
        [DataMember]
        public decimal REC { get; set; }
        [DataMember]
        public decimal OTROS { get; set; }
        [DataMember]
        public decimal MULT { get; set; }
        [DataMember]
        public decimal Trescientos3 { get; set; }
        [DataMember]
        public decimal RT { get; set; }
        [DataMember]
        public decimal BSS { get; set; }
        [DataMember]
        public decimal EUR { get; set; }
        [DataMember]
        public decimal REU { get; set; }
        [DataMember]
        public decimal ECI { get; set; }
        [DataMember]
        public decimal ITV { get; set; }
        [DataMember]
        public decimal MT { get; set; }
        [DataMember]
        public decimal DFC { get; set; }
        //CuentaGastos
        [DataMember]
        public string NombreEmisor { get; set; }
        [DataMember]
        public string RFCEmisor { get; set; }
        [DataMember]
        public string NumeroFactura { get; set; }
        [DataMember]
        public string NoIdentificacion { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string TipoGasto { get; set; }
        [DataMember]
        public double Monto { get; set; }
        [DataMember]
        public double MontoAgenteAduanal { get; set; }
        [DataMember]
        public double MontoAlmacenajes { get; set; }
        [DataMember]
        public double MontoDemoras { get; set; }
        [DataMember]
        public double MontoFletes { get; set; }
        [DataMember]
        public double MontoManiobras { get; set; }
        [DataMember]
        public double MontoSeguridad { get; set; }
        [DataMember]
        public double MontoOtros { get; set; }
        [DataMember]
        public int NoContenedores { get; set; }
        [DataMember]
        public decimal HonorariosAA { get; set; }
        [DataMember]
        public int TipoAduana { get; set; }
        [DataMember]
        public string TipoDeAduana { get; set; }
        [DataMember]
        public int TipoPedimento { get; set; }
        [DataMember]
        public string TipoPedimentoDescripcion { get; set; }
        [DataMember]
        public int NumeroOperaciones { get; set; }
        //Dias Despacho
        [DataMember]
        public string TipoProducto { get; set; }
        [DataMember]
        public bool ConFraccionVulnerable { get; set; }
        [DataMember]
        public bool ConIdentificadorSensible { get; set; }
        [DataMember]
        public bool ConPermisoSensible { get; set; }
        [DataMember]
        public string IntervaloNoPartidas { get; set; }
        [DataMember]
        public string PeriodoMensual { get; set; }
        [DataMember]
        public int DiasDespacho { get; set; }
        //Tasas
        [DataMember]
        public string TasaImpo { get; set; }
        [DataMember]
        public string TasaExpo { get; set; }
        [DataMember]
        public decimal MontoImpo { get; set; }
        [DataMember]
        public decimal MontoExpo { get; set; }
        //expediente digital
        [DataMember]
        public int TotalEsperado { get; set; }
        [DataMember]
        public int Cargados { get; set; }
        [DataMember]
        public int Avance { get; set; }
        //Reportes 7dias
        [DataMember]
        public decimal TotalContribuciones { get; set; }
        [DataMember]
        public string ConIncidencia { get; set; }















    }
}
