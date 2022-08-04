namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "CityAreas_id", c => c.Int(nullable: true));
            CreateIndex("dbo.Tutors", "CityAreas_id");
            AddForeignKey("dbo.Tutors", "CityAreas_id", "dbo.CityAreas", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "CityAreas_id", "dbo.CityAreas");
            DropIndex("dbo.Tutors", new[] { "CityAreas_id" });
            DropColumn("dbo.Tutors", "CityAreas_id");
        }
    }
}
