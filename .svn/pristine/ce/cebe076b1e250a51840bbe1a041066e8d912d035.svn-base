//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CustomSoft.Template.Modelo.Dominio.Entidades;

//namespace CustomSoft.Template.Dominio.Contratos
//{
//    public interface IOperacionPedimentoDominio : IDisposable
//    {
//        EntidadArchivoM RegistraPedimento(EntidadArchivoM request);
//        void ConsultaPedimentoCompletoVucem(EntidadArchivoM request);
//        EntidadArchivoM RegistraPartida(EntidadArchivoM request);
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.VUCEMService;
using ArchivoM = CustomSoft.Template.Modelo.Dominio.Entidades.ArchivoM;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface IOperacionPedimentoDominio : IDisposable
    {
        EntidadArchivoM RegistraPedimento(EntidadArchivoM request, Token token);
        //void ConsultaPedimentoCompletoVucem(EntidadArchivoM request);
        EntidadArchivoM RegistraPedimentoVucem(EntidadArchivoM request); //NEW
        EntidadArchivoM RegistraPartida(EntidadArchivoM request);
        //ArchivoM RegistraPartida(ArchivoM partida);
        int RegistraPartidaVucem(List<DatosReg551Partidas> pPartida, int pIdPedimento, int pIdEmpresa);//NEW
        ListadoArchivoM GetListadoArchivoM(EntidadArchivoM item);
    }
}
