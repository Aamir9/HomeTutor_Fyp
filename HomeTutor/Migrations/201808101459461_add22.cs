namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "LevelOfTaught", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "LevelOfTaught");
        }
    }
}
