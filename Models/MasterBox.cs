using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WonderBox.Models
{
    public class MasterBox
    {
        [Key]
        public int BoxId { get; set; }
        public string BoxName { get; set; }
        public double Price { get; set; }
    }
}
