using PhoneShop.DataAccess;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PhoneShop.Models
{
    public class ProgramDataModel 
    {
        private static ProgramDataModel programDM;
        private ObservableCollection<CustomerM> customers;
        private ObservableCollection<string> customerNICList;
        private ObservableCollection<DetailedPhoneModelM> phoneModels;
        private ObservableCollection<DetailedJobModelM> detailedJobCollection;
        private ObservableCollection<string> phoneBrands;

        CRUDManager crudManager = new CRUDManager();

        private ProgramDataModel() 
        {
        }

        /// <summary>
        /// Singalton Instance
        /// </summary>
        public static ProgramDataModel ProgramDataModelInstance 
        {
            get 
            {
                if (programDM == null)
                {
                    programDM = new ProgramDataModel();
                    return programDM;
                }
                else return programDM;
            }
        }

        #region Getters and Setters

        public ObservableCollection<CustomerM> Customers
        {
            get
            {
                if (customers == null)
                {
                    customers = crudManager.GetAllCustomers();
                    return customers;
                }
                return customers;
            }
            set
            {
                this.customers = value;
            }
        }

        public ObservableCollection<string> CustomerNICList
        {
            get
            {
                if (customerNICList == null)
                {
                    customerNICList = getNICList();
                }
                return customerNICList;
            }
            set
            {
                this.customerNICList = value;
            }
        }

        public ObservableCollection<DetailedPhoneModelM> DetailedPhoneModels
        {
            get
            {
                if (phoneModels == null)
                {
                    phoneModels = crudManager.GetAllPhoneModels();
                }
                return phoneModels;
            }
            set
            {
                this.phoneModels = value;
            }
        }

        public ObservableCollection<DetailedJobModelM> DetailedJobCollection 
        {
            get
            {
                if (detailedJobCollection == null)
                {
                    detailedJobCollection = crudManager.GetAllJobsWithAllDetails();
                }
                return detailedJobCollection;
            }
            set
            {
                this.detailedJobCollection = value;
            }
        }

        public ObservableCollection<string> PhoneBrands
        {
            get
            {
                if (phoneBrands == null)
                {
                    phoneBrands = getPhoneBrands();
                }
                return phoneBrands;
            }
            set
            {
                this.phoneBrands = value;
            }
        }

        
        #endregion

        //public void AddNewCustomer(CustomerM customer) 
        //{
        //    ProgramDataModelInstance.Customers.Add(customer);
        //}

        //internal void UpdateCustomer(string p)
        //{
        //    for (int i = 0; i < Customers.Count; i++)
        //    {

        //        CustomerM c = Customers[i];
        //        c.Name = "Kumara";
        //        Customers[i] = c;

        //    }
        //}

        #region Internal Methods

        private ObservableCollection<string> getNICList()
        {
            ObservableCollection<string> nicl = new ObservableCollection<string>();
            foreach (var item in ProgramDataModelInstance.Customers)
            {
                nicl.Add(item.NIC);
            }
            return nicl;
        }

        private ObservableCollection<string> getPhoneBrands()
        {
            ObservableCollection<string> phoneBrands = new ObservableCollection<string>();
            foreach (var item in ProgramDataModelInstance.DetailedPhoneModels)
            {
                phoneBrands.Add(item.BrandName);
            }
            return phoneBrands;

        }


        #endregion

        public bool AddNewJob(DetailedJobModelM job)
        {
            crudManager.getTelephoneNumberByCustomerId(4);
            if (crudManager.AddNewJobDetailed(job)) 
            {

            }
            return false;
        }

        public async Task<DetailedJobModelM> LoadDetailedJob()//int jobId
        {
            DetailedJobModelM job = new DetailedJobModelM();
            job.Job = new JobM() { JobNumber = "PS - 0001" };
            job.Customer = new CustomerM() { Name = "Jayendra" };

            return job;
        }

    }
}
