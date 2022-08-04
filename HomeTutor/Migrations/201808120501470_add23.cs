namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "CityId", c => c.Int(nullable: true));
            CreateIndex("dbo.Teachers", "CityId");
            AddForeignKey("dbo.Teachers", "CityId", "dbo.Cities", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "CityId", "dbo.Cities");
            DropIndex("dbo.Teachers", new[] { "CityId" });
            DropColumn("dbo.Teachers", "CityId");
        }
    }
}
