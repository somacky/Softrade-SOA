using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class RFCRepositorio : IRFCRepositorio
    {
        //public RFCRepositorio(BaseDatos baseDatos)
        //{
        //    helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        //}   
        public void InicializarConexion(TipoBaseDatos baseDatos)
        {
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        }    
        private SqlHelper helper= null;

        #region Metodos Privados
        /// <summary>
        /// Función que extrae de un stored procedure si un RFC Existe, y trae el id de este para tabla Patente y RFC patente
        /// </summary>
        /// <param name="rfc">Espera el RFC del stored Procedure</param>
        /// <returns>Variable del tipo DatosRFC</returns>
        private RFC ExtraeRFCPatente(string rfc)
        {
            try
            {
                //List<SqlParameterItem> parametros = new List<SqlParameterItem>();
                //parametros.Add(new SqlParameterItem("@prueba", SqlDbType.Bit, 0));
                ////parametros.Add(new SqlParameterItem("@pDescripcion", SqlDbType.VarChar, 100, "prueba"));
                ////parametros.Add(new SqlParameterItem("@pDescripcionIngles", SqlDbType.VarChar, 100, "trial"));
                ////parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, ParameterDirection.Output));
                ////parametros.Add(new SqlParameterItem("@EsActivo", SqlDbType.Bit, item.EsActivo));            
                //InicializarConexion(TipoBaseDatos.Catalogos);
                //var ret = helper.ExecuteNonQuery("Sacsp_Reg001_RegistraDatos", parametros);

                //return null;
                var item = new RFC();
                var parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pRFC", SqlDbType.VarChar, 13, rfc));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
                InicializarConexion(TipoBaseDatos.Softrade);
                helper.ExecuteNonQuery("usp_EmpresaVW_DameIDxRFC", parametros);
                item = new RFC()
                {
                    IdRFC = Convert.ToInt16(helper.GetParameterOutput("@pID"))
                };           
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Función que extrae de un stored procedure si un RFC Existe, y trae este el Id del mismo para tabla empresa
        /// </summary>
        /// <param name="rfc">Espera el RFC del stored Procedure</param>
        /// <returns>Variable del tipo DatosRFC</returns>
        private RFC ExtraeRFCEmpresa(string rfc)
        {
            try
            {
                var item = new RFC();
                var parametros = new List<SqlParameterItem>();
                parametros.Add(new SqlParameterItem("@pRFC", SqlDbType.VarChar, 13, rfc));
                parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
                InicializarConexion(TipoBaseDatos.Softrade);
                helper.ExecuteNonQuery("usp_EmpresaVW_DameIDxRFC", parametros);
                item = new RFC()
                {
                    IdRFC = Convert.ToInt16(helper.GetParameterOutput("@pID"))
                };
                return item;
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Esta función determina a qué tabla se le hablará si a patente o empresa para verificar si el RFC existe
        /// </summary>
        /// <param name="rfc">Entidad tipo RFC es importante que traiga el tipo de RFC y el RFC</param>
        /// <returns></returns>
        public RFC ExtraeRFC(RFC rfc)
        {
            RFC item = null;
            switch (rfc.TipoDeRFC)
            {
                case TipoRFC.RFCEmpresa:
                    item = ExtraeRFCEmpresa(rfc.RFCDato);
                    break;
                case TipoRFC.RFCPatente:
                    item = ExtraeRFCPatente(rfc.RFCDato);
                    break;
            }
            return item;
        }
        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }        
    }
}
