using System;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Servicios.Seguridad.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var seguridad = new RFCController();
            var request = new RFCRequest()
            {
                Item = new RFC()
                {
                 IdRFC = 0,
                 TipoDeRFC = TipoRFC.RFCEmpresa,
                 RFCDato ="OITR900906"
                },
                UsuarioEjecucion = "Roberto"
            };
            var response = seguridad.ExtraeRFC(request);
            Console.Write(response.MensajeError);
        }
    }
}
