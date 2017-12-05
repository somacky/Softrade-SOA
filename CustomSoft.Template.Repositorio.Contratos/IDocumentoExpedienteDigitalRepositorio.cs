using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IDocumentoExpedienteDigitalRepositorio : IDisposable
    {
        Archivo DameItemXIdExpedienteDigital(int idExpedienteDigital, int idEmpresa);
    }
}
