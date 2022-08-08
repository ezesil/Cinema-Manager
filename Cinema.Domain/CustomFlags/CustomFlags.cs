using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.CustomFlags
{
    /// <summary>
    /// Indica si la propiedad debe mostrarse en el grid.
    /// </summary>
    public class VisibleOnGrid : Attribute
    {
        /// <summary>
        /// Nombre a mostrar de la propiedad.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public VisibleOnGrid()
        {

        }

        /// <summary>
        /// Constructor por defecto que recibe un nombre.
        /// </summary>
        public VisibleOnGrid(string name)
        {
            Name = name;
        }
    }
}
