namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherTOAreas", "cityArea_Id", "dbo.CityAreas");
            DropIndex("dbo.TeacherTOAreas", new[] { "cityArea_Id" });
            RenameColumn(table: "dbo.TeacherTOAreas", name: "cityArea_Id", newName: "CityAreasId");
            AlterColumn("dbo.TeacherTOAreas", "CityAreasId", c => c.Int(nullable: false));
            CreateIndex("dbo.TeacherTOAreas", "CityAreasId");
            AddForeignKey("dbo.TeacherTOAreas", "CityAreasId", "dbo.CityAreas", "Id", cascadeDelete: true);
            DropColumn("dbo.TeacherTOAreas", "CityAreraId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeacherTOAreas", "CityAreraId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TeacherTOAreas", "CityAreasId", "dbo.CityAreas");
            DropIndex("dbo.TeacherTOAreas", new[] { "CityAreasId" });
            AlterColumn("dbo.TeacherTOAreas", "CityAreasId", c => c.Int());
            RenameColumn(table: "dbo.TeacherTOAreas", name: "CityAreasId", newName: "cityArea_Id");
            CreateIndex("dbo.TeacherTOAreas", "cityArea_Id");
            AddForeignKey("dbo.TeacherTOAreas", "cityArea_Id", "dbo.CityAreas", "Id");
        }
    }
}
