using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    public class User
    {
        public User()
        {

        }
        public User(Guid _Id, string _Username, string _Password, string _Email, string _FullName, string _DNI)
        {
            Id = _Id;
            Username = _Username;
            Password = _Password;
            Email = _Email;
            Enabled = true;
            FullName = _FullName;
            DNI = _DNI;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }   
        public decimal DVH { get; set; }
        public string FullName { get; set; }
        public string DNI { get; set; }
    }
}
