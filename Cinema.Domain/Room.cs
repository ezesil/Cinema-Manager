using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    /// <summary>
    /// Clase que representa a una sala de cine.
    /// </summary>
    public class Room : Entity
    {
        /// <summary>
        /// ID de la sala.
        /// </summary>
        [VisibleOnGrid("text_id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Codigo fisico que sirve para identificar las salas a simple vista.
        /// </summary>
        [VisibleOnGrid("text_identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Indica si la sala tiene pantalla gigante.
        /// </summary>
        [VisibleOnGrid("text_hasbigscreen")]
        public bool HasBigScreen { get; set; } = false;

        /// <summary>
        /// Indica si la sala soporta 3D.
        /// </summary>
        [VisibleOnGrid("text_has3d")]
        public bool Has3D { get; set; } = false;

        /// <summary>
        /// Indica si la sala está activa para ser utilizada.
        /// </summary>
        [VisibleOnGrid("text_isactive")]
        public bool IsActive { get; set; } = false;

        /// <summary>
        /// Devuelve el codigo fisico identificador de la sala.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Identifier;
        }
    }
}
