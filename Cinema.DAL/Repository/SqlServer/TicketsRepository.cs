using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.SqlServer.Adapter;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.SqlServer
{
    public class TicketsRepository : SqlRepository<Ticket, TicketAdapter>, IGenericRepository<Ticket>
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

        public TicketsRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public void Insert(Ticket obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ticket GetOne(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
