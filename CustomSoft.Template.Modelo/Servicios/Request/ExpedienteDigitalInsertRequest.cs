using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital;
using CustomSoft.Template.Modelo.Servicios.Base;

namespace CustomSoft.Template.Modelo.Servicios.Request
{
    [DataContract]
    public class ExpedienteDigitalInsertRequest : OperacionRequestBase<ExpedienteDigital>
    {
    }
}
