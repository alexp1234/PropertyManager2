using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int?  PropertyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
    }
}
