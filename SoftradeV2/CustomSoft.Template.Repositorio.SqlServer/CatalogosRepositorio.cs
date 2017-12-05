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
    public class CatalogosRepositorio : ICatalogosRepositorio
    {
        private SqlHelper helper = null;

        public void InicializarConexion(TipoBaseDatos baseDatos)
        {
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        }    
        public BuscarCatalogo ExtraerIdMonedaXAbreviatura(BuscarCatalogo abreviaturaMoneda)
        {
            var item = new BuscarCatalogo();
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pClaveMoneda", SqlDbType.VarChar, 6, abreviaturaMoneda.Alias));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.SmallInt, 0, ParameterDirection.Output));
            InicializarConexion(TipoBaseDatos.Catalogos);
            helper.ExecuteNonQuery("usp_Moneda_DameIDxClaveMoneda", parametros);
            item = new BuscarCatalogo()
            {
                Id = Convert.ToInt16(helper.GetParameterOutput("@pID"))
            };
            return item;
        }

        public BuscarCatalogo ExtraerIdTipoComprobanteXNombreComprobante(BuscarCatalogo nombreComprobante)
        {
            var item = new BuscarCatalogo();                        
            InicializarConexion(TipoBaseDatos.Catalogos);
            var parametro = new SqlParameterItem("@pTipoComprobante", SqlDbType.VarChar, 10, nombreComprobante.Nombre);
            var reader = helper.ExecuteReader("usp_TipoComprobante_DameIDxTipoComprobante", parametro);
            while (reader.Read())
            {
                item = new BuscarCatalogo()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("IdTipoComprobante"))
                };
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
