using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using CustomSoft.Template.Modelo.Dominio.Base;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class Usuario : DatosBase
    {
        //[DataMember]
        //public string NombreUsuario { get; set; }
        //
        //[DataMember]
        //public string Login { get; set; }
        //
        //[DataMember]
        //public string Password { get; set; }
        //
        //[DataMember]
        //public bool EsActivo { get; set; }
        //
        //[DataMember]
        //public DateTime FechaRegistro { get; set; }        
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
        [DataMember]
        public int IdIdioma { get; set; }
        [DataMember]
        public int IdPreguntaSecreta { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }

        /// <summary>
        /// anteriormente llamada Usuario
        /// </summary>
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Pass { get; set; }
        [DataMember]
        public string CorreoElectronico { get; set; }
        [DataMember]
        public bool Inactivo { get; set; }
        [DataMember]
        public string RespuestaPreguntaSecreta { get; set; }
        //[DataMember]
        //public bool Activo { get; set; }
        [DataMember]
        public List<int> IdEmpresa { get; set; } 
    }
}
