using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio.CFDIDominio
{
    partial class CFDIDominio : ICFDIDominio
    {
        private ICatalogosRepositorio CatalogosRepositorio;
        private ICuentaGastoRepositorio CuentaGastoRepositorio;
        public CFDIDominio()
        {
            CuentaGastoRepositorio = FactoryEngine<ICuentaGastoRepositorio>.GetInstance("ICuentaGastoRepositorioConfig");
            CatalogosRepositorio = FactoryEngine<ICatalogosRepositorio>.GetInstance("ICatalogosRepositorioConfig");
        }
        /// <summary>
        /// Esta función inserta en la base de datos, los datos del CFDI además que
        /// envía al servidor FTP el archivo físico
        /// </summary>
        /// <param name="cfdi">Contiene el archivo físico y los datos del CFDI</param>
        /// <returns></returns>
        public CuentaGasto InsertaFactura(CFDI cfdi)
        {
            ValidarPedimento(cfdi);
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                var idMoneda = CatalogosRepositorio.ExtraerIdMonedaXAbreviatura(new BuscarCatalogo() {Alias = "MXP"});
                //var cuentaGasto = ConvertirCfdIaCuentaGasto(cfdi);
                var idTipoComprobante = CatalogosRepositorio.ExtraerIdTipoComprobanteXNombreComprobante(new BuscarCatalogo() { Nombre = "ingreso" });//Borrar
                var crearImpuestoTraslado = CrearImpuestosDemo();//Borrar
                var crearImpuestoRetencion = CrearImpuestosDemo2();//Borrar
                var cuentaGasto = new CuentaGasto()//Borrar
                {
                    IdEmpresa = 2,
                    IdPedimento = 1,
                    NumeroFactura = "1234ASDF1234ASDF",
                    OtrosDatos = null,
                    TimeStamp = DateTime.Now,
                    IdComplementoFacturaVW = 0,
                    XML = "PathXML",
                    PDF = null,
                    IdMonedaVW = idMoneda.Id,
                    MontoTotal = 10000,
                    TipoCambio = 15,
                    UUID = "1234ASDFASDFQER12334",
                    FechaFactura = DateTime.Now,
                    Subtotal = 9000,
                    IdTipoComprobanteVW = idTipoComprobante.Id,
                    RFCEmisor = "RFC123456DFF",
                    NombreEmisor = "Nombre Emisor",
                    TrasladoImpuestos = CalcularImpuestoTraslado(crearImpuestoTraslado),
                    RetencionImpuestos = CalcularImpuestoRetencion(crearImpuestoRetencion),
                    IVA = (double) TotalImpuesto(CalcularImpuestoTraslado(crearImpuestoTraslado), "IVA", true),
                    IEPS = (double) TotalImpuesto(CalcularImpuestoTraslado(crearImpuestoTraslado), "IEPS", true),
                    RetencionIVA = (double) TotalImpuesto(CalcularImpuestoTraslado(crearImpuestoTraslado), "", false),
                    RetencionISR = (double) TotalImpuesto(CalcularImpuestoTraslado(crearImpuestoTraslado), "", false),
                    Confirmado = false
                };
                //Inserta a la base de datos la cuenta de gasto y regresa una entidad cuenta gasto con el id
                var cuentaGastoResponse = CuentaGastoRepositorio.InsertaFactura(cuentaGasto);
                //se envía uno por uno los impuestos a la base de datos
                foreach (var VARIABLE in cuentaGasto.RetencionImpuestos)
                {
                    CuentaGastoRepositorio.InsertaImpuestosRetencion(VARIABLE, cuentaGasto.IdCuentaGasto);                    
                }                
                //Se crea el request del NAS para enviarlo al Servicio FTP
                var request = new RecibeArchivoRequest()
                {
                    EjecucionValida = false,                    
                    Item = ConvertirArchivo(cfdi),                   
                    MensajeError = "",
                    UsuarioEjecucion = ""
                };
                //hago llamado a NAS  
                var ftp = ServicioFTPSoftrade();
                var response = ftp.OperacionArchivo(request);  
                transaction.Complete();
                return cuentaGastoResponse;
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
            CatalogosRepositorio.Dispose();
            CuentaGastoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
