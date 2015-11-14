namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "Product_id", "dbo.Products");
            DropIndex("dbo.Stores", new[] { "Product_id" });
            DropColumn("dbo.Stores", "Product_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "Product_id", c => c.Int());
            CreateIndex("dbo.Stores", "Product_id");
            AddForeignKey("dbo.Stores", "Product_id", "dbo.Products", "id");
        }
    }
}
