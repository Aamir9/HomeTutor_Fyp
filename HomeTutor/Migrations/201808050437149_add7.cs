namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tutors", "city_Id", "dbo.Cities");
            DropIndex("dbo.Tutors", new[] { "city_Id" });
            RenameColumn(table: "dbo.Tutors", name: "city_Id", newName: "CityId");
            AlterColumn("dbo.Tutors", "CityId", c => c.Int(nullable: true));
            CreateIndex("dbo.Tutors", "CityId");
            AddForeignKey("dbo.Tutors", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "CityId", "dbo.Cities");
            DropIndex("dbo.Tutors", new[] { "CityId" });
            AlterColumn("dbo.Tutors", "CityId", c => c.Int());
            RenameColumn(table: "dbo.Tutors", name: "CityId", newName: "city_Id");
            CreateIndex("dbo.Tutors", "city_Id");
            AddForeignKey("dbo.Tutors", "city_Id", "dbo.Cities", "Id");
        }
    }
}
