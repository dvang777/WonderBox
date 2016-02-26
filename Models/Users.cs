﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderBox.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string UserID { get; set; }
        public decimal AmountOwed { get; set; }
    }
}