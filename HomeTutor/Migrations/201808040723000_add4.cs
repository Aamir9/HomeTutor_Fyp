namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tutors", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutors", "ImagePath", c => c.String());
        }
    }
}
