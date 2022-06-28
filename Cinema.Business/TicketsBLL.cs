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


        public List<Ticket> GetAllTickets()
        {
            return _repo.GetAll().ToList();
        }




    }
}
