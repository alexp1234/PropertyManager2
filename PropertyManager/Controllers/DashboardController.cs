using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManager.Services;

namespace PropertyManager.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IPropertyService _propertyService;
        public DashboardController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        // Dashboard summary page
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Properties()
        {
            var user = User.Identity;
            var properties = _propertyService.GetUserProperties(User.Identity.Name);
            return View(properties);
        }
    }
}
