using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Base.EdocumentCOVE;
using CustomSoft.Template.Modelo.Dominio.Base.MotorBase;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.VUCEMService;

namespace CustomSoft.Template.Modelo.Dominio.Entidades.EdocumentCOVE
{
    [DataContract]
    public class DatosCOVE : DatosCOVEBase
    {
        [DataMember]
        public ConsultaEdocument Request { get; set; }
        [DataMember]
        public Archivo CerKey { get; set; }        
    }
}
