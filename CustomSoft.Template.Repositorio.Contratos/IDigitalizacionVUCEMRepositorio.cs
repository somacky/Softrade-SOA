using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IDigitalizacionVUCEMRepositorio : IDisposable
    {
        DigitalizacionVUCEM GetDocumentFromVUCEM(DigitalizacionVUCEM digitalizacion);
        bool InsertaGrupoArchivo(int idPedimento, int idExpedienteDigital, int idEmpresa);
        bool CierraEdocument(int pIdEmpresa, int pIdBitacoraEdocumentVUCEM, int pIdPedimento);
    }
}
