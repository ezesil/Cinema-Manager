using BaseServices.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    /// <summary>
    /// Representa el rol de una persona en el sistema.
    /// </summary>
    public class Rol
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Rol()
        {

        }

        /// <summary>
        /// Constructor que recibe un entero, un string y un listado de permisos como parametro.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <param name="nombre">Nombre del rol.</param>
        /// <param name="permisos">Lista de permisos de tipo Permiso.PermissionType.</param>
        public Rol(int id, string nombre, List<Permiso> permisos)
        {
            Id = id;
            Nombre = nombre;
            Permisos = permisos;
        }

        /// <summary>
        /// ID perteneciente al Rol.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre perteneciente al rol.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Listado de permisos pertenecientes a un rol.
        /// </summary>
        public List<Permiso> Permisos { get; set; }
    }

    /// <summary>
    /// Representa un permiso utilizado para control de acceso a formularios.
    /// </summary>
    /// <summary>
    /// Tipos de permisos.
    /// </summary>
    public enum RoleType
    {

        None,

        /// <summary>
        /// Rol de administrador del sistema.
        /// </summary>
        [Description("Cinema.Administrator")]
        Administrator,

        /// <summary>
        /// Rol del gerente del sistema.
        /// </summary>
        [Description("Cinema.Manager")]
        Manager,

        /// <summary>
        /// Rol del recepcionista del sistema.
        /// </summary>
        [Description("Cinema.Receptionist")]
        Receptionist,

        /// <summary>
        /// Rol del testing del sistema.
        /// </summary>
        [Description("Cinema.Test")]
        Test
    }
}
