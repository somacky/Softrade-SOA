using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base.MotorBase
{
    [DataContract]
    public abstract class DatosPedimentoInsercionVUCEM
    {
        [DataMember]
        public int IdBitacoraSinc { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public string NombreAduana { get; set; }
        [DataMember]
        public int NumeroAduana { get; set; }
        [DataMember]
        public string NumeroPedimento { get; set; }
        [DataMember]
        public string Patente { get; set; }
        //[DataMember]
        //public string BaseDatos { get; set; }

    }
}
