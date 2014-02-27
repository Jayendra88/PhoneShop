using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class JobM
    {
        public int Id { get; set; }
        public string JobNumber { get; set; }
        public string JobDiscription { get; set; }
        public string OtherDiscription { get; set; }
        public bool IsCompleted { get; set; }
        public bool HasDevice { get; set; }
        public int CustomerId { get; set; }
        public int PhoneModelId { get; set; }
        public float AdvancePavement { get; set; }
    }
}
