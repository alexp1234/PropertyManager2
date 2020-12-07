using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyManager.Models;
using PropertyManager.Models.Property;

namespace PropertyManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<InvestmentProperty> Properties { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
    }
}
