using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    public class Profile
    {
        /// <summary>
        /// Identificador unico del usuario.
        /// </summary>
        public Guid GuidPersona { get; set; }

        /// <summary>
        /// Imagen de perfil del usuario.
        /// </summary>
        public Image Imagen { get; set; }

        /// <summary>
        /// Descripcion del usuario.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Nombre para mostrar del usuario.
        /// </summary>
        public string Nombre { get; set; }
    }
}
