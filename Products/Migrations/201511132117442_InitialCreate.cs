namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        barcode = c.String(),
                        storeLocation = c.String(),
                        storeName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        storeLocation = c.String(),
                        storeName = c.String(),
                        Store_id = c.Int(),
                        Product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Stores", t => t.Store_id)
                .ForeignKey("dbo.Products", t => t.Product_id)
                .Index(t => t.Store_id)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Stores", "Store_id", "dbo.Stores");
            DropIndex("dbo.Stores", new[] { "Product_id" });
            DropIndex("dbo.Stores", new[] { "Store_id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
        }
    }
}
