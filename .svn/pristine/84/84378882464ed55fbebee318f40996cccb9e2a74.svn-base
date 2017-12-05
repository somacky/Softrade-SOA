using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using CustomSoft.Template.Dominio.CatalogosService;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio
{
    public class TasaCambioDominio : ITasaCambioDominio
    {
         private ITasaCambioRepositorio iTasaCambioRepositorio = null;

         public TasaCambioDominio()
        {
            iTasaCambioRepositorio =
                FactoryEngine<ITasaCambioRepositorio>.GetInstance("ITasaCambioRepositorioConfig");
        }
        public ListaTasaCambio GetListTasaCambio(TasaCambio item)
        {
            var response = new ListaTasaCambio();
             using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                response = iTasaCambioRepositorio.GetListaTasaCambio(item);
                for(var i = 0;i<response.ListaTasaCambios.Count;i++)
                    {
                        switch (response.ListaTasaCambios[i].IdMoneda)
                        {
                            case 35:
                                if (response.ListaTasaCambios[i].EsFix)
                                    response.ListaTasaCambios[i].EnumeradoresTipoCambio =
                                        EnumeradoresTipoCambio.DolarFIX;
                                else
                                    response.ListaTasaCambios[i].EnumeradoresTipoCambio = EnumeradoresTipoCambio.Dolar;
                                break;
                        }
                    }
                if (response.ListaTasaCambios == null)
                {
                    response = GenerarCambioMoneda();
                    
                    for(var i = 0;i<response.ListaTasaCambios.Count;i++)
                    {
                        response.ListaTasaCambios[i] = iTasaCambioRepositorio.InsertarTasaCambio(response.ListaTasaCambios[i]);                        
                    }
                }
                transaction.Complete();
            }
            return response;     
        }
        #region Métodos Privados
        private ListaTasaCambio GenerarCambioMoneda()
        {
            //antes de llamar al webservices verificar que el llamado de hoy no exista
            //si existe llamar al mismo de base de datos y enviar esos datos al front           
            var service = Util.ServicioBanxico();
            var response = service.tiposDeCambioBanxico();
            return GenerarXml(response);
        }

        private ListaTasaCambio GenerarXml(string response)
        {
            XmlDocument documento = new XmlDocument();
            documento.LoadXml(response);
            XmlNodeList ser = documento.GetElementsByTagName("bm:DataSet");

            var monedas = new ListaTasaCambio();
            monedas.ListaTasaCambios = new List<TasaCambio>();
            XmlNodeList lista = ((XmlElement)ser[0]).GetElementsByTagName("bm:Series");
            foreach (XmlElement nodobase in lista)
            {
                string nserie = nodobase.GetAttribute("IDSERIE");
                if (nserie == "SF43718")
                {
                    var moneda = new TasaCambio();
                    moneda.Serie = "SF43718";
                    moneda.EnumeradoresTipoCambio = EnumeradoresTipoCambio.DolarFIX;
                    moneda.EsFix = true;
                    moneda.IdMoneda = GetIdMoneda(EnumeradoresTipoCambio.Dolar);
                    XmlNodeList uno = ((XmlElement)lista[1]).GetElementsByTagName("bm:Obs");
                    foreach (XmlElement nodo in uno)
                    {
                        moneda.TasaDeCambio = (float) Convert.ToDecimal(nodo.GetAttribute("OBS_VALUE"));
                        moneda.FechaCambio = Convert.ToDateTime(nodo.GetAttribute("TIME_PERIOD"));
                    }
                    monedas.ListaTasaCambios.Add(moneda);
                }
                if (nserie == "SF46410")
                {
                    var moneda = new TasaCambio();
                    XmlNodeList dos = ((XmlElement)lista[2]).GetElementsByTagName("bm:Obs");
                    moneda.Serie = "SF46410";
                    moneda.EnumeradoresTipoCambio = EnumeradoresTipoCambio.Euro;
                    moneda.IdMoneda = GetIdMoneda(EnumeradoresTipoCambio.Euro);
                    foreach (XmlElement nodo in dos)
                    {
                        moneda.TasaDeCambio = (float)Convert.ToDecimal(nodo.GetAttribute("OBS_VALUE"));
                        moneda.FechaCambio = Convert.ToDateTime(nodo.GetAttribute("TIME_PERIOD"));
                        monedas.ListaTasaCambios.Add(moneda);
                    }
                }
                if (nserie == "SF60653")
                {
                    var moneda = new TasaCambio();
                    XmlNodeList dos = ((XmlElement)lista[0]).GetElementsByTagName("bm:Obs");
                    moneda.Serie = "SF60653";
                    moneda.IdMoneda = GetIdMoneda(EnumeradoresTipoCambio.Dolar);
                    moneda.EnumeradoresTipoCambio = EnumeradoresTipoCambio.Dolar;
                    foreach (XmlElement nodo in dos)
                    {
                        moneda.TasaDeCambio = (float)Convert.ToDecimal(nodo.GetAttribute("OBS_VALUE"));
                        moneda.FechaCambio = Convert.ToDateTime(nodo.GetAttribute("TIME_PERIOD"));
                        monedas.ListaTasaCambios.Add(moneda);
                    }
                }

            }
            return monedas;
        }

        private int GetIdMoneda(EnumeradoresTipoCambio enumeradoresTipoCambio)
        {
             var servidor = Util.ServicioCatalogos();
                    var request = new CatalogoGeneralOperacionRequest()
                    { 
                        ExtraccionCatalogo = TipoExtraccionCatalogo.ExtraerIdXAbreviatura,
                        Item = new EntidadCatalogo()
                        {
                            CatalogoALlamar = Catalogo.Moneda,
                            FiltradoEspecifico = Filtrado.Alias,
                            
                        }
                    };
            switch (enumeradoresTipoCambio)
            {
                case EnumeradoresTipoCambio.Dolar:
                    request.Item.Alias = "USD";
                    var response = servidor.ExtraerCatalogoItem(request);
                    return response.Item.Id;
                case EnumeradoresTipoCambio.Euro:
                    request.Item.Alias = "EUR";
                    var response2 = servidor.ExtraerCatalogoItem(request);
                    return response2.Item.Id;
            }
            return 0;
        }
        #endregion
        public void Dispose()
        {
            iTasaCambioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
