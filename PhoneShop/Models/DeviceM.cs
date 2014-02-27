using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class DeviceM
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string EmiNumber { get; set; }
        public string Discription { get; set; }
        public bool IsPhone { get; set; }
    }
}
