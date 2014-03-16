using PhoneShop.Models;
using PhoneShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneShop
{
    /// <summary>
    /// Interaction logic for AddNewJobUserControl.xaml
    /// </summary>
    public partial class AddNewJobUserControl : UserControl
    {
        ObservableCollection<string> nics = null;

        public AddNewJobUserControl()
        {
            InitializeComponent();
            emiNoTxtBox.IsEnabled = false;
            //nics = new ObservableCollection<string> { "883481011V", "893481011V", "883581011V" };
            //nicNoCBox.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = nics });

        }

        private void CancelJobBtnClicked(object sender, RoutedEventArgs e)
        {
            ClearAllView();
        }

        private void SaveJobBtnClicked(object sender, RoutedEventArgs e)
        {
            float advancedPavemnt = 0;
            if (nicNoCBox.Text == null || nicNoCBox.Text.Trim() == "") { nicNoCBox.Focus(); return; }
            else if (customrNameTxtBox.Text == null || customrNameTxtBox.Text.Trim() == "") { customrNameTxtBox.Focus(); return; }
            else if (phoneBrandNamesCB.Text == null || phoneBrandNamesCB.Text.Trim() == "") { phoneBrandNamesCB.Focus(); return; }
            else if (phoneModelsCB.Text == null || phoneModelsCB.Text.Trim() == "") { phoneModelsCB.Focus(); return; }
            else if ((bool)isPhoneChkBox.IsChecked && (emiNoTxtBox.Text == null || emiNoTxtBox.Text.Trim() == "")) { emiNoTxtBox.Focus(); return; }
            else if (advancePaymentTxtBox.Text != "" && !float.TryParse(advancePaymentTxtBox.Text.Trim(), out advancedPavemnt)) { advancePaymentTxtBox.Focus(); return; }

            DetailedJobModelM job = new DetailedJobModelM();

            job.Customer.Name = customrNameTxtBox.Text.Trim();
            job.Customer.NIC = nicNoCBox.Text.Trim();
            job.Customer.Email = emailTxtBox.Text.Trim();
            if (mobileNoTxtBox.Text.Trim() != "")
            {
                TelephoneNumberM mobile = new TelephoneNumberM();
                mobile.TelNo = mobileNoTxtBox.Text.Trim();
                mobile.IsHome = false;
                job.Customer.TelephoneNumbers.Add(mobile);
            } 
            if (landNoTxtBox.Text.Trim() != "")
            {
                TelephoneNumberM home = new TelephoneNumberM();
                home.TelNo = landNoTxtBox.Text.Trim();
                home.IsHome = true;
                job.Customer.TelephoneNumbers.Add(home);
            }

            job.PhoneModel.BrandName = phoneBrandNamesCB.Text.Trim();
            job.PhoneModel.SelectedPhoneModel.ModelNumber = phoneModelsCB.Text.Trim();
            //job.PhoneModel.SelectedPhoneModel.ImageURI = //add uri

            job.Job.JobNumber = jobNoTxtBox.Text.Trim();
            job.Job.JobDiscription = new TextRange(jobNoteTxtBox.Document.ContentStart, jobNoteTxtBox.Document.ContentEnd).Text.Trim();
            job.Job.OtherDiscription = new TextRange(otherJobDetailTxtBox.Document.ContentStart, otherJobDetailTxtBox.Document.ContentEnd).Text.Trim();
            job.Job.IsCompleted = false;
            job.Job.AdvancePavement = advancedPavemnt;
            

            if ((bool)isPhoneChkBox.IsChecked) 
            {
                DeviceM phone = new DeviceM();
                phone.IsPhone = true;
                phone.Discription = "Phone";
                phone.EmiNumber = emiNoTxtBox.Text.Trim();
                job.DeviceOrAccaccessories.Add(phone);
            } 
            if ((bool)isBatteryChkBox.IsChecked)
            {
                DeviceM battery = new DeviceM();
                battery.IsPhone = false;
                battery.Discription = "Battery";
                job.DeviceOrAccaccessories.Add(battery);
            }
            if ((bool)isMemoryChkBox.IsChecked)
            {
                DeviceM memory = new DeviceM();
                memory.IsPhone = false;
                memory.Discription = "Memory";
                job.DeviceOrAccaccessories.Add(memory);
            }
            if ((bool)isSimChkBox.IsChecked)
            {
                DeviceM sim = new DeviceM();
                sim.IsPhone = false;
                sim.Discription = "Sim";
                job.DeviceOrAccaccessories.Add(sim);
            }
            if ((bool)isBackCoverChkBox.IsChecked)
            {
                DeviceM backCover = new DeviceM();
                backCover.IsPhone = false;
                backCover.Discription = "Back Cover";
                job.DeviceOrAccaccessories.Add(backCover);
            }
            if (otherAccessoryTxtBox.Text.Trim() != "")
            {
                DeviceM backCover = new DeviceM();
                backCover.IsPhone = false;
                backCover.Discription = otherAccessoryTxtBox.Text.Trim();
                job.DeviceOrAccaccessories.Add(backCover);
            }

            if (ProgramDataModel.ProgramDataModelInstance.AddNewJob(job)) 
            {
                MessageBox.Show("Job is added successfully");
                ClearAllView();
            }
        }

        private void NICComboboxLostForcuse(object sender, RoutedEventArgs e)
        {
            AddNewJobVM anj = (AddNewJobVM)DataContext;
            if (/*validateNICNumber(nicNoCBox.Text.Trim()) &&*/ anj.CustomerNICList.Contains(nicNoCBox.Text.Trim())) 
            {
                foreach (var item in anj.Customers)
                {
                    if (item.NIC == nicNoCBox.Text.Trim()) 
                    {
                        customrNameTxtBox.Text = item.Name != null ? item.Name : "";
                        foreach (var tel in item.TelephoneNumbers)
                        {
                            if(tel.IsHome) landNoTxtBox.Text = tel.TelNo;
                            else mobileNoTxtBox.Text = tel.TelNo;
                        }
                        emailTxtBox.Text = item.Email != null ? item.Email : "";
                    }
                }
            }
        }

        private void BrandNamesComboboxLostForcus(object sender, RoutedEventArgs e)
        {
            AddNewJobVM anj = (AddNewJobVM)DataContext;
            if (anj.PhoneBrands.Contains(phoneBrandNamesCB.Text.Trim()))
            {
                ObservableCollection<string> modelNumbers = new ObservableCollection<string>();
                foreach (var item in anj.DetailedPhoneModels.Where(x=>x.BrandName ==phoneBrandNamesCB.Text.Trim()).FirstOrDefault().PhoneModels)
                {
                    //if (item.BrandName == phoneBrandNamesCB.Text.Trim())
                    //{
                    //    if (phoneModelsCB.ItemsSource != null) 
                    //        phoneModelsCB.Items.Clear();
                    //    phoneImgBox.Source = new BitmapImage(new Uri("/Content/Images/No-Image.jpg", UriKind.Relative));
                    //    phoneModelsCB.ItemsSource = anj.DetailedPhoneModels;
                    //}
                    modelNumbers.Add(item.ModelNumber);
                }
                if (modelNumbers.Count != 0) phoneModelsCB.ItemsSource = modelNumbers;
                phoneImgBox.Source = new BitmapImage(new Uri("/Content/Images/No-Image.jpg", UriKind.Relative));
            }
        }

        private void PhoneModelComboboxLostForcus(object sender, RoutedEventArgs e)
        {
            AddNewJobVM anj = (AddNewJobVM)DataContext;

            if (!anj.PhoneBrands.Contains(phoneBrandNamesCB.Text.Trim())) return;

            foreach (var item in anj.DetailedPhoneModels.Where(a => a.BrandName == phoneBrandNamesCB.Text.Trim()).First().PhoneModels)
            {
                if (item.ModelNumber == phoneModelsCB.Text.Trim())
                {
                    if (item.ImageURI != null && item.ImageURI != "") phoneImgBox.Source = new BitmapImage(new Uri(item.ImageURI, UriKind.Relative));
                    else phoneImgBox.Source = new BitmapImage(new Uri("/Content/Images/No-Image.jpg", UriKind.Relative));
                }
            }
        }

        private void PhoneCBChecked(object sender, RoutedEventArgs e)
        {
            emiNoTxtBox.IsEnabled = true;
        }

        private void PhoneCBUnchecked(object sender, RoutedEventArgs e)
        {
            emiNoTxtBox.Text = "";
            emiNoTxtBox.IsEnabled = false;
        }

        private void NicComboboxKeyUp(object sender, KeyEventArgs e)
        {
            if (nicNoCBox.ItemsSource == null) return;
            if (!((ObservableCollection<string>)nicNoCBox.ItemsSource).Contains(nicNoCBox.Text.Trim())) 
            {
                ClearCustomerView();
            }
        }

        private void PhoneBrandCBKeyUp(object sender, KeyEventArgs e)
        {
            if (phoneBrandNamesCB.ItemsSource == null) return;
            if (!((ObservableCollection<string>)phoneBrandNamesCB.ItemsSource).Contains(phoneBrandNamesCB.Text.Trim()))
            {
                phoneModelsCB.Items.Clear();
                phoneImgBox.Source = new BitmapImage(new Uri("/Content/Images/No-Image.jpg", UriKind.Relative));
            }
        }

        private void PhoneModelsCBKeyUp(object sender, KeyEventArgs e)
        {
            if (phoneModelsCB.ItemsSource == null) return;
            if (!((ObservableCollection<string>)phoneModelsCB.ItemsSource).Contains(phoneBrandNamesCB.Text.Trim()))
            {
                phoneImgBox.Source = new BitmapImage(new Uri("/Content/Images/No-Image.jpg", UriKind.Relative));
            }
        }

        #region Private Methods

        private bool validateNICNumber(string str)
        {
            if ((str.Count(char.IsDigit) == 9) &&
                    (str.EndsWith("X", StringComparison.OrdinalIgnoreCase)
                    || str.EndsWith("V", StringComparison.OrdinalIgnoreCase)) &&
                    (str[2] != '4' && str[2] != '9'))
            {
                return true;
            }
            else
            {
                //MessageBox.Show("Recheck NIC Number");
                return false;
            }
        }

        private void ClearCustomerView()
        {
            customrNameTxtBox.Text = "";
            mobileNoTxtBox.Text = "";
            landNoTxtBox.Text = "";
            emailTxtBox.Text = "";
        }

        private void ClearAllView()
        {
            nicNoCBox.Text = "";
            ClearCustomerView();
            phoneBrandNamesCB.Text = "";
            phoneImgBox.Source = new BitmapImage(new Uri("/Content/Images/No-Image.jpg", UriKind.Relative));
            phoneModelsCB.Text = "";
            //phoneModelsCB.Items.Clear();
            jobNoteTxtBox.SelectAll(); jobNoteTxtBox.Selection.Text = "";
            emiNoTxtBox.Text = "";
            isPhoneChkBox.IsChecked = false;
            isBackCoverChkBox.IsChecked = false;
            isBatteryChkBox.IsChecked = false;
            isSimChkBox.IsChecked = false;
            isMemoryChkBox.IsChecked = false;
            otherAccessoryTxtBox.Text = "";
            otherJobDetailTxtBox.SelectAll(); otherJobDetailTxtBox.Selection.Text = "";
            advancePaymentTxtBox.Text = "";
        }

        #endregion

    }
}
