using BaseServices.BLL;
using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaseServices.Services
{
    /// <summary>
    /// Provee servicios de inicio de sesión.
    /// </summary>
    public class SessionServiceProvider
    {
        private readonly static SessionServiceProvider _instance = new SessionServiceProvider();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static SessionServiceProvider Current
        {
            get
            {
                return _instance;
            }
        }

        private SessionServiceProvider()
        {

        }

        /// <summary>
        /// Indica si el usuario actual es nulo.
        /// </summary>
        public bool UserIsNull
        {
            get
            {
                return SessionManager.Current.UserIsNull;

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
                return SessionManager.Current.CurrentUserName;
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
                return SessionManager.Current.CurrentUserGuid;
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

                return SessionManager.Current.CurrentUserAddress;
            }
        }

        /// <summary>
        /// Efectúa un intento de inicio de sesión.
        /// </summary>
        /// <param name="identificador">Nombre de usuario o contraseña.</param>
        /// <param name="contraseña">Contraseña en texto plano.</param>
        /// <returns></returns>
        public bool LoginAttemp(string identificador, string contraseña)
        {
            if (identificador.Contains("@") && identificador.Contains(".com"))
                return SessionManager.Current.LoginAttempCorreo(identificador, contraseña);
            else
                return SessionManager.Current.LoginAttempUser(identificador, contraseña);
        }
    }
}
