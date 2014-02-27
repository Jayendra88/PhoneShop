using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PhoneShop.Models
{
    public class DetailedJobModelM
    {
        public CustomerM Customer { get; set; }

        public DetailedPhoneModelM PhoneModel { get; set; }

        public JobM Job { get; set; }

        public ObservableCollection<DeviceM> DeviceOrAccaccessories { get; set; }

        public RepareM RepareDetails { get; set; }

        public ObservableCollection<NewPartM> NewParts { get; set; }

        public SystemUserM DeveloperOrMechanist { get; set; }

        public DetailedJobModelM() 
        {
            Customer = new CustomerM();
            PhoneModel = new DetailedPhoneModelM();
            Job = new JobM();
            DeviceOrAccaccessories = new ObservableCollection<DeviceM>();
            RepareDetails = new RepareM();
            NewParts = new ObservableCollection<NewPartM>();
            DeveloperOrMechanist = new SystemUserM();
        }
    }
}
