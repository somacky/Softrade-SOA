using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.CatalogosService;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.OperacionEmpresa;
//using CustomSoft.Template.Dominio.Excepciones.ListaPedimentos;
using CustomSoft.Template.Dominio.Excepciones.OperacionMotor;
using CustomSoft.Template.Dominio.OperacionEmpresa;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades.Empresa;
using CustomSoft.Template.Modelo.Dominio.Entidades.Motor;
//using CustomSoft.Template.Dominio.VUCEMService;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using CustomSoft.Template.Modelo.VUCEMService;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;
using ArchivoM = CustomSoft.Template.Modelo.VUCEMService.ArchivoM;
using ListaPedimentosVUCEM = CustomSoft.Template.Modelo.VUCEMService.ListaPedimentosVUCEM;

namespace CustomSoft.Template.Dominio.OperacionMotor
{
    partial class OperacionMotorDominio : IOperacionMotorDominio
    {
        private IOperacionMotorRepositorio operacionMotorRepositorio;

        public OperacionMotorDominio()
        {
            operacionMotorRepositorio = FactoryEngine<IOperacionMotorRepositorio>.GetInstance("IOperacionMotorRepositorioConfig");
        }

        #region Metodos Privados
        //Variables Globales
        string vPassword = string.Empty;
        string vUser = string.Empty;
        private ArchivoM PedimentoArchivoM(VucemOperacionPedimentoCompletoResponse response)
        {
            var pedimentoVUCEM = new ArchivoM();

            pedimentoVUCEM = response.Entidad;
            return pedimentoVUCEM;
        }


        private List<DatosReg551Partidas> ConsultaCatalogosPartida(List<DatosReg551Partidas> response)
        {
            var vCatalogos = ServicioCatalogos();
            var resCatalogos = new CatalogosService.CatalogoGeneralOperacionResponse();

            //GENERALES PARTIDA
            if (response[0].FraccionArancelaria != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(response[0].FraccionArancelaria), 0, Catalogo.Fraccion));
                response[0].IdFraccionArancelaria = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdFraccionArancelaria = 0;
            }

