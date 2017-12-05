using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Base;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;
using CustomSoft.Template.Servicios.Seguridad.Contratos;
using CustomSoft.Template.Servicios.Seguridad.Controller;

namespace CustomSoft.Template.Servicios.Seguridad
{   
    public class SeguridadService : ISeguridadService
    {
        public UsuarioOperacionResponse UsuarioExecute(UsuarioOperacionRequest request)
        {
            UsuarioOperacionResponse response = new UsuarioOperacionResponse();
            using (UsuarioController controller = new UsuarioController())
            {
                response = controller.ExecuteOperacion(request);
            }
            return response;
        }      


        public RFCResponse ExtraerRFC(RFCRequest request)
        {
            //request.Item = new RFC()
            //{
            //    TipoDeRFC = TipoRFC.RFCEmpresa,
            //    IdRFC = 0,
            //    RFCDato = "RFC123456ASD"
            //};
            var response = new RFCResponse();
            using (var controller = new RFCController())
            {
                response = controller.ExtraeRFC(request);
            }
            return response;
        }
        


        public PedimentoOperacionResponse PedimentoExecute(PedimentoOperacionRequest request)
        {
            var response = new PedimentoOperacionResponse();
            var file = ConvertirFileToByteArray(@"C:\Users\SistemasTI\Documents\acme.sql");
            request.Operacion = TipoOperacion.Insertar;
            request.Item = new Pedimento()
            {
                ArchivoFisico = new Archivo()
                {
                    ArchivoBytes = file,
                    ExtensionArchivo = ".sql",
                    TipoArchivoFiltro = TipoArchivo.ArchivoM,
                    FechaSubida = DateTime.Now,
                    IdCliente = 1,
                    IdEmpresa = 1,
                    LongitudArchivo = file.Length,
                    NombreCompletoArchivo = "acme.sql",
                    Patente = "3772"
                }
            };
            using (var controller = new PedimentoController())
            {
                response = controller.ExecuteOperacionPedimento(request);
            }
            return response;
        }

        private static byte[] ConvertirFileToByteArray(string ruta)
        {
            var fileStream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            /*Create a byte array of file stream length*/
            var bytes = new byte[fileStream.Length];
            /*Read block of bytes from stream into the byte array*/
            fileStream.Read(bytes, 0, System.Convert.ToInt32(fileStream.Length));
            /*Close the File Stream*/
            fileStream.Close();
            return bytes;
        }


        public CFDIOperacionResponse CFDIExecute(CFDIOperacionRequest request)
        {
            var file = ConvertirFileToByteArray(@"C:\Users\SistemasTI\Documents\script.sql");
            var response = new CFDIOperacionResponse();
            request.TipoDeOperacion = TipoOperacion.Insertar;
            request.Item = new CFDI()
            {
                ArchivoFisico = new Archivo()
                {
                    ArchivoBytes = file,
                    ExtensionArchivo = ".sql",
                    FechaSubida = DateTime.Now,
                    IdCliente = 1,
                    IdEmpresa = 1,
                    LongitudArchivo = file.Length,
                    NombreCompletoArchivo = "acme.sql",
                    Patente = "3772"
                }
            };
            using (var controller = new CFDIController())
            {
                response = controller.ExecuteOperacionCFDI(request);
            }
            return response;
        }
    }   
}
