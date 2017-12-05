﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class OperacionPedimentoRepositorio : IOperacionPedimentoRepositorio
    {
        private SqlHelper helper = null;

        //public OperacionPedimentoRepositorio()
        //{
        //    //helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));
        //}

        public SqlHelper InicializaConexion(int pIdEmpresa)
        {
            pBaseDatos = Util.DameBDxIdEmpresa(pIdEmpresa);
            //return new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));

            //Leo la conexion que se tiene en el WEbconfig
            var conexion = ConfigurationManager.ConnectionStrings["cnSqlServerEmpresas"].ConnectionString;
            //sustituyo el parametro por la base de datos a pegarle
            var conexionparametrizada = string.Format(conexion, pBaseDatos);
            helper = new SqlHelper(conexionparametrizada);
            return helper;
        }

        //Variabel gloobal de Base de datos
        private string pBaseDatos = string.Empty;
        #region Metodos Privados

        private int vContadorPedimento = 0;
        private int vContadorPartida = 0;

        /// <summary>
        /// Inserta Registro 500, 501, 800 y 801  insertando el IdPedimento 
        /// </summary>
        /// <param name="pedimento"></param>
        /// <param name="IdUsuarioEjecucion"></param>
        /// <param name="NombreArchivo"></param>
        /// <param name="numerooperacion"></param>
        /// <returns></returns>ImporteFletes
        private bool InsertaEnTablaPedimento(ArchivoM pedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdTipoMovimientoVW", SqlDbType.Int, pedimento.IdTipoMovimiento));
                parametros.Add(new SqlParameterItem("@pPedimento", SqlDbType.VarChar, 10, pedimento.NumeroPedimento));
                parametros.Add(new SqlParameterItem("@pIdAduanaSeccionVW", SqlDbType.Int, pedimento.IdAduanaSeccionVW));
                parametros.Add(new SqlParameterItem("@pIdTipoOperacionVW", SqlDbType.Int, pedimento.IdTipoOperacion));
                parametros.Add(new SqlParameterItem("@pIdClavePedimentoVW", SqlDbType.Int, pedimento.IdTipoPedimento));
                parametros.Add(new SqlParameterItem("@pIdAduanaSeccionESVW", SqlDbType.Int, pedimento.IdCLaveAduanaSeccionEntradaSalida));
                parametros.Add(new SqlParameterItem("@pIdTransporteSalidaVW", SqlDbType.Int, pedimento.IdClaveMedioTrasporteSalidaAduana));
                parametros.Add(new SqlParameterItem("@pIdTransporteArriboVW", SqlDbType.Int, pedimento.IdClaveMedioTrasporteArriboAduana));
                parametros.Add(new SqlParameterItem("@pIdTransporteNacionalVW", SqlDbType.Int, pedimento.IdClaveMedioTrasporteEntradaSalidaMercancia));//CAMBIO ROBER NUEVO
                parametros.Add(new SqlParameterItem("@pTipoCambio", SqlDbType.Float, pedimento.TipoCambio));
                parametros.Add(new SqlParameterItem("@pPesoBruto", SqlDbType.Float, pedimento.PesoBruto));
                parametros.Add(new SqlParameterItem("@pValorAduana", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pValorUSD", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pValorMXP", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pFletes", SqlDbType.Float, pedimento.ImporteFletes));
                parametros.Add(new SqlParameterItem("@pSeguros", SqlDbType.Float, pedimento.ImporteSeguros));
                parametros.Add(new SqlParameterItem("@pEmbalajes", SqlDbType.Float, pedimento.ImporteEmbalajes));
                parametros.Add(new SqlParameterItem("@pOtros", SqlDbType.Float, pedimento.ImporteOtrosIncrementables));
                parametros.Add(new SqlParameterItem("@pClavePrevalidador", SqlDbType.VarChar, 5, pedimento.FinArchivo.ClavePrevalidador));
                parametros.Add(new SqlParameterItem("@pIdPatenteVW", SqlDbType.Int, pedimento.IdPatente));
                parametros.Add(new SqlParameterItem("@pIdEmpresaVW", SqlDbType.Int, pedimento.IdEmpresa));
                parametros.Add(new SqlParameterItem("@pAcuseValidacion", SqlDbType.VarChar, 8, pedimento.Acusevalidacion));
                parametros.Add(new SqlParameterItem("@pIdDestinoVW", SqlDbType.Int, pedimento.IdClaveDestinoMercancia));
                parametros.Add(new SqlParameterItem("@pIdTipoFiguraVW", SqlDbType.Int, pedimento.TipoFigura));
                parametros.Add(new SqlParameterItem("@pFirmaElectronica", SqlDbType.VarChar, 2500, pedimento.FirmaElectronicaAvanzada));
                parametros.Add(new SqlParameterItem("@pNoSerieCertificadoFEA", SqlDbType.VarChar, 3, pedimento.NumeroSerieCertificadoFEA));
                parametros.Add(new SqlParameterItem("@pNombreArchivo", SqlDbType.VarChar, 12, pedimento.NombreArchivo));
                parametros.Add(new SqlParameterItem("@pNoPedimentos", SqlDbType.Int, pedimento.FinArchivo.CantidadPedimentos));
                parametros.Add(new SqlParameterItem("@pCantidadRegistros", SqlDbType.Int, pedimento.FinArchivo.CantidadRegistros));
                parametros.Add(new SqlParameterItem("@pConfimardo", SqlDbType.Bit, false));
                parametros.Add(new SqlParameterItem("@pIdUsuarioCreacion", SqlDbType.Int, pedimento.IdUsuarioEjecucion));
                parametros.Add(new SqlParameterItem("@pNumeroOperacionVUCEM", SqlDbType.Float, pedimento.NoOperacion));//duda solo de vucem
                parametros.Add(new SqlParameterItem("@pInactivo", SqlDbType.Bit, false));
                parametros.Add(new SqlParameterItem("@pNoPartidas", SqlDbType.Int, pedimento.NoTotalPartidas));//NEW
                parametros.Add(new SqlParameterItem("@pEsPedimentoVUCEM", SqlDbType.Int, pedimento.EsPedimentoVUCEM));//NEW
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                helper.ExecuteNonQuery("usp_Pedimento_Inserta", parametros);
                pedimento.IdPedimento = Convert.ToInt16(helper.GetParameterOutput("@pID"));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// TRANSORTE REGISTRO 502 REVISAR STORE PROCEDURE
        /// </summary>
        /// <param name="Pedimento"></param>
        /// <returns></returns>
        private bool InsertarEnTablaTransporte(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Transporte;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pRFCTransportista", SqlDbType.VarChar, 13, pPedimento.Transporte[vContadorPedimento].RFCTransportista));
                    parametros.Add(new SqlParameterItem("@pCURPTransportista", SqlDbType.VarChar, 18, pPedimento.Transporte[vContadorPedimento].CURPTransportista));
                    parametros.Add(new SqlParameterItem("@pRazonSocial", SqlDbType.VarChar, 120, pPedimento.Transporte[vContadorPedimento].NombreTrasportista));
                    parametros.Add(new SqlParameterItem("@pIdentificador", SqlDbType.VarChar, 17, pPedimento.Transporte[vContadorPedimento].IdentificadorTransportista));
                    parametros.Add(new SqlParameterItem("@pIdPaisTransportista", SqlDbType.Int, pPedimento.Transporte[vContadorPedimento].IdPaisMedioTranspote));
                    parametros.Add(new SqlParameterItem("@pTotalBultos", SqlDbType.Int, pPedimento.Transporte[vContadorPedimento].TotalBultos));
                    parametros.Add(new SqlParameterItem("@pDomicilioFiscal", SqlDbType.VarChar, 150, pPedimento.Transporte[vContadorPedimento].DomicilioFiscalTransportista));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    //var helper2 = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));
                    var x = helper.ExecuteNonQuery("usp_Transportista_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// inserta en Registro 503 las guias es una LISTA
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaGuia(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Guias;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pGuiaEmbarque", SqlDbType.VarChar, 50, pPedimento.Guias[vContadorPedimento].NumeroGuiaOManifiesto.Replace(" ", "")));
                    parametros.Add(new SqlParameterItem("@pIdTipoGuiaVW", SqlDbType.Int, pPedimento.Guias[vContadorPedimento].IdTipoGuia));//duda
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var x = helper.ExecuteNonQuery("usp_Guia_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Inserta Registro 504 Contenedor Es una Lista
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaContenedor(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Contenedores;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pNumeroContenedor", SqlDbType.VarChar, 12, pPedimento.Contenedores[vContadorPedimento].NumeroContenedor.Replace(" ", "")));
                    parametros.Add(new SqlParameterItem("@pIdTipoContenedorVW", SqlDbType.Int, pPedimento.Contenedores[vContadorPedimento].IdTipoContenedor));//duda
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var r504 = helper.ExecuteNonQuery("usp_Contenedor_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// funcion que agrega los campos del registro 505
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaFacturas(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Facturas;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    if (pPedimento.Facturas[vContadorPedimento].FechaFacturacion != Convert.ToDateTime("01/01/0001"))
                    {
                        parametros.Add(new SqlParameterItem("@pFechaFacturacion", SqlDbType.DateTime, pPedimento.Facturas[vContadorPedimento].FechaFacturacion));
                    }
                    else
                    {
                        parametros.Add(new SqlParameterItem("@pFechaFacturacion", SqlDbType.DateTime, null));
                    }
                    parametros.Add(new SqlParameterItem("@pNumeroFactura", SqlDbType.VarChar, 30, pPedimento.Facturas[vContadorPedimento].NumeroFactura));//duda
                    parametros.Add(new SqlParameterItem("@pNoCOVE", SqlDbType.VarChar, 15, pPedimento.Facturas[vContadorPedimento].NumeroFactura));
                    parametros.Add(new SqlParameterItem("@pIdTerminoFacturaVW", SqlDbType.Int, pPedimento.Facturas[vContadorPedimento].IdTerminoFactura));
                    parametros.Add(new SqlParameterItem("@pIdMonedaVW", SqlDbType.Int, pPedimento.Facturas[vContadorPedimento].IdMonedaFacturacion));
                    parametros.Add(new SqlParameterItem("@pValorDolares", SqlDbType.Float, pPedimento.Facturas[vContadorPedimento].ValorMercanciaDolares));
                    parametros.Add(new SqlParameterItem("@pValorMonedaFacturacion", SqlDbType.Float, pPedimento.Facturas[vContadorPedimento].ValorMercanciaAsentadaEnFactura));
                    parametros.Add(new SqlParameterItem("@pIdPaisFacturacionVW", SqlDbType.Int, pPedimento.Facturas[vContadorPedimento].IdPaisFacturacion));//duda
                    parametros.Add(new SqlParameterItem("@pIdEntidadFederativaFacturacionVW", SqlDbType.Int, pPedimento.Facturas[vContadorPedimento].IdEntidadFederativaFacturacion));
                    parametros.Add(new SqlParameterItem("@pClaveProveedorComprador", SqlDbType.VarChar, 30, pPedimento.Facturas[vContadorPedimento].ClaveIdentificacionFiscalProveedor));
                    parametros.Add(new SqlParameterItem("@pNombreProveedorComprador", SqlDbType.VarChar, 120, pPedimento.Facturas[vContadorPedimento].NombreProveedorOComprador));
                    parametros.Add(new SqlParameterItem("@pCalle", SqlDbType.VarChar, 80, pPedimento.Facturas[vContadorPedimento].CallePC));
                    parametros.Add(new SqlParameterItem("@pNumeroInterior", SqlDbType.VarChar, 10, pPedimento.Facturas[vContadorPedimento].NumeroInterioPC));
                    parametros.Add(new SqlParameterItem("@pNumeroExterior", SqlDbType.VarChar, 10, pPedimento.Facturas[vContadorPedimento].NumeroExteriorPC));
                    parametros.Add(new SqlParameterItem("@pCodigoPostal", SqlDbType.VarChar, 10, pPedimento.Facturas[vContadorPedimento].CodigoPostalPC));
                    parametros.Add(new SqlParameterItem("@pMunicipio", SqlDbType.VarChar, 80, pPedimento.Facturas[vContadorPedimento].MunicipioPC));
                    parametros.Add(new SqlParameterItem("@pFactorPonderacion", SqlDbType.Float, 1));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));

                    var r505 = helper.ExecuteNonQuery("usp_Factura_Inserta", parametros, false);
                    //inserto en Bitacora NoCOVE
                    InsertaCOVEEnBItacora(pPedimento.Facturas[vContadorPedimento].NumeroFactura);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Funcion que inserta COVE en bitacora para motor
        /// </summary>
        /// <param name="pNoCOVE"></param>
        /// <returns></returns>
        private bool InsertaCOVEEnBItacora(string pNoCOVE)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pNoCOVE", SqlDbType.VarChar, 15, pNoCOVE));

                var rBitacoraCOVE = helper.ExecuteNonQuery("spGeneraCOVEenBitacora", parametros);
                return rBitacoraCOVE;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// inserta Registro 506 Fechas
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaFechas(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Fechas;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdTipoFechaVW", SqlDbType.Int, pPedimento.Fechas[vContadorPedimento].ClaveTipoFecha));//se usa directo la clave tipo fecha
                    parametros.Add(new SqlParameterItem("@pFecha", SqlDbType.Date, pPedimento.Fechas[vContadorPedimento].Fecha));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var r506 = helper.ExecuteNonQuery("usp_FechasXPedimento_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Identificadores Nivel Pedimento Registro 507
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaIdentificadoresNPed(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.IdentificadoresNPed;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdIdentificadorVW", SqlDbType.Int, pPedimento.IdentificadoresNPed[vContadorPedimento].IdTipoIdentificador));
                    parametros.Add(new SqlParameterItem("@pComplemento1", SqlDbType.VarChar, 30, pPedimento.IdentificadoresNPed[vContadorPedimento].Complemento1));
                    parametros.Add(new SqlParameterItem("@pComplemento2", SqlDbType.VarChar, 30, pPedimento.IdentificadoresNPed[vContadorPedimento].Complemento2));
                    parametros.Add(new SqlParameterItem("@pComplemento3", SqlDbType.VarChar, 30, pPedimento.IdentificadoresNPed[vContadorPedimento].Complemento3));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var r507 = helper.ExecuteNonQuery("usp_IdentificadorNivePedimento_Inserta", parametros, false);
                    if (pPedimento.IdentificadoresNPed[vContadorPedimento].IdTipoIdentificador == 41)
                    {
                        InsertaEnBitacoraEdocument(pPedimento.IdentificadoresNPed[vContadorPedimento].Complemento1,
                            pPedimento.IdPedimento);
                    }
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Funcion que Inserta en Bitacora el Edocument para descarga de PDF de SAt
        /// </summary>
        /// <param name="pNoEdocument"></param>
        /// <param name="pIdPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnBitacoraEdocument(string pNoEdocument, int pIdPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pNoEdocument", SqlDbType.VarChar, 30, pNoEdocument));
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pIdPedimento));
                var r507 = helper.ExecuteNonQuery("spGeneraEdocumentenBitacora", parametros, false);
                return r507;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Cuentas Aduaneras Nivel Pedimento Registro 508 Tabla CuentaNivelPedimento
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaCuentasAduanerasNPed(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.CuentasAduanerasNPed;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdInstitucionEmisoraVW", SqlDbType.Int, pPedimento.CuentasAduanerasNPed[vContadorPedimento].ClaveInstitucionEmisoraCuenta));//se usa directo la clave InstitucionEmisora
                    parametros.Add(new SqlParameterItem("@pNumeroCuenta", SqlDbType.Int, pPedimento.CuentasAduanerasNPed[vContadorPedimento].NumeroCuentaAduanera));
                    parametros.Add(new SqlParameterItem("@pFolioConstancia", SqlDbType.VarChar, 17, pPedimento.CuentasAduanerasNPed[vContadorPedimento].FolioConstancia));
                    parametros.Add(new SqlParameterItem("@pFechaConstancia", SqlDbType.Date, pPedimento.CuentasAduanerasNPed[vContadorPedimento].FechaConstancia));
                    parametros.Add(new SqlParameterItem("@pIdTipoCuentaVW", SqlDbType.Int, pPedimento.CuentasAduanerasNPed[vContadorPedimento].ClaveTipoCuentaGarantia));//duda
                    parametros.Add(new SqlParameterItem("@pIdTipoCuentaGarantiaVW", SqlDbType.Int, pPedimento.CuentasAduanerasNPed[vContadorPedimento].ClaveTipoCuentaGarantia));//se utilica la misma ya que el catalogo lo trae directo
                    parametros.Add(new SqlParameterItem("@pValorTitulo", SqlDbType.Float, pPedimento.CuentasAduanerasNPed[vContadorPedimento].ValorUnitarioTitulo));
                    parametros.Add(new SqlParameterItem("@pImporteGarantia", SqlDbType.Float, pPedimento.CuentasAduanerasNPed[vContadorPedimento].ImporteTotalGarantia));
                    parametros.Add(new SqlParameterItem("@pCantidadUnidadMedida", SqlDbType.Float, pPedimento.CuentasAduanerasNPed[vContadorPedimento].CantidadUnidadesMedida));
                    parametros.Add(new SqlParameterItem("@pTitulosAsignados", SqlDbType.Float, pPedimento.CuentasAduanerasNPed[vContadorPedimento].TitulosAsignados));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var r508 = helper.ExecuteNonQuery("usp_CuentaNivelPedimento_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Tasas Nivel Pedimento Registro 509(mismo store que el del registro 556)
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaTasasNPed(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.TasasNPed;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, 0));//se envia en cero ya que no se tiene partida en este nivel
                    parametros.Add(new SqlParameterItem("@pIdTipoTasaVW", SqlDbType.Int, pPedimento.TasasNPed[vContadorPedimento].ClaveTipoTasa));//se usa la misma ya que trae el Id de la tabla directamente
                    parametros.Add(new SqlParameterItem("@pTasa", SqlDbType.Float, pPedimento.TasasNPed[vContadorPedimento].TasaContribucion));
                    parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.TasasNPed[vContadorPedimento].IdClaveContribucionGravamenDerechoTasasNPed));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var res = helper.ExecuteNonQuery("usp_TasaXPedimento_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// CONTRIBUCIONES NIVEL PEDIMENTO REGISTRO 510
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaContribucionesNPed(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.ContribucionesNPed;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.ContribucionesNPed[vContadorPedimento].IdContribucionGravamenDerechoNPed));//Ya se tiene catalogo
                    parametros.Add(new SqlParameterItem("@pIdFormaPagoVW", SqlDbType.Int, pPedimento.ContribucionesNPed[vContadorPedimento].IdClaveFormaPago));//FALTA CATALOGO
                    parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pPedimento.ContribucionesNPed[vContadorPedimento].ImporteContribucion));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var x = helper.ExecuteNonQuery("usp_ContribucionPedimento_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// OBSERVACIONES NIVEL PEDIMENTO REGISTRO 511
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaObservacionesNPed(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                string ObserUnidas = string.Empty;
                var vlista = pPedimento.ObservacionesNPed;
                foreach (var Observaciones in vlista)
                {
                    ObserUnidas = ObserUnidas + pPedimento.ObservacionesNPed[vContadorPedimento].ObservacionesNivelPedimento + " | ";
                    vContadorPedimento++;
                }
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                parametros.Add(new SqlParameterItem("@pObservaciones", SqlDbType.VarChar, 3000, ObserUnidas));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                return helper.ExecuteNonQuery("usp_ObservacionesPedimento_Inserta", parametros, false);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// DESCARGO REGISTRO 512
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaDescargos(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Descargos;
                foreach (var Descargo in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pPatenteOriginal", SqlDbType.VarChar, 4, pPedimento.Descargos[vContadorPedimento].NumeroPatenteOriginal));
                    parametros.Add(new SqlParameterItem("@pDocumentoOriginal", SqlDbType.VarChar, 7, pPedimento.Descargos[vContadorPedimento].NumeroDocumentoOUltimaRecti));
                    parametros.Add(new SqlParameterItem("@pIdAduanaSeccionVW", SqlDbType.Int, pPedimento.Descargos[vContadorPedimento].IdAduanaSeccionDescargos)); //FALTA AGREGAR A CLASE
                    parametros.Add(new SqlParameterItem("@pFechaPagoOriginal", SqlDbType.Date, pPedimento.Descargos[vContadorPedimento].FechaPagoOriginal));
                    parametros.Add(new SqlParameterItem("@pIdFraccionOriginalVW", SqlDbType.Int, pPedimento.Descargos[vContadorPedimento].IdFraccionArancelariaOriginal));
                    parametros.Add(new SqlParameterItem("@pClaveUnidadMedida", SqlDbType.Int, pPedimento.Descargos[vContadorPedimento].IdUnidadMedidaDescargo));//FALTA CATALOGO
                    parametros.Add(new SqlParameterItem("@pCantidadMercancia", SqlDbType.Float, pPedimento.Descargos[vContadorPedimento].CantidadMercancia));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    vContadorPedimento++;
                    var r512 = helper.ExecuteNonQuery("usp_Descargo_Inserta", parametros, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// COMENSACIONES REGISTRO 513
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaCompensaciones(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Compensaciones;
                foreach (var Compensaciones in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pNumeroPatente", SqlDbType.VarChar, 4, pPedimento.Compensaciones[vContadorPedimento].NumeroPatenteOriginal));
                    parametros.Add(new SqlParameterItem("@pNumeroDocumento", SqlDbType.VarChar, 7, pPedimento.Compensaciones[vContadorPedimento].NumeroDocumentoOUltimaRecti));
                    parametros.Add(new SqlParameterItem("@pIdAduanaSeccionVW", SqlDbType.Int, pPedimento.Compensaciones[vContadorPedimento].IdAduanaSeccionCompensacion)); //FALTA AGREGAR A ENTIDAD
                    parametros.Add(new SqlParameterItem("@pFechaPago", SqlDbType.Date, pPedimento.Compensaciones[vContadorPedimento].FechaPagoOriginal));
                    parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.Compensaciones[vContadorPedimento].IdClaveGravamen));//FALTA AGREGAR A ENTIDAD
                    parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pPedimento.Compensaciones[vContadorPedimento].ImporteCompensacion));//FALTA CATALOGO
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    vContadorPedimento++;
                    var r512 = helper.ExecuteNonQuery("usp_Compensacion_Inserta", parametros, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// DOCUMENTO QUE AMPARA FORMA PAGO REGISTRO 514
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaAmparaFormaPago(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.DoctosFormaPago;
                foreach (var FormaPago in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdFormaPagoVW", SqlDbType.Int, pPedimento.DoctosFormaPago[vContadorPedimento].IdClaveFormaPago));//FALTA EN ENTIDAD
                    parametros.Add(new SqlParameterItem("@pInstitucionAfianzadora", SqlDbType.VarChar, 120, pPedimento.DoctosFormaPago[vContadorPedimento].NombreDependencia));
                    parametros.Add(new SqlParameterItem("@pNumeroIdentificaDocumento", SqlDbType.VarChar, 40, pPedimento.DoctosFormaPago[vContadorPedimento].NumeroDocumentoAmpara)); //DUDA
                    parametros.Add(new SqlParameterItem("@pFechaExpedicion", SqlDbType.Date, pPedimento.DoctosFormaPago[vContadorPedimento].FechaExpedicion));
                    parametros.Add(new SqlParameterItem("@pImporteAmpara", SqlDbType.Float, pPedimento.DoctosFormaPago[vContadorPedimento].ImporteSaldoDisponible));//duda
                    parametros.Add(new SqlParameterItem("@pImporteSaldo", SqlDbType.Float, pPedimento.DoctosFormaPago[vContadorPedimento].ImporteTotalDocumento));//duda
                    parametros.Add(new SqlParameterItem("@pImporteTotal", SqlDbType.Float, pPedimento.DoctosFormaPago[vContadorPedimento].ImporteTotalPedimento));//FALTA CATALOGO
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    vContadorPedimento++;
                    var r512 = helper.ExecuteNonQuery("usp_DocumentoAmparaFormaPago_Inserta", parametros, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// INFORME INDUSTRI AUTOMOTRIZ REGISTRO 515
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaInformeIndustriAut(ArchivoM pPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                parametros.Add(new SqlParameterItem("@pPatente", SqlDbType.VarChar, 4, pPedimento.InformeIndustriaAut.Patente));
                parametros.Add(new SqlParameterItem("@pIdAduanaSeccionDVW", SqlDbType.Int, pPedimento.InformeIndustriaAut.IdAduanaSeccionDespacho));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pidAduanaSeccionEVW", SqlDbType.Int, pPedimento.InformeIndustriaAut.IdAduanaSeccionEntrada));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pRFC", SqlDbType.VarChar, 15, pPedimento.InformeIndustriaAut.RFCIE));
                parametros.Add(new SqlParameterItem("@pTipoCambio", SqlDbType.Float, pPedimento.InformeIndustriaAut.TipoCambio));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r = helper.ExecuteNonQuery("usp_IndustriaAutomotriz_Inserta", parametros, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// CANDADOS REGISTRO 516
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaCandados(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Candados;
                foreach (var Candados in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdentificadorTransporte", SqlDbType.VarChar, 17, pPedimento.Candados[vContadorPedimento].IdentificadorTransporte));//FALTA EN ENTIDAD
                    parametros.Add(new SqlParameterItem("@pNumeroCandado", SqlDbType.VarChar, 21, pPedimento.Candados[vContadorPedimento].NumeroCandado));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    vContadorPedimento++;
                    var r512 = helper.ExecuteNonQuery("usp_Candado_Inserta", parametros, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// DESTINATARIOS REGISTRO 520
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaDestinatarios(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.Destinatarios;
                foreach (var Candados in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdentificadorFiscal", SqlDbType.VarChar, 17, pPedimento.Destinatarios[vContadorPedimento].ClaveIdentificadorFiscalDestinatario));
                    parametros.Add(new SqlParameterItem("@pDestinatario", SqlDbType.VarChar, 20, pPedimento.Destinatarios[vContadorPedimento].Destinatario));
                    parametros.Add(new SqlParameterItem("@pCalle", SqlDbType.VarChar, 80, pPedimento.Destinatarios[vContadorPedimento].Calle));
                    parametros.Add(new SqlParameterItem("@pNumeroInterior", SqlDbType.VarChar, 10, pPedimento.Destinatarios[vContadorPedimento].NumeroInterior));
                    parametros.Add(new SqlParameterItem("@pNumeroExterior", SqlDbType.VarChar, 10, pPedimento.Destinatarios[vContadorPedimento].NumeroExterior));
                    parametros.Add(new SqlParameterItem("@pCodigoPostal", SqlDbType.VarChar, 10, pPedimento.Destinatarios[vContadorPedimento].CodigoPostal));
                    parametros.Add(new SqlParameterItem("@pMunicipioCiudad", SqlDbType.VarChar, 80, pPedimento.Destinatarios[vContadorPedimento].MunicipioCiudad));
                    parametros.Add(new SqlParameterItem("@pIdPaisVW", SqlDbType.Int, pPedimento.Destinatarios[vContadorPedimento].IdPaisDestinatario));//FALTA EN ENTIDAD
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    vContadorPedimento++;
                    var r512 = helper.ExecuteNonQuery("usp_Destinatario_Inserta", parametros, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// PARTIDAS REG 551, 552, 553, 554, 555, 556, 557, 558 y procedimiento de Impuestos en pedimento
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaPartidas(DatosReg551Partidas pPartida, int IdPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPartida.IdFraccionArancelaria));
                parametros.Add(new SqlParameterItem("@pSecuenciaPartida", SqlDbType.Int, pPartida.NumeroPartida));//duda
                parametros.Add(new SqlParameterItem("@pSubdivisionFraccion", SqlDbType.VarChar, 8, pPartida.SubdivisionFraccion));
                parametros.Add(new SqlParameterItem("@pDescripcionMercancia", SqlDbType.VarChar, 250, pPartida.DescripcionMercancia));
                parametros.Add(new SqlParameterItem("@pImportePrecioUnitario", SqlDbType.Float, pPartida.ImportePrecioUnitario));
                parametros.Add(new SqlParameterItem("@pValorAduana", SqlDbType.Float, pPartida.ImporteValorAduana));
                parametros.Add(new SqlParameterItem("@pValorComercial", SqlDbType.Float, pPartida.ImportePrecio));//duda
                parametros.Add(new SqlParameterItem("@pValorDolares", SqlDbType.Float, pPartida.ValorFacturaDolares));
                parametros.Add(new SqlParameterItem("@pCantidaUMC", SqlDbType.Float, pPartida.CantidadMercanciaComercial));
                parametros.Add(new SqlParameterItem("@pIdUnidadMedidaComercialVW", SqlDbType.Int, pPartida.IdClaveUnidadMedidaComercial));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pCantidadUMT", SqlDbType.Float, pPartida.CantidadMercanciaTarifa));
                parametros.Add(new SqlParameterItem("@pIdUnidadMedidaTarifaVW", SqlDbType.Int, pPartida.IdClaveUnidadMedidadTarifa));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIVA", SqlDbType.Float, pPartida.IVA));
                parametros.Add(new SqlParameterItem("@pIdVinculacionVW", SqlDbType.Int, pPartida.IdClaveValorAduanaInfluido));//Viene de ClaveValorAduanaInfluido falta agregar a entidad
                parametros.Add(new SqlParameterItem("@pIdMetodoValoracionVW", SqlDbType.Int, pPartida.IdClaveMetodoValoracionMercancia));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pCodigoProducto", SqlDbType.VarChar, 20, pPartida.CodigoProducto));
                parametros.Add(new SqlParameterItem("@pMarcaProducto", SqlDbType.VarChar, 80, pPartida.MarcaProducto));
                parametros.Add(new SqlParameterItem("@pModeloProducto", SqlDbType.VarChar, 80, pPartida.ModeloProducto));
                parametros.Add(new SqlParameterItem("@pIdPaisOrigenDestinoVW", SqlDbType.Int, pPartida.IdClavePaisMercancia));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPaisCompradorVendedorVW", SqlDbType.Int, pPartida.IdPaisDestinatario));//FALTA EN ENTIDAD DUDA
                parametros.Add(new SqlParameterItem("@pIdEntidadOrigenVW", SqlDbType.Int, pPartida.IdClaveEntidadFederativaOrigen));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdEntidadDestinoVW", SqlDbType.Int, pPartida.IdClaveEntidadfederativaDestino));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdEntidadCompradorVW", SqlDbType.Int, pPartida.IdClaveEntidadFederativaComprador));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdEntidadVendedorVW", SqlDbType.Int, pPartida.IdClaveEntidadFederativaVendedor));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pFactorPonderacion", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var rPartida = helper.ExecuteNonQuery("usp_Partida_Inserta", parametros, false);
                var IdPartida = Convert.ToInt16(helper.GetParameterOutput("@pID"));
                //Reviso Registro Mercancias
                if (pPartida.Mercancias != null)
                {
                    var vContadorMercancia = 0;
                    var lista = pPartida.Mercancias;
                    foreach (var Mercancias in lista)
                    {
                        InsertaEnTablaMercancias(pPartida.Mercancias[vContadorMercancia], IdPedimento, IdPartida);
                        vContadorMercancia++;
                    }
                }
                //Reviso Registro Permisos
                if (pPartida.Permisos != null)
                {
                    var vContadorPermiso = 0;
                    var lista = pPartida.Permisos;
                    foreach (var Permisos in lista)
                    {
                        InsertaEnTablaPermisos(pPartida.Permisos[vContadorPermiso], IdPedimento, IdPartida);
                        vContadorPermiso++;
                    }
                }
                //Revico Identificadores
                if (pPartida.IdentificadoresNPartida != null)
                {
                    var vContadorIdentificador = 0;
                    var lista = pPartida.IdentificadoresNPartida;
                    foreach (var Permisos in lista)
                    {
                        InsertaEnTablaIdentificadores(pPartida.IdentificadoresNPartida[vContadorIdentificador], IdPedimento, IdPartida);
                        vContadorIdentificador++;
                    }
                }
                //Reviso Cuenta AduaneraNPartida
                if (pPartida.CuentasAduanerasNPartida != null)
                {
                    var vContadorCuentaAduanera = 0;
                    var lista = pPartida.CuentasAduanerasNPartida;
                    foreach (var Cuentas in lista)
                    {
                        InsertaEnTablaCuentasAduanerasNPartida(pPartida.CuentasAduanerasNPartida[vContadorCuentaAduanera], IdPedimento, IdPartida);
                        vContadorCuentaAduanera++;
                    }
                }
                //Reviso TasasNPartida
                if (pPartida.TasasNPartida != null)
                {
                    var vContadorTasas = 0;
                    var lista = pPartida.TasasNPartida;
                    foreach (var Tasas in lista)
                    {
                        InsertaEnTablaTasasNPartida(pPartida.TasasNPartida[vContadorTasas], IdPedimento, IdPartida, pPartida.NumeroPartida);
                        vContadorTasas++;
                    }
                }
                //Reviso Gravamen
                if (pPartida.GravamenNPartida != null)
                {
                    var vContadorGravamen = 0;
                    var lista = pPartida.GravamenNPartida;
                    foreach (var Tasas in lista)
                    {
                        InsertaEnTablaGravamenNPartida(pPartida.GravamenNPartida[vContadorGravamen], IdPedimento, IdPartida);
                        vContadorGravamen++;
                    }
                }
                //Reviso Observaciones
                if (pPartida.ObservacionesNPart != null)
                {
                    var vContadorObservaciones = 0;
                    string ObserUnidas = string.Empty;
                    var vlista = pPartida.ObservacionesNPart;
                    foreach (var Observaciones in vlista)
                    {
                        ObserUnidas = ObserUnidas + pPartida.ObservacionesNPart[vContadorObservaciones].ObservacionesNivelPartida + " | ";
                        vContadorObservaciones++;
                    }
                    InsertaEnTablaObservacionesNPartida(ObserUnidas, IdPedimento, IdPartida);
                }
                List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                parametros2.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));
                parametros2.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, false, ParameterDirection.Output));
                var rCalculoValores = helper.ExecuteNonQuery("usp_Estadistica_GeneralPartida", parametros2, false);

                return rPartida;
                //las observaciones se sacan de la funcion
                //InsertaEnTablaObservacionesNPartida(pPedimento);

                //duda
                //List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                //parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                //helper.ExecuteNonQuery("usp_spSTCreaRegistroContribucionPartidaEnPedimento", parametros2);
                //List<SqlParameterItem> parametros3 = new List<SqlParameterItem>();
                //parametros3.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                //helper.ExecuteNonQuery("usp_spSTCalculaValoresPedimento", parametros3);
                //return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private int InsertaEnTablaPartidasVUCEM(Modelo.VUCEMService.DatosReg551Partidas pPartida, int IdPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPartida.IdFraccionArancelaria));
                parametros.Add(new SqlParameterItem("@pSecuenciaPartida", SqlDbType.Int, pPartida.NumeroPartida));//duda
                parametros.Add(new SqlParameterItem("@pSubdivisionFraccion", SqlDbType.VarChar, 8, pPartida.SubdivisionFraccion));
                parametros.Add(new SqlParameterItem("@pDescripcionMercancia", SqlDbType.VarChar, 250, pPartida.DescripcionMercancia));
                parametros.Add(new SqlParameterItem("@pImportePrecioUnitario", SqlDbType.Float, pPartida.ImportePrecioUnitario));
                parametros.Add(new SqlParameterItem("@pValorAduana", SqlDbType.Float, pPartida.ImporteValorAduana));
                parametros.Add(new SqlParameterItem("@pValorComercial", SqlDbType.Float, pPartida.ImportePrecio));//duda
                parametros.Add(new SqlParameterItem("@pValorDolares", SqlDbType.Float, pPartida.ValorFacturaDolares));
                parametros.Add(new SqlParameterItem("@pCantidaUMC", SqlDbType.Float, pPartida.CantidadMercanciaComercial));
                parametros.Add(new SqlParameterItem("@pIdUnidadMedidaComercialVW", SqlDbType.Int, pPartida.IdClaveUnidadMedidaComercial));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pCantidadUMT", SqlDbType.Float, pPartida.CantidadMercanciaTarifa));
                parametros.Add(new SqlParameterItem("@pIdUnidadMedidaTarifaVW", SqlDbType.Int, pPartida.IdClaveUnidadMedidadTarifa));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIVA", SqlDbType.Float, pPartida.IVA));
                parametros.Add(new SqlParameterItem("@pIdVinculacionVW", SqlDbType.Int, pPartida.IdClaveValorAduanaInfluido));//Viene de ClaveValorAduanaInfluido falta agregar a entidad
                parametros.Add(new SqlParameterItem("@pIdMetodoValoracionVW", SqlDbType.Int, pPartida.IdClaveMetodoValoracionMercancia));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pCodigoProducto", SqlDbType.VarChar, 20, pPartida.CodigoProducto));
                parametros.Add(new SqlParameterItem("@pMarcaProducto", SqlDbType.VarChar, 80, pPartida.MarcaProducto));
                parametros.Add(new SqlParameterItem("@pModeloProducto", SqlDbType.VarChar, 80, pPartida.ModeloProducto));
                parametros.Add(new SqlParameterItem("@pIdPaisOrigenDestinoVW", SqlDbType.Int, pPartida.IdClavePaisMercancia));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPaisCompradorVendedorVW", SqlDbType.Int, pPartida.IdPaisDestinatario));//FALTA EN ENTIDAD DUDA
                parametros.Add(new SqlParameterItem("@pIdEntidadOrigenVW", SqlDbType.Int, pPartida.IdClaveEntidadFederativaOrigen));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdEntidadDestinoVW", SqlDbType.Int, pPartida.IdClaveEntidadfederativaDestino));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdEntidadCompradorVW", SqlDbType.Int, pPartida.IdClaveEntidadFederativaComprador));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdEntidadVendedorVW", SqlDbType.Int, pPartida.IdClaveEntidadFederativaVendedor));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pFactorPonderacion", SqlDbType.Float, 0));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var rPartida = helper.ExecuteNonQuery("usp_Partida_Inserta", parametros, false);
                var IdPartida = Convert.ToInt16(helper.GetParameterOutput("@pID"));
                //Reviso Registro Mercancias
                if (pPartida.Mercancias != null)
                {
                    var vContadorMercancia = 0;
                    var lista = pPartida.Mercancias;
                    foreach (var Mercancias in lista)
                    {
                        InsertaEnTablaMercanciasVUCEM(pPartida.Mercancias[vContadorMercancia], IdPedimento, IdPartida);
                        vContadorMercancia++;
                    }
                }
                //Reviso Registro Permisos
                if (pPartida.Permisos != null)
                {
                    var vContadorPermiso = 0;
                    var lista = pPartida.Permisos;
                    foreach (var Permisos in lista)
                    {
                        InsertaEnTablaPermisosVUCEM(pPartida.Permisos[vContadorPermiso], IdPedimento, IdPartida);
                        vContadorPermiso++;
                    }
                }
                //Revico Identificadores
                if (pPartida.IdentificadoresNPartida != null)
                {
                    var vContadorIdentificador = 0;
                    var lista = pPartida.IdentificadoresNPartida;
                    foreach (var Permisos in lista)
                    {
                        InsertaEnTablaIdentificadoresVUCEM(pPartida.IdentificadoresNPartida[vContadorIdentificador], IdPedimento, IdPartida);
                        vContadorIdentificador++;
                    }
                }
                //Reviso Cuenta AduaneraNPartida
                if (pPartida.CuentasAduanerasNPartida != null)
                {
                    var vContadorCuentaAduanera = 0;
                    var lista = pPartida.CuentasAduanerasNPartida;
                    foreach (var Cuentas in lista)
                    {
                        InsertaEnTablaCuentasAduanerasNPartidaVUCEM(pPartida.CuentasAduanerasNPartida[vContadorCuentaAduanera], IdPedimento, IdPartida);
                        vContadorCuentaAduanera++;
                    }
                }
                //Reviso TasasNPartida
                if (pPartida.TasasNPartida != null)
                {
                    var vContadorTasas = 0;
                    var lista = pPartida.TasasNPartida;
                    foreach (var Tasas in lista)
                    {
                        InsertaEnTablaTasasNPartidaVUCEM(pPartida.TasasNPartida[vContadorTasas], IdPedimento, IdPartida, pPartida.NumeroPartida);
                        vContadorTasas++;
                    }
                }
                //Reviso Gravamen
                if (pPartida.GravamenNPartida != null)
                {
                    var vContadorGravamen = 0;
                    var lista = pPartida.GravamenNPartida;
                    foreach (var Tasas in lista)
                    {
                        InsertaEnTablaGravamenNPartidaVUCEM(pPartida.GravamenNPartida[vContadorGravamen], IdPedimento, IdPartida);
                        vContadorGravamen++;
                    }
                }
                //Reviso Observaciones
                if (pPartida.ObservacionesNPart != null)
                {
                    var vContadorObservaciones = 0;
                    string ObserUnidas = string.Empty;
                    var vlista = pPartida.ObservacionesNPart;
                    foreach (var Observaciones in vlista)
                    {
                        ObserUnidas = ObserUnidas + pPartida.ObservacionesNPart[vContadorObservaciones].ObservacionesNivelPartida + " | ";
                        vContadorObservaciones++;
                    }
                    InsertaEnTablaObservacionesNPartida(ObserUnidas, IdPedimento, IdPartida);
                }
                List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                parametros2.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));
                parametros2.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, false, ParameterDirection.Output));
                var rCalculoValores = helper.ExecuteNonQuery("usp_Estadistica_GeneralPartida", parametros2, false);

                return IdPartida;
                //las observaciones se sacan de la funcion
                //InsertaEnTablaObservacionesNPartida(pPedimento);

                //duda
                //List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                //parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                //helper.ExecuteNonQuery("usp_spSTCreaRegistroContribucionPartidaEnPedimento", parametros2);
                //List<SqlParameterItem> parametros3 = new List<SqlParameterItem>();
                //parametros3.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                //helper.ExecuteNonQuery("usp_spSTCalculaValoresPedimento", parametros3);
                //return true;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /*RESPALDO CAMBIO
         private bool InsertaEnTablaPartidas(ArchivoM pPedimento)
        {
            try
            {
                if (pPedimento.Partidas != null)
                {
                    //vContadorPartida = 0;
                    int vNoPartida = 0;
                    var vlista = pPedimento.Partidas;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].FraccionArancelaria));
                        parametros.Add(new SqlParameterItem("@pSecuenciaPartida", SqlDbType.Int, pPedimento.Partidas[vNoPartida].NumeroPartida));//duda
                        parametros.Add(new SqlParameterItem("@pSubdivisionFraccion", SqlDbType.VarChar, 8, pPedimento.Partidas[vNoPartida].SubdivisionFraccion));
                        parametros.Add(new SqlParameterItem("@pDescripcionMercancia", SqlDbType.VarChar, 250, pPedimento.Partidas[vNoPartida].DescripcionMercancia));
                        parametros.Add(new SqlParameterItem("@pImportePrecioUnitario", SqlDbType.Float, pPedimento.Partidas[vNoPartida].ImportePrecioUnitario));
                        parametros.Add(new SqlParameterItem("@pValorAduana", SqlDbType.Float, pPedimento.Partidas[vNoPartida].ImporteValorAduana));
                        parametros.Add(new SqlParameterItem("@pValorComercial", SqlDbType.Float, pPedimento.Partidas[vNoPartida].ImportePrecio));//duda
                        parametros.Add(new SqlParameterItem("@pValorDolares", SqlDbType.Float, pPedimento.Partidas[vNoPartida].ValorFacturaDolares));
                        parametros.Add(new SqlParameterItem("@pCantidaUMC", SqlDbType.Float, pPedimento.Partidas[vNoPartida].CantidadMercanciaComercial));
                        parametros.Add(new SqlParameterItem("@pIdUnidadMedidaComercialVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveUnidadMedidaComercial));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pCantidadUMT", SqlDbType.Float, pPedimento.Partidas[vNoPartida].CantidadMercanciaTarifa));
                        parametros.Add(new SqlParameterItem("@pIdUnidadMedidaTarifaVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveUnidadMedidadTarifa));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIVA", SqlDbType.Float, pPedimento.Partidas[vNoPartida].IVA));
                        parametros.Add(new SqlParameterItem("@pIdVinculacionVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveValorAduanaInfluido));//Viene de ClaveValorAduanaInfluido falta agregar a entidad
                        parametros.Add(new SqlParameterItem("@pIdMetodoValoracionVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveMetodoValoracionMercancia));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pCodigoProducto", SqlDbType.VarChar, 20, pPedimento.Partidas[vNoPartida].CodigoProducto));
                        parametros.Add(new SqlParameterItem("@pMarcaProducto", SqlDbType.VarChar, 80, pPedimento.Partidas[vNoPartida].MarcaProducto));
                        parametros.Add(new SqlParameterItem("@pModeloProducto", SqlDbType.VarChar, 80, pPedimento.Partidas[vNoPartida].ModeloProducto));
                        parametros.Add(new SqlParameterItem("@pIdPaisOrigenDestinoVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClavePaisMercancia));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPaisCompradorVendedorVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdPaisDestinatario));//FALTA EN ENTIDAD DUDA
                        parametros.Add(new SqlParameterItem("@pIdEntidadOrigenVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveEntidadFederativaOrigen));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdEntidadDestinoVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveEntidadfederativaDestino));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdEntidadCompradorVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveEntidadFederativaComprador));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdEntidadVendedorVW", SqlDbType.Int, pPedimento.Partidas[vNoPartida].IdClaveEntidadFederativaVendedor));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pFactorPonderacion", SqlDbType.Float, 0));
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        var r512 = helper.ExecuteNonQuery("usp_Partida_Inserta", parametros);
                        pPedimento.IdPartida = Convert.ToInt16(helper.GetParameterOutput("@pID"));
                        InsertaEnTablaMercancias(pPedimento, vNoPartida);
                        InsertaEnTablaPermisos(pPedimento, vNoPartida);
                        InsertaEnTablaIdentificadores(pPedimento, vNoPartida);
                        InsertaEnTablaCuentasAduanerasNPartida(pPedimento, vNoPartida);
                        InsertaEnTablaTasasNPartida(pPedimento, vNoPartida);
                        InsertaEnTablaGravamenNPartida(pPedimento, vNoPartida);
                        InsertaEnTablaObservacionesNPartida(pPedimento);
                        vNoPartida++;
                        
                    }
                    List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                    parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    helper.ExecuteNonQuery("usp_spSTCreaRegistroContribucionPartidaEnPedimento", parametros2);
                    List<SqlParameterItem> parametros3 = new List<SqlParameterItem>();
                    parametros3.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    helper.ExecuteNonQuery("usp_spSTCalculaValoresPedimento", parametros3);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         */

        /// <summary>
        /// MERCANCIAS REGISTRO 552
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaMercancias(DatosReg552Mercancias pMercancia, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pVIN", SqlDbType.VarChar, 17, pMercancia.NumeroIdentificacionVehicular));
                parametros.Add(new SqlParameterItem("@pKilometrajeVehiculo", SqlDbType.Float, pMercancia.KilometrajeVehiculo));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r552 = helper.ExecuteNonQuery("usp_MercanciaNivelPartida_Inserta", parametros, false);
                return r552;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool InsertaEnTablaMercanciasVUCEM(Modelo.VUCEMService.DatosReg552Mercancias pMercancia, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pVIN", SqlDbType.VarChar, 17, pMercancia.NumeroIdentificacionVehicular));
                parametros.Add(new SqlParameterItem("@pKilometrajeVehiculo", SqlDbType.Float, pMercancia.KilometrajeVehiculo));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r552 = helper.ExecuteNonQuery("usp_MercanciaNivelPartida_Inserta", parametros, false);
                return r552;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*CAMBIO MERCANCIA
         private bool InsertaEnTablaMercancias(ArchivoM pPedimento,int IdPedimento, int vNumeroPartida)
        {
            try
            {
                //if (pPedimento.Partidas[vContadorPedimento].Mercancias.Count() != 0)
                if (pPedimento.Partidas[vNumeroPartida].Mercancias != null)
                {
                    //vContadorPedimento = 0;
                    vContadorPartida = 0;
                    //var vlista = pPedimento.Partidas[vContadorPedimento].Mercancias;
                    var vlista = pPedimento.Partidas[vNumeroPartida].Mercancias;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pVIN", SqlDbType.VarChar, 17, pPedimento.Partidas[vNumeroPartida].Mercancias[vContadorPartida].NumeroIdentificacionVehicular));
                        parametros.Add(new SqlParameterItem("@pKilometrajeVehiculo", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].Mercancias[vContadorPartida].KilometrajeVehiculo));
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        //vContadorPedimento++;
                        vContadorPartida++;
                        var r512 = helper.ExecuteNonQuery("usp_MercanciaNivelPartida_Inserta", parametros);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        } 
         */

        /// <summary>
        /// PERMISOS REGISTRO 553
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaPermisos(DatosReg553Permisos pPermiso, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdPermisoVW", SqlDbType.Int, pPermiso.IdCLavePermiso));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pFimarElectronica", SqlDbType.VarChar, 40, pPermiso.FirmaElectronica));
                parametros.Add(new SqlParameterItem("@pNumeroPermiso", SqlDbType.VarChar, 30, pPermiso.NumeroPermisos));
                parametros.Add(new SqlParameterItem("@pValorDolares", SqlDbType.Float, pPermiso.ValorComercialDolares));
                parametros.Add(new SqlParameterItem("@pCantidaUMT", SqlDbType.Float, pPermiso.CantidadMercanciaUM));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r553 = helper.ExecuteNonQuery("usp_PermisoNivelPartida_Inserta", parametros, false);
                return r553;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool InsertaEnTablaPermisosVUCEM(Modelo.VUCEMService.DatosReg553Permisos pPermiso, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdPermisoVW", SqlDbType.Int, pPermiso.IdCLavePermiso));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pFimarElectronica", SqlDbType.VarChar, 40, pPermiso.FirmaElectronica));
                parametros.Add(new SqlParameterItem("@pNumeroPermiso", SqlDbType.VarChar, 30, pPermiso.NumeroPermisos));
                parametros.Add(new SqlParameterItem("@pValorDolares", SqlDbType.Float, pPermiso.ValorComercialDolares));
                parametros.Add(new SqlParameterItem("@pCantidaUMT", SqlDbType.Float, pPermiso.CantidadMercanciaUM));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r553 = helper.ExecuteNonQuery("usp_PermisoNivelPartida_Inserta", parametros, false);
                return r553;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*
         private bool InsertaEnTablaPermisos(ArchivoM pPedimento, int vNumeroPartida)
        {
            try
            {
                if (pPedimento.Partidas[vNumeroPartida].Permisos != null)
                {
                    //vContadorPedimento = 0;
                    vContadorPartida = 0;
                    var vlista = pPedimento.Partidas[vNumeroPartida].Permisos;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pIdPermisoVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].Permisos[vContadorPartida].IdCLavePermiso));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pFimarElectronica", SqlDbType.VarChar, 40, pPedimento.Partidas[vNumeroPartida].Permisos[vContadorPartida].FirmaElectronica));
                        parametros.Add(new SqlParameterItem("@pNumeroPermiso", SqlDbType.VarChar, 30, pPedimento.Partidas[vNumeroPartida].Permisos[vContadorPartida].NumeroPermisos));
                        parametros.Add(new SqlParameterItem("@pValorDolares", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].Permisos[vContadorPartida].ValorComercialDolares));
                        parametros.Add(new SqlParameterItem("@pCantidaUMT", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].Permisos[vContadorPartida].CantidadMercanciaUM));
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        //vContadorPedimento++;
                        vContadorPartida++;
                        var r512 = helper.ExecuteNonQuery("usp_PermisoNivelPartida_Inserta", parametros);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
          */

        /// <summary>
        /// IDENTIFICADORES NIVEL PARTIDA REGISTRO 554
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaIdentificadores(DatosReg554IdentificadoreNPart pIdentificador, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdIdentificadorVW", SqlDbType.Int, pIdentificador.IdCLaveIdentificador));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pComplemento1", SqlDbType.VarChar, 20, pIdentificador.Complemento1));
                parametros.Add(new SqlParameterItem("@pComplemento2", SqlDbType.VarChar, 30, pIdentificador.Complemento2));
                parametros.Add(new SqlParameterItem("@pComplemento3", SqlDbType.VarChar, 30, pIdentificador.Complemento3));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r554 = helper.ExecuteNonQuery("usp_IdentificadorNivelPartida_Inserta", parametros, false);
                return r554;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool InsertaEnTablaIdentificadoresVUCEM(Modelo.VUCEMService.DatosReg554IdentificadoreNPart pIdentificador, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdIdentificadorVW", SqlDbType.Int, pIdentificador.IdCLaveIdentificador));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pComplemento1", SqlDbType.VarChar, 20, pIdentificador.Complemento1));
                parametros.Add(new SqlParameterItem("@pComplemento2", SqlDbType.VarChar, 30, pIdentificador.Complemento2));
                parametros.Add(new SqlParameterItem("@pComplemento3", SqlDbType.VarChar, 30, pIdentificador.Complemento3));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r554 = helper.ExecuteNonQuery("usp_IdentificadorNivelPartida_Inserta", parametros, false);
                return r554;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*
          private bool InsertaEnTablaIdentificadores(ArchivoM pPedimento, int vNumeroPartida)
        {
            try
            {
                if (pPedimento.Partidas[vNumeroPartida].IdentificadoresNPartida != null)
                {
                    //vContadorPedimento = 0;
                    vContadorPartida = 0;
                    var vlista = pPedimento.Partidas[vNumeroPartida].IdentificadoresNPartida;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pIdIdentificadorVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].IdentificadoresNPartida[vContadorPartida].IdCLaveIdentificador));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pComplemento1", SqlDbType.VarChar, 20, pPedimento.Partidas[vNumeroPartida].IdentificadoresNPartida[vContadorPartida].Complemento1));
                        parametros.Add(new SqlParameterItem("@pComplemento2", SqlDbType.VarChar, 30, pPedimento.Partidas[vNumeroPartida].IdentificadoresNPartida[vContadorPartida].Complemento2));
                        parametros.Add(new SqlParameterItem("@pComplemento3", SqlDbType.VarChar, 30, pPedimento.Partidas[vNumeroPartida].IdentificadoresNPartida[vContadorPartida].Complemento3));
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        //vContadorPedimento++;
                        vContadorPartida++;
                        var r512 = helper.ExecuteNonQuery("usp_IdentificadorNivelPartida_Inserta", parametros);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         */

        /// <summary>
        /// CUENTA ADUANERA NIVEL PARTIDA REGISTRO 555
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaCuentasAduanerasNPartida(DatosReg555CuentasAduanerasNPart pCuentasAduanerasNPart, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdInstitucionEmisoraVW", SqlDbType.Int, pCuentasAduanerasNPart.CLaveInstitucionCuentaGarantia));//viene igual
                parametros.Add(new SqlParameterItem("@pFolioConstancia", SqlDbType.VarChar, 17, pCuentasAduanerasNPart.FolioConstancia));
                parametros.Add(new SqlParameterItem("@pFechaConstancia", SqlDbType.Date, pCuentasAduanerasNPart.FechaConstancia));
                parametros.Add(new SqlParameterItem("@pIdTipoCuentaGarantiaVW", SqlDbType.Int, pCuentasAduanerasNPart.CLaveInstitucionCuentaGarantia));//duda
                parametros.Add(new SqlParameterItem("@pValorUnitario", SqlDbType.Float, pCuentasAduanerasNPart.ValorUnitarioTitulo));
                parametros.Add(new SqlParameterItem("@pTotalGarantia", SqlDbType.Float, pCuentasAduanerasNPart.ImporteTotalGarantia));
                parametros.Add(new SqlParameterItem("@pCantidadUM", SqlDbType.Float, pCuentasAduanerasNPart.CantidadUnidadesMedida));
                parametros.Add(new SqlParameterItem("@pTitulosAsignados", SqlDbType.Float, pCuentasAduanerasNPart.TitulosAsignados));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r555 = helper.ExecuteNonQuery("usp_CuentaNivelPartida_Inserta", parametros, false);
                return r555;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool InsertaEnTablaCuentasAduanerasNPartidaVUCEM(Modelo.VUCEMService.DatosReg555CuentasAduanerasNPart pCuentasAduanerasNPart, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdInstitucionEmisoraVW", SqlDbType.Int, pCuentasAduanerasNPart.CLaveInstitucionCuentaGarantia));//viene igual
                parametros.Add(new SqlParameterItem("@pFolioConstancia", SqlDbType.VarChar, 17, pCuentasAduanerasNPart.FolioConstancia));
                parametros.Add(new SqlParameterItem("@pFechaConstancia", SqlDbType.Date, pCuentasAduanerasNPart.FechaConstancia));
                parametros.Add(new SqlParameterItem("@pIdTipoCuentaGarantiaVW", SqlDbType.Int, pCuentasAduanerasNPart.CLaveInstitucionCuentaGarantia));//duda
                parametros.Add(new SqlParameterItem("@pValorUnitario", SqlDbType.Float, pCuentasAduanerasNPart.ValorUnitarioTitulo));
                parametros.Add(new SqlParameterItem("@pTotalGarantia", SqlDbType.Float, pCuentasAduanerasNPart.ImporteTotalGarantia));
                parametros.Add(new SqlParameterItem("@pCantidadUM", SqlDbType.Float, pCuentasAduanerasNPart.CantidadUnidadesMedida));
                parametros.Add(new SqlParameterItem("@pTitulosAsignados", SqlDbType.Float, pCuentasAduanerasNPart.TitulosAsignados));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r555 = helper.ExecuteNonQuery("usp_CuentaNivelPartida_Inserta", parametros, false);
                return r555;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*RESPALDO
         private bool InsertaEnTablaCuentasAduanerasNPartida(ArchivoM pPedimento, int vNumeroPartida)
        {
            try
            {
                if (pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida != null)
                {
                    //vContadorPedimento = 0;
                    vContadorPartida = 0;
                    var vlista = pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pIdInstitucionEmisoraVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].CLaveInstitucionCuentaGarantia));//viene igual
                        parametros.Add(new SqlParameterItem("@pFolioConstancia", SqlDbType.VarChar, 17, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].FolioConstancia));
                        parametros.Add(new SqlParameterItem("@pFechaConstancia", SqlDbType.Date, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].FechaConstancia));
                        parametros.Add(new SqlParameterItem("@pIdTipoCuentaGarantiaVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].CLaveInstitucionCuentaGarantia));//duda
                        parametros.Add(new SqlParameterItem("@pValorUnitario", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].ValorUnitarioTitulo));
                        parametros.Add(new SqlParameterItem("@pTotalGarantia", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].ImporteTotalGarantia));
                        parametros.Add(new SqlParameterItem("@pCantidadUM", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].CantidadUnidadesMedida));
                        parametros.Add(new SqlParameterItem("@pTitulosAsignados", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].CuentasAduanerasNPartida[vContadorPartida].TitulosAsignados));
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        //vContadorPedimento++;
                        vContadorPartida++;
                        var r512 = helper.ExecuteNonQuery("usp_CuentaNivelPartida_Inserta", parametros);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         */

        /// <summary>
        /// TASAS NIVEL PARTIDA REGISTRO 556
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaTasasNPartida(DatosReg556TasasNPart pTasas, int IdPedimento, int IdPartida, int numeropartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdTipoTasaVW", SqlDbType.Int, pTasas.IdTasaContribucion));//FATLA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pTasa", SqlDbType.Float, pTasas.TasaContribucion));
                parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pTasas.IdClaveContribucionGravamenDerechoTasasNPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r556 = helper.ExecuteNonQuery("usp_TasaXPedimento_Inserta", parametros, false);
                return r556;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool InsertaEnTablaTasasNPartidaVUCEM(Modelo.VUCEMService.DatosReg556TasasNPart pTasas, int IdPedimento, int IdPartida, int numeropartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdTipoTasaVW", SqlDbType.Int, pTasas.IdTasaContribucion));//FATLA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pTasa", SqlDbType.Float, pTasas.TasaContribucion));
                parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pTasas.IdClaveContribucionGravamenDerechoTasasNPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r556 = helper.ExecuteNonQuery("usp_TasaXPedimento_Inserta", parametros, false);
                return r556;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*
         private bool InsertaEnTablaTasasNPartida(ArchivoM pPedimento, int vNumeroPartida)
        {
            try
            {
                if (pPedimento.Partidas[vNumeroPartida].TasasNPartida != null)
                {
                    //vContadorPedimento = 0;
                    vContadorPartida = 0;
                    var vlista = pPedimento.Partidas[vNumeroPartida].TasasNPartida;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pIdTipoTasaVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].TasasNPartida[vContadorPartida].IdTasaContribucion));//FATLA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pTasa", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].TasasNPartida[vContadorPartida].TasaContribucion));
                        parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].TasasNPartida[vContadorPartida].IdClaveContribucionGravamenDerechoTasasNPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        //vContadorPedimento++;
                        vContadorPartida++;
                        var r512 = helper.ExecuteNonQuery("usp_TasaXPedimento_Inserta", parametros);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         */

        /// <summary>
        /// GRAVAMEN NIVEL PARTIDA REG 557
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaGravamenNPartida(DatosReg557GravamenNPart pGravamenNPart, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pGravamenNPart.IdClaveContribucionGravamenDerechoNPartida));//FATLA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdFormaPagoVW", SqlDbType.Int, pGravamenNPart.IdClaveFormaPagoNPartida));//FALTA AGREGAR A ENTIDAD
                parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pGravamenNPart.ImporteGravamen));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r557 = helper.ExecuteNonQuery("usp_ContribucionXPartida_Inserta", parametros, false);
                //insercion por parte de pedimento VUCEM
                if (pGravamenNPart.Tasas != null)
                {
                    var vlista2 = pGravamenNPart.Tasas;
                    foreach (var tasas in vlista2)
                    {
                        int NoTasa = 0;
                        List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                        parametros2.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                        parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                        parametros2.Add(new SqlParameterItem("@pIdTipoTasaVW", SqlDbType.Int, pGravamenNPart.Tasas[NoTasa].IdTasaContribucion));//FATLA EN ENTIDAD
                        parametros2.Add(new SqlParameterItem("@pTasa", SqlDbType.Float, pGravamenNPart.Tasas[NoTasa].TasaContribucion));
                        parametros2.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pGravamenNPart.Tasas[NoTasa].IdClaveContribucionGravamenDerechoTasasNPartida));//FALTA EN ENTIDAD
                        parametros2.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        var r556 = helper.ExecuteNonQuery("usp_TasaXPedimento_Inserta", parametros2, false);
                        NoTasa++;
                    }
                }
                return r557;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool InsertaEnTablaGravamenNPartidaVUCEM(Modelo.VUCEMService.DatosReg557GravamenNPart pGravamenNPart, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pGravamenNPart.IdClaveContribucionGravamenDerechoNPartida));//FATLA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdFormaPagoVW", SqlDbType.Int, pGravamenNPart.IdClaveFormaPagoNPartida));//FALTA AGREGAR A ENTIDAD
                parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pGravamenNPart.ImporteGravamen));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r557 = helper.ExecuteNonQuery("usp_ContribucionXPartida_Inserta", parametros, false);
                //insercion por parte de pedimento VUCEM
                if (pGravamenNPart.Tasas != null)
                {
                    var vlista2 = pGravamenNPart.Tasas;
                    foreach (var tasas in vlista2)
                    {
                        int NoTasa = 0;
                        List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                        parametros2.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                        parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                        parametros2.Add(new SqlParameterItem("@pIdTipoTasaVW", SqlDbType.Int, pGravamenNPart.Tasas[NoTasa].IdTasaContribucion));//FATLA EN ENTIDAD
                        parametros2.Add(new SqlParameterItem("@pTasa", SqlDbType.Float, pGravamenNPart.Tasas[NoTasa].TasaContribucion));
                        parametros2.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pGravamenNPart.Tasas[NoTasa].IdClaveContribucionGravamenDerechoTasasNPartida));//FALTA EN ENTIDAD
                        parametros2.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        var r556 = helper.ExecuteNonQuery("usp_TasaXPedimento_Inserta", parametros2, false);
                        NoTasa++;
                    }
                }
                return r557;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*
         private bool InsertaEnTablaGravamenNPartida(ArchivoM pPedimento, int vNumeroPartida)
        {
            try
            {
                if (pPedimento.Partidas[vNumeroPartida].GravamenNPartida != null)
                {
                    vContadorPartida = 0;
                    var vlista = pPedimento.Partidas[vNumeroPartida].GravamenNPartida;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].IdClaveContribucionGravamenDerechoNPartida));//FATLA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdFormaPagoVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].IdClaveFormaPagoNPartida));//FALTA AGREGAR A ENTIDAD
                        parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].ImporteGravamen));
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        var r557 = helper.ExecuteNonQuery("usp_ContribucionXPartida_Inserta", parametros);
                        //insercion por parte de pedimento VUCEM
                        if (pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].Tasas != null)
                        {
                            //vContadorPartida = 0;
                            var vlista2 = pPedimento.Partidas[vNumeroPartida].TasasNPartida;
                            foreach (var tasas in vlista2)
                            {
                                int NoTasa = 0;
                                List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                                parametros.Add(new SqlParameterItem("@pIdTipoTasaVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].Tasas[NoTasa].IdTasaContribucion));//FATLA EN ENTIDAD
                                parametros.Add(new SqlParameterItem("@pTasa", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].Tasas[NoTasa].TasaContribucion));
                                parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].Tasas[NoTasa].IdClaveContribucionGravamenDerechoTasasNPartida));//FALTA EN ENTIDAD
                                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                                var r556 = helper.ExecuteNonQuery("usp_TasaXPedimento_Inserta", parametros2);
                                NoTasa++;
                            }
                        }
                        vContadorPartida++;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         * */

        /*
         * private bool InsertaEnTablaGravamenNPartida(ArchivoM pPedimento, int vNumeroPartida)
        {
            try
            {
                if (pPedimento.Partidas[vNumeroPartida].GravamenNPartida.Count() != 0)
                {
                    //vContadorPedimento = 0;
                    vContadorPartida = 0;
                    var vlista = pPedimento.Partidas[vNumeroPartida].GravamenNPartida;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].IdClaveContribucionGravamenDerechoNPartida));//FATLA EN ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdFormaPagoVW", SqlDbType.Int, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].IdClaveFormaPagoNPartida));//FALTA AGREGAR A ENTIDAD
                        parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pPedimento.Partidas[vNumeroPartida].GravamenNPartida[vContadorPartida].ImporteGravamen));
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        //vContadorPedimento++;
                        vContadorPartida++;
                        var r512 = helper.ExecuteNonQuery("usp_ContribucionXPartida_Inserta", parametros);

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         */
        /// <summary>
        /// OBSERVACIONES NIVEL PARTIDA REG 558
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaObservacionesNPartida(string pObservacionesNPart, int IdPedimento, int IdPartida)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, IdPartida));//FALTA EN ENTIDAD
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, IdPedimento));
                parametros.Add(new SqlParameterItem("@pObservacion", SqlDbType.VarChar, 2000, pObservacionesNPart));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                return helper.ExecuteNonQuery("usp_ObservacionNivelPartida_Inserta", parametros, false);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*
         private bool InsertaEnTablaObservacionesNPartida(ArchivoM pPedimento)
        {
            try
            {
                if (pPedimento.ObservacionesNPart != null)
                {
                    vContadorPedimento = 0;
                    string ObserUnidas = string.Empty;
                    var vlista = pPedimento.ObservacionesNPart;
                    foreach (var Observaciones in vlista)
                    {
                        ObserUnidas = ObserUnidas + pPedimento.ObservacionesNPart[vContadorPedimento].ObservacionesNivelPartida + " | ";
                        vContadorPedimento++;
                    }

                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, pPedimento.IdPartida));//FALTA EN ENTIDAD
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pObservacion", SqlDbType.VarChar, 2000, ObserUnidas));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    return helper.ExecuteNonQuery("usp_ObservacionNivelPartida_Inserta", parametros);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         * */

        /// <summary>
        /// PARTIDAS INDUSTRIA AUTOMOTRIZ REG 560
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaPartidaInfIA(ArchivoM pPedimento)
        {
            try
            {
                if (pPedimento.PartidaIndAutomotriz != null)
                {
                    vContadorPedimento = 0;
                    var vlista = pPedimento.PartidaIndAutomotriz;
                    foreach (var Candados in vlista)
                    {
                        List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                        parametros.Add(new SqlParameterItem("@pImporteSinIncrementables", SqlDbType.Float, pPedimento.PartidaIndAutomotriz[vContadorPedimento].ImportePrecioSinIncrementables));
                        parametros.Add(new SqlParameterItem("@pValorUSD", SqlDbType.Float, pPedimento.PartidaIndAutomotriz[vContadorPedimento].ValosFacturaUSD));
                        parametros.Add(new SqlParameterItem("@pMercanciaUMC", SqlDbType.Float, pPedimento.PartidaIndAutomotriz[vContadorPedimento].CantidadMercanciaUM));
                        parametros.Add(new SqlParameterItem("@pIdUnidadMedidaComercialVW", SqlDbType.Int, pPedimento.PartidaIndAutomotriz[vContadorPedimento].IdClaveUnidadMedidaImpuestos));//FALTA ENTIDAD
                        parametros.Add(new SqlParameterItem("@pCantidadMercancia", SqlDbType.Float, pPedimento.PartidaIndAutomotriz[vContadorPedimento].CantidadMercanciaUM));
                        parametros.Add(new SqlParameterItem("@pIdUnidadMedidaTarifaVW", SqlDbType.Int, pPedimento.PartidaIndAutomotriz[vContadorPedimento].IdClaveUnidadMedida));//FALTA ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPaisOrigenDestinoVW", SqlDbType.Int, pPedimento.PartidaIndAutomotriz[vContadorPedimento].IdClavePaisDestinoFinal));//FALTA ENTIDAD
                        parametros.Add(new SqlParameterItem("@pIdPaisCompradorVendedorVW", SqlDbType.Int, pPedimento.PartidaIndAutomotriz[vContadorPedimento].IdClavePaisVendeIE));//FALTA ENTIDAD
                        parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                        var r512 = helper.ExecuteNonQuery("usp_PartidasInformeIndustriaAutomotriz_Inserta", parametros, false);
                        vContadorPedimento++;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// DATOS GENERALES PREVIO CONSOLIDADO REGISTRO 601
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaDatosGeneralesPConsolidado(ArchivoM pPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                parametros.Add(new SqlParameterItem("@pIdPatenteVW", SqlDbType.Int, pPedimento.DatosGeneralesPrevioConsolidado));
                parametros.Add(new SqlParameterItem("@pIdAduanaSeccionVW", SqlDbType.Int, pPedimento.DatosGeneralesPrevioConsolidado.IdClaveAduanaSeccion));
                parametros.Add(new SqlParameterItem("@pIdClavePedimentoVW", SqlDbType.Int, pPedimento.DatosGeneralesPrevioConsolidado.IdClaveTramiteAduanero));
                parametros.Add(new SqlParameterItem("@pIdTipoOperacionVW", SqlDbType.Int, pPedimento.DatosGeneralesPrevioConsolidado.IdClaveImportacionExportacion));
                parametros.Add(new SqlParameterItem("@pCURPCausante", SqlDbType.VarChar, 18, pPedimento.DatosGeneralesPrevioConsolidado.CURPCausante));
                parametros.Add(new SqlParameterItem("@pRFCCausante", SqlDbType.VarChar, 13, pPedimento.DatosGeneralesPrevioConsolidado.RFCCausante));
                parametros.Add(new SqlParameterItem("@pCURPAgente", SqlDbType.VarChar, 18, pPedimento.DatosGeneralesPrevioConsolidado.CURPAgenteAduanal));
                parametros.Add(new SqlParameterItem("@pIdDestinoVW", SqlDbType.Int, pPedimento.DatosGeneralesPrevioConsolidado.IdClaveDestinoMercancia));
                parametros.Add(new SqlParameterItem("@pRFCAgente", SqlDbType.VarChar, 13, pPedimento.DatosGeneralesPrevioConsolidado.RFCAgenteAduanal));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var r512 = helper.ExecuteNonQuery("usp_PrevioConsolidado_Inserta", parametros, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// RECTIFICACION REGISTRO 701 y REGISTRO 702 SE CREO STORE PROCEDURE, REVISAR
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaRectificacion(ArchivoM pPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                parametros.Add(new SqlParameterItem("@pFechaPago", SqlDbType.Date, pPedimento.Rectificacion.FechaPago));
                parametros.Add(new SqlParameterItem("@pPedimentoOriginal", SqlDbType.VarChar, 7, pPedimento.Rectificacion.NumeroPedimentoOriginal));
                parametros.Add(new SqlParameterItem("@pPatenteOriginal", SqlDbType.VarChar, 4, pPedimento.Rectificacion.PatenteAgenteAduanalOriginal));
                parametros.Add(new SqlParameterItem("@pNoAduanaOriginal", SqlDbType.VarChar, 4, pPedimento.Rectificacion.AduanaSeccionOriginal));
                parametros.Add(new SqlParameterItem("@pNoDocumentoOriginal", SqlDbType.VarChar, 3, pPedimento.Rectificacion.NumeroPedimentoOriginal));
                parametros.Add(new SqlParameterItem("@pFechaOriginal", SqlDbType.Date, pPedimento.Rectificacion.FechaOperacionOriginal));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var respuestarectificacion = helper.ExecuteNonQuery("usp_Rectificacion_Inserta", parametros, false);
                var vIdRectificacion = helper.GetParameterOutput("@pID");
                if (respuestarectificacion)
                {
                    if (pPedimento.DiferenciaNPed != null)
                    {
                        vContadorPedimento = 0;
                        var vlista = pPedimento.DiferenciaNPed;
                        foreach (var Diferencias in vlista)
                        {
                            List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                            parametros2.Add(new SqlParameterItem("@pIdRectificacion", SqlDbType.Int, vIdRectificacion));
                            parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                            parametros2.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.DiferenciaNPed[vContadorPedimento].IdClaveGravamen));
                            parametros2.Add(new SqlParameterItem("@pIdFormaPago", SqlDbType.Int, pPedimento.DiferenciaNPed[vContadorPedimento].IdClaveFormaPago));
                            parametros2.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pPedimento.DiferenciaNPed[vContadorPedimento].ImportePago));
                            parametros2.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                            vContadorPedimento++;
                            var r512 = helper.ExecuteNonQuery("usp_DiferenciaNPedimento_Inserta", parametros2, false);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// PEDIMENTO COMPLEMENTARIO REGISTRO 301 LISTO REVISAR STORE PROCEDURE
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaPedimentoComplementario(ArchivoM pPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                parametros.Add(new SqlParameterItem("@pTipoCambio", SqlDbType.Float, pPedimento.DatosGeneralesPedComplementario.TipoCambioUSD));
                parametros.Add(new SqlParameterItem("@pRFCCausante", SqlDbType.VarChar, 13, pPedimento.DatosGeneralesPedComplementario.RFCCausante));
                parametros.Add(new SqlParameterItem("@pCURPCausante", SqlDbType.VarChar, 18, pPedimento.DatosGeneralesPedComplementario.CURPCausante));
                parametros.Add(new SqlParameterItem("@pNombreImpExp", SqlDbType.VarChar, 120, pPedimento.DatosGeneralesPedComplementario.NombreIE));
                parametros.Add(new SqlParameterItem("@pCurpAgente", SqlDbType.VarChar, 18, pPedimento.DatosGeneralesPedComplementario.CURPAA));
                parametros.Add(new SqlParameterItem("@pRFCAgente", SqlDbType.VarChar, 13, pPedimento.DatosGeneralesPedComplementario.RFCAA));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                var re = helper.ExecuteNonQuery("usp_PedimentoComplementario_Inserta", parametros, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// PRUEBA SUFICIENTE REGISTRO 302
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaPruebaSuficiente(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.PruebaSuficiente;
                foreach (var Pruebas in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdPaisVW", SqlDbType.Int, pPedimento.PruebaSuficiente[vContadorPedimento].IdClavePais));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pPedimentoEUACAN", SqlDbType.VarChar, 14, pPedimento.PruebaSuficiente[vContadorPedimento].NumeroPedimentoEUACAN));
                    parametros.Add(new SqlParameterItem("@pIdTipoPruebaSuficienteVW", SqlDbType.Int, pPedimento.PruebaSuficiente[vContadorPedimento].IdPruebaSuficiente));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pFecha", SqlDbType.Date, pPedimento.PruebaSuficiente[vContadorPedimento].FechaDocumento));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var re = helper.ExecuteNonQuery("usp_PruebaSuficiente_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// DETERMINACION CONTRIBUCIONES NIVEL PARTIDA REG 351
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaDeterminacionContribucionNPartida(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.DetContribucionesNPart;
                foreach (var Pruebas in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdPaisDestinoVW", SqlDbType.Int, pPedimento.DetContribucionesNPart[vContadorPedimento].IdClavePaisDestino));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPedimento.DetContribucionesNPart[vContadorPedimento].IdFraccionArancelaria));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pNoSecuencia", SqlDbType.Int, pPedimento.DetContribucionesNPart[vContadorPedimento].SecuenciaPartida));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pValorMercanciaNoOriginaria", SqlDbType.Float, pPedimento.DetContribucionesNPart[vContadorPedimento].ValorMercancia));
                    parametros.Add(new SqlParameterItem("@pMontoIGI", SqlDbType.Float, pPedimento.DetContribucionesNPart[vContadorPedimento].MontoIGI));
                    parametros.Add(new SqlParameterItem("@pArancelTotal", SqlDbType.Float, pPedimento.DetContribucionesNPart[vContadorPedimento].ArancelTotalPagado));
                    parametros.Add(new SqlParameterItem("@pIdMonedaVW", SqlDbType.Int, pPedimento.DetContribucionesNPart[vContadorPedimento].IdMoneda));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pMontoExento", SqlDbType.Float, pPedimento.DetContribucionesNPart[vContadorPedimento].MontoExento));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var re = helper.ExecuteNonQuery("usp_DeterminaContribucionPCTLC_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// DETALLE IMPORTACION EUACANPC REGISTRO 352 FALTA STORE
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaDetalleImportacion(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.DetalleImportacionEUACAN;
                foreach (var Pruebas in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdPaisVW", SqlDbType.Int, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].IdPaisDestino));
                    parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].IdFraccionAranceralia));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pNoSecuencia", SqlDbType.Int, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].NumeroSecuenciaPartida));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pIdUnidadMedidaVW", SqlDbType.Float, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].IdUnidadMedidaEUACAN));
                    parametros.Add(new SqlParameterItem("@pCantidadUMT", SqlDbType.Float, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].CantidadUnidadTarifaEUACAN));
                    parametros.Add(new SqlParameterItem("@pFraccionEUACAN", SqlDbType.VarChar, 11, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].FraccionArancelariaEUACAN));
                    parametros.Add(new SqlParameterItem("@pTasaEUACAN", SqlDbType.Float, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].TasaArancelEUACAN));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pArancelEUACAN", SqlDbType.Float, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].ArancelImportacionEUACAN));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pMoneda", SqlDbType.VarChar, 3, pPedimento.DetalleImportacionEUACAN[vContadorPedimento].IdMoneda));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var re = helper.ExecuteNonQuery("usp_DetalleImportacionEUACANPC_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// PAGO CONTRIBUCIONES NPARTIDA REGISTRO 353
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaDeterminacionYOPagoContribucionesNPartidaTLCAELC(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.DeterminacionPagoContribucioneNPed;
                foreach (var Pruebas in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPedimento.DeterminacionPagoContribucioneNPed[vContadorPedimento].IdFraccionAracelariaPagoContribucion));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pNoSecuencia", SqlDbType.Int, pPedimento.DeterminacionPagoContribucioneNPed[vContadorPedimento].NumeroSecuencialPartida));
                    parametros.Add(new SqlParameterItem("@pValorMercancia", SqlDbType.Float, pPedimento.DeterminacionPagoContribucioneNPed[vContadorPedimento].ValorMercanciaNoOriginaria));
                    parametros.Add(new SqlParameterItem("@pMontoIGI", SqlDbType.Float, pPedimento.DeterminacionPagoContribucioneNPed[vContadorPedimento].MontoIGI));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var re = helper.ExecuteNonQuery("usp_DeterminaPagoContribucionPCTLC_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// PAGO CONTRIBUCIONES POR APLICACION NIVEL PARTIDA REGISTRO 355
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaPagoContribucionesXAplicacion(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.PagoContribucionesPorAplicacion;
                foreach (var Pruebas in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdPaisVW", SqlDbType.Int, pPedimento.PagoContribucionesPorAplicacion[vContadorPedimento].IdClavePaisDestino));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPedimento.PagoContribucionesPorAplicacion[vContadorPedimento].IdFraccionAracelariaPagoContribucion));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pSecuenciaPartida", SqlDbType.Int, pPedimento.PagoContribucionesPorAplicacion[vContadorPedimento].NumeroSecuencialPartida));
                    parametros.Add(new SqlParameterItem("@pIdContribucionVW", SqlDbType.Int, pPedimento.PagoContribucionesPorAplicacion[vContadorPedimento].IdClaveGravamen));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pIdFormaPagoVW", SqlDbType.Int, pPedimento.PagoContribucionesPorAplicacion[vContadorPedimento].IdFormaPago));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Float, pPedimento.PagoContribucionesPorAplicacion[vContadorPedimento].ImportePago));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var re = helper.ExecuteNonQuery("usp_PagoContAplicacionTLCNPartida_Inserta", parametros, false);
                    vContadorPedimento++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// OBSERVACIONES NIVEL PARTIDA PEDIMENTO COMPLEMENTARIO REGISTRO 358 REVISAR
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool InsertaEnTablaObservacionesNPedimentoComplementario(ArchivoM pPedimento)
        {
            try
            {
                vContadorPedimento = 0;
                var vlista = pPedimento.ObservacionesNPedComplementario;
                foreach (var Pruebas in vlista)
                {
                    List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                    parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pPedimento.IdPedimento));
                    parametros.Add(new SqlParameterItem("@pIdPaisVW", SqlDbType.Int, pPedimento.ObservacionesNPedComplementario[vContadorPedimento].IdClavePaisDestino));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pIdFraccionVW", SqlDbType.Int, pPedimento.ObservacionesNPedComplementario[vContadorPedimento].IdFraccionArancelaria));//FALTA ENTIDAD
                    parametros.Add(new SqlParameterItem("@pSecuenciaPartida", SqlDbType.Int, pPedimento.ObservacionesNPedComplementario[vContadorPedimento].NumeroSecuencialPartida));
                    parametros.Add(new SqlParameterItem("@pObservacion", SqlDbType.VarChar, 120, pPedimento.ObservacionesNPedComplementario[vContadorPedimento].Observaciones));
                    parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                    var re = helper.ExecuteNonQuery("usp_ObservacionNPartidaPComplementario_Inserta", parametros, false);
                    vContadorPedimento++;

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Funcion que ejecuta las Estadisticas Finales del Pedimento
        /// </summary>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private bool ExecuteSPEstadisticasGenerales(int pIdPedimento)
        {
            try
            {
                List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, pIdPedimento));
                parametros2.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, false, ParameterDirection.Output));
                var res = helper.ExecuteNonQuery("usp_Estadistica_GeneralPedimento", parametros2, false);
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Metodos Publicos
        public bool RegistraPedimentoBD(ArchivoM pedimento)
        {
            try
            {


                //vBaseDatos = Pedimento.IdEmpresa;
                //inserta encabezado pedimento
                InicializaConexion(pedimento.IdEmpresa);
                if (InsertaEnTablaPedimento(pedimento))
                {
                    if (pedimento.Transporte != null)
                    {
                        var rtransporte = InsertarEnTablaTransporte(pedimento);
                    }
                    if (pedimento.Guias != null)
                    {
                        var rguias = InsertaEnTablaGuia(pedimento);
                    }
                    if (pedimento.Contenedores != null)
                    {
                        var rcontedores = InsertaEnTablaContenedor(pedimento);
                    }
                    if (pedimento.Facturas != null)
                    {
                        var rfacturas = InsertaEnTablaFacturas(pedimento);
                    }
                    if (pedimento.Fechas != null)
                    {
                        var rfechas = InsertaEnTablaFechas(pedimento);
                    }
                    if (pedimento.IdentificadoresNPed != null)
                    {
                        var ridentificadores = InsertaEnTablaIdentificadoresNPed(pedimento);
                    }
                    if (pedimento.CuentasAduanerasNPed != null)
                    {
                        var rcuentasaduaneras = InsertaEnTablaCuentasAduanerasNPed(pedimento);
                    }
                    if (pedimento.TasasNPed != null)
                    {
                        var rtasas = InsertaEnTablaTasasNPed(pedimento);
                    }
                    if (pedimento.ContribucionesNPed != null)
                    {
                        var rcontribuciones = InsertaEnTablaContribucionesNPed(pedimento);
                    }
                    if (pedimento.ObservacionesNPed != null)
                    {
                        var robsevaciones = InsertaEnTablaObservacionesNPed(pedimento);
                    }
                    if (pedimento.Descargos != null)
                    {
                        var rdescargos = InsertaEnTablaDescargos(pedimento);
                    }
                    if (pedimento.Compensaciones != null)
                    {
                        var rcompensaciones = InsertaEnTablaCompensaciones(pedimento);
                    }
                    if (pedimento.DoctosFormaPago != null)
                    {
                        var rdocumentoampara = InsertaEnTablaAmparaFormaPago(pedimento);
                    }
                    if (pedimento.InformeIndustriaAut != null)
                    {
                        var rinformeIa = InsertaEnTablaInformeIndustriAut(pedimento);
                    }
                    if (pedimento.Candados != null)
                    {
                        var rcandados = InsertaEnTablaCandados(pedimento);
                    }
                    if (pedimento.Destinatarios != null)
                    {
                        var rdestinatarios = InsertaEnTablaDestinatarios(pedimento);
                    }
                    if (pedimento.Partidas != null)
                    {
                        var lista = pedimento.Partidas;
                        int vNoPartidas = 0;
                        foreach (var Partida in lista)
                        {
                            var rpartidas = InsertaEnTablaPartidas(pedimento.Partidas[vNoPartidas], pedimento.IdPedimento);
                            vNoPartidas++;
                        }
                        ////Se pasan las contribuciones por partida a contribuciones pedimento
                        //List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        //parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, Pedimento.IdPedimento));
                        //var rcontribucionXPedimento = helper.ExecuteNonQuery("usp_spSTCreaRegistroContribucionPartidaEnPedimento", parametros);
                        ////Se Hace el calculo de los valores de aduana e impuestos por pedimento sumarizando las partidas
                        //List<SqlParameterItem> parametros3 = new List<SqlParameterItem>();
                        //parametros3.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, Pedimento.IdPedimento));
                        //var rCalculoValores =helper.ExecuteNonQuery("usp_Estadistica_GeneralPartida", parametros3);
                        ////Calcula la partida
                        //List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                        //parametros.Add(new SqlParameterItem("@pIdPartida", SqlDbType.Int, Pedimento.IdPedimento));
                        //parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, false, ParameterDirection.Output));
                        //var rCalculoValores = helper.ExecuteNonQuery("usp_Estadistica_GeneralPartida", parametros);
                    }

                    if (pedimento.PartidaIndAutomotriz != null)
                    {
                        var rinformePartidaIA = InsertaEnTablaPartidaInfIA(pedimento);
                    }
                    if (pedimento.DatosGeneralesPrevioConsolidado != null)
                    {
                        var rprevioconsolidado = InsertaEnTablaDatosGeneralesPConsolidado(pedimento);
                    }
                    if (pedimento.Rectificacion != null)
                    {
                        var rrectificacion = InsertaEnTablaRectificacion(pedimento);
                    }
                    if (pedimento.DatosGeneralesPedComplementario != null)
                    {
                        var rcomplementacio = InsertaEnTablaPedimentoComplementario(pedimento);
                    }
                    if (pedimento.PruebaSuficiente != null)
                    {
                        var rprueba = InsertaEnTablaPruebaSuficiente(pedimento);
                    }
                    if (pedimento.DetContribucionesNPart != null)
                    {
                        var rcontribucionesnp = InsertaEnTablaDeterminacionContribucionNPartida(pedimento);
                    }
                    if (pedimento.DetalleImportacionEUACAN != null)
                    {
                        var rdetalle = InsertaEnTablaDetalleImportacion(pedimento);
                    }
                    if (pedimento.DeterminacionPagoContribucioneNPed != null)
                    {
                        var rcontribucionesnpartida = InsertaEnTablaDeterminacionYOPagoContribucionesNPartidaTLCAELC(pedimento);
                    }
                    if (pedimento.PagoContribucionesPorAplicacion != null)
                    {
                        var rpagocontribuciones = InsertaEnTablaPagoContribucionesXAplicacion(pedimento);
                    }
                    if (pedimento.ObservacionesNPedComplementario != null)
                    {
                        var robservacionesnp = InsertaEnTablaObservacionesNPedimentoComplementario(pedimento);
                    }
                    ////calculo ponderacion de el pedimento
                    //List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                    //parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, Pedimento.IdPedimento));
                    //helper.ExecuteNonQuery("usp_spSTPonderaPedimento", parametros2);

                    //List<SqlParameterItem> parametros2 = new List<SqlParameterItem>();
                    //parametros2.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, Pedimento.IdPedimento));
                    //parametros2.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, false, ParameterDirection.Output));
                    //helper.ExecuteNonQuery("usp_Estadistica_GeneralPedimento", parametros2, false);

                    ExecuteSPEstadisticasGenerales(pedimento.IdPedimento);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// Funcion para ArchivoM
        /// </summary>
        /// <param name="pPartida"></param>
        /// <param name="pIdPedimento"></param>
        /// <param name="pIdEmpresa"></param>
        /// <returns></returns>
        public bool RegistraPartidaBD(DatosReg551Partidas pPartida, int pIdPedimento, int pIdEmpresa)
        {
            InicializaConexion(pIdEmpresa);
            var res = InsertaEnTablaPartidas(pPartida, pIdPedimento);
            return res;
        }

        public Archivo InsertaExpedienteDigital(Archivo archivo, int idCuentaGasto, int idUsuario)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresaVW", SqlDbType.Int, archivo.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pIdCuentaGasto", SqlDbType.Int, idCuentaGasto));
            parametros.Add(new SqlParameterItem("@pIdArticulo", SqlDbType.Int, 0));
            parametros.Add(new SqlParameterItem("@pNombreOrigen", SqlDbType.VarChar, 100, archivo.NombreArchivo));
            parametros.Add(new SqlParameterItem("@pNombreDestino", SqlDbType.VarChar, 100, archivo.NuevoNombreArchivo));
            parametros.Add(new SqlParameterItem("@pPath", SqlDbType.VarChar, 300, archivo.PathDestino));
            parametros.Add(new SqlParameterItem("@pIdTipoDocumentoVW", SqlDbType.Int, archivo.IdTipoDocumento));
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, idUsuario));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            helper.ExecuteNonQuery("usp_ExpedienteDigital_Inserta", parametros);
            archivo.IdArchivo = Convert.ToInt16(helper.GetParameterOutput("@pId"));
            return archivo;
        }

        public bool InsertaGrupoArchivos(int idPedimento, int idExpedienteDigital, int idEmpresa)
        {
            helper = InicializaConexion(idEmpresa);
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, idPedimento));
            parametros.Add(new SqlParameterItem("@pIdExpedienteDigital", SqlDbType.Int, idExpedienteDigital));
            parametros.Add(new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output));
            helper.ExecuteNonQuery("usp_GrupoArchivo_Inserta", parametros);
            return true;
        }
        #endregion

        #region Consultar IDs

        public int DameIdAduanaXClave(ArchivoM pedimento)
        {
            //var item = new EntidadCatalogo();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pClaveAduanaSeccion", SqlDbType.VarChar, 5, pedimento.CLaveAduanaSeccionEntradaSalida));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
            var helper = InicializaConexion(pedimento.IdEmpresa);
            helper.ExecuteNonQuery("usp_AduanaSeccion_DameIDxClave", parametros);
            return Convert.ToInt16(helper.GetParameterOutput("@pID"));
        }
        public int DameIdPatenteXNumeroPatente(ArchivoM pedimento)
        {
            //var item = new EntidadCatalogo();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pNumeroPatente", SqlDbType.VarChar, 4, pedimento.Patente));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
            var helper = InicializaConexion(pedimento.IdEmpresa);
            helper.ExecuteNonQuery("usp_PatenteVW_DameIDXNumeroPatente", parametros);
            return Convert.ToInt16(helper.GetParameterOutput("@pID"));
        }

        public bool InsertaGrupoArchivos(int idPedimento, int idExpedienteDigital)
        {
            throw new NotImplementedException();
        }

        public ArchivoM DameIdPedimentoXPedimento(ArchivoM pedimento)
        {
            try
            {
                //var item = new EntidadCatalogo();
                var parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, pedimento.IdEmpresa));
                parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.Int, pedimento.IdPatente));
                parametros.Add(new SqlParameterItem("@pIdAduana", SqlDbType.Int, pedimento.IdAduanaSeccionVW));
                parametros.Add(new SqlParameterItem("@pPedimento", SqlDbType.VarChar, 10, pedimento.NumeroPedimento));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
                var Helper = InicializaConexion(pedimento.IdEmpresa);
                Helper.ExecuteNonQuery("usp_Pedimento_DameIDxPedimento", parametros);
                pedimento.IdPedimento = Convert.ToInt16(Helper.GetParameterOutput("@pID"));
                return pedimento;
            }
            catch (Exception e)
            {
                pedimento.IdPedimento = 0;
                return pedimento;
            }
        }

        public int DameIdPartidaXIdPedimentoYNoSecuencia(int pNumeroPartida, int pIdPedimento, int pIdEmpresa)
        {
            try
            {
                var parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pSecuenciaPartida", SqlDbType.Int, pNumeroPartida));
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.SmallInt, pIdPedimento));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
                var Helper = InicializaConexion(pIdEmpresa);
                Helper.ExecuteNonQuery("usp_Partida_DameIDxIdPedimentoYNoPartida", parametros);
                var IdPartida = Convert.ToInt16(Helper.GetParameterOutput("@pID"));
                return IdPartida;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        //public bool RegistraPartidaBD(ArchivoM partida)
        //{
        //    throw new NotImplementedException();
        //}


        public ArchivoM DameIdPedimentoXPedimentoYOrigen(ArchivoM pedimento)
        {
            try
            {
                //var item = new EntidadCatalogo();
                var parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, pedimento.IdEmpresa));
                parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.Int, pedimento.IdPatente));
                parametros.Add(new SqlParameterItem("@pIdAduana", SqlDbType.Int, pedimento.IdAduanaSeccionVW));
                parametros.Add(new SqlParameterItem("@pPedimento", SqlDbType.VarChar, 10, pedimento.NumeroPedimento));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
                var Helper = InicializaConexion(pedimento.IdEmpresa);
                Helper.ExecuteNonQuery("usp_Pedimento_DameIDxPedimentoYOrigen", parametros);
                pedimento.IdPedimento = Convert.ToInt16(Helper.GetParameterOutput("@pID"));
                return pedimento;
            }
            catch (Exception e)
            {
                return pedimento;
            }
        }

        public ArchivoM InactivaPedimentoVUCEM(ArchivoM pedimento)
        {
            try
            {
                //var item = new EntidadCatalogo();
                var parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, pedimento.IdEmpresa));
                parametros.Add(new SqlParameterItem("@pIdPatente", SqlDbType.Int, pedimento.IdPatente));
                parametros.Add(new SqlParameterItem("@pIdAduana", SqlDbType.Int, pedimento.IdAduanaSeccionVW));
                parametros.Add(new SqlParameterItem("@pPedimento", SqlDbType.VarChar, 10, pedimento.NumeroPedimento));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
                var Helper = InicializaConexion(pedimento.IdEmpresa);
                Helper.ExecuteNonQuery("usp_Pedimento_InactivaPedimentoVUCEM", parametros);
                pedimento.IdPedimento = Convert.ToInt16(Helper.GetParameterOutput("@pID"));
                return pedimento;
            }
            catch (Exception e)
            {
                return pedimento;
            }
        }

        public List<ArchivoM> DameListaXPedimento(ArchivoM pedimento)
        {
            try
            {
                //var item = new EntidadCatalogo();
                var listado = new List<ArchivoM>();
                var parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, pedimento.IdEmpresa));
                parametros.Add(new SqlParameterItem("@pPedimento", SqlDbType.VarChar, 10, pedimento.NumeroPedimento));
                parametros.Add(new SqlParameterItem("@pPagina", SqlDbType.Int, 1));
                parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.Int, 20));
                parametros.Add(new SqlParameterItem("@pTotalRegistros", SqlDbType.Int, 0, ParameterDirection.Output));
                InicializaConexion(pedimento.IdEmpresa);
                var reader = helper.ExecuteReader("[usp_Pedimento_DameListaXPedimento]", parametros);
                while (reader.Read())
                {
                    listado.Add(new ArchivoM()
                    {
                        IdPedimento = reader.GetInt32(reader.GetOrdinal("IdPedimento")),
                        IdTipoMovimiento = reader.GetInt32(reader.GetOrdinal("IdTipoMovimientoVW")),
                        NumeroPedimento = Convert.ToInt64(reader.GetString(reader.GetOrdinal("Pedimento"))),
                        NumeroPedimentoCompleto = reader.GetString(reader.GetOrdinal("NumeroPedimentoCompleto")),
                        IdAduanaSeccionVW = reader.GetInt32(reader.GetOrdinal("IdAduanaSeccionVW")),
                        //TipoCambio = reader.GetFloat(reader.GetOrdinal("TipoCambio")),
                        //ValorDolares = reader.GetFloat(reader.GetOrdinal("ValorUSD")),
                        //ValorAduanaTotal = reader.GetFloat(reader.GetOrdinal("ValorAduana")),
                        IdPatente = reader.GetInt32(reader.GetOrdinal("IdPatenteVW"))
                        
                    });
                }
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int RegistraPartidaBD(Modelo.VUCEMService.DatosReg551Partidas pPartida, int pIdPedimento, int pIdEmpresa)
        {
            InicializaConexion(pIdEmpresa);
            var res = InsertaEnTablaPartidasVUCEM(pPartida, pIdPedimento);
            return res;
        }

        #endregion



        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
