using BaseServices.BLL;
using BaseServices.Domain;
using BaseServices.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaseServices.Services
{
    /// <summary>
    /// Provee servicios de sesión de usuario.
    /// </summary>
    public class SessionService
    {
        public delegate void OnLoginEventHandler();
        public event OnLoginEventHandler OnSuccessfulLogin;

        public delegate void OnLogoutEventHandler();
        public event OnLogoutEventHandler OnSuccessfulLogout;

        private IntegrityService _checkerDigitService => ServiceContainer.Get<IntegrityService>();

        private bool initialized = false;

        public SessionService()
        {

        }

        /// <summary>
        /// Indica si el usuario actual es nulo.
        /// </summary>
        public bool UserIsNull
        {
            get
            {
                return SessionBLL.Current.UserIsNull;
            }
        }

        /// <summary>
        /// Devuelve el nombre de usuario actual.
        /// </summary>
        public string CurrentUser
        {
            get
            {
                if (UserIsNull)
                    return "None";
                return SessionBLL.Current.CurrentUserName;
            }
        }

        /// <summary>
        /// Devuelve el Guid del usuario actual.
        /// </summary>
        public Guid CurrentUserGuid
        {
            get
            {
                if (UserIsNull)
                    return Guid.Parse("00000000-0000-0000-0000-000000000000");
                return SessionBLL.Current.CurrentUserGuid;
            }
        }

        /// <summary>
        /// Obtiene el correo electronico del usuario actual.
        /// </summary>
        public string CurrentUserCorreo
        {
            get
            {
                if (UserIsNull)
                    return "None";

                return SessionBLL.Current.CurrentUserAddress;
            }
        }

        /// <summary>
        /// Efectúa un intento de inicio de sesión.
        /// </summary>
        /// <param name="identifier">Nombre de usuario o contraseña.</param>
        /// <param name="pass">Contraseña en texto plano.</param>
        /// <returns></returns>
        public bool TryLogin(string identifier, string pass)
        {
            if (identifier.Contains("@") && identifier.Contains(".com"))
            {
                if (SessionBLL.Current.LoginByEmail(identifier, pass))
                {
                    try
                    {
                        OnSuccessfulLogin.Invoke();
                    }
                    catch (Exception ex)
                    {

                    }
                    return true;
                }
                else
                    return false;
            }
            else
            {
                if (SessionBLL.Current.LoginByUsername(identifier, pass))
                {
                    try
                    {
                        OnSuccessfulLogin.Invoke();
                    }
                    catch (Exception ex)
                    {

                    }
                    return true;
                }
                else
                    return false;
            }
        }

        public bool RegisterUser(User user)
        {
            user.DVH = _checkerDigitService.CalcularDVH(user);
            user.Password = HashingService.Current.HashPassword(user.Password);
            return SessionBLL.Current.RegisterUser(user);
        }

        public void Logout()
        {
            SessionBLL.Current.Logout();
            OnSuccessfulLogout.Invoke();
        }

        /// <summary>
        /// Comprueba si el usuario posee el permiso especificado.
        /// </summary>
        /// <param name="CodigoPermiso"></param>
        /// <returns>Retorna un booleano indicando si el usuario posee o no los permisos. Retorna siempre false si no hay usuario logeado en el sistema.</returns>
        public bool UserHasPermission(Permission CodigoPermiso)
        {
            if (UserIsNull)
                return false;

            return PermissionBLL.Current.HasRight(CodigoPermiso);
        }       
    }
}
