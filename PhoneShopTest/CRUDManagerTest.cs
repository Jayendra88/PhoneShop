using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneShop.DataAccess;
using PhoneShop.Models;

namespace PhoneShopTest
{
    [TestClass]
    public class CRUDManagerTest
    {
        [TestMethod]
        public void AddNewCustomerTest()
        {
            CRUDManager crudm = new CRUDManager();

            CustomerVM c = new CustomerVM();
            c.Name = "Jayendrak";
            c.NIC = "883481011v";
            c.Email = "jayendra.k.a@gmail.com";

            crudm.AddNewCustomer(c);
        }

        [TestMethod]
        public void GetCustomerByIDTest() 
        {
            CRUDManager crudm = new CRUDManager();
            CustomerVM c = crudm.GetCustomerByID("883481011v");
        }

    }
}
