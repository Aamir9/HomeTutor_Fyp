namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class area4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.City_areas", newName: "CityAreas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CityAreas", newName: "City_areas");
        }
    }
}
