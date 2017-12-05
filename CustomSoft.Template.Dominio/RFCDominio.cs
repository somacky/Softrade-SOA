using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.ExtraeRFC;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio
{
    public class RFCDominio : IRFCDominio
    {
        private IRFCRepositorio extraeRFCRepositorio;

        public RFCDominio()
        {
            extraeRFCRepositorio = FactoryEngine<IRFCRepositorio>.GetInstance("IRFCRepositorioConfig");
        }

        public RFC ExtraeRFC(RFC rfc)
        {
            if (!String.IsNullOrEmpty(rfc.RFCDato))
            {
                ValidarRFCExistente(rfc);
            }
            var datos = extraeRFCRepositorio.ExtraeRFC(rfc);
            return datos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginUsuario"></param>
        private void ValidarRFCExistente(RFC filtro)
        {
            if (null == extraeRFCRepositorio.ExtraeRFC(filtro))
            {
                throw new NoExisteRFCException();
            }
        }

        public void Dispose()
        {
            extraeRFCRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
