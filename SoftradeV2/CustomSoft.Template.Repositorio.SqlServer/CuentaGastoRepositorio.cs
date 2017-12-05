using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class CuentaGastoRepositorio : ICuentaGastoRepositorio
    {
        private SqlHelper helper = null;

        public void InicializarConexion(TipoBaseDatos baseDatos)
        {            
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
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
                parametros.Add(new SqlParameterItem("@pNumeroFactura", SqlDbType.VarChar, 15, cuentaGasto.NumeroFactura));
                parametros.Add(new SqlParameterItem("@pOtrosDatos", SqlDbType.VarChar, 15, cuentaGasto.OtrosDatos));
                parametros.Add(new SqlParameterItem("@pIdComplementoFacturaVW ", SqlDbType.Int,
                    cuentaGasto.IdComplementoFacturaVW));
                parametros.Add(new SqlParameterItem("@pXML", SqlDbType.VarChar, 100, cuentaGasto.XML));
                parametros.Add(new SqlParameterItem("@pPDF", SqlDbType.VarChar, 100, cuentaGasto.PDF));
                parametros.Add(new SqlParameterItem("@pIdMonedaVW", SqlDbType.Int, cuentaGasto.IdMonedaVW));
                parametros.Add(new SqlParameterItem("@pMontoTotal", SqlDbType.Decimal, cuentaGasto.MontoTotal));
                parametros.Add(new SqlParameterItem("@pTipoCambio", SqlDbType.Float, cuentaGasto.TipoCambio));
                parametros.Add(new SqlParameterItem("@pUUID", SqlDbType.VarChar, 35, cuentaGasto.UUID));
                parametros.Add(new SqlParameterItem("@pFechaFactura", SqlDbType.DateTime, cuentaGasto.FechaFactura));
                parametros.Add(new SqlParameterItem("@pSubtotal", SqlDbType.Decimal, cuentaGasto.Subtotal));
                parametros.Add(new SqlParameterItem("@pIdTipoComprobanteVW", SqlDbType.Int,
                    cuentaGasto.IdTipoComprobanteVW));
                parametros.Add(new SqlParameterItem("@pRFCEmisor", SqlDbType.VarChar, 15, cuentaGasto.RFCEmisor));
                parametros.Add(new SqlParameterItem("@pNombreEmisor", SqlDbType.VarChar, 200, cuentaGasto.NombreEmisor));
                parametros.Add(new SqlParameterItem("@pIVA", SqlDbType.Decimal, cuentaGasto.IVA));
                parametros.Add(new SqlParameterItem("@pIEPS", SqlDbType.Decimal, cuentaGasto.IEPS));
                parametros.Add(new SqlParameterItem("@pRetencionIVA", SqlDbType.Decimal, cuentaGasto.RetencionIVA));
                parametros.Add(new SqlParameterItem("@pRetencionISR", SqlDbType.Decimal, cuentaGasto.RetencionISR));
                parametros.Add(new SqlParameterItem("@pConfirmado", SqlDbType.Bit, cuentaGasto.Confirmado));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
                //Se inicializa exactamente la conexión a la base de datos
                InicializarConexion(TipoBaseDatos.Softrade);
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

        public IEnumerable<CuentaGasto> GetList(CuentaGasto cfdi)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }

        public ListaImpuestos InsertaImpuestosRetencion(ListaImpuestos impuestos, int idCuentaGasto)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdCuentaGasto", SqlDbType.Int, idCuentaGasto));
            parametros.Add(new SqlParameterItem("@pImpuesto", SqlDbType.VarChar, 10, impuestos.Impuesto));
            parametros.Add(new SqlParameterItem("@pTasa", SqlDbType.Int, impuestos.Tasa));
            parametros.Add(new SqlParameterItem("@pImporte", SqlDbType.Decimal, impuestos.Importe));
            helper.ExecuteNonQuery("usp_ImpuestoXCuentaGasto_Inserta", parametros);
            impuestos.IdImpuestoXCuentaGasto = Convert.ToInt16(helper.GetParameterOutput("@pIdImpuestoXCuentaGasto"));
            return impuestos;            
        }      
    }
}
