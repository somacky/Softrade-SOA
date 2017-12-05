using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Modelo.Dominio.Filtro
{
    [DataContract]
    public class UsuarioFiltro : Usuario
    {
        [DataMember]
        public TipoFiltroUsuario TipoFiltro { get; set; }
    }
}
