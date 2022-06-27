using BaseServices.Domain;
using BaseServices.Domain.Control_de_acceso;
using BaseServices.Services;
using System;
using System.Collections.Generic;

namespace BaseServices.BLL
{
    internal class SessionManager
    {
        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        LogService _logger = ServiceContainer.Get<LogService>();

        DAL.Interfaces.IUserRepository<User> repo = DAL.Factory.FactoryDAL.UserRepository;

        private User CurrentUserData;

        #region single

        private readonly static SessionManager _instance = new SessionManager();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static SessionManager Current
        {
            get
            {
                return _instance;
            }
        }

        private SessionManager()
        {
            repo = BaseServices.DAL.Factory.FactoryDAL.UserRepository;
        }
        #endregion


        public string CurrentUserAddress
        {
            get
            {
                if (this.UserIsNull)
                    return "None";

                return this.CurrentUserData.Email;
            }
        }


        public Guid CurrentUserGuid
        {
            get
            {
                if (this.UserIsNull)
                    return Guid.Parse("0000000000000000000000000");

                return CurrentUserData.Id;
            }
        }


        /// <summary>
        /// Indica si el usuario es nulo.
        /// </summary>
        public bool UserIsNull
        {
            get
            {
                if (CurrentUserData == null)
                    return true;

                return false;
            }
        }


        /// <summary>
        /// Obtiene un listado de los permisos del usuario actual. Retorna null si no hay usuario logeado en el sistema.
        /// </summary>
        //public List<Permiso> CurrentUserPermissions
        //{
        //    get
        //    {
        //        if (this.UserIsNull)
        //            return null;

        //        return CurrentUserData.;
        //    }
        //}

        /// <summary>
        /// Obtiene el nombre de usuario del usuario actual. Retorna null si no hay usuario logeado en el sistema.
        /// </summary>
        public string CurrentUserName
        {
            get
            {
                if (this.UserIsNull)
                    return null;

                return CurrentUserData.Username;
            }
        }



        /// <summary>
        /// Intentar un inicio de sesion utilizando la direccion de correo del usuario.
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public bool LoginAttempCorreo(string correo, string contraseña)
        {
           
            var user = repo.GetPassCorreo(new User() { Email = correo });

            if (user == null)
            {
                return false;
            }


            if (HashingService.Current.VerificarContraseña(contraseña, user.HashedPassword))
            {
                try
                {
                    user.Email = correo;
                    CurrentUserData = repo.SelectUserDataByEmailAddress(user);
                    return true;
                }

                catch (Exception ex)
                {
                    _exhandler.Handle(ex);
                    return false;
                }

            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Intentar un inicio de sesion utilizando el nombre de usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public bool AttempLogin(string usuario, string contraseña)
        {
            var user = repo.GetPassUsuario(new User() { Username = usuario });
            
            if(user == null)
            {
                return false;
            }      

            else if (HashingService.Current.VerificarContraseña(contraseña, user.HashedPassword))
            {
                try
                {
                    user.Username = usuario;
                    CurrentUserData = repo.SelectUserDataByUsername(user);
                    
                    return true;
                }

                catch(Exception ex)
                {
                    _exhandler.Handle(ex);
                    return false;
                }
                
            }

            else
            {
                return false;
            }
        }

        public void Logout()
        {
            CurrentUserData = null;
        }

        



    }
}
