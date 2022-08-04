namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class area7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tutors", "CityAreaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutors", "CityAreaId", c => c.Int(nullable: false));
        }
    }
}
