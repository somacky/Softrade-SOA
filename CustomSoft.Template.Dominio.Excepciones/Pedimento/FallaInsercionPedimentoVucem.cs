﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Dominio.Excepciones.Pedimento
{
    public class FallaInsercionPedimentoVucem : ApplicationException
    {
        public override string Message
        {
            get
            {
                return ConfigurationManager.AppSettings["errorInsercionPedVucem"];
            }
        }
    }
}
