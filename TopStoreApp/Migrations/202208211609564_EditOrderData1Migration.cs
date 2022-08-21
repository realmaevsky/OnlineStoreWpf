namespace TopStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderData1Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ResponsibleMngr_Id", "dbo.Managers");
            DropIndex("dbo.Orders", new[] { "ResponsibleMngr_Id" });
            DropColumn("dbo.Orders", "IsCompleted");
            DropColumn("dbo.Orders", "ResponsibleMngr_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ResponsibleMngr_Id", c => c.Int());
            AddColumn("dbo.Orders", "IsCompleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Orders", "ResponsibleMngr_Id");
            AddForeignKey("dbo.Orders", "ResponsibleMngr_Id", "dbo.Managers", "Id");
        }
    }
}
