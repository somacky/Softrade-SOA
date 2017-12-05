using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.EdocumentCOVE;
using CustomSoft.Template.Modelo.Dominio.Entidades.Motor;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IOperacionEdocumentCOVERepositorio : IDisposable
    {
        //List<BitacoraCOVE> DameListaCOVEConsulta(int pIdEmpresa);
        bool CierraCove(int pIdEmpresa, int pIdBitacoraCOVEVUCEM, int pIdCOVE);
        
        //int InsertaTablaCOVE(int pIdEmpresa, int pIdAduana, int pIdPaisCompradosVenderos, string pEdocument, int pIdPatente, string pTipoOperacion,
        //    DateTime pFechaExpedicion, string pNumerofactura, string pNombreEmisor, string pIdentificadorEmisor, string pNombreDestinatario,
        //    string pIdentificadorDestinatario, bool pCertificadoOrigen, float pSumaValorTotal, string pPath);

        DatosCOVE InsertaCOVE(DatosCOVE datosCOVE);        

        DatosCOVE DameIdXNOCOVE(DatosCOVE datosCOVE);
    }
}
