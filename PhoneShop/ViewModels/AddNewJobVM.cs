using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PhoneShop.ViewModels
{
    public class AddNewJobVM 
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CustomerM> Customers
        {
            get { return ProgramDataModel.ProgramDataModelInstance.Customers; }
            set { Customers = value; }
        }

        public ObservableCollection<string> CustomerNICList
        {
            get { return ProgramDataModel.ProgramDataModelInstance.CustomerNICList; }
            set { CustomerNICList = value; }
        }

        public ObservableCollection<DetailedPhoneModelM> DetailedPhoneModels
        {
            get { return ProgramDataModel.ProgramDataModelInstance.DetailedPhoneModels; }
            set { DetailedPhoneModels = value; }
        }

        public ObservableCollection<string> PhoneBrands 
        {
            get { return ProgramDataModel.ProgramDataModelInstance.PhoneBrands;}
            set { PhoneBrands = value; }
        }

        //public void AddNewCustomer(CustomerM customer) 
        //{
        //    ProgramDataModel.ProgramDataModelInstance.AddNewCustomer(customer);
        //    OnChanged("Customers");
        //}

        //void OnChanged(string pn)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(pn));
        //    }
        //}
    }
}
