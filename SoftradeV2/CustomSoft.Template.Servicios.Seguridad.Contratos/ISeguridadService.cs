﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CustomSoft.Template.Modelo.Servicios.Request;
using CustomSoft.Template.Modelo.Servicios.Response;

namespace CustomSoft.Template.Servicios.Seguridad.Contratos
{
    [ServiceContract]
    public interface ISeguridadService
    {
        [OperationContract]
        UsuarioOperacionResponse UsuarioExecute(UsuarioOperacionRequest request);                    

        /// <summary>
        /// Espera recibir un RFC válido para compararlo con los dados de alta en la base
        /// de datos para verificar y posteriormente regresar un id 
        /// </summary>
        /// <param name="request">Dentro viene el RFC que se solicita</param>
        /// <returns></returns>
        [OperationContract]
        RFCResponse ExtraerRFC(RFCRequest request);

        [OperationContract]
        PedimentoOperacionResponse PedimentoExecute(PedimentoOperacionRequest request);

        [OperationContract]
        CFDIOperacionResponse CFDIExecute(CFDIOperacionRequest request);
    }
}
