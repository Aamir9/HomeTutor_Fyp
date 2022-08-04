namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class city : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tutors", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutors", "City", c => c.String(nullable: false));
        }
    }
}
