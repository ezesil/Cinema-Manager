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
    public class UsersRepository : SqlRepository<User, UserAdapter>, IGenericRepository<User>
    {
        private static string DeleteQuery 
        { get => "DELETE * FROM USERS WHERE guid_usuario = @Usuario"; }
        private static string SelectAllQuery 
        { get => ""; }
        private static string SelectQuery 
        { get => ""; }
        private static string InsertQuery 
        { get => ""; }
        private static string UpdateQuery 
        { get => ""; }

        public UsersRepository() 
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {    
        }

        // TODO: Implementar clase User
        public void Insert(User obj) => base.Insert(new SqlParameter[] { new SqlParameter("guid", obj.UserGuid) });

        public void Update(User obj) => base.Update(new SqlParameter[] { new SqlParameter("guid", obj.UserGuid) });

        public IEnumerable<User> GetAll() => base.GetAll();

        public User GetOne(Guid guid) => base.GetOne(new SqlParameter[] { new SqlParameter("guid", guid) });

        public void Delete(Guid guid) => base.Delete(new SqlParameter[] { new SqlParameter("guid", guid) });

    }
}
