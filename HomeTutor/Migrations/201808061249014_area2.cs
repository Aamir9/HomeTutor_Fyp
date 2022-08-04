namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class area2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "City_areas_Id", c => c.Int());
            CreateIndex("dbo.Tutors", "City_areas_Id");
            AddForeignKey("dbo.Tutors", "City_areas_Id", "dbo.City_areas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "City_areas_Id", "dbo.City_areas");
            DropIndex("dbo.Tutors", new[] { "City_areas_Id" });
            DropColumn("dbo.Tutors", "City_areas_Id");
        }
    }
}
