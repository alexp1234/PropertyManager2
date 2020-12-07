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
    public class RespondToServiceRequestController : Controller
    {
        // THIS IS A PERFECT ACTION TO MOVE TO AZURE FUNCTIONS
        private readonly IMaintenanceService _maintenanceService;
        private readonly IPropertyService _propertyService;
        public RespondToServiceRequestController(IMaintenanceService maintenanceService, IPropertyService propertyService)
        {
            _maintenanceService = maintenanceService;
            _propertyService = propertyService;
        }
        // returns isolated view of service request
        public async Task<IActionResult> Index(Guid responseCode)
        {
            var response =  _maintenanceService.GetMaintenanceRequestByResponseCode(responseCode);
            var property =  await _propertyService.GetProperty(response.PropertyId);
            var model = new ServiceResponseViewModel();
            model.ProblemCategory = response.MaintenanceType;
            model.ProblemFullDescription = response.FullDescription;
            model.PropertyAddress = property.StreetAddress + "," + Environment.NewLine + property.City + ", " + property.State;
            model.RequestorEmail = property.UserId;
            model.RequestedDateAndTime = "Test Date And Time";
            return View(model);
        }
    }
}
