﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Dominio.Entidades;

namespace CustomSoft.Template.Dominio.Contratos
{
    public interface IRFCDominio : IDisposable
    {
        RFC ExtraeRFC(RFC rfc);
    }
}

