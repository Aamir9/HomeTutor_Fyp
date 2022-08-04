namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class area8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tutors", "Areas_Id", "dbo.CityAreas");
            DropIndex("dbo.Tutors", new[] { "Areas_Id" });
            RenameColumn(table: "dbo.Tutors", name: "Areas_Id", newName: "CityAreas_id");
            AlterColumn("dbo.Tutors", "CityAreas_id", c => c.Int(nullable: true));
            CreateIndex("dbo.Tutors", "CityAreas_id");
            AddForeignKey("dbo.Tutors", "CityAreas_id", "dbo.CityAreas", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "CityAreas_id", "dbo.CityAreas");
            DropIndex("dbo.Tutors", new[] { "CityAreas_id" });
            AlterColumn("dbo.Tutors", "CityAreas_id", c => c.Int());
            RenameColumn(table: "dbo.Tutors", name: "CityAreas_id", newName: "Areas_Id");
            CreateIndex("dbo.Tutors", "Areas_Id");
            AddForeignKey("dbo.Tutors", "Areas_Id", "dbo.CityAreas", "Id");
        }
    }
}
