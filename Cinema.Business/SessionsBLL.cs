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
        private readonly IGenericRepository<Session> _repo = FactoryDAL.SessionRepository;

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


        public List<Session> GetAllSessions()
        {
            return _repo.GetAll().ToList();
        }

        public Session GetSession(Guid id)
        {
            return _repo.GetOne(id);
        }

        public void CreateSession(Session session)
        {
            _repo.Insert(session);
        }

        public void UpdateSession(Session session)
        {
            _repo.Update(session);
        }

        public void DeleteSession(Guid? id)
        {
            _repo.Delete(id);
        }

    }
}
