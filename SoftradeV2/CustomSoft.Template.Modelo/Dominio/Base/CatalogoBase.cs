using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    public abstract class CatalogoBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
    }
}
