namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "Expertise", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tutors", "Expertise");
        }
    }
}
