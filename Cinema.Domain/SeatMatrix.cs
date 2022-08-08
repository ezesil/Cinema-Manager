using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Extensions;

namespace Cinema.Domain
{
    /// <summary>
    /// Representa una matriz de asientos.
    /// </summary>
    public class SeatMatrix
    {
        /// <summary>
        /// Lista de objetos de la matriz.
        /// </summary>
        public Seat[][] Items { get; set; }

        /// <summary>
        /// Cantidad de filas
        /// </summary>
        public int RowsCount { get => Items.Length; }

        /// <summary>
        /// Cantidad de columnas.
        /// </summary>
        public int ColumnsCount { get => Items[0].Length; }

        /// <summary>
        /// Indica si contiene una lista interna de colecciones.
        /// </summary>
        public bool ContainsListCollection => false;

        /// <summary>
        /// Constructor por defecto de la matriz.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="translator"></param>
        public SeatMatrix(int rows, int columns, Func<string, string> translator = null)
        {
            Items = new Seat[rows][];
            int i = 0;
            int j = 0;
            for (i = 0; i < rows; i++)
            {
                Items[i] = new Seat[columns];
                j = 0;
                for (j = 0; j < rows; j++)
                {
                    if(translator == null)
                        Items[i][j] = new Seat(i, j, false);
                    else
                        Items[i][j] = new Seat(i, j, false).TranslateToString(translator);
                }
            }
        }

        /// <summary>
        /// Limpia los asientos ocupados.
        /// </summary>
        public void ClearOccupied()
        {
            for (var i = 0; i < Items.Length; i++)
            {
                for (var j = 0; i < Items.Length; i++)
                {
                    Items[i][j].Occupied = false;
                }
            }
        }

        /// <summary>
        /// Convierte la matriz actual en DataTable.
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
           
            foreach (var seat in Items[0])
                dt.Columns.Add();

            foreach(var seatsrow in Items)
            {
                dt.Rows.Add(seatsrow);
            }

            return dt;
        }

        //public string[] GetRowTuple(int row)
        //{
        //    try
        //    {
        //        var items = Items[row].ToArray();
        //        if (!items.Any())
        //            return null;

        //        return items.Select(x => x);
        //    }
        //    catch(Exception)
        //    {
        //        return null;
        //    }

        //}
    }
}
