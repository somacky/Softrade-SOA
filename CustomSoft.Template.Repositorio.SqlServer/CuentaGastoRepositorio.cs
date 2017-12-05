﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class CuentaGastoRepositorio : ICuentaGastoRepositorio
    {
        private SqlHelper helper = null;

        private string baseDatos;
        public SqlHelper InicializaConexion(int pIdEmpresa)
        {
            baseDatos = Util.DameBDxIdEmpresa(pIdEmpresa);
            //pBaseDatos = "BASFPrueba";
            //return new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));

            //Leo la conexion que se tiene en el WEbconfig
            var conexion = ConfigurationManager.ConnectionStrings["cnSqlServerEmpresas"].ConnectionString;

            //sustituyo el parametro por la base de datos a pegarle
            var conexionparametrizada = string.Format(conexion, baseDatos);
            helper = new SqlHelper(conexionparametrizada);
            return helper;
        } 
        
        /// <summary>
        /// Funcion que inserta el base de datos la cuenta de gasto 
        /// </summary>
        /// <param name="cuentaGasto"></param>
        /// <returns></returns>
        public CuentaGasto InsertaFactura(CuentaGasto cuentaGasto)
        {
            try
            {
                List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, cuentaGasto.IdEmpresa));
                parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, cuentaGasto.IdPedimento));
                parametros.Add(new SqlParameterItem("@pNumeroFactura", SqlDbType.VarChar, 50, cuentaGasto.NumeroFactura));
                parametros.Add(new SqlParameterItem("@pOtrosDatos", SqlDbType.VarChar, 15, cuentaGasto.OtrosDatos));
                parametros.Add(new SqlParameterItem("@pIdComplementoFacturaVW ", SqlDbType.Int,cuentaGasto.IdComplementoFacturaVW));
                parametros.Add(new SqlParameterItem("@pXML", SqlDbType.VarChar, 100, cuentaGasto.XML));
                parametros.Add(new SqlParameterItem("@pPDF", SqlDbType.VarChar, 100, cuentaGasto.PDF));
                parametros.Add(new SqlParameterItem("@pIdMonedaVW", SqlDbType.Int, cuentaGasto.IdMonedaVW));
                parametros.Add(new SqlParameterItem("@pMontoTotal", SqlDbType.Decimal, cuentaGasto.MontoTotal));
                parametros.Add(new SqlParameterItem("@pTipoCambio", SqlDbType.Float, cuentaGasto.TipoCambio));
                parametros.Add(new SqlParameterItem("@pUUID", SqlDbType.VarChar, 35, cuentaGasto.UUID));
                parametros.Add(new SqlParameterItem("@pFechaFactura", SqlDbType.DateTime, cuentaGasto.FechaFactura));
                parametros.Add(new SqlParameterItem("@pSubtotal", SqlDbType.Decimal, cuentaGasto.Subtotal));
                parametros.Add(new SqlParameterItem("@pIdTipoComprobanteVW", SqlDbType.Int,cuentaGasto.IdTipoComprobanteVW));
                parametros.Add(new SqlParameterItem("@pRFCEmisor", SqlDbType.VarChar, 15, cuentaGasto.RFCEmisor));
                parametros.Add(new SqlParameterItem("@pNombreEmisor", SqlDbType.VarChar, 200, cuentaGasto.NombreEmisor));
                parametros.Add(new SqlParameterItem("@pIVA", SqlDbType.Decimal, cuentaGasto.IVA));
                parametros.Add(new SqlParameterItem("@pIEPS", SqlDbType.Decimal, cuentaGasto.IEPS));
                parametros.Add(new SqlParameterItem("@pRetencionIVA", SqlDbType.Decimal, cuentaGasto.RetencionIVA));
                parametros.Add(new SqlParameterItem("@pRetencionISR", SqlDbType.Decimal, cuentaGasto.RetencionISR));
                parametros.Add(new SqlParameterItem("@pConfirmado", SqlDbType.Bit, cuentaGasto.Confirmado));
                parametros.Add(new SqlParameterItem("@pSerie", SqlDbType.VarChar, 2, cuentaGasto.Serie));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                //Se inicializa exactamente la conexión a la base de datos
                InicializaConexion(cuentaGasto.IdEmpresa);
                helper.ExecuteNonQuery("usp_CuentaGasto_Inserta", parametros);
                cuentaGasto.IdCuentaGasto = Convert.ToInt16(helper.GetParameterOutput("@pID"));
                return cuentaGasto;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public CuentaGasto GetFactura(CuentaGasto cfdi)
        {
            throw new NotImplementedException();
        }

        public ListadoCuentaGasto GetList(ListadoCuentaGasto cuentaGasto)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, cuentaGasto.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pIdPedimento", SqlDbType.Int, cuentaGasto.IdPedimento));
            InicializaConexion(cuentaGasto.IdEmpresa);
            var reader = helper.ExecuteReader("[usp_CuentaGasto_DameListaXPedimento]", parametros);
            cuentaGasto.Lista = new List<CuentaGasto>();
            while (reader.Read())
            {
                cuentaGasto.Lista.Add(new CuentaGasto()
                {
                    IdCuentaGasto = Convert.ToInt32(reader.GetOrdinal("IdCuentaGasto")),
                    IdEmpresa = cuentaGasto.IdEmpresa,
                    NumeroFactura = reader.GetString(reader.GetOrdinal("NumeroFactura")),
                    OtrosDatos = reader.GetString(reader.GetOrdinal("OtrosDatos")),
                    //XML = reader.GetString(reader.GetOrdinal("XML")),
                    //PDF = reader.GetString(reader.GetOrdinal("PDF")),
                    MontoTotal = Convert.ToDouble(reader.GetOrdinal("MontoTotal")),
                    TipoCambio = Convert.ToDouble(reader.GetOrdinal("TipoCambio")),
                    UUID = reader.GetString(reader.GetOrdinal("UUID")),
                    FechaFactura = reader.GetDateTime(reader.GetOrdinal("FechaFactura")),
                    Subtotal = Convert.ToDouble(reader.GetOrdinal("Subtotal")),
                    RFCEmisor = reader.GetString(reader.GetOrdinal("RFCEmisor")),
                    NombreEmisor = reader.GetString(reader.GetOrdinal("NombreEmisor")),
                    IVA = Convert.ToDouble(reader.GetOrdinal("IVA")),
                    IEPS = Convert.ToDouble(reader.GetOrdinal("IEPS")),
                    RetencionIVA = Convert.ToDouble(reader.GetOrdinal("RetencionIVA")),
                    RetencionISR = Convert.ToDouble(reader.GetOrdinal("RetencionISR")),
                    Confirmado = reader.GetBoolean(reader.GetOrdinal("Confirmado")),
                    IdComplementoFacturaVW = Convert.ToInt32(reader.GetOrdinal("IdComplementoFacturaVW"))

                });

            }
            return cuentaGasto;
        }
       
        public ListaImpuestos InsertaImpuestosRetencion(ListaImpuestos impuestos, int idCuentaGasto, int idEmpresa)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdCuentaGasto", SqlDbType.Int, idCuentaGasto));
            parametros.Add(new SqlParameterItem("@pImpuesto", SqlDbType.VarChar, 10, impuestos.Impuesto));
            parametros.Add(new SqlParameterItem("@pTasa", SqlDbType.Int, impuestos.Tasa));
            parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Decimal, impuestos.Importe));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializaConexion(idEmpresa);
            helper.ExecuteNonQuery("usp_ImpuestoXCuentaGasto_Inserta", parametros);
            impuestos.IdImpuestoXCuentaGasto = Convert.ToInt16(helper.GetParameterOutput("@pID"));
            return impuestos;            
        }


        public DetalleCuentaGasto InsertaDetalleCuentaGasto(DetalleCuentaGasto detalleCuentaGasto, int idEmpresa)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdCuentaGasto", SqlDbType.Int, detalleCuentaGasto.IdCuentaGasto));            
            parametros.Add(new SqlParameterItem("@pIdServicioVW", SqlDbType.Int, 0));
            parametros.Add(new SqlParameterItem("@pDescripcion", SqlDbType.VarChar, 255, detalleCuentaGasto.Descripcion));
            parametros.Add(new SqlParameterItem("@pValorMercancia", SqlDbType.Decimal, detalleCuentaGasto.ValorMercancia));
            parametros.Add(new SqlParameterItem("@pCantidad", SqlDbType.Decimal, detalleCuentaGasto.Cantidad));
            parametros.Add(new SqlParameterItem("@pValorUnitario", SqlDbType.Decimal, detalleCuentaGasto.ValorUnitario));
            parametros.Add(new SqlParameterItem("@pValorTotal", SqlDbType.Decimal, detalleCuentaGasto.ValorTotal));
            parametros.Add(new SqlParameterItem("@pNoIdentificacion", SqlDbType.VarChar, 30, detalleCuentaGasto.NoIdentificacion));
            parametros.Add(new SqlParameterItem("@pUnidad", SqlDbType.VarChar, 30, detalleCuentaGasto.Unidad));            
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializaConexion(idEmpresa);
            helper.ExecuteNonQuery("usp_ImpuestoXCuentaGasto_Inserta", parametros);
            detalleCuentaGasto.IdDetalleCuentaGasto = Convert.ToInt16(helper.GetParameterOutput("@pIdImpuestoXCuentaGasto"));
            return detalleCuentaGasto;            
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
            InicializaConexion(archivo.IdEmpresa);
            helper.ExecuteNonQuery("usp_ExpedienteDigital_Inserta", parametros);
            archivo.IdArchivo = Convert.ToInt16(helper.GetParameterOutput("@pId"));
            return archivo;
        }

        public CuentaGasto DameIdCuentaGastoExistente(CuentaGasto cuentaGasto)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, cuentaGasto.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pRFCEmisor", SqlDbType.VarChar, 15, cuentaGasto.RFCEmisor));
            parametros.Add(new SqlParameterItem("@pNumeroFactura", SqlDbType.VarChar, 50, cuentaGasto.NumeroFactura));                   
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializaConexion(cuentaGasto.IdEmpresa);
            helper.ExecuteNonQuery("usp_CuentaGasto_DameID", parametros);
            cuentaGasto.IdCuentaGasto = Convert.ToInt16(helper.GetParameterOutput("@pId"));
            return cuentaGasto;
        }

        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
