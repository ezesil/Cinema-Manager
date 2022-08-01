using Cinema.Domain.CustomFlags;
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

        [VisibleOnGrid("")]
        public string Username { get; set; }

        public string Password { get; set; }

        [VisibleOnGrid("")]
        public string Email { get; set; }

        [VisibleOnGrid("")]
        public bool Enabled { get; set; }

        public decimal DVH { get; set; }

        [VisibleOnGrid("")]
        public string FullName { get; set; }

        [VisibleOnGrid("")]
        public string DNI { get; set; }

    }
}
