namespace HomeTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherToCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherToCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherToCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.TeacherToCourses", new[] { "TeacherId" });
            DropIndex("dbo.TeacherToCourses", new[] { "CourseId" });
            DropTable("dbo.TeacherToCourses");
        }
    }
}
