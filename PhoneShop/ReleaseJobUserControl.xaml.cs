using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ReleaseJobUserControl.xaml
    /// </summary>
    public partial class ReleaseJobUserControl : UserControl
    {
        public delegate DetailedJobModelM DelegateDetailedJob(int jobId);

        public ReleaseJobUserControl()
        {
            InitializeComponent();
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ThreadDataLoad();
        }

        private void ThreadDataLoad()
        {
            Thread DataLoadAsy = new Thread(LoadData);
            DataLoadAsy.IsBackground = true;
            DataLoadAsy.Start();
        }

        private void LoadData(object obj)
        {
            DelegateDetailedJob jobs = new DelegateDetailedJob(ProgramDataModel.ProgramDataModelInstance.LoadDetailedJob);
            this.Dispatcher.BeginInvoke(new Action(delegate() 
                                {
                                    releaseJobSearchListView.Items.Add(jobs);
                                }));
            Thread.Sleep(5000);
            DelegateDetailedJob jobs1 = new DelegateDetailedJob(ProgramDataModel.ProgramDataModelInstance.LoadDetailedJob);
            this.Dispatcher.BeginInvoke(new Action(delegate()
            {
                releaseJobSearchListView.Items.Add(jobs);
            }));
            

            //DetailedJobModelM job = ProgramDataModel.ProgramDataModelInstance.LoadDetailedJob();
        }
    }
}
