using Cinema.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    /// <summary>
    /// Clase que representa a un asiento.
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Fila.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Columna o numero de asiento.
        /// </summary>
        public int SeatNumber { get; set; }

        /// <summary>
        /// Indica si el asiento está ocupadoi.
        /// </summary>
        public bool Occupied { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Seat()
        {

        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="seatnumber"></param>
        /// <param name="occupied"></param>
        public Seat(int row, int seatnumber, bool occupied)
        {
            Row = row;
            SeatNumber = seatnumber;
            Occupied = occupied;
        }

        /// <summary>
        /// Intenta parsear el texto de un asiento a su objeto correspondiente.
        /// </summary>
        /// <param name="seatText"></param>
        /// <param name="seat"></param>
        /// <returns></returns>
        public static bool TryParse(string seatText, out Seat seat)
        {
            try
            {
                var items = seatText.Split(",");

                if (items.Length != 2)
                    throw new Exception("No se pudo convertir la entrada en un asiento.");

                seat = new Seat() { Row = int.Parse(items[0]), SeatNumber = int.Parse(items[1]) };

                return true;
            }
            catch (Exception)
            {
                seat = null;
                return false;
            }
        }

        /// <summary>
        /// Texto de fila.
        /// </summary>
        [Description("text_row")]
        public string RowText { get; set; } = "text_row";

        /// <summary>
        /// Texto de columna.
        /// </summary>

        [Description("text_seat")]
        public string SeatText { get; set; } = "text_seat";

        /// <summary>
        /// Traduce los codigos que el asiento requiera.
        /// </summary>
        /// <param name="translator"></param>
        /// <returns></returns>
        public Seat TranslateToString(Func<string, string> translator)
        {
            RowText = translator.Invoke(RowText.GetDescription());
            SeatText = translator.Invoke(SeatText.GetDescription());
            return this;
        }

        /// <summary>
        /// Devuelve una representacion en texto del asiento.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[ ({Row+1}) | ({SeatNumber+1}) ]";
        }
    }
}
