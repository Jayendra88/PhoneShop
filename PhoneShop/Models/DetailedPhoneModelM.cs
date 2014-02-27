using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class DetailedPhoneModelM
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public ObservableCollection<PhoneModelM> PhoneModels { get; set; }

        public PhoneModelM SelectedPhoneModel { get; set; }

        public DetailedPhoneModelM() 
        {
            PhoneModels = new ObservableCollection<PhoneModelM>();
            SelectedPhoneModel = new PhoneModelM();
        }

        //public string ModelNo { get; set; }
        //public string ImageUri { get; set; }
    }
}
