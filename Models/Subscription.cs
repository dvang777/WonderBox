using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderBox.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string SubName { get; set; }
        public int SubLength { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal YearlyPrice { get; set; }
    }
}