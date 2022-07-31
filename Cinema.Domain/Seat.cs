using Cinema.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Seat
    {
        public int Row { get; set; }

        public int SeatNumber { get; set; }

        public bool Occupied { get; set; }

        public Seat()
        {

        }

        public Seat(int row, int seatnumber, bool occupied)
        {
            Row = row;
            SeatNumber = seatnumber;
            Occupied = occupied;
        }
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

        [Description("text_row")]
        public string RowText { get; set; } = "text_row";

        [Description("text_seat")]
        public string SeatText { get; set; } = "text_seat";


        public Seat TranslateToString(Func<string, string> translator)
        {
            RowText = translator.Invoke(RowText.GetDescription());
            SeatText = translator.Invoke(SeatText.GetDescription());
            return this;
        }

        public override string ToString()
        {
            return $"[ ({Row+1}) | ({SeatNumber+1}) ]";
        }
    }
}
