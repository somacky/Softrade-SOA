using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Modelo.Dominio.Base
{
    [DataContract]
    public class DatosReg555CuentasAduanerasNPart
    {
        [DataMember]
        public int NumeroDocumento { get; set; }
        [DataMember]
        public string FraccionAracelaria { get; set; }
        [DataMember]
        public int NumeroPartida { get; set; }
        [DataMember]
        public int CLaveInstitucionCuentaGarantia { get; set; }
        [DataMember]
        public string NumeroCuentaGarancia { get; set; }
        [DataMember]
        public string FolioConstancia { get; set; }
        [DataMember]
        public DateTime FechaConstancia { get; set; }
        [DataMember]
        public int ClaveTipoGarantia { get; set; }
        [DataMember]
        public float ValorUnitarioTitulo { get; set; }
        [DataMember]
        public float ImporteTotalGarantia { get; set; }
        [DataMember]
        public float CantidadUnidadesMedida { get; set; }
        [DataMember]
        public float TitulosAsignados { get; set; }
        [DataMember]
        public string TipoGarantiaVUCEM { get; set; }//VUCEM
    }
}
