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
    public class SessionsBLL
    {
        private readonly IGenericRepository<Session> _sessionrepo = FactoryDAL.SessionRepository;

        #region Singleton
        private static SessionsBLL _instance = new SessionsBLL();

        /// <summary>
        /// Instancia actual de la clase.
        /// </summary>
        public static SessionsBLL Current
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionsBLL();

                return _instance;
            }
        }

        private SessionsBLL()
        {

        }
        #endregion

        public List<Session> GetAllCompleteSessions()
        {
            var completesessions = new List<Session>();
            foreach(var session in _sessionrepo.GetAll().ToList())
            {
                session.Sala = RoomsBLL.Current.GetRoom(session.RoomId);
                session.Pelicula = MoviesBLL.Current.GetMovie(session.MovieId);
                completesessions.Add(session);
            }

            return completesessions;
        }

        public List<Session> GetAllSessions()
        {
            return _sessionrepo.GetAll().ToList();
        }

        public Session GetSession(Guid id)
        {
            return _sessionrepo.GetOne(id);
        }

        public void CreateSession(Session session)
        {
            _sessionrepo.Insert(session);
        }

        public void UpdateSession(Session session)
        {
            _sessionrepo.Update(session);
        }

        public void DeleteSession(Guid? id)
        {
            _sessionrepo.Delete(id);
        }

    }
}
