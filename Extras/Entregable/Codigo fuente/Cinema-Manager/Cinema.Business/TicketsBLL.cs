using Cinema.DAL.Factory;
using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business
{
    /// <summary>
    /// Clase singleton con logica de negocio de tickets.
    /// </summary>
    public class TicketsBLL
    {
        private readonly IGenericRepository<Ticket> _repo = FactoryDAL.TicketRepository;

        #region Singleton
        private static TicketsBLL _instance = new TicketsBLL();

        /// <summary>
        /// Instancia actual de la clase.
        /// </summary>
        public static TicketsBLL Current
        {
            get
            {
                if (_instance == null)
                    _instance = new TicketsBLL();

                return _instance;
            }
        }

        private TicketsBLL()
        {

        }
        #endregion

        /// <summary>
        /// Obtiene todos los tickets entre las fechas especificadas.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<Ticket> GetAllTickets(DateTime FechaDesde, DateTime FechaHasta)
        {
            return _repo.GetAll(new { FechaDesde, FechaHasta } ).ToList();
        }

        /// <summary>
        /// Obtiene todos los tickets.
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetAllTickets()
        {
            return _repo.GetAll().ToList();
        }

        /// <summary>
        /// Genera un ticket.
        /// </summary>
        /// <param name="ticket"></param>
        public void CreateTicket(Ticket ticket)
        {
            _repo.Insert(ticket);
        }
    }
}
