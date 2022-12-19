using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex_DAL.Entities;

namespace Vaultex_DAL.DBContext
{
    public class VaultexDBContext : DbContext
    {
        public VaultexDBContext(DbContextOptions<VaultexDBContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organisation> Organisations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Organisation)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.OrganisationNumber);

            modelBuilder.Entity<Organisation>().HasKey(e => e.OrganisationNumber);
        }
    }
}
