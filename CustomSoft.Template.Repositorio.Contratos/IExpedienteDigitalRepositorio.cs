using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public interface IExpedienteDigitalRepositorio : IDisposable
    {
        ListaExpedienteDigital ObtenerListaDeArchivos(string where, ListaExpedienteDigital request, int idUsuario);
        ExpedienteDigital InsertaExpedienteDigital(ExpedienteDigital expediente);
        ListaExpedienteDigital ObtenerListaDeArchivosTop5Pedimento(ListaExpedienteDigital request, int idUsuario);
        ListaExpedienteDigital ObtenerListaDeArchivosTop5CuentaGasto(ListaExpedienteDigital request, int idUsuario);
        ListaExpedienteDigital ObtenerListaDeArchivosXIdArticulo(ListaExpedienteDigital request,
            int idUsuario);
    }
}
