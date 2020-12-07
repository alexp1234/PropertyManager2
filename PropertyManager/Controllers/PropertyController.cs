using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManager.Services;
using PropertyManager.Services.Property;
using PropertyManager.ViewModels;

namespace PropertyManager.Controllers
{
    [Authenticate]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IServiceProviderService _serviceProviderService;
        private readonly IMaintenanceService _maintenanceService;
        public PropertyController(IPropertyService propertyService, IServiceProviderService serviceProviderService, IMaintenanceService maintenanceService)
        {
            _propertyService = propertyService;
            _serviceProviderService = serviceProviderService;
            _maintenanceService = maintenanceService;
        }
        public async Task<IActionResult> Details(int propertyId)
        {
            var model = new PropertyDetailsVM();
            model.Property = await _propertyService.GetProperty(propertyId);
            model.ServiceProviders = _serviceProviderService.GetServiceProvidersByProperty(propertyId);
            model.MaintenanceRequests = await _maintenanceService.GetMaintenanceRequestsByProperty(propertyId);
            model.UserEmail = User.Identity.Name;
            if(model.Property != null && model.Property.UserId == User.Identity.Name && model.ServiceProviders != null && model.MaintenanceRequests != null)
            {
                return View(model);
            }
            
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
