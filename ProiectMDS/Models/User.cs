﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sex { get; set; }
        public DateTime birthDate { get; set; }
        public string bankAccount { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Reservation> reservation { get; set; }//one to many
    }
}
