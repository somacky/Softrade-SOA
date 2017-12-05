using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.VUCEMService;

//using CustomSoft.Template.Modelo.VUCEMService;

namespace CustomSoft.Template.Modelo.Dominio.Entidades.Motor
{
    [DataContract]
    public class EntidadMotor
    {
        /// <summary>
        /// Entidad para arranque de sistema y creacion de Bitacora del dia
        /// </summary>
        [DataMember]
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Entidad que usa el listado que se tiene que consultar en SAT
        /// </summary>
        [DataMember]
        public List<ListadoPedimentosPendientes> ListadoPedimentosPend { get; set; }
        /// <summary>
        /// Entidad que devuelve el listado de los pedimentos de VUCEM
        /// </summary>
        [DataMember]
        public List<ListaPedimentosVUCEM> ListadoPedimentosVucem { get; set; }
        /// <summary>
        /// Entidad que se usa para consulta en VUCEM
        /// </summary>
        [DataMember]
        public RequestVUCEM RequestVucemListado { get; set; }
        /// <summary>
        /// Entidad que se usa para insercion uno por uno de los listados en BD
        /// </summary>
        [DataMember]
        public EntidadListadoVUCEMInsercion Pedimento { get; set; }
        //[DataMember]
        //public TablaBulk TablaBulk { get; set; }

        [DataMember]
        public List<ListadoPedimentosXProcesar> ListadoPedimentosXProcesar { get; set; }

        /// <summary>
        /// Entidad que se usa para devolver el pedimento de VUCEM al hacer la consulta de pedimento y partida
        /// </summary>
        [DataMember]
        public CustomSoft.Template.Modelo.VUCEMService.ArchivoM PedimentoArchivoM { get; set; }
        //public ArchivoM PedimentoArchivoM { get; set; }

        /// <summary>
        /// Entidad que tiene los datos finales a ocupar por el motor para el registro del token y el cierre del pedimento en BD
        /// </summary>
        [DataMember]
        public EntidadFinalPedimento CierrePedimento { get; set; }

        /// <summary>
        /// BD a la cual se va hacer la consulta
        /// </summary>
        [DataMember]
        public string BaseDatos { get; set; }

        /// <summary>
        /// Entidad de listado de COVEs
        /// </summary>
        [DataMember]
        public List<BitacoraCOVE> ListaCOVE { get; set; }

        [DataMember]
        public int IdEmpresa { get; set; }

        [DataMember]
        public List<BitacoraEdocument> ListadoEdocuments { get; set; }
    }
}
