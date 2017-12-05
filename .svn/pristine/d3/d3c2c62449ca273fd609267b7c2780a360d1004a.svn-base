using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.Edocument;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades.EdocumentCOVE;
using CustomSoft.Template.Modelo.FTPSoftrade;
using CustomSoft.Template.Modelo.VUCEMService;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio.EdocumentCOVE
{
    public partial class OperacionesEdocumentCOVEDominio : IOperacionesEdocumentCOVEDominio
    {
         private IOperacionEdocumentCOVERepositorio iOperacionEdocumentCoveRepositorio;

        public OperacionesEdocumentCOVEDominio()
        {
            iOperacionEdocumentCoveRepositorio =
                FactoryEngine<IOperacionEdocumentCOVERepositorio>.GetInstance("IOperacionEdocumentCOVERepositorioConfig");
        }

        public DatosCOVE GetDataCOVE(DatosCOVE datosCOVE)
        {
            //using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            //{                   
            var coveExiste = iOperacionEdocumentCoveRepositorio.DameIdXNOCOVE(datosCOVE);
            if (coveExiste.Request.ResponseEdocument.Cove.IdCOVE == 0)
            {
                //llamar a servicio VUCEM con CERKEY de Empresa
                var response = LlamarAServicioVUCEM(datosCOVE, ConsultaEdocumentPor.Empresa);
                if (response.ConsultaEdocumentVucemResult.Entidad != null)
                {
                    datosCOVE.Request = response.ConsultaEdocumentVucemResult.Entidad;
                    datosCOVE.Request.ResponseEdocument.Cove.XML = SubirArchivoXMLaFTP(datosCOVE.IdEmpresa, datosCOVE.IdPatente,
                        Util.GetXmlBytes(coveExiste.Request.ResponseEdocument), datosCOVE.Request.Edocument);

                }
                else
                {
                    var response2 = LlamarAServicioVUCEM(datosCOVE, ConsultaEdocumentPor.Patente);                    
                    if (response2.ConsultaEdocumentVucemResult.Entidad != null)
                    {
                        datosCOVE.Request = response2.ConsultaEdocumentVucemResult.Entidad;
                        datosCOVE.Request.ResponseEdocument.Cove.XML = SubirArchivoXMLaFTP(datosCOVE.IdEmpresa, datosCOVE.IdPatente,
                            Util.GetXmlBytes(coveExiste.Request.ResponseEdocument), datosCOVE.Request.Edocument);
                    }
                    else
                    {
                        throw new NoSePudoExtraerElCove();
                    }
                }
                datosCOVE = iOperacionEdocumentCoveRepositorio.InsertaCOVE(datosCOVE);
                if (datosCOVE.Request.ResponseEdocument.Cove.IdCOVE != 0)
                {
                    iOperacionEdocumentCoveRepositorio.CierraCove(datosCOVE.IdEmpresa, datosCOVE.IdBitacoraCOVE,
                       datosCOVE.Request.ResponseEdocument.Cove.IdCOVE);
                }
                else
                {
                    throw new NoSeInsertoCoveEnBaseDeDatos();
                }
                //trae respuesta vacía throw
            }
            //    transaction.Complete();
            //}
            return datosCOVE;

        }

        public void Dispose()
        {
            iOperacionEdocumentCoveRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
