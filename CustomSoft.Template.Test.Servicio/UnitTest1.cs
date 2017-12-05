using System;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Filtro;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Servicios.Seguridad.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomSoft.Template.Test.Servicio
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var datosRFC = new DatosRFCRequest()
            {
                UsuarioEjecucion = "Roberto Olivares",
                Item = new DatosRFC()
                {
                    RFC = "OITR900906HDF",
                    TipoDeRFC = TipoRFC.RFCEmpresa,
                    Existe = false
                },
            };
            var repositorio = new ComparaRFCController();
            var response = repositorio.ExtraeRFC(datosRFC);
        }
    }
}
