using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneShop.DataAccess;
using PhoneShop.Models;
using System.Collections.ObjectModel;

namespace PhoneShopTest
{
    [TestClass]
    public class CRUDManagerTest
    {
        [TestMethod]
        public void AddNewCustomerTest()
        {
            CRUDManager crudm = new CRUDManager();

            CustomerM c = new CustomerM();
            c.Name = "Jayendrak";
            c.NIC = "883481018v";
            c.Email = "jayendra.k.a@gmail.com";

            crudm.AddNewCustomer(c);
        }

        [TestMethod]
        public void GetCustomerByIDTest() 
        {
            CRUDManager crudm = new CRUDManager();
            //CustomerM c = crudm.GetCustomerByNIC("883481018v");
        }

        [TestMethod]
        public void GetAllCustomersTest() 
        {
            CRUDManager crudm = new CRUDManager();
            ObservableCollection<CustomerM> cl = crudm.GetAllCustomers();
        }
        [TestMethod]
        public void DetailedJobModelTest() 
        {

            DetailedJobModelM job = new DetailedJobModelM();
            CustomerM c = new CustomerM();
            c.Name = "Jayendrak";
            c.NIC = "883481918v";
            c.Email = "jayendra.k.a@gmail.com";
            job.Customer = c;

            CRUDManager crudm = new CRUDManager();

            bool b = crudm.AddNewJobDetailed(job);
        }
    }
}
