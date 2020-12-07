using PropertyManager.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Services.Property
{
    public interface IMaintenanceService
    {
        Task<List<MaintenanceRequest>> GetMaintenanceRequestsAll(string userId);
        Task<List<MaintenanceRequest>> GetMaintenanceRequestsByProperty(int propertyId);
        Task AddMaintenanceRequest(MaintenanceRequest service);
        Task RemoveMaintenanceService(int serviceId);
        Task<List<MaintenanceRequest>> GetMaintenanceRequestsByStatus(string status, string userId);

        Task<List<MaintenanceRequest>> GetRoutineMaintenanceRequestsAll(string userId);
        Task<List<MaintenanceRequest>> GetMaintenceRequestsByProperty(int propertyId);
        Task AddRoutineMaintenanceRequest(MaintenanceRequest request);
        Task UpdateMaintenceRequest(object request);
        MaintenanceRequest GetMaintenanceRequestByResponseCode(Guid responseCode);

    }
}
