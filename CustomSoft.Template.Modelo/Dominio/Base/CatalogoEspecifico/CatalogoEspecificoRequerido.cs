using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;

namespace CustomSoft.Template.Modelo.Dominio.Base.CatalogoEspecifico
{
    [DataContract]
    public abstract class CatalogoEspecificoRequerido 
    {
        [DataMember]
        public TipoCatalogoEspecifico TipoCatalogo { get; set; }
    }
}
