using DrugManagementWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Data
{
    public class ApplicationContext: IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<UsageConditionDrug> UsageConditionDrugs { get; set; }
        public virtual DbSet<ReactionAgent> ReactionAgents { get; set; }
        public virtual DbSet<AllergicSymptom> AllergicSymptoms { get; set; }
        public virtual DbSet<AntiAllergicDrug> AntiAllergicDrugs { get; set; }
        public virtual DbSet<ConditionDetail> ConditionDetails { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<AntiAllergicDrugSymptom> AntiAllergicDrugSymptoms { get; set; }
        public DbSet<DrugManagementWebApp.Models.DrugTrailDetail> DrugTrailDetail { get; set; }

    }
}
