namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsfixedProductPriceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "productPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "productPrice");
        }
    }
}
