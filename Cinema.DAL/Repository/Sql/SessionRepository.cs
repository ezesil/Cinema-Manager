using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.Sql.Adapter;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql
{
    public class SessionRepository : SqlRepository<Session, SessionAdapter>, IGenericRepository<Session>
    {
        private static string DeleteQuery
        { get => ""; }
        private static string SelectAllQuery
        { get => ""; }
        private static string SelectQuery
        { get => ""; }
        private static string InsertQuery
        { get => ""; }
        private static string UpdateQuery
        { get => ""; }

        public SessionRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public void Insert(Session obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Session obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Session> GetAll()
        {
            throw new NotImplementedException();
        }

        public Session GetOne(Guid? guid)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid? guid)
        {
            throw new NotImplementedException();
        }
    }
}
