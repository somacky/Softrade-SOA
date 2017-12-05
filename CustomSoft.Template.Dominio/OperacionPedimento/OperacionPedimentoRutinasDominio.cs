using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.CatalogosService;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;


namespace CustomSoft.Template.Dominio.OperacionPedimento
{
    partial class OperacionPedimentoDominio
    {
        
        private Archivo ConvertirArchivo(Archivo archivo)
        {
            var request = new Archivo()
            {
                ArchivoBytes = archivo.ArchivoBytes,
                TipoArchivoFiltro = TipoArchivo.ArchivoM,
                ExtensionArchivo = archivo.ExtensionArchivo,
                FechaSubida = archivo.FechaSubida,
                LongitudArchivo = archivo.LongitudArchivo,
                NombreArchivo = archivo.NombreArchivo,
                Patente = archivo.Patente,
                ExtensionData = archivo.ExtensionData,
                IdCliente = archivo.IdCliente,
                
            };
            return request;
        }
        private CatalogoGeneralOperacionRequest RequestTipoDocumentoXAbreviatura(string tipoDocumento, int idUsuarioEjecucion)
        {
            return new CatalogoGeneralOperacionRequest()
            {
                ExtraccionCatalogo = TipoExtraccionCatalogo.ExtraerIdXAbreviatura,
                IdUsuarioEjecucion = idUsuarioEjecucion,
                Item = new EntidadCatalogo()
                {
                    Alias = tipoDocumento,
                    CatalogoALlamar = Catalogo.TipoDocumento
                }
            };
        }
    }


}
