namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        EmailId = c.String(nullable: false, maxLength: 128),
                        SpecialityId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId)
                .Index(t => t.SpecialityId);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorPatientMappings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PatientDetailsId = c.Guid(nullable: false),
                        DoctorDetailsId = c.Guid(nullable: false),
                        FromDateTime = c.DateTime(nullable: false),
                        ToDateTime = c.DateTime(nullable: false),
                        IsCancelled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorDetails", t => t.DoctorDetailsId)
                .ForeignKey("dbo.PatientDetails", t => t.PatientDetailsId)
                .Index(t => t.PatientDetailsId)
                .Index(t => t.DoctorDetailsId);
            
            CreateTable(
                "dbo.PatientDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Age = c.Int(nullable: false),
                        Gender = c.String(maxLength: 6),
                        UserTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserManagements",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 255),
                        UserTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserManagements", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.DoctorPatientMappings", "PatientDetailsId", "dbo.PatientDetails");
            DropForeignKey("dbo.PatientDetails", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.DoctorPatientMappings", "DoctorDetailsId", "dbo.DoctorDetails");
            DropForeignKey("dbo.DoctorDetails", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.UserManagements", new[] { "UserTypeId" });
            DropIndex("dbo.UserManagements", new[] { "UserName" });
            DropIndex("dbo.PatientDetails", new[] { "UserTypeId" });
            DropIndex("dbo.DoctorPatientMappings", new[] { "DoctorDetailsId" });
            DropIndex("dbo.DoctorPatientMappings", new[] { "PatientDetailsId" });
            DropIndex("dbo.DoctorDetails", new[] { "SpecialityId" });
            DropTable("dbo.UserManagements");
            DropTable("dbo.UserTypes");
            DropTable("dbo.PatientDetails");
            DropTable("dbo.DoctorPatientMappings");
            DropTable("dbo.Specialities");
            DropTable("dbo.DoctorDetails");
        }
    }
}
