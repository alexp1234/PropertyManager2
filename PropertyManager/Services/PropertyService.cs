using PropertyManager.Data;
using PropertyManager.Models;
using PropertyManager.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Services
{
    // Replace this with calls to azure functions data access layer
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _propertyDb;
        public PropertyService(ApplicationDbContext propertyDb)
        {
            _propertyDb = propertyDb;
        }
        public async Task<InvestmentProperty> AddProperty(InvestmentProperty property)
        {
            await _propertyDb.Properties.AddAsync(property);
            await _propertyDb.SaveChangesAsync();
            return property;
        }

        public async Task<InvestmentProperty> GetProperty(int propertyId)
        {
            return await _propertyDb.Properties.FindAsync(propertyId);
        }

        public List<InvestmentProperty> GetUserProperties(string userName)
        {
            return _propertyDb.Properties.Where(m => m.UserId == userName).ToList();
        }

        public async Task RemoveProperty(int propertyId)
        {
            var property = _propertyDb.Properties.FirstOrDefault(m => m.Id == propertyId);
            _propertyDb.Properties.Remove(property);
            await _propertyDb.SaveChangesAsync();
        }
    }
}
