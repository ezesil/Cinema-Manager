using System;
using System.Collections.Generic;
using System.Text;
using BaseServices.Domain.Control_de_acceso;
using Domain;

namespace BaseServices.Domain.Login
{
    /// <summary>
    /// Representa al usuario de forma generica.
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
            this.Permisos = new List<Permiso>();
        }

        /// <summary>
        /// Constructor que toma un listado de permisos como parametro.
        /// </summary>
        /// <param name="permisos"></param>
        public Persona(List<Permiso> permisos)
        {
            this.Permisos = permisos;
        }

        /// <summary>
        /// Indica el tipo de persona.
        /// </summary>
        public enum TipoPersona
        {
            /// <summary>
            /// Representacion de Persona Fisica.
            /// </summary>
            PersonaFisica = 0,

            /// <summary>
            /// Representacion de Persona Juridica.
            /// </summary>
            PersonaJuridica = 1,
        }

        /// <summary>
        /// Tipo de persona.
        /// </summary>
        public TipoPersona TipoUsuario { get; set; }

        /// <summary>
        /// Guid de la persona.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Contraseña del usuario. Utilizado con muy poca frecuencia por razones de seguridad.
        /// </summary>
        public string Contraseña { get; set; }

        /// <summary>
        /// Direccion de correo del usuario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Estado de habilitacion del usuario.
        /// </summary>
        public string Habilitado { get; set; }

        /// <summary>
        /// Digito verificador horizontal.
        /// </summary>
        public int DVH { get; set; }

        /// <summary>
        /// Representa los permisos de formulario del usuario actual.
        /// </summary>
        public List<Permiso> Permisos { get; private set; }

        /// <summary>
        /// Representa el rol de esta persona.
        /// </summary>
        public string Rol { get; set; }

        /// <summary>
        /// Perfil de usuario.
        /// </summary>
        public Profile Profile { get; set; }
    }
}
