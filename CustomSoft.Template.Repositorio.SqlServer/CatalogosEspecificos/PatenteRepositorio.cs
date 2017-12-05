using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using MCS.ApplicationBlock.SqlServer;

namespace CustomSoft.Template.Repositorio.SqlServer.CatalogosEspecificos
{
    public class PatenteRepositorio : IDisposable
    {
        private SqlHelper Helper = null;

        public PatenteRepositorio()
        {
            Helper = new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));
        }

        public List<CatalogoEspecifico> DameListaPatente()
        {
            var items = new List<CatalogoEspecifico>();
            var parametro = new SqlParameterItem("@pResultado", SqlDbType.Bit, ParameterDirection.Output);
            var reader = Helper.ExecuteReader("usp_Patente_DameLista", parametro);
            while (reader.Read())
            {
                items.Add(new CatalogoEspecifico()
                {
                    Nombre = reader.GetString(reader.GetOrdinal("NombreAgente")),
                    Id = reader.GetInt32(reader.GetOrdinal("IdPatenteVW")),
                    Alias = reader.GetString(reader.GetOrdinal("NumeroPatente"))
                    
                });
            }
            reader.Close();
            return items;
        }

        public void Dispose()
        {
            Helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

