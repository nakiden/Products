namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productsfixed5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "Product_id", "dbo.Products");
            DropIndex("dbo.Stores", new[] { "Product_id" });
            AddColumn("dbo.Stores", "Product_id1", c => c.Int());
            AlterColumn("dbo.Stores", "Product_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Stores", "Product_id1");
            AddForeignKey("dbo.Stores", "Product_id1", "dbo.Products", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "Product_id1", "dbo.Products");
            DropIndex("dbo.Stores", new[] { "Product_id1" });
            AlterColumn("dbo.Stores", "Product_id", c => c.Int());
            DropColumn("dbo.Stores", "Product_id1");
            CreateIndex("dbo.Stores", "Product_id");
            AddForeignKey("dbo.Stores", "Product_id", "dbo.Products", "id");
        }
    }
}
