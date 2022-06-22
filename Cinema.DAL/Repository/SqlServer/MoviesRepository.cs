using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.SqlServer.Adapter;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.SqlServer
{
    internal class MoviesRepository : SqlRepository<Movie, MovieAdapter>, IGenericRepository<Movie>
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

        public MoviesRepository()
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public void Insert(Movie obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetOne(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
