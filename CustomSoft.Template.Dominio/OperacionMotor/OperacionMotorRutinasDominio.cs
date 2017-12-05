using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.CatalogosService;
using CustomSoft.Template.Modelo.VUCEMService;

//using CustomSoft.Template.Modelo.VUCEMService;
//new EndpointAddress("http://207.198.117.44:8888/SACService.svc");
//new EndpointAddress("http://localhost:8585/VUCEMService.svc");
//new EndpointAddress("http://192.168.2.160:8585/VucemService.svc");
//new EndpointAddress("http://207.198.117.41:8787/VucemService.svc");

namespace CustomSoft.Template.Dominio.OperacionMotor
{
    partial class OperacionMotorDominio
    {
        private SeguridadVucemServiceClient ServicioVUCEM()
        {
            var catalogosService = System.Configuration.ConfigurationSettings.AppSettings.Get("VUCEMService");
            var basicHttpBinding = new BasicHttpBinding()
            {
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            //basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            var endpoint =
                new EndpointAddress(catalogosService);
            var servicioConsultarListadoPedimento = new SeguridadVucemServiceClient(basicHttpBinding, endpoint);
            return servicioConsultarListadoPedimento;
        }

        //public VucemOperacionRequest CreaRequestListadoPedimentos(RequestVUCEM pRequestVucem)
        private InvocaVUCEMListadosRequest CreaRequestListadoPedimentos(string pUsuario, string pPass, int pAduana,
            string pRFC, DateTime pFechaInicial, DateTime pFechaFin)
        {
            return new InvocaVUCEMListadosRequest()
            {
                pRequest = new VucemOperacionRequest()
                {
                    pUsuarioAA = pUsuario.Trim(),
                    pPassAA = pPass.Trim(),
                    pAduana = pAduana,
                    pRFC = pRFC.Trim(),
                    FechaInicial = pFechaInicial,
                    FechaFinal = pFechaFin,
                    NoIntentos = 1,
                    Consulta = TipoConsulta.ByRFC
                }
            };
        }

        /// <summary>
        /// Funcion que Crea el Request para invocar a WCFVUCEM el pedimento (Cuerpo)
        /// </summary>
        /// <param name="pUsuarioAA"></param>
        /// <param name="pPasswordAA"></param>
        /// <param name="pAduana"></param>
        /// <param name="pPatente"></param>
        /// <param name="pPedimento"></param>
        /// <returns></returns>
        private InvocaVUCEMPedimentoRequest CreaRequestPedimento(string pUsuarioAA, string pPasswordAA,
            int pAduana, string pPatente, string pPedimento)
        {
            return new InvocaVUCEMPedimentoRequest()
            {
                pRequest = new VucemOperacionPedimentoCompletoRequest()
                {
                    Consulta = TipoConsultaPedimento.PedimentoCompleto,
                    NoIntentos = 1,
                    Entidad = new RequestVUCEM()
                    {
                        pUsuarioAA = pUsuarioAA,
                        pPassAA = pPasswordAA,
                        pAduana = pAduana,
                        pPatente = pPatente,
                        pPedimento = pPedimento
                    }
                }
            };
            //var requesPedimento = new VucemOperacionPedimentoCompletoRequest();
            //requesPedimento.Consulta = TipoConsultaPedimento.PedimentoCompleto;
            //requesPedimento.NoIntentos = 1;
            //requesPedimento.Entidad = new RequestVUCEM();
            //requesPedimento.Entidad.pUsuarioAA = pUsuarioAA;
            //requesPedimento.Entidad.pPassAA = pPasswordAA;
            //requesPedimento.Entidad.pAduana = pAduana;
            //requesPedimento.Entidad.pPatente = pPatente;
            //requesPedimento.Entidad.pPedimento = pPedimento;
            //return requesPedimento;
        }

        private InvocaVUCEMPedimentoRequest CreaRequestPartida(string pUsuarioAA, string pPasswordAA,
            int pAduana, string pPatente, string pPedimento, int pNoPartida, long pNoOperacion)
        {
            return new InvocaVUCEMPedimentoRequest()
            {
                pRequest = new VucemOperacionPedimentoCompletoRequest()
                {
                    Consulta = TipoConsultaPedimento.Partida,
                    NoIntentos = 1,
                    Entidad = new RequestVUCEM()
                    {
                        pUsuarioAA = pUsuarioAA,
                        pPassAA = pPasswordAA,
                        pAduana = pAduana,
                        pPatente = pPatente,
                        pPedimento = pPedimento,
                        NoPartida = pNoPartida,
                        pNumeroOperacion = pNoOperacion,

                    }
                }
            };
            //var requesPedimento = new VucemOperacionPedimentoCompletoRequest();
            //requesPedimento.Entidad = new RequestVUCEM();
            //requesPedimento.Consulta = TipoConsultaPedimento.Partida;
            //requesPedimento.NoIntentos = 1;
            //requesPedimento.Entidad = new RequestVUCEM();
            //requesPedimento.Entidad.pUsuarioAA = pUsuarioAA;
            //requesPedimento.Entidad.pPassAA = pPasswordAA;
            //requesPedimento.Entidad.pAduana = pAduana;
            //requesPedimento.Entidad.pPatente = pPatente;
            //requesPedimento.Entidad.pPedimento = pPedimento;
            //requesPedimento.Entidad.NoPartida = pNoPartida;
            //requesPedimento.Entidad.pNumeroOperacion = pNoOperacion;
            //return requesPedimento;
        }

        public CatalogosServiceClient ServicioCatalogos()
        {
            var catalogosService = System.Configuration.ConfigurationSettings.AppSettings.Get("CatalogosService");
            var basicHttpBinding = new BasicHttpBinding()
            {
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            var endpoint =
                new EndpointAddress(
                    catalogosService);
            var servicioCatalogos = new CatalogosServiceClient(basicHttpBinding, endpoint);
            return servicioCatalogos;
        }

        private CatalogoGeneralOperacionRequest RequestTipoCatalogoXAbreviatura(string pAlias, int idUsuarioEjecucion,
            Catalogo pTipoCatagolo)
        {
            return new CatalogoGeneralOperacionRequest()
            {
                ExtraccionCatalogo = TipoExtraccionCatalogo.ExtraerIdXAbreviatura,
                IdUsuarioEjecucion = idUsuarioEjecucion,
                Item = new EntidadCatalogo()
                {
                    Alias = pAlias,
                    CatalogoALlamar = pTipoCatagolo,
                    FiltradoEspecifico = Filtrado.Alias
                }
            };
        }

        private CatalogoGeneralOperacionRequest RequestTipoCatalogoXDescripcion(string pAlias, int idUsuarioEjecucion,
            Catalogo pTipoCatagolo, Filtrado pFiltrado)
        {
            return new CatalogoGeneralOperacionRequest()
            {
                ExtraccionCatalogo = TipoExtraccionCatalogo.ExtraerIdXAbreviatura,
                IdUsuarioEjecucion = idUsuarioEjecucion,
                Item = new EntidadCatalogo()
                {
                    Alias = pAlias,
                    CatalogoALlamar = pTipoCatagolo,
                    FiltradoEspecifico = pFiltrado
                }
            };
        }
    }
}