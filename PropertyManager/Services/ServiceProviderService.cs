using PropertyManager.Data;
using PropertyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Services
{
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly ApplicationDbContext _context;
        public ServiceProviderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddServiceProvider(ServiceProvider provider)
        {
            await _context.ServiceProviders.AddAsync(provider);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiceProvider> GetServiceProviderByIdAsync(int serviceProviderId)
        {
            return  await _context.ServiceProviders.FindAsync(serviceProviderId);
        }

        public List<ServiceProvider> GetServiceProvidersByProperty(int propertyId)
        {
            return  _context.ServiceProviders.Where(m => m.PropertyId == propertyId).ToList();
        }

        public async Task RemoveServiceProvider(int providerId)
        {
            var provider = await _context.ServiceProviders.FindAsync(providerId);
            _context.ServiceProviders.Remove(provider);
            await _context.SaveChangesAsync();
        }

         
    }
}
