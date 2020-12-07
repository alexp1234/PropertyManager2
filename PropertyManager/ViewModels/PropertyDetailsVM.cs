using PropertyManager.Models;
using PropertyManager.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.ViewModels
{
    public class PropertyDetailsVM
    {
        public InvestmentProperty Property { get; set; }
        public List<MaintenanceRequest> MaintenanceRequests { get; set; }
        public List<ServiceProvider> ServiceProviders { get; set; }
        public string UserEmail { get; set; }
    }
}
