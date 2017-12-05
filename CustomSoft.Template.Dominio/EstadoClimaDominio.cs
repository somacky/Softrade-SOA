using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.UI;
using System.Xml;
using CustomSoft.Template.Dominio.CatalogosService;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;
using Newtonsoft.Json.Linq;

namespace CustomSoft.Template.Dominio
{
    public class EstadoClimaDominio : IEstadoClimaDominio
    {
        public IEstadoClimaRepositorio iEstadoClimaRepositorio = null;

        public EstadoClimaDominio()
        {
            iEstadoClimaRepositorio = FactoryEngine<IEstadoClimaRepositorio>.GetInstance("IEstadoClimaRepositorioConfig");
        }

        public EstadoClima GetEstadoClima(EstadoClima item)
        {
            //verifica si existe el clima por la mañana o tarde depende la hora actual
            //si existe envialo, sino pidelo de yahoo
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                //el único dato necesario es el identidadFederativa
                item = iEstadoClimaRepositorio.GetEstadoClimaActual(item);
                if (item.IdEstadoClima == 0)
                {
                    item.EntidadFederativa = GetNameEntidadFederativaYahoo(item.IdEntidadFederativa);
                    item = GetClimaFromYahoo(item.EntidadFederativa);
                    iEstadoClimaRepositorio.InsertarEstadoClima(item);
                }
                transaction.Complete();
            }
            // e insertarlo en la base de datos
            throw new NotImplementedException();
        }
        private string GetNameEntidadFederativaYahoo(int idEntidadFederativa)
        {
            var servidor = Util.ServicioCatalogos();
            var request = new CatalogoGeneralOperacionRequest()
            {
                ExtraccionCatalogo = TipoExtraccionCatalogo.ExtraerIdXAbreviatura,
                Item = new EntidadCatalogo()
                {
                    CatalogoALlamar = Catalogo.EntidadFederativa,
                    FiltradoEspecifico = Filtrado.Id,                   
                    Id = idEntidadFederativa
                }
            };

            var response = servidor.ExtraerCatalogoItem(request);
            return response.Item.Nombre;
        }

        private EstadoClima GetClimaFromYahoo(string entidadfederativa)
        {
            StringBuilder theWebAddress = new StringBuilder();
            theWebAddress.Append("https://query.yahooapis.com/v1/public/yql?");
            theWebAddress.Append("q=" +
                                 System.Web.HttpUtility.UrlEncode(
                                     "select * from weather.forecast where woeid in (select woeid from geo.places(1)" +
                                     " where text=\""+entidadfederativa+"\") and u=\"c\""));//cambia la ciudad solamente

            theWebAddress.Append("&format=xml");
            theWebAddress.Append("&env=store://datatables.org/alltableswithkeys");

            string result = "";
            using (WebClient wc = new WebClient())
            {
                result = wc.DownloadString(theWebAddress.ToString());
            }
             XmlDocument documento = new XmlDocument();
             documento.LoadXml(result);
             XmlNodeList clima = documento.GetElementsByTagName("yweather:forecast");
            var viento = documento.GetElementsByTagName("yweather:wind");
            var estadoClima = new EstadoClima()
            {
                IdClima = Convert.ToInt32(((XmlElement)clima[0]).GetAttribute("code")),
                Fecha = Convert.ToDateTime(((XmlElement)clima[0]).GetAttribute("date")),
                TemperaturaMaxima = Convert.ToInt32(((XmlElement)clima[0]).GetAttribute("high")),
                TemperaturaMinima = Convert.ToInt32(((XmlElement)clima[0]).GetAttribute("low")),
                VelocidadViento = Convert.ToDouble(((XmlElement)viento[0]).GetAttribute("speed"))
            };                        
            return estadoClima;
        }

        public void Dispose()
        {
            iEstadoClimaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
