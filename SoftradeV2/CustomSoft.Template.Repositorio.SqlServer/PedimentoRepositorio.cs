using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.ApplicationBlock.SqlServer;
using System.Data;

namespace CustomSoft.Template.Repositorio.SqlServer
{
    public class PedimentoRepositorio : IPedimentoRepositorio
    {
        private SqlHelper helper = null;
        public void InicializarConexion(TipoBaseDatos baseDatos)
        {
            helper = new SqlHelper(Util.ConexionSqlServer(baseDatos));
        }      
       
        /// <summary>
        /// Se insertará una entidad que son los datos del pedimento, estos datos pueden venir de cualquier fuente pero deben tener el modelo
        /// de la clase Pedimento creada en el servidor pedimento
        /// </summary>
        public void InsertarPedimento()
        {
            //Genera la entidad tipo archivo M para insertar en base de datos
            //var item = null;
            //TODO:Aquí parametrizas todo lo que necesitas para ejecutar el storedprocedure
            //var parametro = new SqlParameterItem("@RFC", SqlDbType.Char, 15, rfc);
            //ejecuta el storedprocedure
            //var reader = helper.ExecuteReader("spInsertarPedimentoHeader", parametro);
            //Inserta en base de datos los datos del pedimento
            //while (reader.Read())
            //{
            //    item = new Pedimento()
            //    {
            //        //Datos del archivo M
            //    };
            //}
            //reader.Close();
            //return item;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Se inserta en la tabla grupopedimento la asociacion de el pedimento
        /// con el archivo físico.
        /// </summary>
        public void InsertarAsociacionPedimentoExpediente()
        {
            //TODO:Insertar en tabla grupo pedimentos
            throw new NotImplementedException();
        }

        /// <summary>
        /// Se insertará en la base de datos el path que se insertó en el NAS   
        /// </summary>
        public void InsertarExpedienteDigital()
        {
            //TODO:se parametrizan los datos para insertarlos a la base de datos 
            //List<SqlParameterItem> parametros = new List<SqlParameterItem>();
            //parametros.Add(new SqlParameterItem("@pIdUsuario", SqlDbType.Int, item.IdTabla, ParameterDirection.Output));
            //parametros.Add(new SqlParameterItem("@pIdRol", SqlDbType.Int, item.IdRol));           
            //helper.ExecuteNonQuery("spInsertaUsuario", parametros);
            //return item;
            throw new NotImplementedException();
        }       

        /// <summary>
        /// Espera recibir una entidad tipo pedimento con las especificaciones que se necesitan
        /// para traer más de un pedimento de la base de datos
        /// </summary>
        public void ObtenerListaPedimentos()
        {
            //TODO:parametrizar el llamado al stored procedure
            //Usuario item = null;
            //SqlParameterItem parametro = new SqlParameterItem("@Login", SqlDbType.VarChar, 50, login);

            //var reader = helper.ExecuteReader("uspBuscarUsuarioPorLogin", parametro);
            //while (reader.Read())
            //{
            //    item = new Usuario()
            //    {
            //        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
            //        Correo = reader.GetString(reader.GetOrdinal("Correo")),
            //        EsActivo = reader.GetBoolean(reader.GetOrdinal("EsActivo")),
            //        Login = login
            //    };
            //}
            //reader.Close();
            //return item;
            throw new NotImplementedException();
        }

        public void ObtenerPedimento()
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            helper.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
