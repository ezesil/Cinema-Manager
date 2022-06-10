using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Exceptions;
using BaseServices.Domain.Login;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    internal class SessionManager
    {
        ExceptionHandlerService _exhandler = InstanceManager.Get<ExceptionHandlerService>();
        LogService _logger = InstanceManager.Get<LogService>();

        DAL.Interfaces.ILoginRepository<Persona> repo = DAL.Factory.FactoryDAL.PersonaRepository;

        private Persona CurrentUserData;

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
            repo = BaseServices.DAL.Factory.FactoryDAL.PersonaRepository;
        }
        #endregion


        public string CurrentUserAddress
        {
            get
            {
                if (this.UserIsNull)
                    return "None";

                return this.CurrentUserData.Correo;
            }
        }


        public Guid CurrentUserGuid
        {
            get
            {
                if (this.UserIsNull)
                    return Guid.Parse("0000000000000000000000000");

                return CurrentUserData.Guid;
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
        public List<Permiso> CurrentUserPermissions
        {
            get
            {
                if (this.UserIsNull)
                    return null;

                return CurrentUserData.Permisos;
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

                return CurrentUserData.Usuario;
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
           
            var user = repo.GetPassCorreo(new Persona() { Correo = correo });

            if (user == null)
            {
                return false;
            }


            if (HashingService.Current.VerificarContraseña(contraseña, user.Contraseña))
            {
                try
                {
                    user.Correo = correo;
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
        public bool LoginAttempUser(string usuario, string contraseña)
        {
            var user = repo.GetPassUsuario(new Persona() { Usuario = usuario });
            
            if(user == null)
            {
                return false;
            }      

            else if (HashingService.Current.VerificarContraseña(contraseña, user.Contraseña))
            {
                try
                {
                    user.Usuario = usuario;
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

        



    }
}
