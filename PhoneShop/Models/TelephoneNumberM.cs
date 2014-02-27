using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class TelephoneNumberM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string TelNo { get; set; }
        public bool IsHome { get; set; }
    }
}
