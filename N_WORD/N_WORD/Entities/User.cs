using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PassowrdHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
