namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class city2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Tutor_TutorId", "dbo.Tutors");
            DropIndex("dbo.Cities", new[] { "Tutor_TutorId" });
            DropColumn("dbo.Cities", "Tutor_TutorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "Tutor_TutorId", c => c.Int());
            CreateIndex("dbo.Cities", "Tutor_TutorId");
            AddForeignKey("dbo.Cities", "Tutor_TutorId", "dbo.Tutors", "TutorId");
        }
    }
}
