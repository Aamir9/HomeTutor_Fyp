namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tutors", "ImagePath");
        }
    }
}
