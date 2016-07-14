﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.DAL.EntityNew
{
    public class UserAccount : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public string Role { get; set; }
        public bool IsActivated { get; set; }
    }
}
