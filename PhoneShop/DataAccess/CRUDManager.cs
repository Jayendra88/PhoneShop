using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneShop.DataAccess
{
    public class CRUDManager
    {
        public void AddNewCustomer(CustomerVM customer) 
        {
            using (PhoneShopdbEntities e = new PhoneShopdbEntities())
            {
                Customer c = new Customer();
                c.Name = customer.Name;
                c.NIC = customer.NIC;
                c.Email = customer.Email;
                e.Customers.Add(c);
                e.SaveChanges();
            }
        }

        public CustomerVM GetCustomerByID(string NIC) 
        {
            CustomerVM customer = new CustomerVM();

            using (PhoneShopdbEntities e = new PhoneShopdbEntities())
            {
                var c = e.Customers.Where(x => x.NIC == NIC).FirstOrDefault();

                if (c != null)
                {
                    customer.Id = c.Id;
                    customer.Name = c.Name;
                    customer.NIC = c.NIC;
                    customer.Email = c.Email;
                }
            }

            return customer;
        }


    }
}
