using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace PhoneShop.DataAccess
{
	public class CRUDManager
	{
		public void AddNewCustomer(CustomerM customer) 
		{
			using (PhoneShopdbEntities e = new PhoneShopdbEntities())
			{
				try
				{
					Customer c = new Customer();
					c.Name = customer.Name;
					c.NIC = customer.NIC;
					c.Email = customer.Email;
					e.Customers.Add(c);
					e.SaveChanges();
				}
				catch { }
			}
		}

		public Customer GetCustomerByNIC(string NIC) 
		{
			Customer customer = new Customer();

			using (PhoneShopdbEntities e = new PhoneShopdbEntities())
			{
				customer = e.Customers.Where(x => x.NIC == NIC).FirstOrDefault();

				//if (c != null)
				//{
				//    customer.Id = c.Id;
				//    customer.Name = c.Name;
				//    customer.NIC = c.NIC;
				//    customer.Email = c.Email;
				//}
			}

			return customer;
		}

		public ObservableCollection<CustomerM> GetAllCustomers() 
		{
			ObservableCollection<CustomerM> customers = new ObservableCollection<CustomerM>();
			using (PhoneShopdbEntities ctx = new PhoneShopdbEntities())
			{
				
				var c = ctx.Customers.ToList();

				foreach (var item in c)
				{
					CustomerM customer = new CustomerM();
					customer.Id = (int)item.Id;
					customer.Name = (string)item.Name;
					customer.NIC = (string)item.NIC;
					customer.Email = (string)item.Email;

					var t = ctx.TelephoneNumbers.Where(x => x.Customer_Id == item.Id).ToList();
					foreach (var t1 in t)
					{
						TelephoneNumberM tel = new TelephoneNumberM();
						tel.Id = t1.Id;
						tel.CustomerId = (int)t1.Customer_Id;
						tel.IsHome = (bool)t1.IsHome;
						tel.TelNo = t1.TelNo;
						customer.TelephoneNumbers.Add(tel);
					}

					customers.Add(customer);
				}
			}
			return customers;
		}

		internal ObservableCollection<DetailedPhoneModelM> GetAllPhoneModels()
		{
			ObservableCollection<DetailedPhoneModelM> phoneModels = new ObservableCollection<DetailedPhoneModelM>();
			using (PhoneShopdbEntities ctx = new PhoneShopdbEntities())
			{
				
				var brands = ctx.PhoneBrands.ToList();

				foreach (var item in brands)
				{
					DetailedPhoneModelM phoneM = new DetailedPhoneModelM();
					phoneM.Id = (int)item.Id;
					phoneM.BrandName = (string)item.BrandName;
					var models = ctx.PhoneModels.Where(x => x.Brand_Id == item.Id).ToList();
					foreach (var m in models)
					{
						PhoneModelM pm = new PhoneModelM();
						pm.Id = m.Id;
						pm.BrandId = (int)m.Brand_Id;
						pm.ModelNumber = m.ModelNumber;
						pm.ImageURI = m.ImageURI;
						phoneM.PhoneModels.Add(pm);
					}
					phoneModels.Add(phoneM);
				}
			}
			return phoneModels;
		}

		internal ObservableCollection<DetailedJobModelM> GetAllJobsWithAllDetails()
		{
			ObservableCollection<DetailedJobModelM> jobs = new ObservableCollection<DetailedJobModelM>();
			
			//using (PhoneShopdbEntities e = new PhoneShopdbEntities())
			//{
			//    var jobList = e.Jobs.ToList();

			//    foreach (var item in jobList)
			//    {
			//        DetailedJobModelM model = new DetailedJobModelM();

			//        model.Job.Id = item.Id;
			//        model.Job.JobNumber= item.JobNo;
			//        model.Job.CustomerId =  (int)item.Customer_Id;
			//        model.Job.PhoneModelId = (int)item.PhoneModel_Id;
			//        model.Job.IsCompleted = (bool)item.IsCompleted;
			//        model.Job.HasDevice = (bool)item.IsDevice;
			//        model.Job.JobDiscription = item.JobDiscription;
			//        model.Job.OtherDiscription = item.OtherDiscription;
			//        //model.Job.AdvancePavement

			//        #region get customer

			//        var customer = e.Customers.Where(x => x.Id == item.Customer_Id).FirstOrDefault();
			//        model.Customer = new CustomerM()
			//        {
			//            Id = customer.Id,
			//            Name = customer.Name,
			//            Email = customer.Email,
			//            NIC = customer.Email,
			//        };
			//        var telephones = e.TelephoneNumbers.Where(x => x.Customer_Id == customer.Id).ToList();
			//        foreach (var number in telephones)
			//        {
			//            model.Customer.TelephoneNumbers.Add(new TelephoneNumberM()
			//            {
			//                Id = number.Id,
			//                CustomerId = customer.Id,
			//                IsHome = (bool)number.IsHome,
			//                TelNo = number.TelNo
			//            });
			//        }

			//        #endregion

			//        #region get phone model
			//        var phoneModel = e.PhoneModels.Where(x => x.Id == item.PhoneModel_Id).FirstOrDefault();
			//        model.PhoneModel = new DetailedPhoneModelM()
			//                    {
			//                        Id = phoneModel.Id, 
			//                        BrandName = phoneModel.PhoneBrand,
									
			//                    }

			//        #endregion

			//    }

			//}

			DetailedJobModelM job = new DetailedJobModelM();
			job.Job = new JobM() { JobNumber = "PS - 0001"};
			job.Customer = new CustomerM() { Name = "Jayendra"};

			jobs.Add(job);

			DetailedJobModelM job1 = new DetailedJobModelM();
			job1.Job = new JobM() { JobNumber = "PS - 0001" };
			job1.Customer = new CustomerM() { Name = "Jayendra" };

			jobs.Add(job1);

			return jobs;
		}

		public ObservableCollection<TelephoneNumberM> getTelephoneNumberByCustomerId(int customerId) 
		{
			ObservableCollection<TelephoneNumberM> tels = new ObservableCollection<TelephoneNumberM>();

			using (PhoneShopdbEntities e = new PhoneShopdbEntities())
			{
				TelephoneNumberM tel = new TelephoneNumberM();
				var t = e.TelephoneNumbers.Where(a => a.Customer_Id == customerId).ToList();

				foreach (var item in t)
				{
					tel.Id = (int)item.Id;
					tel.TelNo = (string)item.TelNo;
					tel.IsHome = (bool)item.IsHome;
					tel.CustomerId = (int)item.Customer_Id;
					tels.Add(tel);
				}
			}

			return tels;
		}

		public bool AddNewJobDetailed(DetailedJobModelM job)
		{
			using (PhoneShopdbEntities ctx = new PhoneShopdbEntities())
			{
				Customer customer = ctx.Customers.Where(x => x.NIC == job.Customer.NIC).FirstOrDefault();
				if (customer == null)
				{
					customer = new Customer();
					customer.Name = job.Customer.Name;
					customer.NIC = job.Customer.NIC;
					customer.Email = job.Customer.Email;
					ctx.Customers.Add(customer);
				}
				else 
				{
					customer = GetCustomerByNIC(job.Customer.NIC);
					customer.Name = job.Customer.Name;
					customer.Email = job.Customer.Email;
				}

				var telNums = ctx.TelephoneNumbers.Where(x => x.Customer_Id == customer.Id).ToList();
				TelephoneNumber home = null;
				TelephoneNumber mobile = null;

				foreach (var item in job.Customer.TelephoneNumbers)
				{
					if (item.IsHome)
					{
						home = telNums.Where(x => x.IsHome == true).FirstOrDefault();
						if (home == null)
						{
							home = new TelephoneNumber();
							home.Customer_Id = customer.Id;
							home.IsHome = item.IsHome;
							home.TelNo = item.TelNo;
							ctx.TelephoneNumbers.Add(home);
						}
						else
						{
							home.TelNo = item.TelNo;
						}
					}
					else
					{
						mobile = telNums.Where(x => x.IsHome == false).FirstOrDefault();
						if (mobile == null)
						{
							mobile = new TelephoneNumber();
							mobile.Customer_Id = customer.Id;
							mobile.IsHome = item.IsHome;
							mobile.TelNo = item.TelNo;
							ctx.TelephoneNumbers.Add(mobile);
						}
						else
						{
							mobile.TelNo = item.TelNo;
						}
					}
				}

				PhoneBrand brand = ctx.PhoneBrands.Where(x => x.BrandName == job.PhoneModel.BrandName).FirstOrDefault();
				PhoneModel model = null;
				if (brand == null)
				{
					brand = new PhoneBrand();
					brand.BrandName = job.PhoneModel.BrandName;
					ctx.PhoneBrands.Add(brand);

					model = new PhoneModel();
					model.Brand_Id = brand.Id;
					model.ModelNumber = job.PhoneModel.SelectedPhoneModel.ModelNumber;
					model.ImageURI = job.PhoneModel.SelectedPhoneModel.ImageURI;

					ctx.PhoneModels.Add(model);
				}
				else 
				{
					model = ctx.PhoneModels.Where(x => x.ModelNumber == job.PhoneModel.SelectedPhoneModel.ModelNumber).FirstOrDefault();
					if (model == null)
					{
						model = new PhoneModel();
						model.Brand_Id = (int)brand.Id;
						model.ModelNumber = job.PhoneModel.SelectedPhoneModel.ModelNumber;
						model.ImageURI = job.PhoneModel.SelectedPhoneModel.ImageURI;
						ctx.PhoneModels.Add(model);
					}
					else 
					{
						model.ImageURI = job.PhoneModel.SelectedPhoneModel.ImageURI;
					}

					//model.ImageURI = job.PhoneModel.SelectedPhoneModel.ImageURI;
				}

				Job newJob = new Job();
				newJob.Customer_Id = customer.Id;
				newJob.IsCompleted = false;
				newJob.IsDevice = job.DeviceOrAccaccessories.Count == 0 ? false : true;
				newJob.JobDiscription = job.Job.JobDiscription;
				newJob.JobNo = job.Job.JobNumber;
				newJob.OtherDiscription = job.Job.OtherDiscription;
				newJob.PhoneModel_Id = model.Id;
				//advanced pavement
				ctx.Jobs.Add(newJob);

				foreach (var item in job.DeviceOrAccaccessories)
				{
					Device d = new Device();
					d.Job_Id = newJob.Id;
					if (item.IsPhone) 
					{
						d.IsPhone = true;
						d.EmiNumber = item.EmiNumber;
					}
					d.Discription = item.Discription;
					ctx.Devices.Add(d);
				}

				ctx.SaveChanges();
			}
			return false;
		}

		//private bool IsCustomerAlradyExist(string NIC)
		//{
		//    using (PhoneShopdbEntities e = new PhoneShopdbEntities())
		//    {
		//        var c = e.Customers.Where(x => x.NIC == NIC).FirstOrDefault();

		//        if (c != null)
		//        {
		//            return true;
		//        }
		//        else return false;
		//    }
		//}
	}
}
