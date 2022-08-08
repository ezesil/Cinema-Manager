using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationSettings = BaseServices.Domain.ApplicationSettings;


namespace Cinema.DAL.Factory
{
    /// <summary>
    /// Clase de tipo Factory para los servicios de base.
    /// </summary>
    public static class FactoryDAL
    {

        /// <summary>
        /// String de repositorio. Indica donde se ubican los repositorios.
        /// </summary>
        readonly static string repository;

        /// <summary>
        /// Instancia de repositorio de clientes.
        /// </summary>
        public static IGenericRepository<Movie> MovieRepository { get; private set; }

        /// <summary>
        /// Instancia de repositorio de anunciantes.
        /// </summary>
        public static IGenericRepository<Room> RoomRepository { get; private set; }

        /// <summary>
        /// Instancia de repositorio de administradores de publicidad.
        /// </summary>
        public static IGenericRepository<Session> SessionRepository { get; private set; }

        /// <summary>
        /// Instancia de repositorio de espacios publicitarios.
        /// </summary>
        public static IGenericRepository<Ticket> TicketRepository { get; private set; }



        static FactoryDAL()
        {
            repository = ApplicationSettings.Instance.Repository;

            MovieRepository = CreateInstance<Movie>("MoviesRepository");
            RoomRepository = CreateInstance<Room>("RoomsRepository");
            SessionRepository = CreateInstance<Session>("SessionRepository");
            TicketRepository = CreateInstance<Ticket>("TicketsRepository");
        }


        private static IGenericRepository<T> CreateInstance<T>(string type) where T : class, new()
        {
            return (IGenericRepository<T>)Activator.CreateInstance(Type.GetType("Cinema." + repository + "." + type));
        }

    }
}
