using Cinema.DAL.Interfaces;
using Cinema.Domain;
using Cinema.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql.Adapter
{
    /// <summary>
    /// Adaptador de tickets.
    /// </summary>
    public class TicketAdapter : IGenericAdapter<Ticket>
    {
        /// <summary>
        /// Adapta tickets a partir de un object[];
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Ticket Adapt(object[] values)
        {
            return new Ticket()
            {
                Id = values[0].ToGuid(),
                CreationTime = DateTime.Parse(values[1].ToString()),
                Row = (int)values[2],
                SeatNumber = (int)values[3],
                SessionId = values[4].ToGuid(),
                CreatorUserId = values[5].ToGuid(),
                UsuarioCreador = values[6].ToString(),
                FechaSesion = values[7].ToString(),
                NombrePelicula = values[8].ToString(),
                Idioma = values[9].ToString(),
                IdiomaSubtitulado = values[10].ToString()              
            };
        }
    }
}
