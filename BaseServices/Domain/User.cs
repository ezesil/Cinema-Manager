using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    /// <summary>
    /// Clase que representa a un usuario.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// Constructor con parametros necesarios para instanciar un usuario.
        /// </summary>
        /// <param name="_Id"></param>
        /// <param name="_Username"></param>
        /// <param name="_Password"></param>
        /// <param name="_Email"></param>
        /// <param name="_FullName"></param>
        /// <param name="_DNI"></param>
        public User(Guid _Id, string _Username, string _Password, string _Email, string _FullName, string _DNI)
        {
            Id = _Id;
            Username = _Username;
            Password = _Password;
            Email = _Email;
            Enabled = true;
            FullName = _FullName;
            DNI = _DNI;
        }

        /// <summary>
        /// ID del usuario.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        [VisibleOnGrid("")]
        public string Username { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Email del usuario.
        /// </summary>
        [VisibleOnGrid("")]
        public string Email { get; set; }

        /// <summary>
        /// Indica si el usuario está activo.
        /// </summary>
        [VisibleOnGrid("")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Digito verificador de integridad. Usado para el chequeo de integridad de datos del sistema.
        /// </summary>
        public decimal DVH { get; set; }

        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        [VisibleOnGrid("")]
        public string FullName { get; set; }

        /// <summary>
        /// Numero de documento del usuario.
        /// </summary>
        [VisibleOnGrid("")]
        public string DNI { get; set; }

    }
}
