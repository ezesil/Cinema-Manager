using BaseServices.Services.Extensions;
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
    public static class PermissionTranslator
    {
        public static Dictionary<string, Permission?> permissions = new Dictionary<string, Permission?>();

        public static Permission? GetPermissionType(string code)
        {
            return permissions[code] != null ? permissions[code] : Permission.None;
        }

        static PermissionTranslator()
        {
            foreach (Permission perm in Enum.GetValues(typeof(Permission)))
            {
                permissions.Add(perm.ToTextCode(), perm);
            }
        }
    }

    public class Permiso
    {
        public Permiso()
        {

        }

        public Permiso(int id, string code)
        {
            Id = id;
            Codigo = code;
            PermissionType = PermissionTranslator.GetPermissionType(code);
        }

        public Permiso(int id, Permission permission)
        {
            Id = id;
            Codigo = permission.ToTextCode();
            PermissionType = permission;
        }

        /// <summary>
        /// Representa un codigo unico interno de permiso
        /// </summary>
        public string Codigo { get; set; }

        public Permission? PermissionType { get; }

        /// <summary>
        /// Codigo unico de permiso
        /// </summary>
        public int Id { get; set; }
    }
}
