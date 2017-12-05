using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades.ExpedienteDigital;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface IExpedienteDigitalDominio : IDisposable
    {
        ListaExpedienteDigital ExtraerListaDocumentos(ListaExpedienteDigital listaExpedienteDigital);
        ListaExpedienteDigital ExtraerListaDocumentosTop5(ListaExpedienteDigital listaExpedienteDigital);
        ExpedienteDigital InsertarExpedienteDigital(ExpedienteDigital expediente);
        ListaExpedienteDigital ExtraerListaDocumentosXIdArticulo(ListaExpedienteDigital listaExpedienteDigital);
    }
}
