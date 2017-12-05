using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Compartido
{
    public class EnumeradoresPedimento
    {
        public enum TipoConsulta : byte
        {

            [EnumMember]
            ByPatente,

            [EnumMember]
            ByPedimento,

            [EnumMember]
            ByCoveEDocument,

            [EnumMember]
            ByRFC,

            [EnumMember]
            ByContendor,

            [EnumMember]
            ByGuia,

            [EnumMember]
            ByAduana
        }

        [DataContract]
        public enum TipoPedimento : byte
        {
            [EnumMember]
            PedimentoCompleto,

            [EnumMember]
            PedimentoSimple
        }

        [DataContract]
        public enum OrigenPedimento : byte
        {
            [EnumMember]
            PedimentoArchivoM,

            [EnumMember]
            PedimentoVucem
        }
        //enumerador para funcion ExecuteOperacionPedimento
        [DataContract]
        public enum OperacionPedimento : byte
        {
            [EnumMember]
            InsertaPedimentoBD,

            [EnumMember]
            InsertaPedimentoVUCEM,

            [EnumMember]
            InsertaPartidaBD
        }
    }
}
