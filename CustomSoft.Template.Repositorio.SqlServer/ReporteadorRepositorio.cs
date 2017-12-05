using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class ReporteadorRepositorio : IReporteadorRepositorio
    {
        private SqlHelper helper = null;
        public ReporteadorRepositorio()
        {
            helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));
        }

        private string baseDatos = string.Empty;
        public void InicializaConexion(int pIdEmpresa)
        {
            baseDatos = Util.DameBDxIdEmpresa(pIdEmpresa);
            //pBaseDatos = "BASFPrueba";
            //return new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));

            //Leo la conexion que se tiene en el WEbconfig
            var conexion = ConfigurationManager.ConnectionStrings["cnSqlServerEmpresas"].ConnectionString;

            //sustituyo el parametro por la base de datos a pegarle
            var conexionparametrizada = string.Format(conexion, baseDatos);
            helper = new SqlHelper(conexionparametrizada);
            //where += pIdEmpresa;
            //return helper;
        }

        //private string where = " WHERE PED.IdEmpresavw =  ";
        #region Metodos Privados
        /// <summary>
        /// Funcion que busca en base de datos la infomcacion para el Reporte Iva Pagado Nivel Partida
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteIvaNPartida(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_IvaPagadoNivelPartida");

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    FechaPago = reader.GetDateTime(reader.GetOrdinal("FechaPago")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("NombreAgente")),
                    Rectificado = reader.GetBoolean(reader.GetOrdinal("Rectificado")),
                    IdPartida = reader.GetInt32(reader.GetOrdinal("IdPartida")),
                    SecuenciaPartida = reader.GetInt32(reader.GetOrdinal("SecuenciaPartida")),
                    Fraccion = reader.GetString(reader.GetOrdinal("Fraccion")),
                    DescripcionMercancia = reader.GetString(reader.GetOrdinal("DescripcionMercancia")),
                    Proveedor = reader.GetString(reader.GetOrdinal("Proveedor")),
                    ClavePaisOrigen = reader.GetString(reader.GetOrdinal("ClavePaisOrigen")),
                    PaisOrigen = reader.GetString(reader.GetOrdinal("PaisOrigen")),
                    ValorAduana = reader.GetDecimal(reader.GetOrdinal("ValorAduanaPartida")),
                    IvaEfectivo0 = reader.GetDecimal(reader.GetOrdinal("IvaEfectivo0")),
                    IvaDepositoCuentaAduanera4 = reader.GetDecimal(reader.GetOrdinal("IvaDepositoCuentaAduanera4")),
                    IvaPendientePago6 = reader.GetDecimal(reader.GetOrdinal("IvaPendientePago6")),
                    IvaCuentaAduaneraGarantia15 = reader.GetDecimal(reader.GetOrdinal("IvaCuentaAduaneraGarantia15")),
                    IvaCreditoIvaeps21 = reader.GetDecimal(reader.GetOrdinal("IvaCreditoIvaIeps21")),
                    IvaGarantiaIvaIeps22 = reader.GetDecimal(reader.GetOrdinal("IvaGarantiaIvaIeps22"))

                });
            }
            reader.Close();
            return ListaReporte;
        }
       
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_IvaPagadoNivelPedimento
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteIvaNPedimento(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_IvaPagadoNivelPedimento");

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    FechaPago = reader.GetDateTime(reader.GetOrdinal("FechaPago")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    ValorDolares = reader.GetDecimal(reader.GetOrdinal("ValorDolares")),
                    ValorAduana = reader.GetDecimal(reader.GetOrdinal("ValorAduana")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("NombreAgente")),
                    Rectificado = reader.GetBoolean(reader.GetOrdinal("Rectificado")),
                    Proveedor = reader.GetString(reader.GetOrdinal("Proveedor")),
                    IvaEfectivo0 = reader.GetDecimal(reader.GetOrdinal("IvaEfectivo0")),
                    IvaDepositoCuentaAduanera4 = reader.GetDecimal(reader.GetOrdinal("IvaDepositoCuentaAduanera4")),
                    IvaPendientePago6 = reader.GetDecimal(reader.GetOrdinal("IvaPendientePago6")),
                    IvaCuentaAduaneraGarantia15 = reader.GetDecimal(reader.GetOrdinal("IvaCuentaAduaneraGarantia15")),
                    IvaCreditoIvaeps21 = reader.GetDecimal(reader.GetOrdinal("IvaCreditoIvaIeps21")),
                    IvaGarantiaIvaIeps22 = reader.GetDecimal(reader.GetOrdinal("IvaGarantiaIvaIeps22"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_OperacionNivelPartida
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteOperacionNPartida(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));            
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_OperacionNivelPartida", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    NumeroPedimento = reader.GetString(reader.GetOrdinal("Pedimento")),
                    IdAduanaSeccion = reader.GetInt32(reader.GetOrdinal("IdAduanaSeccionVW")),
                    TipoCambio = reader.GetDouble(reader.GetOrdinal("TipoCambio")),
                    PesoBruto = reader.GetDouble(reader.GetOrdinal("PesoBruto")),
                    ValorAduana = reader.GetDecimal(reader.GetOrdinal("ValorAduanaPedimento")),
                    ValorDolares = reader.GetDecimal(reader.GetOrdinal("ValorUSD")),
                    ValorMXP = reader.GetDecimal(reader.GetOrdinal("ValorMXP")),
                    Fletes = reader.GetDecimal(reader.GetOrdinal("Fletes")),
                    Seguros = reader.GetDecimal(reader.GetOrdinal("Seguros")),
                    Embalajes = reader.GetDecimal(reader.GetOrdinal("Embalajes")),
                    OtrosIncrementables = reader.GetDecimal(reader.GetOrdinal("OtrosIncrementables")),
                    ClavePrevalidador = reader.GetString(reader.GetOrdinal("ClavePrevalidador")),
                    AcuseValidacion = reader.GetString(reader.GetOrdinal("AcuseValidacion")),
                    FirmaElectronica = reader.GetString(reader.GetOrdinal("FirmaElectronica")),
                    FEA = reader.GetString(reader.GetOrdinal("NoSerieCertificadoFEA")),
                    NombreArchivo = reader.GetString(reader.GetOrdinal("NombreArchivo")),
                    NumeroPedimentos = reader.GetInt32(reader.GetOrdinal("NoPedimentos")),
                    CantidadRegistros = reader.GetInt32(reader.GetOrdinal("CantidadRegistros")),
                    Confirmado = reader.GetBoolean(reader.GetOrdinal("Confimardo")),
                    NumeroOperacionVUCEM = reader.GetDecimal(reader.GetOrdinal("NumeroOperacionVUCEM")),
                    Rectificado = reader.GetBoolean(reader.GetOrdinal("Rectificado")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    TipoMovimiento = reader.GetString(reader.GetOrdinal("TipoMovimiento")),
                    ClaveAduanaSeccion = reader.GetString(reader.GetOrdinal("ClaveAduanaSeccion")),
                    Aduana = reader.GetString(reader.GetOrdinal("AduanaSeccion")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    ClaveAduanaEntrada = reader.GetString(reader.GetOrdinal("ClaveAduanaEntrada")),
                    AduanaEntrada = reader.GetString(reader.GetOrdinal("AduanaEntrada")),
                    TransporteSalida = reader.GetInt32(reader.GetOrdinal("MedioTransporteSalida")),
                    TransporteArribo = reader.GetInt32(reader.GetOrdinal("MedioTransporteArribo")),
                    TransporteNacional = reader.GetInt32(reader.GetOrdinal("MedioTransporteNacional")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("NombreAgente")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    Destino = reader.GetString(reader.GetOrdinal("Destino")),
                    TipoFigura = reader.GetString(reader.GetOrdinal("TipoFigura")),
                    IdPartida = reader.GetInt32(reader.GetOrdinal("IdPartida")),
                    SecuenciaPartida = reader.GetInt32(reader.GetOrdinal("SecuenciaPartida")),
                    Fraccion = reader.GetString(reader.GetOrdinal("Fraccion")),
                    DescripcionMercancia = reader.GetString(reader.GetOrdinal("DescripcionMercancia")),
                    ValorAduanaPartida = reader.GetDecimal(reader.GetOrdinal("ValorAduanaPartida")),
                    ValorDolaresPartida = reader.GetDecimal(reader.GetOrdinal("ValorDolares")),
                    CantidadUMC = reader.GetDouble(reader.GetOrdinal("CantidaUMC")),
                    ClaveUMC = reader.GetInt32(reader.GetOrdinal("ClaveUMC")),
                    DescripcionClaveUMC = reader.GetString(reader.GetOrdinal("DescripcionUMC")),
                    CantidadUMT = reader.GetDouble(reader.GetOrdinal("CantidadUMT")),
                    ClaveUMT = reader.GetInt32(reader.GetOrdinal("ClaveUMT")),
                    DescripcionClaveUMT = reader.GetString(reader.GetOrdinal("DescripcionUMT")),
                    Vinculacion = reader.GetString(reader.GetOrdinal("Vinculacion")),
                    MetodoValoracion = reader.GetString(reader.GetOrdinal("MetodoValoracion")),
                    ClavePaisOrigenDestino = reader.GetString(reader.GetOrdinal("ClavePaisOrigenDestino")),
                    ClavePaiCompradorVendedor = reader.GetString(reader.GetOrdinal("ClavePaisCopradorVendedor")),
                    ListadoIdentificador = reader.GetString(reader.GetOrdinal("ListadoIdentificador")),
                    ListadoComplemento = reader.GetString(reader.GetOrdinal("ListadoComplemento")),
                    ListadoNumeroPermiso = reader.GetString(reader.GetOrdinal("ListadoNumeroPermiso")),
                    ListadoPermiso = reader.GetString(reader.GetOrdinal("ListadoPermiso")),

                    PRV = reader.GetDecimal(reader.GetOrdinal("PRV")),
                    CNT = reader.GetDecimal(reader.GetOrdinal("CNT")),
                    DTA = reader.GetDecimal(reader.GetOrdinal("DTA")),
                    CC = reader.GetDecimal(reader.GetOrdinal("CC")),
                    IVA = reader.GetDecimal(reader.GetOrdinal("IVA")),
                    ISAN = reader.GetDecimal(reader.GetOrdinal("ISAN")),
                    IEPS = reader.GetDecimal(reader.GetOrdinal("IEPS")),
                    IGIE = reader.GetDecimal(reader.GetOrdinal("IGIE")),
                    REC = reader.GetDecimal(reader.GetOrdinal("REC")),
                    OTROS = reader.GetDecimal(reader.GetOrdinal("OTROS")),
                    MULT = reader.GetDecimal(reader.GetOrdinal("MULT")),
                    Trescientos3 = reader.GetDecimal(reader.GetOrdinal("Trescientos3")),
                    RT = reader.GetDecimal(reader.GetOrdinal("RT")),
                    BSS = reader.GetDecimal(reader.GetOrdinal("BSS")),
                    EUR = reader.GetDecimal(reader.GetOrdinal("EUR")),
                    REU = reader.GetDecimal(reader.GetOrdinal("REU")),
                    ECI = reader.GetDecimal(reader.GetOrdinal("ECI")),
                    ITV = reader.GetDecimal(reader.GetOrdinal("ITV")),
                    MT = reader.GetDecimal(reader.GetOrdinal("MT")),
                    DFC = reader.GetDecimal(reader.GetOrdinal("DFC")),
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_ResumenOperaciones
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteResumenOperaciones(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_ResumenOperaciones");

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    TipoMovimiento = reader.GetString(reader.GetOrdinal("TipoMovimiento")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    TipoDeAduana = reader.GetString(reader.GetOrdinal("TipoAduana")),
                    NumeroPatenteYNombreAgente = reader.GetString(reader.GetOrdinal("Patente")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    TipoPedimentoDescripcion = reader.GetString(reader.GetOrdinal("TipoPedimento")),
                    NumeroOperaciones = reader.GetInt32(reader.GetOrdinal("Operaciones"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_OperacionNivelPedimento
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteOperacionNPedimento(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_OperacionNivelPedimento", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    NumeroPedimento = reader.GetString(reader.GetOrdinal("Pedimento")),
                    IdAduanaSeccion = reader.GetInt32(reader.GetOrdinal("IdAduanaSeccionVW")),
                    TipoCambio = reader.GetDouble(reader.GetOrdinal("TipoCambio")),
                    PesoBruto = reader.GetDouble(reader.GetOrdinal("PesoBruto")),
                    ValorAduana = reader.GetDecimal(reader.GetOrdinal("ValorAduana")),
                    ValorDolares = reader.GetDecimal(reader.GetOrdinal("ValorUSD")),
                    ValorMXP = reader.GetDecimal(reader.GetOrdinal("ValorMXP")),
                    Fletes = reader.GetDecimal(reader.GetOrdinal("Fletes")),
                    Seguros = reader.GetDecimal(reader.GetOrdinal("Seguros")),
                    Embalajes = reader.GetDecimal(reader.GetOrdinal("Embalajes")),
                    OtrosIncrementables = reader.GetDecimal(reader.GetOrdinal("Otros")),
                    ClavePrevalidador = reader.GetString(reader.GetOrdinal("ClavePrevalidador")),
                    AcuseValidacion = reader.GetString(reader.GetOrdinal("AcuseValidacion")),
                    FirmaElectronica = reader.GetString(reader.GetOrdinal("FirmaElectronica")),
                    FEA = reader.GetString(reader.GetOrdinal("NoSerieCertificadoFEA")),
                    NombreArchivo = reader.GetString(reader.GetOrdinal("NombreArchivo")),
                    NumeroPedimentos = reader.GetInt32(reader.GetOrdinal("NoPedimentos")),
                    CantidadRegistros = reader.GetInt32(reader.GetOrdinal("CantidadRegistros")),
                    Confirmado = reader.GetBoolean(reader.GetOrdinal("Confimardo")),
                    NumeroOperacionVUCEM = reader.GetDecimal(reader.GetOrdinal("NumeroOperacionVUCEM")),
                    Rectificado = reader.GetBoolean(reader.GetOrdinal("Rectificado")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    TipoMovimiento = reader.GetString(reader.GetOrdinal("TipoMovimiento")),
                    ClaveAduanaSeccion = reader.GetString(reader.GetOrdinal("ClaveAduanaSeccion")),
                    Aduana = reader.GetString(reader.GetOrdinal("AduanaSeccion")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    ClaveAduanaEntrada = reader.GetString(reader.GetOrdinal("ClaveAduanaEntrada")),
                    AduanaEntrada = reader.GetString(reader.GetOrdinal("AduanaEntrada")),
                    TransporteSalida = reader.GetInt32(reader.GetOrdinal("MedioTransporteSalida")),
                    TransporteArribo = reader.GetInt32(reader.GetOrdinal("MedioTransporteArribo")),
                    TransporteNacional = reader.GetInt32(reader.GetOrdinal("MedioTransporteNacional")),
                    NumeroPatente = reader.GetString(reader.GetOrdinal("NumeroPatente")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("NombreAgente")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    Destino = reader.GetString(reader.GetOrdinal("Destino")),
                    TipoFigura = reader.GetString(reader.GetOrdinal("TipoFigura")),
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_CuentaGastoDetallado
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteCuentaGastosDetallado(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            parametros.Add(new SqlParameterItem("@pWhereCuentaGasto", SqlDbType.VarChar, 800, pWhere.WhereCuentaGasto));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_CuentaGastoDetallado", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    TipoMovimiento = reader.GetString(reader.GetOrdinal("TipoMovimiento")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("AgenteAduanal")),
                    NombreEmisor = reader.GetString(reader.GetOrdinal("NombreEmisor")),
                    RFCEmisor = reader.GetString(reader.GetOrdinal("RFCEmisor")),
                    NumeroFactura = reader.GetString(reader.GetOrdinal("NumeroFactura")),
                    NoIdentificacion = reader.GetString(reader.GetOrdinal("NoIdentificacion")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    TipoGasto = reader.GetString(reader.GetOrdinal("TipoGasto")),
                    Monto = reader.GetDouble(reader.GetOrdinal("Monto")),
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_CuentaGastoTotalizado
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteCuentaGastosTotalizado(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            parametros.Add(new SqlParameterItem("@pWhereCuentaGasto", SqlDbType.VarChar, 800, pWhere.WhereCuentaGasto));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_CuentaGastoTotalizado", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    TipoMovimiento = reader.GetString(reader.GetOrdinal("TipoMovimiento")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("AgenteAduanal")),
                    MontoAgenteAduanal = reader.GetDouble(reader.GetOrdinal("MontoAgenteAduanal")),
                    MontoAlmacenajes = reader.GetDouble(reader.GetOrdinal("MontoAlmacenajes")),
                    MontoDemoras = reader.GetDouble(reader.GetOrdinal("MontoDemoras")),
                    MontoFletes = reader.GetDouble(reader.GetOrdinal("MontoFlete")),
                    MontoManiobras = reader.GetDouble(reader.GetOrdinal("MontoManiobras")),
                    MontoSeguridad = reader.GetDouble(reader.GetOrdinal("MontoSeguridad")),
                    MontoOtros = reader.GetDouble(reader.GetOrdinal("MontoOtros"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_DiasDespacho
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteDiasDespacho(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_DiasDespacho", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("AgenteAduanal")),
                    TipoProducto = reader.GetString(reader.GetOrdinal("TipoProducto")),
                    ConFraccionVulnerable = reader.GetBoolean(reader.GetOrdinal("ConFraccionVulnerable")),
                    ConIdentificadorSensible = reader.GetBoolean(reader.GetOrdinal("ConIdentificadorSensible")),
                    ConPermisoSensible = reader.GetBoolean(reader.GetOrdinal("ConPermisoSensible")),
                    IntervaloNoPartidas = reader.GetString(reader.GetOrdinal("IntervaloNoPartidas")),
                    PeriodoMensual = reader.GetString(reader.GetOrdinal("PeriodoMensual")),
                    DiasDespacho = reader.GetInt32(reader.GetOrdinal("DiasDespacho"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_VerificacionCuentaGastoAA
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteVerificacionCGAgenteA(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_VerificacionCuentaGastoAA", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    TipoMovimiento = reader.GetString(reader.GetOrdinal("TipoMovimiento")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    TipoDeAduana = reader.GetString(reader.GetOrdinal("TipoAduana")),
                    NumeroPatenteYNombreAgente = reader.GetString(reader.GetOrdinal("Patente")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    TipoPedimentoDescripcion = reader.GetString(reader.GetOrdinal("TipoPedimento")),
                    FechaPago = reader.GetDateTime(reader.GetOrdinal("FechaPago")),
                    PeriodoMensual = reader.GetString(reader.GetOrdinal("PeriodoMensual")),
                    NoContenedores = reader.GetInt32(reader.GetOrdinal("NoContenedores")),
                    IntervaloNoPartidas = reader.GetString(reader.GetOrdinal("IntervaloNoPartidas")),
                    HonorariosAA = reader.GetDecimal(reader.GetOrdinal("HonorariosAA"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_Anexo9DictamenFiscal
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteAnexo9DictamenFiscal(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();            
            parametros.Add(new SqlParameterItem("@pWhere", SqlDbType.VarChar, 800, pWhere.Where));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_Anexo9DictamenFiscal");

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    TasaImpo = reader.GetString(reader.GetOrdinal("TasasImpo")),
                    TasaExpo = reader.GetString(reader.GetOrdinal("TasasExpo"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_Anexo18DictamenFiscal
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteAnexo18DictamenFiscal(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, pWhere.IdUsuario));
            parametros.Add(new SqlParameterItem("@pWherePedimento", SqlDbType.VarChar, 800, pWhere.WherePedimento));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_Anexo18DictamenFiscal");

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    MontoImpo = reader.GetDecimal(reader.GetOrdinal("MontoImpo")),
                    MontoExpo = reader.GetDecimal(reader.GetOrdinal("MontoExpo"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        /// <summary>
        /// Funcion que invoca en la base de datos el store procedure usp_Reporte_EstatusExpedienteDigital
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private List<DatosReporte> ConsultaReporteEstatusExpedienteDigital(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@IdPedimento", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@IdEmpresaVW", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@IdTipoOperacionVW", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@IdClavePedimentoVW", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@Empresa", SqlDbType.VarChar, 120, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@NumeroPedimentoCompleto", SqlDbType.VarChar, 20, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@Aduana", SqlDbType.VarChar, 255, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@TipoOperacion", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@ClavePedimento", SqlDbType.VarChar, 3, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@AgenteAduanal", SqlDbType.VarChar, 120, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@TotalEsperado", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@Cargados", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@Avance", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@pWhere", SqlDbType.VarChar, 500, pWhere.Where));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_EstatusExpedienteDigital");

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    IdEmpresa = reader.GetInt32(reader.GetOrdinal("IdEmpresaVW")),
                    Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    TipoOperacion = reader.GetInt32(reader.GetOrdinal("TipoOperacion")),
                    ClavePedimento = reader.GetString(reader.GetOrdinal("ClavePedimento")),
                    NombreAgente = reader.GetString(reader.GetOrdinal("AgenteAduanal")),
                    TotalEsperado = reader.GetInt32(reader.GetOrdinal("TotalEsperado")),
                    Cargados = reader.GetInt32(reader.GetOrdinal("Cargados")),
                    Avance = reader.GetInt32(reader.GetOrdinal("Avance"))
                });
            }
            reader.Close();
            return ListaReporte;
        }

        private List<DatosReporte> ConsultaReporteContribucionesMis7(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@Fecha", SqlDbType.VarChar, 20, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@IVA", SqlDbType.Decimal, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@IGI", SqlDbType.Decimal, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@CC", SqlDbType.Decimal, 0, ParameterDirection.ReturnValue));
            //parametros.Add(new SqlParameterItem("@DTA", SqlDbType.Decimal, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@ISAN", SqlDbType.Decimal, 120, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@Otros", SqlDbType.Decimal, 20, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, false, ParameterDirection.Output));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_ContribucionesMis7", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    FechaPago = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                    IVA = reader.GetDecimal(reader.GetOrdinal("IVA")),
                    IGIE = reader.GetDecimal(reader.GetOrdinal("IGI")),//DUDA
                    CC = reader.GetDecimal(reader.GetOrdinal("CC")),
                    //DTA = reader.GetDecimal(reader.GetOrdinal("DTA")),
                    ISAN = reader.GetDecimal(reader.GetOrdinal("ISAN")),
                    OTROS = reader.GetDecimal(reader.GetOrdinal("Otros"))
                });
            }
            reader.Close();
            return ListaReporte;
        }

        private List<DatosReporte> ConsultaReporteDiasDespachoMis7(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@Aduana", SqlDbType.VarChar, 255, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@DiasDespacho", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, 0, ParameterDirection.InputOutput));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_DiasDespachoMis7", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    DiasDespacho = reader.GetInt32(reader.GetOrdinal("DiasDespacho")),
                    NumeroOperaciones = reader.GetInt32(reader.GetOrdinal("NumeroOperaciones"))
                });
            }
            reader.Close();
            return ListaReporte;
        }

        private List<DatosReporte> ConsultaReporteOperacionesMis7(ReporteadorEntidad pWhere)
        {
            var ListaReporte = new List<DatosReporte>();
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@IdPedimento", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@NumeroPedimentoCompleto", SqlDbType.VarChar, 20, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@Aduana", SqlDbType.VarChar, 255, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@Patente", SqlDbType.VarChar, 25, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@FechaEntrada", SqlDbType.VarChar, 20, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@FechaPago", SqlDbType.VarChar, 20, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@TotalContribuciones", SqlDbType.Decimal, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@NoPartidas", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@DiasDespacho", SqlDbType.SmallInt, 0, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@TipoProducto", SqlDbType.VarChar, 120, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@ConIncidencia", SqlDbType.VarChar, 3, ParameterDirection.ReturnValue));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, 0, ParameterDirection.InputOutput));
            InicializaConexion(pWhere.IdEmpresa);
            var reader = helper.ExecuteReader("usp_Reporte_OperacionesMis7", parametros);

            while (reader.Read())
            {
                ListaReporte.Add(new DatosReporte()
                {
                    IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                    NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                    Aduana = reader.GetString(reader.GetOrdinal("Aduana")),
                    NumeroPatenteYNombreAgente = reader.GetString(reader.GetOrdinal("Patente")),
                    FechaEntrada = reader.GetDateTime(reader.GetOrdinal("FechaEntrada")),
                    FechaPago = reader.GetDateTime(reader.GetOrdinal("FechaPago")),
                    TotalContribuciones = reader.GetDecimal(reader.GetOrdinal("TotalContribuciones")),
                    NumeroPartidas = reader.GetInt32(reader.GetOrdinal("NoPartidas")),
                    DiasDespacho = reader.GetInt32(reader.GetOrdinal("DiasDespacho")),
                    TipoProducto = reader.GetString(reader.GetOrdinal("TipoProducto")),
                    ConIncidencia = reader.GetString(reader.GetOrdinal("ConIncidencia"))
                });
            }
            reader.Close();
            return ListaReporte;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_IvaPagadoNivelPartida agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteIvaNPartida(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteIvaNPartida(pWhere);
            return response;

        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_IvaPagadoNivelPedimento agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteIvaNPedimento(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteIvaNPedimento(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_OperacionNivelPartida agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteOperNPartida(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteOperacionNPartida(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_IvaPagadoNivelPedimento agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteOperNPedimento(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteOperacionNPedimento(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_ResumenOperaciones agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteResumenOper(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteResumenOperaciones(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_CuentaGastoDetallado agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteCGDetallado(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteCuentaGastosDetallado(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_CuentaGastoTotalizado agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteCGTotalizado(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteCuentaGastosTotalizado(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_DiasDespacho agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteDiasDespacho(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteDiasDespacho(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_VerificacionCuentaGastoAA agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteCGAgenteAduanal(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteVerificacionCGAgenteA(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_Anexo18DictamenFiscal agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReportaAnexo18(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteAnexo18DictamenFiscal(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_Anexo9DictamenFiscal agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteAnexo9(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteAnexo9DictamenFiscal(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_EstatusExpedienteDigital agregando informacion a entidad
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteEstatusExpedienteDigital(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteEstatusExpedienteDigital(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_ContribucionesMis7 agregando informacion a entidad
        /// </summary>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteContribucionesMis7(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteContribucionesMis7(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_DiasDespachoMis7 agregando informacion a entidad
        /// </summary>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteDiasDespachoMis7(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteDiasDespachoMis7(pWhere);
            return response;
        }
        /// <summary>
        /// Funcion que ejecuta store usp_Reporte_OperacionesMis7 agregando informacion a entidad 
        /// </summary>
        /// <returns></returns>
        public ReporteadorEntidad DameDatosReporteOperacionesMis7(ReporteadorEntidad pWhere)
        {
            ReporteadorEntidad response = new ReporteadorEntidad();
            response.Informacion = ConsultaReporteOperacionesMis7(pWhere);
            return response;
        }

        #endregion

        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
