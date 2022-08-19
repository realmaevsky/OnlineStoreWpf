namespace TopStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        AccessLevel = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Online = c.Boolean(nullable: false),
                        OrdersInProgress = c.Int(nullable: false),
                        CompletedOrders = c.Int(nullable: false),
                        AccountInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AccountInfo_Id)
                .Index(t => t.AccountInfo_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsCompleted = c.Boolean(nullable: false),
                        Client_Id = c.Int(),
                        ResponsibleMngr_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Client_Id)
                .ForeignKey("dbo.Managers", t => t.ResponsibleMngr_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.ResponsibleMngr_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Memory = c.Short(nullable: false),
                        InStock = c.Boolean(nullable: false),
                        ImageSource = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Order_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ResponsibleMngr_Id", "dbo.Managers");
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Users");
            DropForeignKey("dbo.Managers", "AccountInfo_Id", "dbo.Users");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "ResponsibleMngr_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropIndex("dbo.Managers", new[] { "AccountInfo_Id" });
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Managers");
            DropTable("dbo.Users");
        }
    }
}
