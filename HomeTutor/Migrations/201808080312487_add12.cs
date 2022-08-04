namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Email = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 16),
                        Password = c.String(nullable: false, maxLength: 100),
                        Qualification = c.String(nullable: false),
                        Institute = c.String(nullable: false),
                        SecondQualification = c.String(nullable: false),
                        SecondInstitute = c.String(),
                        AboutMe = c.String(nullable: false),
                        TutoringType = c.String(nullable: false),
                        SkypId = c.String(),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Expertise = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
