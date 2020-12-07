using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.ViewModels
{
    public class ServiceResponseViewModel
    {
        public string RequestorEmail { get; set; }
        public string ProblemCategory { get; set; }
        public string PropertyAddress { get; set; }
        public string ProblemFullDescription { get; set; }
        public string RequestedDateAndTime { get; set; }
        public string Priority { get; set; }
    }
}
