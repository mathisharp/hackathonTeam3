using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Common
{
    public class DatabaseHelper : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var userTypes = new List<UserType>()
            {
                new UserType() {Id = Guid.NewGuid(), Description = "Admin"},
                new UserType() {Id = Guid.NewGuid(),Description = "Doctor"},
                new UserType() {Id = Guid.NewGuid(),Description = "Patient"}
            };

            userTypes.ForEach(x => context.UserTypes.Add(x));

            var speciality = new List<Speciality>()
            {
                new Speciality() {Id = Guid.NewGuid(), Description = "Cardio"},
                new Speciality() {Id = Guid.NewGuid(),Description = "surgeon"},
                new Speciality() {Id = Guid.NewGuid(),Description = "General physician"}
            };

            speciality.ForEach(x => context.Specialitys.Add(x));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}