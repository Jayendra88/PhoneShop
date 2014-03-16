using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        public ReleaseJobUserControl()
        {
            InitializeComponent();
        }
        
        public void ThreadDataLoad()
        {
            Thread DataLoadAsy = new Thread(LoadData);
            DataLoadAsy.IsBackground = true;
            DataLoadAsy.Start();
        }

        private async void LoadData()
        {
            DetailedJobModelM job = await ProgramDataModel.ProgramDataModelInstance.LoadDetailedJob();
            this.Dispatcher.BeginInvoke(new Action(delegate()
            {
                releaseJobSearchListView.Items.Add(job);
            }));
        }

        
    }
}
