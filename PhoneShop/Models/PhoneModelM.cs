using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class PhoneModelM
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ModelNumber { get; set; }
        public string ImageURI { get; set; }
    }
}
