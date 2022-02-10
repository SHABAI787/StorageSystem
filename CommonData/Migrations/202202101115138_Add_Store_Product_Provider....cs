namespace CommonData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Store_Product_Provider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Person_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.Person_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Provider_Id = c.Int(),
                        State_Id = c.Int(),
                        Store_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.Provider_Id)
                .ForeignKey("dbo.ProductStates", t => t.State_Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .Index(t => t.Provider_Id)
                .Index(t => t.State_Id)
                .Index(t => t.Store_Id);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Responsible_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.Responsible_Id)
                .Index(t => t.Responsible_Id);
            
            CreateTable(
                "dbo.ProductStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.Products", "State_Id", "dbo.ProductStates");
            DropForeignKey("dbo.Products", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Providers", "Responsible_Id", "dbo.Persons");
            DropForeignKey("dbo.Orders", "Person_Id", "dbo.Persons");
            DropIndex("dbo.Providers", new[] { "Responsible_Id" });
            DropIndex("dbo.Products", new[] { "Store_Id" });
            DropIndex("dbo.Products", new[] { "State_Id" });
            DropIndex("dbo.Products", new[] { "Provider_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "Person_Id" });
            DropTable("dbo.Stores");
            DropTable("dbo.ProductStates");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
