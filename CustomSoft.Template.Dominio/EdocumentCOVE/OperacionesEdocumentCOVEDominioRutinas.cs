﻿using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.OperacionEmpresa;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades.EdocumentCOVE;
using CustomSoft.Template.Modelo.Dominio.Entidades.Empresa;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.VUCEMService;
using MCS.Factory;

namespace CustomSoft.Template.Dominio.EdocumentCOVE
{
    public partial class OperacionesEdocumentCOVEDominio
    {
        private ConsultaEdocumentVucemResponse1 LlamarAServicioVUCEM(DatosCOVE datosCOVE, ConsultaEdocumentPor consultarPor)
        {
            //pedir a base de datos path y archivo de cer,
            //luego path y archivo de key
            //tambien datos de key y cer.
            var request = new ConsultaEdocumentVucemRequest1()
            {
                request = new ConsultaEdocumentVUCEMRequest()
                {
                    
                
                Entidad = GenerarLlamado(datosCOVE, consultarPor)
}
            };
            var vucem = Util.ServicioVUCEM();
            var response = vucem.ConsultaEdocumentVucem(request);
            
            return response;
        }

        private ConsultaEdocument GenerarLlamado(DatosCOVE datosCOVE, ConsultaEdocumentPor consultarPor)
        {
            var vucem = Util.ServicioVUCEM();
            //var io = FactoryEngine<IOperacionEmpresaDominio>.GetInstance("IOperacionEmpresaDominioConfig");           
            var entidad = GenerarLlamadoEspecifico(datosCOVE, consultarPor);
            return entidad;
            //var response = vucem.ConsultaEdocumentVucem(new ConsultaEdocumentVUCEMRequest());
        }

        private ConsultaEdocument GenerarLlamadoEspecifico(DatosCOVE datosCOVE,  ConsultaEdocumentPor consultaPor)
        {

            //var vucem = Util.ServicioVUCEM();
            var io = FactoryEngine<IOperacionEmpresaDominio>.GetInstance("IOperacionEmpresaDominioConfig");            
            var entidad = new ConsultaEdocument();
            switch (consultaPor)
            {
                case ConsultaEdocumentPor.Empresa:
                    var req = new EntidadEmpresa()
                    {
                        OperacionEspecifica = OperacionEmpresaItem.DameDatosEmpresaXId,
                        DatosEmpresa = new Empresa()
                        {
                            IdEmpresaVw = datosCOVE.IdEmpresa

                        },
                        DatosPatente = new Patente()
                        {
                            IdPatente = datosCOVE.IdPatente
                        }
                    };
                    var response = io.OperacionEmpresaItem(req);
                    entidad = new ConsultaEdocument()
                    {
                        ArchivoCer = GetArchivoCerKey(ConvertirEmpresaToArchivoCer(response.DatosEmpresa)),
                        ArchivoKey = GetArchivoCerKey(ConvertirEmpresaToArchivoKey(response.DatosEmpresa)),
                        Edocument = datosCOVE.Request.Edocument.Trim(),
                        RFC = response.DatosEmpresa.RFC.Trim(),
                        PasswordCerKey = response.DatosEmpresa.PasswordCertificado.Trim(),
                        PasswordWSVucem = response.DatosEmpresa.WebKeyVUCEM.Trim()
                    };
                    break;
                case ConsultaEdocumentPor.Patente:
                    req = new EntidadEmpresa()
                    {
                        OperacionEspecifica = OperacionEmpresaItem.DameDatosPatenteXId,
                        DatosEmpresa = new Empresa()
                        {
                            IdEmpresaVw = datosCOVE.IdEmpresa

                        },
                        DatosPatente = new Patente()
                        {
                            IdPatente = datosCOVE.IdPatente
                        }
                    };
                    response = io.OperacionEmpresaItem(req);
                    entidad = new ConsultaEdocument()
                    {
                        ArchivoCer = GetArchivoCerKey(ConvertirPatenteToArchivoCer(response.DatosPatente)),
                        ArchivoKey = GetArchivoCerKey(ConvertirPatenteToArchivoKey(response.DatosPatente)),
                        Edocument = datosCOVE.Request.Edocument.Trim(),
                        RFC = response.DatosPatente.RFC.Trim(),
                        PasswordCerKey = response.DatosPatente.PasswordKey.Trim(),
                        PasswordWSVucem = response.DatosPatente.WebKeyVUCEM.Trim()
                    };
                    break;
            }
            return entidad;
            //var response = vucem.ConsultaEdocumentVucem(new ConsultaEdocumentVUCEMRequest());
        }

        private Archivo ConvertirPatenteToArchivoCer(Patente patente)
        {
            var archivo = new Archivo();
            archivo.Patente = patente.NumeroPatente;
            archivo.NombreArchivo = patente.ArchivoCer;
            archivo.NuevoNombreArchivo = patente.ArchivoCer;
            archivo.TipoDeCerKey = TipoCerKey.Patente;
            return archivo;
        }

        private Archivo ConvertirPatenteToArchivoKey(Patente patente)
        {
            var archivo = new Archivo();
            archivo.Patente = patente.NumeroPatente;
            archivo.NombreArchivo = patente.ArchivoKey;
            archivo.NuevoNombreArchivo = patente.ArchivoKey;
            archivo.TipoDeCerKey = TipoCerKey.Patente;
            return archivo;
        }

