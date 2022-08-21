namespace TopStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBaseMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Managers", "AccountInfo_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Users");
            DropIndex("dbo.Managers", new[] { "AccountInfo_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            AddColumn("dbo.Orders", "ClientFirstName", c => c.String());
            AddColumn("dbo.Orders", "ClientLastName", c => c.String());
            AddColumn("dbo.Orders", "ClientPhoneNumber", c => c.String());
            AddColumn("dbo.Orders", "PaymentMethod", c => c.String());
            DropColumn("dbo.Managers", "AccountInfo_Id");
            DropColumn("dbo.Orders", "Client_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Client_Id", c => c.Int());
            AddColumn("dbo.Managers", "AccountInfo_Id", c => c.Int());
            DropColumn("dbo.Orders", "PaymentMethod");
            DropColumn("dbo.Orders", "ClientPhoneNumber");
            DropColumn("dbo.Orders", "ClientLastName");
            DropColumn("dbo.Orders", "ClientFirstName");
            CreateIndex("dbo.Orders", "Client_Id");
            CreateIndex("dbo.Managers", "AccountInfo_Id");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Managers", "AccountInfo_Id", "dbo.Users", "Id");
        }
    }
}
