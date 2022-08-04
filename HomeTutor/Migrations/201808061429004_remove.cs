namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tutors", "CityAreas_id", "dbo.CityAreas");
            DropIndex("dbo.Tutors", new[] { "CityAreas_id" });
            DropColumn("dbo.Tutors", "CityAreas_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutors", "CityAreas_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tutors", "CityAreas_id");
            AddForeignKey("dbo.Tutors", "CityAreas_id", "dbo.CityAreas", "Id", cascadeDelete: true);
        }
    }
}
