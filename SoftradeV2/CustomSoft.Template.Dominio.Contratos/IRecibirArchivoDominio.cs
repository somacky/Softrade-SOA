using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTPSoftrade.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface IRecibirArchivoDominio : IDisposable
    {
        //void CompararRFC();
        Archivo ProcesarArchivoM(Archivo item);
        Archivo ProcesarArchivoCFDI(Archivo item);
        Archivo ProcesarArchivoPDF(Archivo item);        
    }
}