            if (response[0].ClaveUnidadMedidaComercial != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(response[0].ClaveUnidadMedidaComercial), 0, Catalogo.UnidadMedida));
                response[0].IdClaveUnidadMedidaComercial = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClaveUnidadMedidaComercial = 0;
            }

            if (response[0].ClaveUnidadMedidadTarifa != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(response[0].ClaveUnidadMedidadTarifa), 0, Catalogo.UnidadMedida));
                response[0].IdClaveUnidadMedidadTarifa = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClaveUnidadMedidadTarifa = 0;
            }

            if (response[0].ClaveValorAduanaInfluido != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXDescripcion(
                  Convert.ToString(response[0].ClaveValorAduanaInfluido), 0, Catalogo.Vinculacion, Filtrado.Descripcion));
                response[0].IdClaveValorAduanaInfluido = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClaveValorAduanaInfluido = 0;
            }

            if (response[0].ClaveMetodoValoracionMercancia != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXDescripcion(
                   response[0].ClaveMetodoValoracionMercancia, 0, Catalogo.MetodoValoracion, Filtrado.Descripcion));
                if (resCatalogos.EjecucionValida)
                {
                    response[0].IdClaveMetodoValoracionMercancia = resCatalogos.Item.Id;
                }
                else
                {
                    response[0].IdClaveMetodoValoracionMercancia = 0;
                }

            }
            else
            {
                response[0].IdClaveMetodoValoracionMercancia = 0;
            }

            if (response[0].ClavePaisMercancia != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   response[0].ClavePaisMercancia, 0, Catalogo.Pais));
                response[0].IdClavePaisMercancia = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClavePaisMercancia = 0;
            }

            if (response[0].ClaveEntidadFederativaOrigen != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   response[0].ClaveEntidadFederativaOrigen, 0, Catalogo.Pais));
                response[0].IdClaveEntidadFederativaOrigen = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClaveEntidadFederativaOrigen = 0;
            }

            if (response[0].ClaveEntidadfederativaDestino != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   response[0].ClaveEntidadfederativaDestino, 0, Catalogo.Pais));
                response[0].IdClaveEntidadfederativaDestino = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClaveEntidadfederativaDestino = 0;
            }

            if (response[0].ClaveEntidadFederativaComprador != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   response[0].ClaveEntidadFederativaComprador, 0, Catalogo.Pais));
                response[0].IdClaveEntidadFederativaComprador = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClaveEntidadFederativaComprador = 0;
            }

            if (response[0].ClaveEntidadFederativaVendedor != "")
            {
                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   response[0].ClaveEntidadFederativaVendedor, 0, Catalogo.Pais));
                response[0].IdClaveEntidadFederativaVendedor = resCatalogos.Item.Id;
            }
            else
            {
                response[0].IdClaveEntidadFederativaVendedor = 0;
            }

            //CUENTAS ADUANERAS DIRECTO

            //GRAVAMEN
            if (response[0].GravamenNPartida != null)
            {
                var vContadorGravamen = 0;
                var vlista = response[0].GravamenNPartida;
                foreach (var Variable in vlista)
                {
                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(vlista[vContadorGravamen].ClaveGravamen), 0, Catalogo.ContribucionGravamenDerecho));
                    response[0].GravamenNPartida[vContadorGravamen].IdClaveContribucionGravamenDerechoNPartida = resCatalogos.Item.Id;

                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(vlista[vContadorGravamen].ClaveFormaPago), 0, Catalogo.FormaPago));
                    response[0].GravamenNPartida[vContadorGravamen].IdClaveFormaPagoNPartida = resCatalogos.Item.Id;

                    if (response[0].GravamenNPartida[vContadorGravamen].Tasas != null)
                    {
                        var vContadorTasas = 0;
                        var vlista2 = response[0].GravamenNPartida[vContadorGravamen].Tasas;
                        foreach (var Variable2 in vlista2)
                        {
                            resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                                Convert.ToString(vlista2[vContadorTasas].ClaveTipoTasa), 0, Catalogo.TipoTasa));
                            response[0].GravamenNPartida[vContadorGravamen].Tasas[vContadorTasas].IdTasaContribucion = resCatalogos.Item.Id;

                            resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                               Convert.ToString(vlista2[vContadorTasas].ClaveContribucion), 0, Catalogo.ContribucionGravamenDerecho));
                            response[0].GravamenNPartida[vContadorGravamen].Tasas[vContadorTasas].IdClaveContribucionGravamenDerechoTasasNPartida = resCatalogos.Item.Id;

                            //Incremento contador Tasas
                            vContadorTasas++;
                        }
                    }
                    //Incremento contador
                    vContadorGravamen++;
                }
            }

            //IDENTIFICADOR NIVEL PARTIDA
            if (response[0].IdentificadoresNPartida != null)
            {
                var vContadorIdentificador = 0;
                var vlista = response[0].IdentificadoresNPartida;
                foreach (var Variable in vlista)
                {
                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista[vContadorIdentificador].CLaveIdentificador), 0, Catalogo.Identificador));
                    response[0].IdentificadoresNPartida[vContadorIdentificador].IdCLaveIdentificador = resCatalogos.Item.Id;

                    //Incremento contador
                    vContadorIdentificador++;
                }
            }

            //MERCANCIAS DIRECTO

            //PERMISOS

            if (response[0].Permisos != null)
            {
                var vContadorIdentificador = 0;
                var vlista = response[0].Permisos;
                foreach (var Variable in vlista)
                {
                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista[vContadorIdentificador].CLavePermiso), 0, Catalogo.Permiso));
                    response[0].Permisos[vContadorIdentificador].IdCLavePermiso = resCatalogos.Item.Id;

                    //Incremento contador
                    vContadorIdentificador++;
                }
            }
            return response;
        }
        /// <summary>
        /// Invoca a catalogos de pedimento para su insercion
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private ArchivoM ConsultaCatalogosPedimento(ArchivoM response)
        {
            try
            {
                //var catalogos = ServicioCatalogos();
                //var responseCatalogos =
                //    catalogos.ExtraerCatalogoItem(RequestTipoDocumentoXAbreviatura("num", idUsuario));
                //archivo = response.Item;
                //archivo.IdTipoDocumento = responseCatalogos.Item.Id;
                var vCatalogos = ServicioCatalogos();
                var resCatalogos = new CatalogosService.CatalogoGeneralOperacionResponse();
                //GENERALES

                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(response.CLaveAduanaSeccionEntradaSalida), 0, Catalogo.AduanaSeccion));
                response.IdCLaveAduanaSeccionEntradaSalida = resCatalogos.Item.Id;
                response.IdAduanaSeccionVW = resCatalogos.Item.Id;

                if (response.TipoPedimento != "")
                {
                    //resCatalogos = new CatalogosService.CatalogoGeneralOperacionResponse();
                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(response.TipoPedimento), 0, Catalogo.ClavePedimento));
                    response.IdTipoPedimento = resCatalogos.Item.Id;
                }
                else
                {
                    response.IdTipoPedimento = 0;
                }

                //resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoDocumentoXAbreviatura(
                //    Convert.ToString(response.ClaveDestinoMercancia), 0, Catalogo.Destino));
                response.IdClaveDestinoMercancia = response.ClaveDestinoMercancia;

                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(response.ClaveMedioTrasporteArriboAduana), 0, Catalogo.MedioTransporte));
                response.IdClaveMedioTrasporteArriboAduana = resCatalogos.Item.Id;

                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(response.ClaveMedioTrasporteEntradaSalidaMercancia), 0, Catalogo.MedioTransporte));
                response.IdClaveMedioTrasporteEntradaSalidaMercancia = resCatalogos.Item.Id;

                resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(response.ClaveMedioTrasporteSalidaAduana), 0, Catalogo.MedioTransporte));
                response.IdClaveMedioTrasporteSalidaAduana = resCatalogos.Item.Id;

                //RECTIFICACION DIRECTO
                //IMPORTADOR-EXPORTADOR DIRECTO
                //FECHAS DIRECTO

                //TASAS NIVEL PEDIMENTO
                if (response.TasasNPed != null) //PROVADO
                {
                    var vContadorTasas = 0;
                    var vlista = response.TasasNPed;
                    foreach (var Variable in vlista)
                    {
                        //pedimentoVUCEM.TasasNPed = new DatosReg509TasasNPed[vContadorTasas];
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista[vContadorTasas].ClaveContribucionGravamenDerechoTasasNPed), 0, Catalogo.ContribucionGravamenDerecho));
                        response.TasasNPed[vContadorTasas].IdClaveContribucionGravamenDerechoTasasNPed = resCatalogos.Item.Id;

                        //Incremento contador
                        vContadorTasas++;
                    }
                }

                //PROVEEDOR COMPRADOR Y FACTURAS

                if (response.Facturas != null) //PROVADO
                {
                    var vContadorFacturas = 0;
                    var vlista2 = response.Facturas;
                    foreach (var Variable in vlista2)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista2[vContadorFacturas].ClaveTerminoFactura), 0, Catalogo.TerminoFactura));
                        response.Facturas[vContadorFacturas].IdTerminoFactura = resCatalogos.Item.Id;

                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista2[vContadorFacturas].MonedaFacturacion), 0, Catalogo.Moneda));
                        response.Facturas[vContadorFacturas].IdMonedaFacturacion = resCatalogos.Item.Id;

                        //no se tiene el pais de facturacion se envia en 0 el IdPais Facturacion
                        response.Facturas[vContadorFacturas].IdPaisFacturacion = 0;
                        //se envia en 0 entidad federativa facuracion
                        response.Facturas[vContadorFacturas].IdEntidadFederativaFacturacion = 0;

                        //Incremento Contador
                        vContadorFacturas++;
                    }
                }


                //DESTINATARIO
                if (response.Destinatarios != null)
                {
                    var vContadorDestinatario = 0;
                    var vlista3 = response.Destinatarios;
                    foreach (var Variable in vlista3)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista3[vContadorDestinatario].PaisDestinatario), 0, Catalogo.Pais));
                        response.Destinatarios[vContadorDestinatario].IdPaisDestinatario = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorDestinatario++;
                    }
                }


                //TRANSPORTE
                if (response.Transporte != null)
                {
                    var vContadorTransporte = 0;
                    var vlista4 = response.Transporte;
                    foreach (var Variable in vlista4)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista4[vContadorTransporte].PaisMedioTranspote), 0, Catalogo.Pais));
                        response.Transporte[vContadorTransporte].IdPaisMedioTranspote = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorTransporte++;
                    }
                }


                //GUIA
                if (response.Guias != null) //PROVADO
                {
                    var vContadorGuia = 0;
                    var vlista5 = response.Guias;
                    foreach (var Variable in vlista5)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista5[vContadorGuia].IdentificadorGuia), 0, Catalogo.TipoGuia));
                        response.Guias[vContadorGuia].IdTipoGuia = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorGuia++;
                    }
                }



                //IDENTIFICADOR DIRECTO HASTA AQUI ME QUEDE
                if (response.IdentificadoresNPed != null) //PROVADO
                {
                    var vContadorIdentificadorNPed = 0;
                    var vlista6 = response.IdentificadoresNPed;
                    foreach (var Variable in vlista6)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                        Convert.ToString(vlista6[vContadorIdentificadorNPed].ClaveIdentificador), 0, Catalogo.Identificador));
                        response.IdentificadoresNPed[vContadorIdentificadorNPed].IdTipoIdentificador = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorIdentificadorNPed++;
                    }
                }


                //CUENTA ADUANERA DIRECTO

                //DESCARGO
                if (response.Descargos != null)
                {
                    var vContadorDescargo = 0;
                    var vlista7 = response.Descargos;
                    foreach (var Variable in vlista7)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                       Convert.ToString(vlista7[vContadorDescargo].ClaveAduanaOriginal), 0, Catalogo.AduanaSeccion));
                        response.Descargos[vContadorDescargo].IdAduanaSeccionDescargos = resCatalogos.Item.Id;

                        if (vlista7[vContadorDescargo].FraccionArancelariaOriginal != "")
                        {
                            resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                                Convert.ToString(vlista7[vContadorDescargo].FraccionArancelariaOriginal), 0,
                                Catalogo.Fraccion));
                            response.Descargos[vContadorDescargo].IdFraccionArancelariaOriginal = resCatalogos.Item.Id;
                        }
                        else
                        {
                            response.Descargos[vContadorDescargo].IdFraccionArancelariaOriginal = 0;
                        }


                        if (vlista7[vContadorDescargo].ClaveUnidadMedida != 0)
                        {
                            resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                       Convert.ToString(vlista7[vContadorDescargo].ClaveUnidadMedida), 0, Catalogo.UnidadMedida));//DUDA
                            response.Descargos[vContadorDescargo].IdUnidadMedidaDescargo = resCatalogos.Item.Id;
                        }
                        else
                        {
                            response.Descargos[vContadorDescargo].IdUnidadMedidaDescargo = 0;
                        }


                        //Incremento Contador
                        vContadorDescargo++;
                    }
                }


                //COMPENSACION
                if (response.Compensaciones != null)
                {
                    var vContadorCompensacion = 0;
                    var vlista8 = response.Compensaciones;
                    foreach (var Variable in vlista8)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                       Convert.ToString(vlista8[vContadorCompensacion].ClaveAduanaOriginal), 0, Catalogo.AduanaSeccion));
                        response.Compensaciones[vContadorCompensacion].IdAduanaSeccionCompensacion = resCatalogos.Item.Id;

                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(vlista8[vContadorCompensacion].ClaveGravamen), 0, Catalogo.ContribucionGravamenDerecho));
                        response.Compensaciones[vContadorCompensacion].IdClaveGravamen = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorCompensacion++;
                    }
                }


                //DOCUMENTO PAGO
                if (response.DoctosFormaPago != null)
                {
                    var vContadorDoctos = 0;
                    var vlista9 = response.DoctosFormaPago;
                    foreach (var Variable in vlista9)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                      Convert.ToString(vlista9[vContadorDoctos].ClaveFormaPago), 0, Catalogo.FormaPago));
                        response.DoctosFormaPago[vContadorDoctos].IdClaveFormaPago = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorDoctos++;
                    }
                }

                //OBSERVACIONES DIRECTO

                //DIFERENCIA CONTRIBUCION
                if (response.DiferenciaNPed != null)
                {
                    var vContadorDiferencias = 0;
                    var vlista10 = response.DiferenciaNPed;
                    foreach (var Variable in vlista10)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                      Convert.ToString(vlista10[vContadorDiferencias].ClaveFormaPago), 0, Catalogo.FormaPago));
                        response.DiferenciaNPed[vContadorDiferencias].IdClaveFormaPago = resCatalogos.Item.Id;

                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXDescripcion(
                      Convert.ToString(vlista10[vContadorDiferencias].DescripcionGravamen), 0, Catalogo.ContribucionGravamenDerecho, Filtrado.Abreviacion));
                        response.DiferenciaNPed[vContadorDiferencias].IdClaveGravamen = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorDiferencias++;
                    }
                }

                //PRUEBA SUFICIENTE
                if (response.PruebaSuficiente != null)
                {
                    var vContadorPrueba = 0;
                    var vlista11 = response.PruebaSuficiente;
                    foreach (var Variable in vlista11)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                     Convert.ToString(vlista11[vContadorPrueba].ClavePais), 0, Catalogo.Pais));
                        response.PruebaSuficiente[vContadorPrueba].IdClavePais = resCatalogos.Item.Id;

                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                     Convert.ToString(vlista11[vContadorPrueba].PruebaSuficiente), 0, Catalogo.TipoPruebaSuficiente));
                        response.PruebaSuficiente[vContadorPrueba].IdPruebaSuficiente = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorPrueba++;
                    }
                }

                //INFORME AUTOMOTRIZ
                if (response.InformeIndustriaAut != null)
                {
                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(response.InformeIndustriaAut.AduanaSeccionDespacho), 0, Catalogo.AduanaSeccion));
                    response.InformeIndustriaAut.IdAduanaSeccionDespacho = resCatalogos.Item.Id;

                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(response.InformeIndustriaAut.AduanaSeccionEntrada), 0, Catalogo.AduanaSeccion));
                    response.InformeIndustriaAut.IdAduanaSeccionEntrada = resCatalogos.Item.Id;
                }

                //DETERMINACION CONTRIBUCIONES ARTICULO
                if (response.DeterminacionPagoContribucioneNPed != null)
                {
                    var vContadorDet = 0;
                    var vlista12 = response.DeterminacionPagoContribucioneNPed;
                    foreach (var Variable in vlista12)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                    Convert.ToString(vlista12[vContadorDet].FraccionAracelaria), 0, Catalogo.Fraccion));
                        response.DeterminacionPagoContribucioneNPed[vContadorDet].IdFraccionAracelariaPagoContribucion = resCatalogos.Item.Id;

                        //Incremento Contador
                        vContadorDet++;
                    }
                }

                //PREVIO CONSOLIDADO
                if (response.DatosGeneralesPrevioConsolidado != null)
                {
                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(response.DatosGeneralesPrevioConsolidado.ClaveAduanaSeccion), 0, Catalogo.AduanaSeccion));
                    response.DatosGeneralesPrevioConsolidado.IdClaveAduanaSeccion = resCatalogos.Item.Id;

                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(response.DatosGeneralesPrevioConsolidado.ClaveTramiteAduanero), 0, Catalogo.TipoOperacion));//DUDA
                    response.DatosGeneralesPrevioConsolidado.IdClaveTramiteAduanero = resCatalogos.Item.Id;

                    //duda con clave importacionexportacion

                    resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(response.DatosGeneralesPrevioConsolidado.ClaveDestinoMercancia), 0, Catalogo.Destino));//DUDA
                    response.DatosGeneralesPrevioConsolidado.IdClaveDestinoMercancia = resCatalogos.Item.Id;
                }

                //PEDIMENTO COMPLEMENTARIO DIRECTO

                //CONTENEDOR DIRECTO
                //if (response.Contenedores != null)
                //{
                //    var vContadorContenedor = 0;
                //    var vlista13 = response.Contenedores;
                //    foreach (var Variable in vlista13)
                //    {
                //        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                //   Convert.ToString(vlista13[vContadorContenedor].TipoContenedor), 0, Catalogo.TipoContenedor));
                //        response.Contenedores[vContadorContenedor].IdTipoContenedor = resCatalogos.Item.Id;
                //
                //        //Incremento Contador
                //        vContadorContenedor++;
                //    }
                //}

                //PARTIDAS INFORME INDUSTRIA AUTOMOTRIZ
                if (response.PartidaIndAutomotriz != null)
                {
                    var vContadorPartidIA = 0;
                    var vlista14 = response.PartidaIndAutomotriz;
                    foreach (var Variable in vlista14)
                    {
                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(vlista14[vContadorPartidIA].ClaveUnidadMedidaImpuestos), 0, Catalogo.UnidadMedida));//DUDA
                        response.PartidaIndAutomotriz[vContadorPartidIA].IdClaveUnidadMedidaImpuestos = resCatalogos.Item.Id;

                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(vlista14[vContadorPartidIA].ClaveUnidadMedida), 0, Catalogo.UnidadMedida));//DUDA
                        response.PartidaIndAutomotriz[vContadorPartidIA].IdClaveUnidadMedida = resCatalogos.Item.Id;

                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(vlista14[vContadorPartidIA].ClavePaisDestinoFinal), 0, Catalogo.Pais));//DUDA
                        response.PartidaIndAutomotriz[vContadorPartidIA].IdClavePaisDestinoFinal = resCatalogos.Item.Id;

                        resCatalogos = vCatalogos.ExtraerCatalogoItem(RequestTipoCatalogoXAbreviatura(
                   Convert.ToString(vlista14[vContadorPartidIA].ClavePaisVendeIE), 0, Catalogo.Pais));//DUDA
                        response.PartidaIndAutomotriz[vContadorPartidIA].IdClavePaisVendeIE = Convert.ToString(resCatalogos.Item.Id);

                        //Incremento Contador
                        vContadorPartidIA++;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private OperacionMotorResponse LlenaRespuesta(VucemOperacionResponse response)
        {
            var vResponseServicio = new OperacionMotorResponse();
            vResponseServicio.Item = new EntidadMotor();
            vResponseServicio.Item.ListadoPedimentosVucem = new List<ListaPedimentosVUCEM>();
            foreach (var lista in response.Entidad)
            {
                vResponseServicio.Item.ListadoPedimentosVucem.Add(LlenaEntidadListaPedimentos(lista));
            }
            return vResponseServicio;
        }
        //reviasar si funciona correctamente el listado
        private ListaPedimentosVUCEM LlenaEntidadListaPedimentos(ListaPedimentosVUCEM pbase)
        {
            var pedimento = new ListaPedimentosVUCEM()
            {
                NombreAduanaDespacho = pbase.NombreAduanaDespacho,
                NumeroPedimento = pbase.NumeroPedimento,
                NumeroAduanaDespacho = pbase.NumeroAduanaDespacho,
                Patente = pbase.Patente
            };
            return pedimento;
        }
        /// <summary>
        /// Funcion que Valida que se tenga el WEBKEYVUCEM y en caso de no tenerlo se usara el del Agente Aduanal
        /// </summary>
        /// <param name="request"></param>
        private void ValidaContrasenaVUCEM(OperacionMotorRequest request)
        {
            try
            {
                if (request.Item.RequestVucemListado.pPassAA == "")
                {
                    var OperacionEmpresa = new OperacionEmpresaDominio();
                    var PasswordBD = OperacionEmpresa.OperacionEmpresaItem(new EntidadEmpresa()
                    {
                        OperacionEspecifica = OperacionEmpresaItem.DameDatosPatenteXNoPatente,
                        DatosPatente = new Patente()
                        {
                            NumeroPatente = request.Item.RequestVucemListado.pPatente
                        }
                    });
                    vPassword = PasswordBD.DatosPatente.WebKeyVUCEM;
                    vUser = PasswordBD.DatosPatente.RFC;
                }
                else
                {
                    vPassword = request.Item.RequestVucemListado.pPassAA;
                    vUser = request.Item.RequestVucemListado.pUsuarioAA;
                }
            }
            catch (Exception)
            {
                throw new PatenteNoEncontradaException();
            }

        }

        private void CalculaUsuarioYContrasenaAA(OperacionMotorRequest request)
        {
            try
            {
                var OperacionEmpresa = new OperacionEmpresaDominio();
                var PasswordBD = OperacionEmpresa.OperacionEmpresaItem(new EntidadEmpresa()
                {
                    OperacionEspecifica = OperacionEmpresaItem.DameDatosPatenteXNoPatente,
                    DatosPatente = new Patente()
                    {
                        NumeroPatente = request.Item.RequestVucemListado.pPatente
                    }
                });
                vPassword = PasswordBD.DatosPatente.WebKeyVUCEM;
                vUser = PasswordBD.DatosPatente.RFC;
            }
            catch (Exception)
            {
                throw new PatenteNoEncontradaException();
            }

        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Operacion Dia Ejecucion para que se genere la bitacora a trabajar en el dia
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OperacionMotorResponse DiaEjecucion(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    response.EjecucionValida = operacionMotorRepositorio.DiaEjecucion(request.Item.FechaInicio);

                }
                catch (Exception ex)
                {
                    throw new DiaEjecucionException();
                }
                transaction.Complete();
            }
            return response;
        }

        /// <summary>
        /// Funcion que invoca a WCFVucem y solicita el listado
        /// </summary>
        /// <returns></returns>
        public OperacionMotorResponse InvocaServicioVucemListadoPedimentos(OperacionMotorRequest request)
        {
            var Response = new OperacionMotorResponse();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    var VUCEM = ServicioVUCEM();
                    //Genera el request para ServicioVUCEM
                    var requestVUCEM = CreaRequestListadoPedimentos(request.Item.RequestVucemListado.pUsuarioAA,
                        request.Item.RequestVucemListado.pPassAA, request.Item.RequestVucemListado.pAduana,
                        request.Item.RequestVucemListado.pRFC, request.Item.RequestVucemListado.FechaInicial,
                        request.Item.RequestVucemListado.FechaFinal);
                    //invoca a WCFVUCEM
                    var response = VUCEM.InvocaVUCEMListados(requestVUCEM);
                    var respuestaservicio = response.InvocaVUCEMListadosResult;
                    if (respuestaservicio.EjecucionValida)
                    {
                        Response = LlenaRespuesta(respuestaservicio);
                    }
                    else
                    {
                        throw new ServicioVucemException();
                    }
                }
                catch (Exception ex)
                {
                    throw new ServicioVucemException();
                }

                transaction.Complete();
            }
            return Response;
        }

        /// <summary>
        /// Listado de Pedimentos que se tienen que buscar en el SAT (Bitacora)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OperacionMotorResponse DameListadoPedimentosPendientes(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    response.Item = new EntidadMotor();
                    response.Item.ListadoPedimentosPend = operacionMotorRepositorio.ListadoPedimentosPendientesMotor(request.Item.IdEmpresa);
                }
                catch (Exception ex)
                {
                    throw new ListadoPedimentoPendException();
                }
                transaction.Complete();
            }
            return response;
        }

        public OperacionMotorResponse InsertaListadoPedimentoBulk(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            //{
            try
            {
                ////Conexion a OperacionEmpresaDominio para obtener la BD
                //var empresaDominio = new OperacionEmpresaDominio();
                //var requestDominio = new OperacionEmpresaRequest();
                //requestDominio.Item = new EntidadEmpresa();
                //requestDominio.Item.IdEmpresaConsulta = request.Item.Pedimento.IdEmpresa;
                //var vNombreBD = empresaDominio.DameBDXIdEmpresa(requestDominio);
                response.Item = new EntidadMotor();
                response.Item.Pedimento = new EntidadListadoVUCEMInsercion();
                response.Item.Pedimento.IdBitacoraSinc =
                    operacionMotorRepositorio.InsertaListadoBulk(request.Item.Pedimento.IdBitacoraSinc,
                                                                 request.Item.Pedimento.IdEmpresa,
                                                                 request.Item.Pedimento.NombreAduana,
                                                                 request.Item.Pedimento.NumeroAduana,
                                                                 request.Item.Pedimento.NumeroPedimento,
                                                                 request.Item.Pedimento.Patente,
                    //vNombreBD.Item.BaseDatos);
                                                                 request.Item.BaseDatos);
            }
            catch (Exception ex)
            {
                throw new InsercionListadoPedimentoException();
            }
            //    transaction.Complete();
            //}
            return response;
        }

        public OperacionMotorResponse CierraListadoPedimento(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    response.EjecucionValida = operacionMotorRepositorio.CierraListadoPedimento(request.Item.Pedimento.IdBitacoraSinc);


                }
                catch (Exception ex)
                {
                    throw new CierreListadoPedimentoBDExcepcion();
                }
                transaction.Complete();
            }
            return response;
        }
        /// <summary>
        /// Funcion que obtiene de BD los pedimentos a consultar en VUCEM
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OperacionMotorResponse DameListaPedimentos(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    response.Item = new EntidadMotor();
                    response.Item.ListadoPedimentosXProcesar = new List<ListadoPedimentosXProcesar>();
                    response.Item.ListadoPedimentosXProcesar = operacionMotorRepositorio.ListadoPedimentosXProcesar(request.Item.BaseDatos);
                }
                catch (Exception ex)
                {
                    throw new ListadoPedimentoException();
                }
                transaction.Complete();
            }
            return response;
        }
        //no se ocupa
        //public ListadoPedimentosResponse DameListadoEmpresas(ListadoPedimentosRequest request)
        //{
        //    var response = new ListadoPedimentosResponse();
        //    using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //
        //
        //        transaction.Complete();
        //    }
        //    return response;
        //
        //}
        /// <summary>
        /// Funcion que invoca el WCFVUCEM trayendo la informacion de el pedimento SIN TERMINAR
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OperacionMotorResponse InvocaServicioVucemPedimento(OperacionMotorRequest request)
        {
            vPassword = string.Empty;
            vUser = string.Empty;
            ValidaContrasenaVUCEM(request);
            var Response = new OperacionMotorResponse();
            var transactionOptions = new TransactionOptions();
            transactionOptions.Timeout = new TimeSpan(3000000000);
            //using(TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            //{
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            //{
            //try
            //{
            var VUCEM = ServicioVUCEM();
            //Genera el request para ServicioVUCEM
            var requestVUCEM = CreaRequestPedimento(vUser,
                                                    vPassword,
                                                    request.Item.RequestVucemListado.pAduana,
                                                    request.Item.RequestVucemListado.pPatente,
                                                    request.Item.RequestVucemListado.pPedimento);
            //var requestVUCEM = CreaRequestPedimento("usuario", "passs", 123, "123", "1");
            //invoca a WCFVUCEM
            var vInvocacion1 = VUCEM.InvocaVUCEMPedimento(requestVUCEM);
            var vResPrimerIntento = vInvocacion1.InvocaVUCEMPedimentoResult;
            if (vResPrimerIntento.EjecucionValida && string.IsNullOrEmpty(vResPrimerIntento.MensajeError))
            {
                var vRespuestaFinal = ConsultaCatalogosPedimento(vResPrimerIntento.Entidad);
                Response.Item = new EntidadMotor();
                Response.Item.PedimentoArchivoM = new ArchivoM();
                Response.Item.PedimentoArchivoM = vRespuestaFinal;
                //Response.Item.PedimentoArchivoM.EsPedimentoVUCEM();
            }
            else
            {
                if (vResPrimerIntento.MensajeError == "No se tiene permiso de consulta")
                {
                    CalculaUsuarioYContrasenaAA(request);
                    var requestVUCEM2 = CreaRequestPedimento(vUser,
                                                   vPassword,
                                                   request.Item.RequestVucemListado.pAduana,
                                                   request.Item.RequestVucemListado.pPatente,
                                                   request.Item.RequestVucemListado.pPedimento);
                    var vInvocacion2 = VUCEM.InvocaVUCEMPedimento(requestVUCEM2);
                    var vResSegundoIntento = vInvocacion2.InvocaVUCEMPedimentoResult;
                    if (vResSegundoIntento.EjecucionValida && string.IsNullOrEmpty(vResSegundoIntento.MensajeError))
                    {
                        var vRespuestaFinal2 = ConsultaCatalogosPedimento(vResSegundoIntento.Entidad);
                        Response.Item = new EntidadMotor();
                        Response.Item.PedimentoArchivoM = new ArchivoM();
                        Response.Item.PedimentoArchivoM = vRespuestaFinal2;
                    }
                    else
                    {
                        throw new SegundoIntentoException();
                    }
                }
                else
                {
                    throw new ServicioVUCEMPedimentoException();
                }
                //throw new ServicioVUCEMPedimentoException();
            }
            //}
            //catch (Exception ex)
            //{
            //    throw new ServicioVUCEMPedimentoException();
            //}

            //    transaction.Complete();
            //}
            return Response;
        }
        /// <summary>
        /// Listo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OperacionMotorResponse InvocaServicioVucemPartidaYGuarda(OperacionMotorRequest request)
        {
            vPassword = string.Empty;
            vUser = string.Empty;
            ValidaContrasenaVUCEM(request);
            var Response = new OperacionMotorResponse();
            //var transactionOptions = new TransactionOptions();
            //transactionOptions.IsolationLevel = IsolationLevel.Serializable;
            //transactionOptions.Timeout = new TimeSpan(3000000000);
            ////Falta Validar Datos de Entrada
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            ////using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            //{
            try
            {
                //inicializo pedimentodominio
                var operacionpartidadominio = new OperacionPedimento.OperacionPedimentoDominio();
                Response.Item = new EntidadMotor();
                Response.Item.PedimentoArchivoM = new ArchivoM();
                //Verifico que la partida no exista en BD
                Response.Item.PedimentoArchivoM.IdPartida = operacionpartidadominio.PartidaExiste(request.Item.RequestVucemListado.NoPartida,
                    request.Item.PedimentoArchivoM.IdPedimento, request.Item.PedimentoArchivoM.IdEmpresa);
                //si el IdPartida es diferente de 0 entonces invoco pedimento
                if (Response.Item.PedimentoArchivoM.IdPartida == 0)
                {
                    var VUCEM = ServicioVUCEM();
                    //Genera el request para ServicioVUCEM
                    var requestVUCEM = CreaRequestPartida(vUser,
                                                          vPassword,
                                                          request.Item.RequestVucemListado.pAduana,
                                                          request.Item.RequestVucemListado.pPatente,
                                                          request.Item.RequestVucemListado.pPedimento,
                                                          request.Item.RequestVucemListado.NoPartida,
                                                          request.Item.RequestVucemListado.pNumeroOperacion);

                    //var requestVUCEM = CreaRequestPartida("a","b",1,"c","d",1,1);

                    //invoca a WCFVUCEM
                    var response = VUCEM.InvocaVUCEMPedimento(requestVUCEM);
                    var vResPartida1erIntento = response.InvocaVUCEMPedimentoResult;
                    //Valido respuesta
                    if (vResPartida1erIntento.EjecucionValida && string.IsNullOrEmpty(vResPartida1erIntento.MensajeError))
                    {
                        var vRespuestafinal1 = ConsultaCatalogosPartida(vResPartida1erIntento.Entidad.Partidas);
                        Response.Item.PedimentoArchivoM.IdPartida = operacionpartidadominio.RegistraPartidaVucem(
                            vRespuestafinal1, request.Item.PedimentoArchivoM.IdPedimento,
                            request.Item.PedimentoArchivoM.IdEmpresa);
                    }
                    else
                    {
                        //Verifico error regresado
                        if (vResPartida1erIntento.MensajeError ==
                            "El número de operacion no corresponde con los datos de petición.")
                        {
                            CalculaUsuarioYContrasenaAA(request);
                            //Genera el request para invocar de nuevo ServicioVUCEM
                            var requestVUCEM2 = CreaRequestPartida(vUser,
                                                                  vPassword,
                                                                  request.Item.RequestVucemListado.pAduana,
                                                                  request.Item.RequestVucemListado.pPatente,
                                                                  request.Item.RequestVucemListado.pPedimento,
                                                                  request.Item.RequestVucemListado.NoPartida,
                                                                  request.Item.RequestVucemListado.pNumeroOperacion);
                            //invoca a WCFVUCEM
                            var response2 = VUCEM.InvocaVUCEMPedimento(requestVUCEM2);
                            var vResPartida2doIntento = response2.InvocaVUCEMPedimentoResult;
                            if (vResPartida2doIntento.EjecucionValida && string.IsNullOrEmpty(vResPartida2doIntento.MensajeError))
                            {
                                var vRespuestafinal2 = ConsultaCatalogosPartida(vResPartida2doIntento.Entidad.Partidas);

                                Response.Item.PedimentoArchivoM.IdPartida = operacionpartidadominio.RegistraPartidaVucem(
                                    vRespuestafinal2, request.Item.PedimentoArchivoM.IdPedimento,
                                    request.Item.PedimentoArchivoM.IdEmpresa);
                            }
                            else
                            {
                                throw new SegundoIntentoPartidaException();
                            }
                        }
                        else
                        {
                            throw new ServicioVUCEMPartidaException();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new ServicioVUCEMPartidaException();
            }

            //    transaction.Complete();
            //}
            return Response;
        }

        public OperacionMotorResponse RegistraToken(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    response.EjecucionValida = operacionMotorRepositorio.RegistraToken(request.Item.CierrePedimento.IdListadoPedimento, request.Item.CierrePedimento.NoOperacion, request.Item.BaseDatos, request.Item.CierrePedimento.NoPartidas, request.Item.PedimentoArchivoM.IdPedimento);
                }
                catch (Exception ex)
                {
                    throw new ListadoPedimentoException();
                }
                transaction.Complete();
            }
            return response;
        }

        public OperacionMotorResponse CierraPedimento(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    //response.Item = new EntidadMotor();
                    //response.Item.ListadoPedimentosXProcesar = new List<ListadoPedimentosXProcesar>();
                    response.EjecucionValida = operacionMotorRepositorio.CierraPedimento(request.Item.CierrePedimento.IdListadoPedimento, request.Item.CierrePedimento.IdPedimento, request.Item.BaseDatos);
                }
                catch (Exception ex)
                {
                    throw new ListadoPedimentoException();
                }
                transaction.Complete();
            }
            return response;
        }

        public OperacionMotorResponse DameListadoCoveConsulta(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    response.Item = new EntidadMotor();
                    //response.Item.ListadoPedimentosXProcesar = new List<ListadoPedimentosXProcesar>();
                    response.Item.ListaCOVE = new List<BitacoraCOVE>();
                    response.Item.ListaCOVE = operacionMotorRepositorio.DameListaCOVEConsulta(request.Item.IdEmpresa);
                }
                catch (Exception ex)
                {
                    throw new ListadoPedimentoException();
                }
                //transaction.Complete();
            }
            return response;
        }


        public OperacionMotorResponse DameListadoEdocumentConsulta(OperacionMotorRequest request)
        {
            var response = new OperacionMotorResponse();
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            //{
            try
            {
                response.Item = new EntidadMotor();
                response.Item.ListadoEdocuments = new List<BitacoraEdocument>();
                response.Item.ListadoEdocuments = operacionMotorRepositorio.DameListaEdocumentConsulta(request.Item.IdEmpresa);
            }
            catch (Exception ex)
            {
                throw new ListadoPedimentoException();
            }
            //    transaction.Complete();
            //}
            return response;
        }
        #endregion
        public void Dispose()
        {
            operacionMotorRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

