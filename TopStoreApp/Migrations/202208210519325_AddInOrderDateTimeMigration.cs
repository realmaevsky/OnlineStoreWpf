namespace TopStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInOrderDateTimeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
