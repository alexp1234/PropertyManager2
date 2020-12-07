using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public double? Income { get; set; }
        public int? CreditScore { get; set; }
        public string BackgroundCheckResult { get; set; }
    }
}
