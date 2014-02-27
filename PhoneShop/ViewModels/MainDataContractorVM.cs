using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneShop.ViewModels
{
    public class MainDataContractorVM
    {
        private AddNewJobVM addNewCustomerVM;

        public MainDataContractorVM() 
        {
            addNewCustomerVM = new AddNewJobVM();
        }

        public AddNewJobVM AddNewCustomerViewModel
        {
            get
            {
                return addNewCustomerVM;
            }
        }
    }
}