        private Archivo ConvertirEmpresaToArchivoCer(Empresa empresa)
        {
            var archivo = new Archivo();
            archivo.IdEmpresa = empresa.IdEmpresaVw;
            archivo.NombreArchivo = empresa.Nombrecertificado;
            archivo.NuevoNombreArchivo = empresa.Nombrecertificado;
            archivo.TipoDeCerKey = TipoCerKey.Cliente;
            return archivo;
        }

        private Archivo ConvertirEmpresaToArchivoKey(Empresa empresa)
        {
            var archivo = new Archivo();
            archivo.IdEmpresa = empresa.IdEmpresaVw;
            archivo.NombreArchivo = empresa.NombreKey;
            archivo.NuevoNombreArchivo = empresa.NombreKey;
            archivo.TipoDeCerKey = TipoCerKey.Cliente;
            return archivo;
        }

        private byte[] GetArchivoCerKey(Archivo archivo)
        {
            var request = new RecibeArchivoRequest()
            {
                Item = archivo,
                UsuarioEjecucion = "",
                Operacion = TipoOperacionArchivo.Extraer
            };            
            var ftp = Util.ServicioFTPSoftrade();
            var response = ftp.OperacionArchivo(request);
            return response.Item.ArchivoBytes;
            //return null;
        }

        //private DatosCOVE InsertarArchivo(DatosCOVE digitalizacion)
        //{
        //    var archivo = digitalizacion.ArchivoFisico;
        //    var req = new Template.Modelo.Dominio.Entidades.ExpedienteDigital.ExpedienteDigital()
        //    {
        //        IdEmpresa = archivo.IdEmpresa,
        //        NombreOrigen = archivo.NombreArchivo,
        //        NombreDestino = archivo.NuevoNombreArchivo,
        //        Path = archivo.PathDestino,
        //        IdUsuario = 0,//pendiente
        //        IdTipoDocumento = 2
        //    };
        //    var io = FactoryEngine<IExpedienteDigitalDominio>.GetInstance("IExpedienteDigitalDominioConfig");
        //    req = io.InsertarExpedienteDigital(req);
        //    bool ok = false;
        //    if (req.IdExpedienteDigital != 0)
        //    {
        //        if (iDigitalizacionVUCEMRepositorio.InsertaGrupoArchivo(digitalizacion.IdPedimento,
        //            req.IdExpedienteDigital,
        //            archivo.IdEmpresa))
        //            if (iDigitalizacionVUCEMRepositorio.CierraEdocument(archivo.IdEmpresa,
        //                digitalizacion.IdBitacoraEdocumentVUCEM, digitalizacion.IdPedimento))
        //                return digitalizacion;
        //    }
        //    return null;
        //}           

        private string SubirArchivoXMLaFTP(int idEmpresa, int idPatente, byte[] archivoBytes, string edocument)
        {
            //var xmlBytes = Util.GetXmlBytes(response.Entidad.ResponseEdocument);
            var iEmpresa = new OperacionEmpresaDominio();
            var req = new EntidadEmpresa()
            {
                DatosEmpresa = new Empresa()
                {
                    IdEmpresaVw = idEmpresa
                }
            };
            var datosEmpresa = iEmpresa.OperacionEmpresaItem(req);

            var reqPatente = new EntidadEmpresa()
            {
                OperacionEspecifica = OperacionEmpresaItem.DameDatosPatenteXId,
                DatosPatente = new Patente()
                {
                    IdPatente = idPatente
                }
            };
            var datosPatente = iEmpresa.OperacionEmpresaItem(reqPatente);
            var file =  GuardarArchivoFTP(datosEmpresa.DatosEmpresa.IdClienteVw, idEmpresa,
                datosPatente.DatosPatente.NumeroPatente, edocument, archivoBytes);
            //Inserta en expedienteDigital el Archivo físico.
            InsertarArchivo(file);          
            return file.PathDestino + file.NuevoNombreArchivo;
        }

        private void InsertarArchivo(Archivo archivo)
        {
            
            var req = new Template.Modelo.Dominio.Entidades.ExpedienteDigital.ExpedienteDigital()
            {
                IdEmpresa = archivo.IdEmpresa,
                NombreOrigen = archivo.NombreArchivo,
                NombreDestino = archivo.NuevoNombreArchivo,
                Path = archivo.PathDestino,
                IdUsuario = 0,//pendiente
                IdTipoDocumento = 3
            };
            var io = FactoryEngine<IExpedienteDigitalDominio>.GetInstance("IExpedienteDigitalDominioConfig");
            req = io.InsertarExpedienteDigital(req);
            bool ok = false;                      
        }           

        private Archivo LlamadoAServidorFTP(Archivo archivo)
        {
            var request = new RecibeArchivoRequest()
            {
                Item = archivo,
                UsuarioEjecucion = "",
                Operacion = TipoOperacionArchivo.Insertar
            };
            var ftp = Util.ServicioFTPSoftrade();
            var responseFTP = ftp.OperacionArchivo(request);
            return responseFTP.Item;
        }

        private Archivo GuardarArchivoFTP(int idCliente, int idEmpresa, string patente, string eDocument, byte[] archivoBytes)
        {
            var request = new Archivo()
            {
                IdCliente = idCliente,
                IdEmpresa = idEmpresa,
                Patente = patente,
                NombreArchivo = eDocument,
                ExtensionArchivo = "xml",
                ArchivoBytes = archivoBytes,
                TipoArchivoFiltro = TipoArchivo.XML,
                LongitudArchivo = archivoBytes.Length,
                
            };

            return LlamadoAServidorFTP(request);
        }
    }
}
