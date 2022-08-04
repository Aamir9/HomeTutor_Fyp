namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add16 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TeacherTOAreas", name: "cityAra_Id", newName: "cityArea_Id");
            RenameIndex(table: "dbo.TeacherTOAreas", name: "IX_cityAra_Id", newName: "IX_cityArea_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TeacherTOAreas", name: "IX_cityArea_Id", newName: "IX_cityAra_Id");
            RenameColumn(table: "dbo.TeacherTOAreas", name: "cityArea_Id", newName: "cityAra_Id");
        }
    }
}
