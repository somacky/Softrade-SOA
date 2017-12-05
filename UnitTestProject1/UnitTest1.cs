using System;
using CustomSoft.Template.Dominio;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rfc = new RFC()
            {
                IdRFC = 0,
                TipoDeRFC = TipoRFC.RFCEmpresa,
                RFCDato = "OITR900906"
            };
            var dominio =  new RFCDominio();
            var respuesta = dominio.ExtraeRFC(rfc);            
        }
    }
}
