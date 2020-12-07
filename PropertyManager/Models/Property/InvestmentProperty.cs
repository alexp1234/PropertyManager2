using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Models.Property
{
    public class InvestmentProperty
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double? PurchasePrice { get; set; }
        public double? CurrentMarketValue { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string PropertyType { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double? MonthsOwned { get; set; }
        public int? CurrentRentPerMonth { get; set; }
        public int? MarketRentPerMonth { get; set; }
        public bool IsVacant { get; set; }
        // public List<Applicant> Applicants { get; set; }
        //  public List<Expense> Expenses { get; set; }
       // public List<ServiceProvider> ServiceProviders { get; set; }
    }
}
