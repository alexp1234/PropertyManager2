using PropertyManager.Models;
using PropertyManager.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Services
{
    public interface IPropertyService
    {
        List<InvestmentProperty> GetUserProperties(string userName);
        Task<InvestmentProperty> AddProperty(InvestmentProperty property);
        Task RemoveProperty(int propertyId);
        Task<InvestmentProperty> GetProperty(int propertyId);


    }
}
