using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class Notificacion : NotificacionBase
    {
    }

    [DataContract]
    public class ListNotificaciones
    {
        [DataMember]
        public Paginacion ListaPaginacion { get; set; }
        [DataMember]
        public List<Notificacion> ListaDeNotificaciones { get; set; }
        [DataMember]
        public TipoNotificacion TipoDeNotificacion { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public OperacionNotificacion OperacionDeNotificacion { get; set; }
    }
}
