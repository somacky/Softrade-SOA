using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Excepciones.Archivo;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Dominio.CFDIDominio
{
    partial class CFDIDominio
    {
        private void ValidarPedimento(CFDI pedimento)
        {
            //TODO:Agregar otras validaciones a funcion validar pedimento
            if (pedimento.ArchivoFisico.LongitudArchivo != pedimento.ArchivoFisico.ArchivoBytes.Length)
            {
                throw new ArchivoCorruptoException();
            }
        }

        public FTPSeguridadServiceClient ServicioFTPSoftrade()
        {
            //var basicHttpBinding = new WSHttpBinding(SecurityMode.Transport);
            var basicHttpBinding = new BasicHttpBinding()
            {
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            //basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            var endpoint =
                new EndpointAddress(
                    "http://192.168.2.160:8090/FTPService.svc");
            var servicioConsultarPedimento = new FTPSeguridadServiceClient(basicHttpBinding, endpoint);
            //if (servicioConsultarPedimento.ClientCredentials != null)
            //{
            //    servicioConsultarPedimento.ClientCredentials.UserName.UserName = "VECM6011173A2";
            //    servicioConsultarPedimento.ClientCredentials.UserName.Password = "rJ6/wsPzE4AWCNo9NhKEaQGUQkJl7RZQAJBeOAtqKajjR63zhEalSf/asMBZ1J4R";
            //}
            return servicioConsultarPedimento;
        }

        private Archivo ConvertirArchivo(CFDI archivo)
        {
            var request = new Archivo()
            {
                ArchivoBytes = archivo.ArchivoFisico.ArchivoBytes,
                TipoArchivoFiltro = TipoArchivo.CFDI,
                ExtensionArchivo = archivo.ArchivoFisico.ExtensionArchivo,
                FechaSubida = archivo.ArchivoFisico.FechaSubida,
                LongitudArchivo = archivo.ArchivoFisico.LongitudArchivo,
                NombreCompletoArchivo = archivo.ArchivoFisico.NombreCompletoArchivo,
                Patente = archivo.ArchivoFisico.Patente,
                ExtensionData = archivo.ArchivoFisico.ExtensionData,
                IdCliente = archivo.ArchivoFisico.IdCliente
            };
            return request;
        }

        public CuentaGasto ConvertirCfdIaCuentaGasto(CFDI cfdi)
        {
            var listaImpuestosTraslado = CalcularImpuestoTraslado(cfdi.Comprobante.Impuestos.Traslados);
            var listaImpuestosRetencion = CalcularImpuestoRetencion(cfdi.Comprobante.Impuestos.Retenciones);
            var idMoneda = CatalogosRepositorio.ExtraerIdMonedaXAbreviatura(new BuscarCatalogo() {Alias = cfdi.Comprobante.Moneda});
            var idTipoComprobante = CatalogosRepositorio.ExtraerIdTipoComprobanteXNombreComprobante(new BuscarCatalogo(){Nombre =  Convert.ToString(cfdi.Comprobante.tipoDeComprobante)});
            var cuentaGasto = new CuentaGasto()
            {                               
                IdEmpresa = cfdi.IdEmpresa,                
                IdPedimento = cfdi.IdPedimento,
                NumeroFactura = cfdi.Comprobante.noCertificado,
                OtrosDatos = null,
                TimeStamp = DateTime.Now,
                IdComplementoFacturaVW = 0,
                XML = cfdi.ArchivoFisico.NombreCompletoArchivo,
                PDF = null,
                IdMonedaVW = idMoneda.Id,//método para buscar el tipo de moneda
                MontoTotal = (double) cfdi.Comprobante.total,
                TipoCambio = Convert.ToDouble(cfdi.Comprobante.TipoCambio),
                UUID = cfdi.TimbreFiscalDigital.UUID,
                FechaFactura = cfdi.Comprobante.fecha,
                Subtotal = (double) cfdi.Comprobante.subTotal,
                IdTipoComprobanteVW = idTipoComprobante.Id,
                RFCEmisor = cfdi.Comprobante.Emisor.rfc,
                NombreEmisor = cfdi.Comprobante.Emisor.nombre,
                TrasladoImpuestos = CalcularImpuestoTraslado(cfdi.Comprobante.Impuestos.Traslados),
                RetencionImpuestos = CalcularImpuestoRetencion(cfdi.Comprobante.Impuestos.Retenciones),
                IVA = (double)TotalImpuesto(listaImpuestosTraslado, "IVA",true),
                IEPS = (double)TotalImpuesto(listaImpuestosTraslado, "IEPS", true),
                RetencionIVA = (double)TotalImpuesto(listaImpuestosRetencion,"",false),
                RetencionISR = (double)TotalImpuesto(listaImpuestosRetencion, "", false),
                Confirmado = false
            };
            return cuentaGasto;
        }

        public List<ListaImpuestos> CalcularImpuestoRetencion(Retencion[] impuestos)
        {
            var listaImpuestos = new List<ListaImpuestos>();
            decimal totalImpuestoIVA = 0;            
            foreach (var impuestoEspecifico in impuestos)
            {
                switch (impuestoEspecifico.impuesto)
                {
                    case RetencionImpuesto.ISR:
                        listaImpuestos.Add(new ListaImpuestos()
                        {
                            Importe = impuestoEspecifico.importe,
                            Impuesto = impuestoEspecifico.impuesto.ToString(),
                            EsTraslado = false
                        });
                        break;
                    case RetencionImpuesto.IVA:
                        listaImpuestos.Add(new ListaImpuestos()
                        {
                            Importe = impuestoEspecifico.importe,
                            Impuesto = impuestoEspecifico.impuesto.ToString(),
                            EsTraslado = false
                        });
                        break;
                }                
            }
            return listaImpuestos;
        }

        public List<ListaImpuestos> CalcularImpuestoTraslado(Traslado[] impuestos)
        {
            var listaImpuestos = new List<ListaImpuestos>();
            decimal totalImpuestoIVA = 0;
            foreach (var impuestoEspecifico in impuestos)
            {
                switch (impuestoEspecifico.impuesto)
                {
                    case TrasladoImpuesto.IEPS:
                        listaImpuestos.Add(new ListaImpuestos()
                        {
                            Importe = impuestoEspecifico.importe,
                            Impuesto = impuestoEspecifico.impuesto.ToString(),
                            Tasa = impuestoEspecifico.tasa,
                            EsTraslado = true
                        });
                        break;
                    case TrasladoImpuesto.IVA:
                        listaImpuestos.Add(new ListaImpuestos()
                        {
                            Importe = impuestoEspecifico.importe,
                            Impuesto = impuestoEspecifico.impuesto.ToString(),
                            Tasa = impuestoEspecifico.tasa,
                            EsTraslado = true
                        });
                        break;
                }
            }
            return listaImpuestos;
        }

        public decimal TotalImpuesto(List<ListaImpuestos> listadoImpuestos, string tipoDeImpuesto, bool esTraslado)
        {
            decimal totalImpuesto = 0;
            foreach (ListaImpuestos VARIABLE in listadoImpuestos)
            {
                if(VARIABLE.Impuesto == tipoDeImpuesto && esTraslado)
                totalImpuesto += VARIABLE.Importe;
            }
            return totalImpuesto;
        }

        private Traslado[] CrearImpuestosDemo()
        {
            var traslado = new Traslado[]
            {
                new Traslado()
                {
                    importe = 12,
                    impuesto = TrasladoImpuesto.IEPS,
                    tasa = 12
                },
                new Traslado()
                {
                    importe = 12,
                    impuesto = TrasladoImpuesto.IEPS,
                    tasa = 12
                },
                new Traslado()
                {
                    importe = 12,
                    impuesto = TrasladoImpuesto.IEPS,
                    tasa = 12
                },
                new Traslado()
                {
                    importe = 12,
                    impuesto = TrasladoImpuesto.IEPS,
                    tasa = 12
                }
            };
            return traslado;
        }

        private Retencion[] CrearImpuestosDemo2()
        {
            var traslado = new Retencion[]
            {
                new Retencion()
                {
                   importe = 1000,
                   impuesto = RetencionImpuesto.ISR
                },
                new Retencion()
                {
                    importe = 12,
                    impuesto = RetencionImpuesto.ISR
                },
                new Retencion()
                {
                    importe = 12,
                    impuesto = RetencionImpuesto.ISR                    
                },
                new Retencion()
                {
                    importe = 12,
                    impuesto = RetencionImpuesto.ISR
                }
            };
            return traslado;
        }
    }
}
