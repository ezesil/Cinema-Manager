﻿using BaseServices.BLL;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaseServices.Services
{
    /// <summary>
    /// Provee servicios de inicio de sesión.
    /// </summary>
    public class SessionService
    {
        private readonly static SessionService _instance = new SessionService();

        public delegate void OnLoginEventHandler();
        public event OnLoginEventHandler OnSuccessfulLogin;

        public delegate void OnLogoutEventHandler();
        public event OnLogoutEventHandler OnSuccessfulLogout;

        

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static SessionService Current
        {
            get
            {
                return _instance;
            }
        }

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

        ///// <summary>
        ///// Efectúa un intento de inicio de sesión.
        ///// </summary>
        ///// <param name="identificador">Nombre de usuario o contraseña.</param>
        ///// <param name="contraseña">Contraseña en texto plano.</param>
        ///// <returns></returns>
        //public bool LoginAttemp(string identificador, string contraseña)
        //{
        //    if (identificador.Contains("@") && identificador.Contains(".com"))
        //        return SessionBLL.Current.LoginAttempCorreo(identificador, contraseña);
        //    else
        //        return SessionBLL.Current.AttempLogin(identificador, contraseña);
        //}

        public void Logout()
        {
            SessionBLL.Current.Logout();
        }

        /// <summary>
        /// Comprueba si el usuario posee el permiso especificado.
        /// </summary>
        /// <param name="CodigoPermiso"></param>
        /// <returns>Retorna un booleano indicando si el usuario posee o no los permisos. Retorna siempre false si no hay usuario logeado en el sistema.</returns>
        public bool UserHasPermission(Permission CodigoPermiso)
        {
            Permiso permiso = new Permiso(PermissionExtractor.GetDescription(CodigoPermiso));

            if (SessionService.Current.UserIsNull)
                return false;

            return PermissionBLL.Current.HasRight(permiso);
        }

        /// <summary>
        /// Comprueba si el usuario posee todos los permisos especificados.
        /// </summary>
        /// <param name="CodigoPermiso"></param>
        /// <returns>Retorna un valor booleando indicando si posee los permisos necesarios.</returns>
        //public bool HasPermission(Permission[] CodigoPermiso)
        //{
        //    List<Permiso> permisos = new List<Permiso>();
        //    foreach (var item in CodigoPermiso)
        //    {
        //        permisos.Add(new Permiso(PermissionExtractor.GetDescription(item)));
        //    }


        //    if (SessionService.Current.UserIsNull)
        //        return false;

        //    return PermissionManager.Current.HasRight(permisos);
        //}

    }
}
