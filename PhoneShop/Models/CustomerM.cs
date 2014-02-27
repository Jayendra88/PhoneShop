using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class CustomerM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public ObservableCollection<TelephoneNumberM> TelephoneNumbers { get; set; }

        public CustomerM() 
        {
            TelephoneNumbers = new ObservableCollection<TelephoneNumberM>();
        }
    }
}
