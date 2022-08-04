namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class area6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "CityAreaId", c => c.Int(nullable: false));
            AddColumn("dbo.Tutors", "Areas_Id", c => c.Int());
            CreateIndex("dbo.Tutors", "Areas_Id");
            AddForeignKey("dbo.Tutors", "Areas_Id", "dbo.CityAreas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "Areas_Id", "dbo.CityAreas");
            DropIndex("dbo.Tutors", new[] { "Areas_Id" });
            DropColumn("dbo.Tutors", "Areas_Id");
            DropColumn("dbo.Tutors", "CityAreaId");
        }
    }
}
