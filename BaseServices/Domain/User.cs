using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }   
        public int DVH { get; set; }
        public string FullName { get; set; }
        public string DNI { get; set; }
    }
}
