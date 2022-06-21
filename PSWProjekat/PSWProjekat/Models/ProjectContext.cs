using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PSWProjekat.Configuration;

namespace PSWProjekat.Models
{
    public class ProjectContext : DbContext
    {
        public static ProjectConfiguration Configuration;

        public ProjectContext(DbContextOptions<ProjectContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                Configuration = configuration;
            }
        }

        public ProjectContext()
        {
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entires = ChangeTracker.
                Entries().
                Where(e => e.Entity is Entity &&
                (e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (EntityEntry entityEntry in entires)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).Deleted = false;


                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Pharmacy> Pharmacys { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Procurement> Procurements { get; set; }
        public DbSet<Refferal> Refferals { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionMedicine { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            
            optionsBuilder.UseSqlServer("data source=localhost; Initial Catalog=psw;Integrated Security=True;");
        }
    }
}

