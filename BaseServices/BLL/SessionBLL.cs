using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseServices.BLL
{
    internal class SessionBLL
    {
        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Services.Logger _logger = ServiceContainer.Get<Services.Logger>();

        IUserRepository<User> repo = DAL.Factory.FactoryDAL.UserRepository;

        private User CurrentUserData;

        #region single

        private readonly static SessionBLL _instance = new SessionBLL();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static SessionBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private SessionBLL()
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
                    return Guid.Empty;

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
        public bool LoginAttempByEmail(string correo, string contraseña)
        {

            try
            {
                var user = repo.SelectUserDataByEmailAddressAndPassword(correo, HashingService.Current.HashPassword(contraseña));

                if (user == null)
                {
                    return false;
                }

                user.Email = correo;
                CurrentUserData = user;
                return true;
            }

            catch (Exception ex)
            {
                _exhandler.Handle(ex);
                return false;
            }
        }

        /// <summary>
        /// Intentar un inicio de sesion utilizando el nombre de usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public bool AttempLoginByUsername(string usuario, string contraseña)
        {
            try
            {
                var user = repo.SelectUserDataByUsernameAndPassword(usuario, HashingService.Current.HashPassword(contraseña));

                if (user == null)
                {
                    return false;
                }

                user.Email = user.Email;
                CurrentUserData = user;
                return true;
            }

            catch (Exception ex)
            {
                _exhandler.Handle(ex);
                return false;
            }
        }

        /// <summary>
        /// Registra un usuario en el sistema.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool RegisterUser(User user)
        {
            try
            {
                return repo.Insert(user) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                _exhandler.Handle(ex);
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return repo.SelectAll().ToList();
        }

        public User GetUser(Guid Id)
        {
            return repo.Select(Id);
        }

        public void Logout()
        {
            CurrentUserData = null;
        }





    }
}
