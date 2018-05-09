using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Common
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("HMS")
        { }

        #region DbSet/Table Definitions  
        /// <summary>
        /// UserTypes Table
        /// </summary>
        public DbSet<UserType> UserTypes  { get; set; }

        /// <summary>
        /// Specialitys Table
        /// </summary>
        public DbSet<Speciality> Specialitys { get; set; }

        /// <summary>
        /// DoctorDetails Table
        /// </summary>
        public DbSet<DoctorDetails> DoctorDetails { get; set; }

        /// <summary>
        /// UserManagements Table
        /// </summary>
        public DbSet<UserManagement> UserManagements { get; set; }

        /// <summary>
        /// PatientDetails Table
        /// </summary>
        public DbSet<PatientDetails> PatientDetails { get; set; }

        /// <summary>
        /// DoctorPatientMappings Table
        /// </summary>
        public DbSet<DoctorPatientMapping> DoctorPatientMappings { get; set; }

        #endregion

        /// <summary>
        /// If there are any custom rules need to be added after Model creation, this method helps to do that
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}