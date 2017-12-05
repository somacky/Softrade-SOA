using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.FTPSoftrade;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IArchivoMRepositorio : IDisposable
    {
        ArchivoM InsertaPedimento(ArchivoM Pedimento);
        Archivo InsertaExpedienteDigital(Archivo archivo, int idUsuario);
        bool InsertaGrupoArchivo(int idPedimento, Archivo archivo);
    }
}
