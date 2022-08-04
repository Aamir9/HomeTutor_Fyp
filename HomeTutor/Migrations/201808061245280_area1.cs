namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class area1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.City_areas", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.City_areas", "CityId");
            AddForeignKey("dbo.City_areas", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City_areas", "CityId", "dbo.Cities");
            DropIndex("dbo.City_areas", new[] { "CityId" });
            DropColumn("dbo.City_areas", "CityId");
        }
    }
}
