namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "Store_id", "dbo.Stores");
            DropIndex("dbo.Stores", new[] { "Store_id" });
            AddColumn("dbo.Stores", "latitdue", c => c.String());
            AddColumn("dbo.Stores", "longitude", c => c.String());
            AddColumn("dbo.Stores", "Product_id", c => c.Int());
            CreateIndex("dbo.Stores", "Product_id");
            AddForeignKey("dbo.Stores", "Product_id", "dbo.Products", "id");
            DropColumn("dbo.Stores", "storeName");
            DropColumn("dbo.Stores", "Store_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "Store_id", c => c.Int());
            AddColumn("dbo.Stores", "storeName", c => c.String());
            DropForeignKey("dbo.Stores", "Product_id", "dbo.Products");
            DropIndex("dbo.Stores", new[] { "Product_id" });
            DropColumn("dbo.Stores", "Product_id");
            DropColumn("dbo.Stores", "longitude");
            DropColumn("dbo.Stores", "latitdue");
            CreateIndex("dbo.Stores", "Store_id");
            AddForeignKey("dbo.Stores", "Store_id", "dbo.Stores", "id");
        }
    }
}
