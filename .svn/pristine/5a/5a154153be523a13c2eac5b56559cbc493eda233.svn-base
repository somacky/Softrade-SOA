using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CustomSoft.Template.Dominio.Excepciones.Archivo
{
    public class ArchivoNoSubidoException : ApplicationException
    {
        public override string Message 
        {
            get
            {
                return ConfigurationManager.AppSettings["errorArchivoNoSubido"];
            } 
        }
    }
}
