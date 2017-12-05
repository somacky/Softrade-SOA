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
    public class TasaCambioRepositorio : ITasaCambioRepositorio
    {
        private SqlHelper helper = null;

        public void InicializarConexion(TipoBaseDatos baseDatos)
        {
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        }


        public TasaCambio InsertarTasaCambio(TasaCambio item)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdMoneda", SqlDbType.Int, item.IdMoneda));
            parametros.Add(new SqlParameterItem("@pTasaCambio", SqlDbType.Float, item.TasaDeCambio));
            parametros.Add(new SqlParameterItem("@pEsFix", SqlDbType.Bit, item.EsFix));
            parametros.Add(new SqlParameterItem("@pFechaCambio", SqlDbType.DateTime, item.FechaCambio));
            parametros.Add(new SqlParameterItem("@pID", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializarConexion(TipoBaseDatos.MainSoft);
            helper.ExecuteNonQuery("[usp_TasaCambio_Inserta]", parametros);
            item.IdTasaCambio = Convert.ToInt16(helper.GetParameterOutput("@pID"));
            return item;
        }

        public ListaTasaCambio GetListaTasaCambio(TasaCambio item)
        {

            var listado = new ListaTasaCambio();
            var parametros = new SqlParameterItem("@pResultado", SqlDbType.Int, 0);
            InicializarConexion(TipoBaseDatos.MainSoft);
            var reader = helper.ExecuteReader("[usp_TasaCambio_DameUltimaTasaCambio]", parametros);
            listado.ListaTasaCambios = new List<TasaCambio>();
            //float x;
            while (reader.Read())
            {
                listado.ListaTasaCambios.Add(new TasaCambio()
                {
                    IdTasaCambio = reader.GetInt32(reader.GetOrdinal("IdTasaCambio")),
                    IdMoneda = Convert.ToInt32(reader.GetOrdinal("IdMoneda")),
                    TasaDeCambio = reader.GetDouble(reader.GetOrdinal("TasaCambio")),
                    EsFix = reader.GetBoolean(reader.GetOrdinal("EsFix")),
                    FechaCambio = reader.GetDateTime(reader.GetOrdinal("FechaCambio"))
                });
                //var x = reader.GetDateTime(reader.GetOrdinal("FechaCambio"));
            }
            reader.Close();
            return listado;
        }

        public void Dispose()
        {

            if(helper != null)
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
