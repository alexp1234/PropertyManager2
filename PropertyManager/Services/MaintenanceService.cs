using PropertyManager.Data;
using PropertyManager.Models.Property;
using PropertyManager.Services.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly ApplicationDbContext _context;
        public MaintenanceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddMaintenanceRequest(MaintenanceRequest request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task AddRoutineMaintenanceRequest(MaintenanceRequest request)
        {
            await _context.MaintenanceRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MaintenanceRequest>> GetMaintenanceRequestsAll(string userId)
        {
            List<MaintenanceRequest> requests = new List<MaintenanceRequest>();
            await Task.Run(() =>
            {
                requests = _context.MaintenanceRequests.Where(m => m.PropertyOwnerId == userId).ToList();
            });
            return requests;
        }

        public async Task<List<MaintenanceRequest>> GetMaintenanceRequestsByProperty(int propertyId)
        {
            List<MaintenanceRequest> requests = new List<MaintenanceRequest>();
            await Task.Run(() =>
            {
                requests = _context.MaintenanceRequests.Where(m => m.PropertyId == propertyId).ToList();
            });
            return requests;
        }

        public async Task<List<MaintenanceRequest>> GetMaintenanceRequestsByStatus(string status, string userId)
        {
            List<MaintenanceRequest> requests = new List<MaintenanceRequest>();
            await Task.Run(() =>
            {
                requests = _context.MaintenanceRequests.Where(m => m.PropertyOwnerId == userId && m.Status == status).ToList();
            });
            return requests;
        }

        public Task<List<MaintenanceRequest>> GetMaintenceRequestsByProperty(int propertyId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MaintenanceRequest>> GetRoutineMaintenanceRequestsAll(string userId)
        {
            List<MaintenanceRequest> requests = new List<MaintenanceRequest>();
            await Task.Run(() => {
                requests = _context.MaintenanceRequests.Where(m => m.PropertyOwnerId == userId).ToList();
            });
            return requests;
        }

        public MaintenanceRequest GetMaintenanceRequestByResponseCode(Guid responseCode)
        {
            return  _context.MaintenanceRequests.FirstOrDefault(m => m.ResponseCode == responseCode);
            
        }

        public async Task RemoveMaintenanceService(int serviceId)
        {
            var request = await _context.MaintenanceRequests.FindAsync(serviceId);
            if(request != null){
                _context.MaintenanceRequests.Remove(request);
            }
        }

        public Task UpdateMaintenceRequest(object request)
        {
            throw new NotImplementedException();
        }
    }
}
