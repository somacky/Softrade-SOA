using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class CuentaGasto : CuentaGastoBase
    {        
        [DataMember]
        public Archivo ArchivoFisico { get; set; }    
        [DataMember]
        public int IdUsuario { get; set; }
    }

    [DataContract]
    public class ListadoCuentaGasto
    {
        [DataMember]
        public EnumeradoresCuentaGasto TipoFiltroLista { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdPedimento { get; set; }
        [DataMember]
        public List<CuentaGasto> Lista { get; set; }
    }
}
