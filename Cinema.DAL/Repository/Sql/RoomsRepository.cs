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
    public class RoomsRepository : SqlRepository<Room, RoomAdapter>, IGenericRepository<Room>
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

        public RoomsRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }


        public void Delete(Guid? guid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAll()
        {
            throw new NotImplementedException();
        }

        public Room GetOne(Guid? guid)
        {
            throw new NotImplementedException();
        }

        public void Insert(Room obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Room obj)
        {
            throw new NotImplementedException();
        }
    }
}
