﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_API_SP.DAL
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

       // public virtual Room Room { get; set; }
    }
}