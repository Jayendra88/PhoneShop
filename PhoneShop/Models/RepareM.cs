using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class RepareM
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public int JobId { get; set; }
        public string Discription { get; set; }
        public string RepareCost { get; set; }
    }
}
