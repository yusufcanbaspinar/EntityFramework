namespace EF_CodeFirst_StudentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class_",
                c => new
                    {
                        Class_ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Class_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        TCID = c.Long(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 80),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TCID)
                .ForeignKey("dbo.Class_", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Class_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Class_");
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Class_");
        }
    }
}
