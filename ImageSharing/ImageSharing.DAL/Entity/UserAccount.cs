using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSharing.DAL.Entity
{
    public class UserAccount : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public int TapeID { get; set; }
        public string IDsFriends { get; set; }
        public string Role { get; set; }
        public string IDsSubscriptions { get; set; }
        public bool IsActivated { get; set; }
        public string IDsRequests { get; set; }
    }
}
