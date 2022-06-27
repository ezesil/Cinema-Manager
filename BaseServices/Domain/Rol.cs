using BaseServices.BLL;
using System;
using System.Collections.Generic;
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
        /// <param name="rights">Lista de permisos de tipo Permiso.PermissionType.</param>
        public Rol(int id, string nombre, List<Permiso> rights)
        {
            IdRol = id;
            NombreRol = nombre;
            PermisoList = rights;
        }



        /// <summary>
        /// Constructor que recibe un entero, un string y un listado de permisos como parametro.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <param name="nombre">Nombre del rol.</param>
        /// <param name="rights">Lista de permisos de tipo Permiso.PermissionType.</param>
        public Rol(int id, string nombre, string rights)
        {
            IdRol = id;
            NombreRol = nombre;
            PermisosString = rights;
        }



        /// <summary>
        /// Atributo interno para los permisos en formato string.
        /// </summary>
        private string _permisos = "";

        /// <summary>
        /// Lista interna de permisos en formato de objetos Permiso.
        /// </summary>
        private List<Permiso> _permissions = new List<Permiso>();


        /// <summary>
        /// Listado de permisos pertenecientes a un rol.
        /// </summary>
        public List<Permiso> PermisoList
        {
            get
            {
                return _permissions;
            }
            private set
            {
                _permissions = value;


                for (int i = 0; i < value.Count - 2; i++)
                {
                    _permisos += value[i].Codigo + ";";
                }

                _permisos += value[value.Count - 1];

            }
        }

        /// <summary>
        /// Permisos pertenecientes al rol en formato string.
        /// </summary>
        public string PermisosString
        {
            get
            {
                return _permisos;
            }
            private set
            {
                _permisos = value;
                foreach (string item in value.Split(';'))
                {
                    _permissions.Add(new Permiso(item));
                }
            }
        }

        /// <summary>
        /// Nombre perteneciente al rol.
        /// </summary>
        public string NombreRol { get; private set; }


        /// <summary>
        /// ID perteneciente al Rol.
        /// </summary>
        public int IdRol { get; private set; }



    }
}
