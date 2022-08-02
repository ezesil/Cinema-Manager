using BaseServices.Services.Extensions;
using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    /// <summary>
    /// Tipos de permisos.
    /// </summary>
    public enum Permission
    {
        /// <summary>
        /// Permiso vacío
        /// </summary>
        None,

        /// <summary>
        /// Permiso para pagina inicio
        /// </summary>
        [Description("Cinema.MainPage")]
        MainPage,

        /// <summary>
        /// Permiso para pagina de creacion de tickets
        /// </summary>
        [Description("Cinema.CreateTicketPage")]
        CreateTicketPage,

        /// <summary>
        /// Permiso para pagina de gestion de peliculas
        /// </summary>
        [Description("Cinema.MoviesPage")]
        MoviesPage,

        /// <summary>
        /// Permiso para pagina de registro
        /// </summary>
        [Description("Cinema.RegisterPage")]
        RegisterPage,

        /// <summary>
        /// Permiso para pagina de gestion de salas
        /// </summary>
        [Description("Cinema.RoomsPage")]
        RoomsPage,

        /// <summary>
        /// Permiso para pagina de gestion de sesiones
        /// </summary>
        [Description("Cinema.SessionsPage")]
        SessionsPage,

        /// <summary>
        /// Permiso para pagina de gestion de tickets
        /// </summary>
        [Description("Cinema.TicketsPage")]
        TicketsPage,

        /// <summary>
        /// Permiso para pagina de administrador del sistema
        /// </summary>
        [Description("Cinema.AdminPanel")]
        AdminPanel,

        /// <summary>
        /// Permiso para pagina de backups
        /// </summary>
        [Description("Cinema.Administrator.BackupPanel")]
        BackupPanel,

        /// <summary>
        /// Permiso para pagina de gestion de digito verificador
        /// </summary>
        [Description("Cinema.Administrator.CheckerDigitPanel")]
        CheckerDigitPanel,

        /// <summary>
        /// Permiso para pagina de gestion de lenguajes
        /// </summary>
        [Description("Cinema.Administrator.LanguagesPanel")]
        LanguagesPanel,

        /// <summary>
        /// Permiso para pagina de logs 
        /// </summary>
        [Description("Cinema.Administrator.LogsPanel")]
        LogsPanel,

        /// <summary>
        /// Permiso para pagina de gestion de permisos
        /// </summary>
        [Description("Cinema.Administrator.PermissionsPanel")]
        PermissionsPanel,

        /// <summary>
        /// Permiso para pagina de digito verificador
        /// </summary>
        [Description("Cinema.Administrator.RolesPanel")]
        RolesPanel,

        /// <summary>
        /// Permiso para pagina de digito verificador
        /// </summary>
        [Description("Cinema.Administrator.UsersPanel")]
        UsersPanel
    }

    /// <summary>
    /// Traductor de nombres de permisos.
    /// </summary>
    public static class PermissionTranslator
    {
        /// <summary>
        /// Lista interna de permisos.
        /// </summary>
        public static Dictionary<string, Permission?> permissions = new Dictionary<string, Permission?>();

        /// <summary>
        /// Obtiene el tipo de permiso segun el codigo en formato string.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Permission? GetPermissionType(string code)
        {
            return permissions.TryGetValue(code, out Permission? perm) ? perm : null;
        }

        /// <summary>
        /// Indica si existe el codigo en el sistema.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool Exists(string code)
        {
            return permissions.TryGetValue(code, out Permission? perm);
        }


        static PermissionTranslator()
        {
            foreach (Permission perm in Enum.GetValues(typeof(Permission)))
            {
                permissions.Add(perm.ToTextCode(), perm);
            }
        }
    }

    /// <summary>
    /// Representa un permiso del sistema.
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Permiso()
        {

        }

        /// <summary>
        /// Constructor que toma un ID y un codigo de permiso como parametros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        public Permiso(int id, string code)
        {
            Id = id;
            Codigo = code;
            PermissionType = PermissionTranslator.GetPermissionType(code);
        }

        /// <summary>
        /// Constructor que toma un ID y un tipo de permiso como parametros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permission"></param>
        public Permiso(int id, Permission permission)
        {
            Id = id;
            Codigo = permission.ToTextCode();
            PermissionType = permission;
        }

        /// <summary>
        /// Codigo unico de permiso
        /// </summary>
        [VisibleOnGrid("text_identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Tipo de permiso usando un enum.
        /// </summary>
        [VisibleOnGrid("text_permission")]
        public Permission? PermissionType { get; }

        /// <summary>
        /// Representa un codigo unico interno de permiso
        /// </summary>
        [VisibleOnGrid("text_code")]
        public string Codigo { get; set; }

        /// <summary>
        /// Devuelve el codigo interno de permiso.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Codigo;
        }


    }
}
