namespace EF_CodeFirst_StudentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YasEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Yas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Yas");
        }
    }
}
