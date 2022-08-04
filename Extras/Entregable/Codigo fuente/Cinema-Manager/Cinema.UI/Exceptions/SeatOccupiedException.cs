using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.UI.Exceptions
{
    /// <summary>
    /// Excepcion que representa un error de asiento ocupado.
    /// </summary>
    public class SeatOccupiedException : Exception
    {

        public SeatOccupiedException() : base("text_seat_occupied")
        {
        }

        public SeatOccupiedException(string? message) : base(message)
        {
        }
    }
}
