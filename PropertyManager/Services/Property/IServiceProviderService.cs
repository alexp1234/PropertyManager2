using PropertyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Services
{
    public interface IServiceProviderService
    {
        Task<ServiceProvider> GetServiceProviderByIdAsync(int servideProviderId);
        List<ServiceProvider> GetServiceProvidersByProperty(int propertyId);
        Task AddServiceProvider(ServiceProvider provider);
        Task RemoveServiceProvider(int providerId);
    }
}
