using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IPedimentoRepositorio : IDisposable
    {
        /// <summary>
        /// Esta funcion contiene la lógica de subida FTP y Procesa el archivo para subirlo a base de datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        void InsertarPedimento(/*PedimentoCompleto pedimento*/);
        void InsertarExpedienteDigital();
        void InsertarAsociacionPedimentoExpediente();
        void ObtenerListaPedimentos();
        void ObtenerPedimento();
    }
}
