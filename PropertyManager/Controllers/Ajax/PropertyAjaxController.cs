using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManager.Models;
using PropertyManager.Models.Property;
using PropertyManager.Services;

namespace PropertyManager.Controllers.Ajax
{
    // this layer will be replaced with azure functions
    [Authorize]
    public class PropertyAjaxController : Controller
    {
        private readonly IPropertyService _propertyService;
        public PropertyAjaxController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        [Authorize]
        public async Task SavePropertyFromForm(double? purchasePrice, double? currentMarketValue, 
            string state, string city, string streetAddress, string propertyType, DateTime? purchaseDate,
            int? currentRentPerMonth, int? marketRentsPerMonth, bool isVacant)
        {
            var property = new InvestmentProperty();
            property.UserId = User.Identity.Name;
            property.PurchasePrice = purchasePrice;
            property.CurrentMarketValue = currentMarketValue;
            property.State = state;
            property.City = city;
            property.StreetAddress = streetAddress;
            property.PropertyType = propertyType;
            property.PurchaseDate = purchaseDate;
            property.CurrentRentPerMonth = currentRentPerMonth;
            property.MarketRentPerMonth = marketRentsPerMonth;
            property.IsVacant = isVacant;
            // TODO: Calculate months owned for each property
            await _propertyService.AddProperty(property);
        }

        [HttpPost]
        [Authorize]
        public async Task DeleteUserProperty(int propertyId)
        {
            var property = await _propertyService.GetProperty(propertyId);
            // check to make sure user owns this property
            if(property != null && property.UserId == User.Identity.Name)
            {
                await _propertyService.RemoveProperty(propertyId);
            }
            else if(property != null && property.UserId != User.Identity.Name)
            {
                throw new Exception("401. You are not authorized to remove this property.");
            }
            else if(property == null)
            {
                throw new Exception("Error. Something went wrong.");
            }
        }


    }
}
