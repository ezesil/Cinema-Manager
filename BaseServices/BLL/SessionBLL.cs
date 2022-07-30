using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseServices.BLL
{
    internal class SessionBLL
    {
        ExceptionHandler _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();

        Services.Logger _logger = ServiceContainer.Instance.GetService<Services.Logger>();

        IGenericRepository<User, Guid> repo = DAL.Factory.FactoryDAL.UserRepository as IGenericRepository<User, Guid>;

        IGenericRepository<Rol, int> _rolrepo = DAL.Factory.FactoryDAL.RolRepository;

        IGenericRepository<Permiso, int> _permisorepo = DAL.Factory.FactoryDAL.PermisoRepository;

        List<Rol> userRoles = new List<Rol>();

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

        // <summary>
        // Obtiene un listado de los permisos del usuario actual.Retorna null si no hay usuario logeado en el sistema.
        // </summary>
        public List<Rol> CurrentUserRoles
        {
            get
            {
                if (this.UserIsNull)
                    return null;

                return userRoles;
            }
        }

        // <summary>
        // Obtiene un listado de los permisos del usuario actual.Retorna null si no hay usuario logeado en el sistema.
        // </summary>
        public List<Permiso> CurrentUserPermissions
        {
            get
            {
                if (this.UserIsNull)
                    return null;
                var perms = new List<Permiso>();
                userRoles.ForEach(role => perms.AddRange(role.Permisos));
                return perms;
            }
        }

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
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginByEmail(string correo, string password)
        {

            try
            {
                var user = (repo as IUserRepository).SelectUserDataByEmailAddress(correo);

                if (user == null)
                {
                    return false;
                }

                if (HashingService.Current.VerificarContraseña(password, user.Password))
                {
                    SetupRoles(user);
                    user.Email = user.Email;
                    CurrentUserData = user;
                    return true;
                }
                else
                {
                    return false;
                }
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
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginByUsername(string usuario, string password)
        {
            try
            {
                var user = (repo as IUserRepository).SelectUserDataByUsername(usuario);

                if (user == null)
                {
                    return false;
                }

                if (HashingService.Current.VerificarContraseña(password, user.Password))
                {
                    SetupRoles(user);
                    user.Email = user.Email;
                    CurrentUserData = user;
                    return true;
                }
                else
                {
                    return false;
                }
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
                Console.WriteLine(ex);
                _exhandler.Handle(ex);
                return false;
            }
        }

        private void SetupRoles(User user)
        {
            userRoles = _rolrepo.GetAll(new { UserId = user.Id }).ToList();
            userRoles.ForEach(rol => rol.Permisos = _permisorepo.GetAll(new { IdRol = rol.Id }).ToList());
        }

        public List<User> GetAllUsers()
        {
            return repo.GetAll().ToList();
        }

        public User GetUser(Guid Id)
        {
            return repo.GetOne(Id);
        }

        public bool Logout()
        {
            CurrentUserData = null;
            return true;
        }
    }
}
