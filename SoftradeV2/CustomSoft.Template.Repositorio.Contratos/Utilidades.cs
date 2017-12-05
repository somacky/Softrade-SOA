using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Repositorio.Contratos
{
    public static class Utilidades
    {
        public static void AddParam(this SqlCommand cmd,
                                  string paramName,
                                  SqlDbType paramType,
                                  object paramValue,
                                  ParameterDirection paramDirection = ParameterDirection.Input)
        {
            var parametro = new SqlParameter();
            parametro.ParameterName = paramName;
            parametro.SqlDbType = paramType;
            parametro.Direction = paramDirection;
            parametro.Value = paramValue;
            cmd.Parameters.Add(parametro);
        }

    }
}
