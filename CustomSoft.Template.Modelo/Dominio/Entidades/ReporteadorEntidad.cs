using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;

namespace CustomSoft.Template.Modelo.Dominio.Entidades
{
    [DataContract]
    public class ReporteadorEntidad
    {
        public int IdUsuario { get; set; }
        [DataMember]
        public Reporte NombreReporte { get; set; }

        public string WherePedimento { get; set; }

        public string WhereCove { get; set; }

        public string WhereCuentaGasto { get; set; }

        public string Where { get; set; }
        [DataMember]
        public List<DatosReporte> Informacion { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public FiltroReporte FiltroReporte { get; set; }
        [DataMember]
        public FiltroPedimento FiltroPedimento { get; set; }
        [DataMember]
        public FiltroCuentaGasto FiltroCuentaGasto { get; set; }
        [DataMember]
        public FiltroCove FiltroCove { get; set; }      
        //[DataMember]
        //public 
    }

    [DataContract]
    public class FiltroReporte
    {
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public DateTime? FechaEntrada1 { get; set; }
        [DataMember]
        public DateTime? FechaEntrada2 { get; set; }
        [DataMember]
        public DateTime? FechaPago1 { get; set; }
        [DataMember]
        public DateTime? FechaPago2 { get; set; }
        [DataMember]
        public string Pedimento { get; set; }
        [DataMember]
        public int IdAduanaSeccion { get; set; }
        [DataMember]
        public int IdTipoOperacion { get; set; }
        [DataMember]
        public int IdClavePedimento { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
        [DataMember]
        public int IdFraccion { get; set; }
        [DataMember]
        public int IdVinculacionVW { get; set; }
        [DataMember]
        public int IdPaisOrigenDestino { get; set; }
        [DataMember]
        public int IdPaisCompradorVendedor { get; set; }
        [DataMember]
        public DateTime? FechaFacturacion1 { get; set; }
        [DataMember]
        public DateTime? FechaFacturacion2 { get; set; }        
        [DataMember]
        public string NombreProveedor { get; set; }
        [DataMember]
        public string Guia { get; set; }
        [DataMember]
        public string NumeroContenedor { get; set; }
        [DataMember]
        public string IdentificadorNivelPartida { get; set; }
        [DataMember]
        public string IdentificadorNivelPedimento { get; set; }
        [DataMember]
        public int IdPermiso { get; set; }           
        [DataMember]
        public string NumeroCove { get; set; }       
        [DataMember]
        public bool CertificadoOrigen { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string ClaveArticulo { get; set; }
        [DataMember]
        public string NumeroFactura { get; set; }
        [DataMember]
        public int IdMoneda { get; set; }
        [DataMember]
        public string UUID { get; set; }
        [DataMember]
        public string RFCEmisor { get; set; }
        [DataMember]
        public string NombreEmisor { get; set; }
    }

    [DataContract]
    public class FiltroPedimento
    {
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public DateTime? FechaEntrada1 { get; set; }
        [DataMember]
        public DateTime? FechaEntrada2 { get; set; }
        [DataMember]
        public DateTime? FechaPago1 { get; set; }
        [DataMember]
        public DateTime? FechaPago2 { get; set; }
        [DataMember]
        public string Pedimento { get; set; }
        [DataMember]
        public int IdAduanaSeccion { get; set; }
        [DataMember]
        public int IdTipoOperacion { get; set; }
        [DataMember]
        public int IdClavePedimento { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
        [DataMember]
        public int IdFraccion { get; set; }
        [DataMember]
        public int IdVinculacionVW { get; set; }
        [DataMember]
        public int IdPaisOrigenDestino { get; set; }
        [DataMember]
        public int IdPaisCompradorVendedor { get; set; }
        [DataMember]
        public DateTime? FechaFacturacion1 { get; set; }
        [DataMember]
        public DateTime? FechaFacturacion2 { get; set; }
        [DataMember]
        public string NombreProveedor { get; set; }
        [DataMember]
        public string Guia { get; set; }
        [DataMember]
        public string NumeroContenedor { get; set; }
        [DataMember]
        public int IdIdentificadorNivelPartida { get; set; }
        [DataMember]
        public int IdIdentificadorNivelPedimento { get; set; }
    }

    [DataContract]
    public class FiltroCove
    {
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdAduanaVW { get; set; }
        [DataMember]
        public int IdPatente { get; set; }
        [DataMember]
        public string NumeroCove { get; set; }
        [DataMember]
        public bool CertificadoOrigen { get; set; }        
        [DataMember]
        public string ClaveArticulo { get; set; }        
        [DataMember]
        public int IdMoneda { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }

    [DataContract]
    public class FiltroCuentaGasto
    {
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string NumeroFactura { get; set; }
        [DataMember]
        public int IdMoneda { get; set; }
        [DataMember]
        public string UUID { get; set; }
        [DataMember]
        public string RFCEmisor { get; set; }
        [DataMember]
        public string NombreEmisor { get; set; }
    }
}
