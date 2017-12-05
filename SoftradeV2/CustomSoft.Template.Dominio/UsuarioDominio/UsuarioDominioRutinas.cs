using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSoft.Template.Dominio.Excepciones.Usuario;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Filtro;
using CustomSoft.Template.Repositorio.Contratos;

namespace CustomSoft.Template.Dominio.UsuarioDominio
{
    partial class UsuarioDominio 
    {
        private void ValidarDatosUsuarioNuevo(Usuario item)
        {
            Usuario UsuarioExiste = usuarioRepositorio.GetEntidad(new UsuarioFiltro()
            {
                TipoFiltro = TipoFiltroUsuario.ByLogin,
                Login = item.Login
            });
            if (UsuarioExiste != null)
            {
                throw new LoginExistenteException();
            }

            UsuarioExiste = usuarioRepositorio.GetEntidad(new UsuarioFiltro()
            {
                TipoFiltro = TipoFiltroUsuario.ByNombre,
                Nombre = item.NombreORazonSocial
                
            });
            if (UsuarioExiste != null)
            {
                throw new NombreExistenteException();
            }

            UsuarioExiste = usuarioRepositorio.GetEntidad(new UsuarioFiltro()
            {
                TipoFiltro = TipoFiltroUsuario.ByCorreo,
                CorreoElectronico = item.CorreoElectronico
            });

        }

        private void ValidarDatosUsuarioExistente(Usuario item)
        {
            Usuario usuarioExistente = usuarioRepositorio.GetEntidad(new UsuarioFiltro()
            {
                TipoFiltro = TipoFiltroUsuario.ByLogin,
                Login = item.Login
            });
            if (usuarioExistente == null)
            {
                throw new UsuarioNoExisteException();
            }

            usuarioExistente = usuarioRepositorio.GetEntidad(new UsuarioFiltro()
            {
                TipoFiltro = TipoFiltroUsuario.ByNombre,
                Nombre = item.Nombre
            });
            if (usuarioExistente != null && !usuarioExistente.Login.Equals(item.Login))
            {
                //Si el nombre del usuario corresponde a otro login
                throw new NombreExistenteException();
            }

            usuarioExistente = usuarioRepositorio.GetEntidad(new UsuarioFiltro()
            {
                TipoFiltro = TipoFiltroUsuario.ByCorreo,
                CorreoElectronico = item.CorreoElectronico
            });
            if (usuarioExistente != null && !usuarioExistente.Login.Equals(item.Login))
            {
                //Si el correo del usuario corresponde a otro login
                throw new CorreoExistenteException();
            }
        }

        private void ValidarLoginExistente(string loginUsuario)
        {
            Usuario usuarioExistente = usuarioRepositorio.GetEntidad(new UsuarioFiltro()
            {
                TipoFiltro = TipoFiltroUsuario.ByLogin,
                Login = loginUsuario
            });
            if (usuarioExistente == null)
            {
                throw new UsuarioNoExisteException();
                          
            }
        }
    }
}
