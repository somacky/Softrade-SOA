using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.UrlTemporal;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio
{
    public class UrlTemporalDominio : IUrlTemporalDominio
    {
        public IUrlTemporalRepositorio iUrlTemporalRepositorio = null;


        private string passPhrase = "S0ft#@d3";        // can be any string
        private string saltValue = "s@1tValue";        // can be any string
        private string hashAlgorithm = "SHA1";             // can be "MD5"
        private int passwordIterations = 2;                // can be any number
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        private int keySize = 256;                // can be 192 or 128

        public UrlTemporalDominio()
        {
            iUrlTemporalRepositorio = FactoryEngine<IUrlTemporalRepositorio>.GetInstance("IUrlTemporalRepositorioConfig");
        }

        public UrlTemporal ComprobarUrlTemporal(UrlTemporal url)
        {
            // UrlTemporal/"IdEmpresa"/"id"/"OtroIDDeSerNecesario"/
            //decodificar guid para ver el idEmpresa a consultar
            var urlValidaRjindael = ConvertirCaracteresOriginales(url.GuidUrl);
            var stringDecodificado = RijndaelSimple.Decrypt
            (
                urlValidaRjindael,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );
            string[] separadas = stringDecodificado.Split('/');
            url.IdEmpresa = Convert.ToInt16(separadas[2]);
            switch (separadas[0])
            {
                case "CambioPassword":
                    url.TipoUrlTemporal = TipoUrlTemporal.CambioPassword;
                    break;
                case "ExpedienteDigital":
                    url.TipoUrlTemporal = TipoUrlTemporal.ExpedienteDigital;
                    break;
            }
            //la linea anterior depende de que tipo de liga sea
            //comprobar que el guid efectivamente existe en la base de datos
            url = iUrlTemporalRepositorio.EsUrlValida(url);
            if (url.IdUrl == 0)
            {
                url = iUrlTemporalRepositorio.InactivarUrl(url);
                throw new ErrorUrlTemporal();
            }
            url.Ids = new List<int>();
            for (int i = 3; i < separadas.Count(); i++)
            {
                url.Ids.Add(Convert.ToInt32(separadas[i]));
            }
             //marcar como url usada.
            url = iUrlTemporalRepositorio.InactivarUrl(url);
            return url;            
            //en caso que no exista en base de datos o haya algo malo con el guid
            //enviar excepciones
        }

        /// <summary>
        /// Rutina que genera una url temporal con formato 
        /// /TipoUrl/Guid/"IdEmpresa"/"id"/"OtroIDDeSerNecesario"/  por lo que se pide que siempre venga lleno
        /// el IdEmpresa
        /// y el listado de ids.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public UrlTemporal GenerarUrlTemporal(UrlTemporal url)
        {            
            //transaction scope
            // /UrlTemporal/"IdEmpresa"/"id"/"OtroIDDeSerNecesario"/            
            url = GenerarUrl(url);
            string[] separadas = url.GuidUrl.Split('/');
            //Llamar a var stringCodificado = UtilUrl.Base64Encode(// UrlTemporal/"IdEmpresa"/"id"/) para codificar primero el string
            url.GuidUrl = RijndaelSimple.Encrypt
            (
                url.GuidUrl,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );
            url.GuidUrl = ConvertirCaracteresInvalidos(url.GuidUrl);
            //guardar este último guidDefinitivo en la base de datos, los parametros de fecha e intentos depende de para que fue generada
            url = iUrlTemporalRepositorio.InsertarUrlTemporal(url);
            //la liga
            //enviar correo con la liga generada dependiendo el tipo de url que debe enviarse
            //terminar rutina
            return url;
        }

        public static string ConvertirCaracteresInvalidos(string guid)
        {
            //string enc = Convert.ToBase64String(guid.ToByteArray());
            guid = guid.Replace("/", "_");
            guid = guid.Replace("+", "-");
            return guid;
        }

        public static string ConvertirCaracteresOriginales(string guid)
        {
            //string enc = Convert.ToBase64String(guid.ToByteArray());
            guid = guid.Replace("_", "/");
            guid = guid.Replace("-", "+");
            return guid;
        }
        

        private UrlTemporal GenerarUrl(UrlTemporal url)
        {
            string urlString = string.Empty;
            switch (url.TipoUrlTemporal)
            {
                    case TipoUrlTemporal.CambioPassword:
                    urlString = "CambioPassword";
                    break;
                    case TipoUrlTemporal.ExpedienteDigital:
                    urlString = "ExpedienteDigital";
                    break;
            }
            urlString += "/" + Guid.NewGuid() + "/" + url.IdEmpresa + "/";
            string urlResto = string.Empty;
            foreach (var ids in url.Ids)
            {
                if (!string.IsNullOrEmpty(urlResto))
                    urlResto += "/";
                urlResto += ids ;
            }
            urlString += urlResto;
            url.GuidUrl = urlString;            
            return url;
        }

        public void Dispose()
        {
            iUrlTemporalRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
