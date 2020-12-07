using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManager.Models.Property
{
    public class PropertyLoan
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public double InitialAmount { get; set; }
        public double CurrentBalance { get; set; }
        public double InterestRate { get; set; }
        public string LoanType { get; set; }
        public string LenderName { get; set; }
        public int LoanTermInMonths { get; set; }
        public DateTime LoanOpenDate { get; set; }
        public DateTime LoanMaturityDate { get; set; }
        public DateTime AmountDueAtMaturity { get; set; }
    }
}
