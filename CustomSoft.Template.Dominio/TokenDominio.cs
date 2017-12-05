using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.Token;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Dominio
{
    public class TokenDominio : ITokenDominio
    {
        private string path = string.Empty;
        private string fileName = string.Empty;
        public TokenDominio()
        {                        
            path = ConfigurationManager.AppSettings["pathTokens"];
            fileName = "tokens.xml";
        }

        public Token GenerarToken(Token token)
        {
            //primero deserializa los tokens existentes
            var tokens = Deserialize();
            //luego agrega un nuevo token que se va a generar      
            int id = 0;
            if(tokens.Count != 0)
            { 
                id = (from c in tokens
                select c.IdToken).Max();
            }
            var newToken = new Token()
            {
                IdToken = id + 1,
                Guid = Guid.NewGuid(),
                FechaExpiracion = DateTime.Now.AddMinutes(5),
                NumeroIntentosDisponibles = 1
            };
            var tokens1 = from c in tokens
                          where c.FechaExpiracion > DateTime.Now
                                && c.NumeroIntentosDisponibles > c.NumeroIntentosRealizados
                          select c;
            tokens = tokens1.ToList();
            tokens.Add(newToken);
            //agrega el token a la lista de tokens
            //guarda el xml en un path específico
            SaveObjectXml(tokens);            
            return newToken;
        }

        public Token BuscarToken(Token token)
        {
            //Primero busca en la BD de tokens el guid.
            var tokens = Deserialize();

            var guidExistente = from c in tokens
                where c.Guid == token.Guid
                //&& c.FechaExpiracion > DateTime.Now
                //&& c.NumeroIntentosDisponibles > c.NumeroIntentosRealizados
                select c;

            //si existe entonces verifica la fecha que no sea menor a hoy 5 minutos            
            //verifica que el numero de intentos disponibles sean menor que los intentos realizados.
            var enumerable = guidExistente as Token[] ?? guidExistente.ToArray();
            if (!enumerable.Any())
            {
                GuardarTokens();
                throw new ErrorEnToken();                
            }
            //regresa un bool con la respuesta.
            var guidExistente2 = enumerable.ToList();
            var guidList = from c in guidExistente2
                where c.FechaExpiracion > DateTime.Now
                      && c.NumeroIntentosDisponibles > c.NumeroIntentosRealizados
                select c;
            enumerable = guidList as Token[] ?? guidList.ToArray();
            if (!enumerable.Any())
            {
                GuardarTokens();
                throw new TokenExpirado();
            }

            token.TokenValido = true;
            tokens.Find(token1 => token1.Guid.Equals(token.Guid)).NumeroIntentosRealizados++;
            //if que comprueba los que el token se uso hasta el numero de veces permitidas o lo borra
            if (tokens.Find(token1 => token1.Guid.Equals(token.Guid)).NumeroIntentosRealizados >=
                tokens.Find(token1 => token1.Guid.Equals(token.Guid)).NumeroIntentosDisponibles)
            {
                var tokenEspecifico = enumerable.ToList();
                tokens.Remove(tokenEspecifico[0]);            
            }

            GuardarTokens(tokens);
            return token;
        }

        private void GuardarTokens(List<Token> tokens = null)
        {
            if (tokens == null)
                tokens = Deserialize();
            var tokens1 = from c in tokens
                          where c.FechaExpiracion > DateTime.Now
                                && c.NumeroIntentosDisponibles > c.NumeroIntentosRealizados
                          select c;
            tokens = tokens1.ToList();
            SaveObjectXml(tokens);
        }

        private List<Token> Deserialize()
        {
            var dir = new DirectoryInfo(path);
            if (!dir.Exists)
                dir.Create();
            var fileInfo = new FileInfo(path + fileName);
            if (fileInfo.Exists)
            {
                //File.Create(path + fileName).Dispose();

                if (fileInfo.Length != 0)
                {
                    var serializer = new XmlSerializer(typeof (List<Token>));
                    var reader = new StreamReader(path + fileName);
                    var enumerable = (List<Token>) serializer.Deserialize(reader);
                    reader.Close();

                    return enumerable;

                }
            }
            return new List<Token>();
        }

        public void SaveObjectXml(object objeto)
        {
            byte[] data;
            var ms = new MemoryStream();
            var serializer = new XmlSerializer(objeto.GetType());
            serializer.Serialize(ms, objeto);
            data = ms.ToArray();
            File.WriteAllBytes(path + fileName,data);            

        }       
        private IEnumerable<Token> GetToken(string guid)
        {
            
            var xml = XDocument.Load(path);            

            var token = from c in xml.Descendants("contacto")
                where c.Element("Guid").Value.Equals(guid)
                 //&& Convert.ToDateTime(c.Element("FechaExpiracion").Value.Equals("") )< DateTime.Now 
                orderby c.Element("nombre").Value
                            select new Token()
                            {
                                IdToken = Convert.ToInt16(c.Element("Id")),
                                Guid = Guid.Parse(Convert.ToString(c.Element("Guid"))),
                                FechaExpiracion = Convert.ToDateTime(c.Element("FechaExpiracion")),
                                NumeroIntentosDisponibles = Convert.ToInt16(c.Element("NumeroIntentosDisponibles")),
                                NumeroIntentosRealizados = Convert.ToInt16(c.Element("NumeroIntentosRealizados"))
                            };
            return token;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
