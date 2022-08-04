namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class city3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "city_Id", c => c.Int());
            CreateIndex("dbo.Tutors", "city_Id");
            AddForeignKey("dbo.Tutors", "city_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "city_Id", "dbo.Cities");
            DropIndex("dbo.Tutors", new[] { "city_Id" });
            DropColumn("dbo.Tutors", "city_Id");
        }
    }
}
