namespace EF_CodeFirst_FaturaProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OriginalDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        CountyID = c.Int(nullable: false, identity: true),
                        CountyName = c.String(),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountyID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CountyID = c.Int(nullable: false),
                        Adrress = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Counties", t => t.CountyID, cascadeDelete: true)
                .Index(t => t.CountyID);
            
            CreateTable(
                "dbo.InvoiceHeaders",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceDateTime = c.DateTime(nullable: false),
                        DeliveryNoteNumber = c.Int(nullable: false),
                        PaymentDateTime = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                        VATAmount = c.Int(nullable: false),
                        TotalAmountWithVAT = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.InvoiceID, t.ProductID })
                .ForeignKey("dbo.InvoiceHeaders", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductNumber = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Units", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.UnitID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                    })
                .PrimaryKey(t => t.UnitID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UnitID", "dbo.Units");
            DropForeignKey("dbo.InvoiceDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceID", "dbo.InvoiceHeaders");
            DropForeignKey("dbo.InvoiceHeaders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CountyID", "dbo.Counties");
            DropForeignKey("dbo.Counties", "CityID", "dbo.Cities");
            DropIndex("dbo.Products", new[] { "UnitID" });
            DropIndex("dbo.InvoiceDetails", new[] { "ProductID" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceID" });
            DropIndex("dbo.InvoiceHeaders", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "CountyID" });
            DropIndex("dbo.Counties", new[] { "CityID" });
            DropTable("dbo.Units");
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.InvoiceHeaders");
            DropTable("dbo.Customers");
            DropTable("dbo.Counties");
            DropTable("dbo.Cities");
        }
    }
}
