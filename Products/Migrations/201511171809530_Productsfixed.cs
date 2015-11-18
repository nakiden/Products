namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productsfixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "Product_id", "dbo.Products");
            DropIndex("dbo.Stores", new[] { "Product_id" });
            DropColumn("dbo.Products", "storeLocation");
            DropColumn("dbo.Products", "storeName");
            DropColumn("dbo.Stores", "Product_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "Product_id", c => c.Int());
            AddColumn("dbo.Products", "storeName", c => c.String());
            AddColumn("dbo.Products", "storeLocation", c => c.String());
            CreateIndex("dbo.Stores", "Product_id");
            AddForeignKey("dbo.Stores", "Product_id", "dbo.Products", "id");
        }
    }
}
