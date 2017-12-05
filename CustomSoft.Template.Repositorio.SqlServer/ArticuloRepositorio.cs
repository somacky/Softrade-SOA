using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private SqlHelper helper = null;
        private string baseDatos;
        public SqlHelper InicializaConexion(int pIdEmpresa)
        {
            baseDatos = Util.DameBDxIdEmpresa(pIdEmpresa);
            //pBaseDatos = "BASFPrueba";
            //return new SqlHelper(Util.ConexionSqlServer(TipoBaseDatos.Softrade));

            //Leo la conexion que se tiene en el WEbconfig
            var conexion = ConfigurationManager.ConnectionStrings["cnSqlServerEmpresas"].ConnectionString;

            //sustituyo el parametro por la base de datos a pegarle
            var conexionparametrizada = string.Format(conexion, baseDatos);
            helper = new SqlHelper(conexionparametrizada);
            return helper;
        }

        public ListaArticulos InsertaListaArticulos(ListaArticulos item)
        {
            for (int i = 0; i < item.ListaArticulos.Count; i++)
            {
                item.ListaArticulos[i] = InsertaArticulo(item.ListaArticulos[i], item.IdEmpresa);
            }                        
            return item;
        }

        private Articulo InsertaArticulo(Articulo item, int idEmpresa)
        {
            List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, idEmpresa));
            parametros.Add(new SqlParameterItem("@pClaveArticulo", SqlDbType.VarChar, 30, item.ClaveArticulo));
            parametros.Add(new SqlParameterItem("@pArticulo", SqlDbType.VarChar, 255, item.Articulo));
            parametros.Add(new SqlParameterItem("@pIdFraccion", SqlDbType.Int, item.IdFraccion));
            parametros.Add(new SqlParameterItem("@pIdUnidadMedidaComercial", SqlDbType.Int, item.IdUnidadMedidaComercial));
            parametros.Add(new SqlParameterItem("@pIdUnidadMedidaFactura", SqlDbType.Int, item.IdUnidadMedidaFactura));
            parametros.Add(new SqlParameterItem("@pAdValorem", SqlDbType.Int, item.AdValorem));
            parametros.Add(new SqlParameterItem("@pIVA", SqlDbType.Int, item.IVA));
            parametros.Add(new SqlParameterItem("@pIdUsuarioCreacion", SqlDbType.Int, item.IdUsuarioCreacion));
            parametros.Add(new SqlParameterItem("@pCodigo", SqlDbType.VarChar, 30, item.Codigo));
            parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, item.IdUsuario));
            parametros.Add(new SqlParameterItem("@pId", SqlDbType.Int, 0, ParameterDirection.Output));
            InicializaConexion(idEmpresa);
            helper.ExecuteNonQuery("[usp_Articulo_Inserta]", parametros);
            item.IdArticulo = Convert.ToInt16(helper.GetParameterOutput("@pId"));
            return item;
        }

        public ListaArticulos DameListaArticulosXClave(ListaArticulos item)
        {
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, item.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pClaveArticulo", SqlDbType.VarChar, 30, item.ListaArticulos[0].ClaveArticulo));
            parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.SmallInt, item.Paginas.Registros));
            parametros.Add(new SqlParameterItem("@pTotalRegistros", SqlDbType.SmallInt,0,ParameterDirection.Output));
            InicializaConexion(item.IdEmpresa);
            var reader = helper.ExecuteReader("[usp_Articulo_DameListaXClave]", parametros);
            while (reader.Read())
            {
                item.ListaArticulos.Add(new Articulo()
                {
                    IdArticulo = reader.GetInt32(reader.GetOrdinal("IdArticulo")),
                    RazonSocial = reader.GetString(reader.GetOrdinal("Empresa")),
                    ClaveArticulo = reader.GetString(reader.GetOrdinal("ClaveArticulo")),
                    Articulo = reader.GetString(reader.GetOrdinal("Articulo")),
                    Fraccion = reader.GetString(reader.GetOrdinal("Fraccion")),
                    UnidadMedidaComercial = reader.GetString(reader.GetOrdinal("UnidadMedidaComercial")),
                    UnidadMedidaFactura = reader.GetString(reader.GetOrdinal("UnidadMedidaComercial")),
                    AdValorem = reader.GetInt32(reader.GetOrdinal("AdValorem")),
                    IVA = reader.GetInt32(reader.GetOrdinal("IVA")),
                    Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                    DocumentoExpediente = new DocumentoExpedienteDigital()
                    {
                        IdExpedienteDigital = reader.GetInt32(reader.GetOrdinal("IdExpedienteDigital")),
                        IdEmpresa = item.IdEmpresa
                    }
                });
            }
            reader.Close();
            item.Paginas.TotalRegistros = reader.GetInt32(reader.GetOrdinal("@pTotalRegistros"));            
            return item;
        }

        public ListaArticulos DameListaArticulosXEmpresa(ListaArticulos item)
        {

            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdEmpresa", SqlDbType.Int, 4000, item.IdEmpresa));
            parametros.Add(new SqlParameterItem("@pPagina", SqlDbType.SmallInt, item.Paginas.Pagina));
            parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.SmallInt, item.Paginas.Registros));            
            parametros.Add(new SqlParameterItem("@pTotalRegistros", SqlDbType.SmallInt, 0, ParameterDirection.Output));
            InicializaConexion(item.IdEmpresa);
            var reader = helper.ExecuteReader("[usp_Articulo_DameListaXEmpresa]", parametros);
            while (reader.Read())
            {                
                item.ListaArticulos.Add(new Articulo()
                {
                    IdArticulo = reader.GetInt32(reader.GetOrdinal("IdArticulo")),
                    RazonSocial = reader.GetString(reader.GetOrdinal("Empresa")),
                    ClaveArticulo = reader.GetString(reader.GetOrdinal("ClaveArticulo")),
                    Articulo = reader.GetString(reader.GetOrdinal("Articulo")),
                    Fraccion = reader.GetString(reader.GetOrdinal("Fraccion")),
                    UnidadMedidaComercial = reader.GetString(reader.GetOrdinal("UnidadMedidaComercial")),
                    UnidadMedidaFactura = reader.GetString(reader.GetOrdinal("UnidadMedidaComercial")),
                    AdValorem = reader.GetInt32(reader.GetOrdinal("AdValorem")),
                    IVA = reader.GetInt32(reader.GetOrdinal("IVA")),
                    Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                    DocumentoExpediente = new DocumentoExpedienteDigital()
                    {
                        IdExpedienteDigital = reader.GetInt32(reader.GetOrdinal("IdExpedienteDigital")),
                        IdEmpresa = item.IdEmpresa
                    }
                });
            }
            reader.Close();
            item.Paginas.TotalRegistros = Convert.ToInt16(helper.GetParameterOutput("@pTotalRegistros"));
            //request..ListaDocumentos = listaExpedienteDigital;            
            return item;
        }

        public ListaArticulos DameListaArticulosXFraccion(ListaArticulos item)
        {
            var parametros = new List<SqlParameterItem>();
            parametros.Add(new SqlParameterItem("@pIdFraccion", SqlDbType.Int, 4000, item.IdFraccion));
            parametros.Add(new SqlParameterItem("@pPagina", SqlDbType.SmallInt, item.Paginas.Pagina));
            parametros.Add(new SqlParameterItem("@pRegistros", SqlDbType.SmallInt, item.Paginas.Registros));
            parametros.Add(new SqlParameterItem("@pTotalRegistros", SqlDbType.SmallInt, 0, ParameterDirection.Output));
            InicializaConexion(item.IdEmpresa);
            var reader = helper.ExecuteReader("[usp_Articulo_DameListaXEmpresa]", parametros);
            while (reader.Read())
            {
                item.ListaArticulos.Add(new Articulo()
                {
                    IdArticulo = reader.GetInt32(reader.GetOrdinal("IdArticulo")),
                    RazonSocial = reader.GetString(reader.GetOrdinal("Empresa")),
                    ClaveArticulo = reader.GetString(reader.GetOrdinal("ClaveArticulo")),
                    Articulo = reader.GetString(reader.GetOrdinal("Articulo")),
                    Fraccion = reader.GetString(reader.GetOrdinal("Fraccion")),
                    UnidadMedidaComercial = reader.GetString(reader.GetOrdinal("UnidadMedidaComercial")),
                    UnidadMedidaFactura = reader.GetString(reader.GetOrdinal("UnidadMedidaComercial")),
                    AdValorem = reader.GetInt32(reader.GetOrdinal("AdValorem")),
                    IVA = reader.GetInt32(reader.GetOrdinal("IVA")),
                    Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                    DocumentoExpediente = new DocumentoExpedienteDigital()
                    {
                        IdExpedienteDigital = reader.GetInt32(reader.GetOrdinal("IdExpedienteDigital")),
                        IdEmpresa = item.IdEmpresa
                    }
                });
            }
            reader.Close();
            item.Paginas.TotalRegistros = reader.GetInt32(reader.GetOrdinal("@pTotalRegistros"));
            //request..ListaDocumentos = listaExpedienteDigital;
            return item;
        }

        public void Dispose()
        {
            if (helper != null)
                helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
