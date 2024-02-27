using DatabaseModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.DatabaseContext
{
    public class PatientInfoPortalDbContext:DbContext
    {
        public PatientInfoPortalDbContext(DbContextOptions<PatientInfoPortalDbContext> options):base(options)
        {
            
        }

        public DbSet<Allergy> tblAllergy { get; set; } = default!;
        public DbSet<Disease> tblDisease { get; set; } = default!;
        public DbSet<NCD> tblNCD { get; set; } = default!;
        public DbSet<Patient> tblPatient { get; set; } = default!;
        public DbSet<NCD_Details> tblNCD_Details { get; set; } = default!;
        public DbSet<Allergies_Details> tblAllergies_Details { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Disease>().HasData(
                new Disease { DiseaseId = 1, DiseaseName = "Diabetes" },
                new Disease { DiseaseId = 2, DiseaseName = "Hypertension" },
                new Disease { DiseaseId = 3, DiseaseName = "Arthritis" },
                new Disease { DiseaseId = 4, DiseaseName = "Heart Disease" },
                new Disease { DiseaseId = 5, DiseaseName = "Respiratory Infections" }
            );

            modelBuilder.Entity<NCD>().HasData(
                new NCD { NCD_Id = 1, NCD_Name = "Asthma" },
                new NCD { NCD_Id = 2, NCD_Name = "Cancer" },
                new NCD { NCD_Id = 3, NCD_Name = "Disorders of ear" },
                new NCD { NCD_Id = 4, NCD_Name = "Disorder of eye" },
                new NCD { NCD_Id = 5, NCD_Name = "Mental illness" }
            );

            modelBuilder.Entity<Allergy>().HasData(
                new Allergy { AllergyId = 1, AllergyName = "Drugs - Penicillin" },
                new Allergy { AllergyId = 2, AllergyName = "Drugs - Others" },
                new Allergy { AllergyId = 3, AllergyName = "Animals" },
                new Allergy { AllergyId = 4, AllergyName = "Food" },
                new Allergy { AllergyId = 5, AllergyName = "Ointments" },
                new Allergy { AllergyId = 6, AllergyName = "Plant" },
                new Allergy { AllergyId = 7, AllergyName = "Sprays" },
                new Allergy { AllergyId = 8, AllergyName = "Others" },
                new Allergy { AllergyId = 9, AllergyName = "No Allergies" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
