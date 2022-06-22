using System;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.SqlServer;
using Cinema.Domain;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IGenericRepository<User> users = new UsersRepository();
            




            Console.ReadKey();
        }
    }
}
