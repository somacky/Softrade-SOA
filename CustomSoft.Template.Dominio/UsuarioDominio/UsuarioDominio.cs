﻿using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CustomSoft.Template.Dominio.Contratos;
using CustomSoft.Template.Dominio.Excepciones.Usuario;
using CustomSoft.Template.Modelo.Compartido;
using CustomSoft.Template.Modelo.Dominio.Entidades;
using CustomSoft.Template.Modelo.Dominio.Filtro;
using CustomSoft.Template.Repositorio.Contratos;
using MCS.Factory;

namespace CustomSoft.Template.Dominio.UsuarioDominio
{
    public partial class UsuarioDominio : IUsuarioDominio
    {
        private const string SecurityString = "abcdefghijklmnopqrs";
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioDominio()
        {
            usuarioRepositorio = FactoryEngine<IUsuarioRepositorio>.GetInstance("IUsuarioRepositorioConfig");
        }

        #region Metodos Publicos

        public Usuario InsertaUsuario(Usuario item, int idUsuarioCreacion)
        {
            //valida los datos del usuario para hacer 
            
            //valido los datos depentiendo en base a sus filtros
            ValidarDatosUsuarioNuevo(item);
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                item.Pass = "";//CriptografiaDominio.EncodePWD(item.Pass, SecurityString);
                item = usuarioRepositorio.InsertaUsuario(item);
                item  = usuarioRepositorio.InsertaUsuarioXEmpresa(item, idUsuarioCreacion);
                item = CrearUrlCambioContraseña(item);
                //crear url temporal para cambio de contraseña
                //UrlTemporal/"IdEmpresa"/"id"/"OtroIDDeSerNecesario"/                   
                //transaction.Complete();

            }
            return item;
        }


        private Usuario CrearUrlCambioContraseña(Usuario item)
        {
            var urlTemporal = FactoryEngine<IUrlTemporalDominio>.GetInstance("IUrlTemporalDominioConfig");
            var url = new UrlTemporal()
            {
                Correo = item.CorreoElectronico,
                FechaExpiracion = DateTime.Now.AddDays(1),
                GuidUrl = Convert.ToString(Guid.NewGuid()),
                TipoUrlTemporal = TipoUrlTemporal.CambioPassword,
                IdEmpresa = item.IdEmpresa[0],
                IdUrl = item.Id,                
            };
            url = urlTemporal.GenerarUrlTemporal(url);
            if (url.IdUrl == 0)
                throw new NoSePudoCrearUsuario();
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Usuario Actualizar(Usuario item)
        {
            ValidarDatosUsuarioExistente(item);

            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                usuarioRepositorio.Actualizar(item);
                //TODO: De existir datos adicionales del usuario, debe procesarse en este bloque de transacción
                transaction.Complete();
            }

            return item;
        }

        public Usuario GetEntidad(UsuarioFiltro filtro)
        {
            if (!String.IsNullOrEmpty(filtro.Login))
            {
                ValidarLoginExistente(filtro.Login);
            }

            var usuario = usuarioRepositorio.GetEntidad(filtro);
            if(usuario.Pass == "")
                throw new UsuarioOPasswordIncorrectosException();
            if (usuario.Pass != CriptografiaDominio.EncodePWD(filtro.Pass, SecurityString))
                throw new UsuarioOPasswordIncorrectosException();            
            return usuario;
        }

        public Usuario UpdatePassword(UsuarioFiltro item)
        {
            ValidarDatosUsuarioExistente(item);
            Usuario usuario = new Usuario();
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                item.TipoFiltro = TipoFiltroUsuario.ById;
                usuario = usuarioRepositorio.GetEntidad(item);
                usuario.Pass = CriptografiaDominio.EncodePWD(usuario.Pass, SecurityString);
                if (!usuarioRepositorio.Actualizar(item))
                    throw new NoSePudoCambiarLaContraseña();
                usuario.Pass = "";
                transaction.Complete();                
            }
            return usuario;
        }
        #endregion
        ////agregado por resharper para isuauriodominio
        //public Modelo.Dominio.Entidades.Usuario InsertaUsuario(Modelo.Dominio.Entidades.Usuario item)
        //{
        //    throw new NotImplementedException();
        //}
        //
        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        public void Dispose()
        {
            usuarioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}