using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Dominio.Excepciones.Reporteador
{
    class SqlNoRespondio : ApplicationException//sin uso
    {
        public override string Message
        {
            get
            {
                return ConfigurationManager.AppSettings["errorSQLException"];
            }
        }
    }
}

