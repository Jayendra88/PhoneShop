using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PhoneShop.ViewModels
{
    class ReleaseJobVM
    {
        private ObservableCollection<DetailedJobModelM> jobsInDetail;
        
        public ObservableCollection<DetailedJobModelM> JobsInDetail 
        {
            get 
            {
                if (jobsInDetail == null)
                {
                    jobsInDetail = ProgramDataModel.ProgramDataModelInstance.DetailedJobCollection;
                }
                return jobsInDetail;
            }
            set { jobsInDetail = value; }
        }
    }
}
