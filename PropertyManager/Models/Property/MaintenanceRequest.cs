using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Models.Property
{
    public class MaintenanceRequest
    {
        public Guid Id { get; set; }
        public string SubmitterEmail { get; set; }
        public int PropertyId { get; set; }
        public string Priority { get; set; }
        public string PropertyOwnerId { get; set; }
        public string MaintenanceType { get; set; }
        public string FullDescription { get; set; }
        public string CompanyUsed { get; set; }
        public string CompanyEmail { get; set; }
        public string Status { get; set; }
        public double? Cost { get; set; }
        public DateTime RequestSentDate { get; set; }
        public DateTime? ResponseTime { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public Guid ResponseCode { get; set; }
        
    }
}
