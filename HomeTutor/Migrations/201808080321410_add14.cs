namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherTOAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CityAreraId = c.Int(nullable: false),
                        cityAra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CityAreas", t => t.cityAra_Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.cityAra_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherTOAreas", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherTOAreas", "cityAra_Id", "dbo.CityAreas");
            DropIndex("dbo.TeacherTOAreas", new[] { "cityAra_Id" });
            DropIndex("dbo.TeacherTOAreas", new[] { "TeacherId" });
            DropTable("dbo.TeacherTOAreas");
        }
    }
}
