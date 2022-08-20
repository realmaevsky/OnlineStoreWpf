namespace TopStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalCost1Migration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "TotalCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
