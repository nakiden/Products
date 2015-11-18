namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productsfixed6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Stores", new[] { "Product_id1" });
            DropColumn("dbo.Stores", "Product_id");
            RenameColumn(table: "dbo.Stores", name: "Product_id1", newName: "Product_id");
            AlterColumn("dbo.Stores", "Product_id", c => c.Int());
            CreateIndex("dbo.Stores", "Product_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Stores", new[] { "Product_id" });
            AlterColumn("dbo.Stores", "Product_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Stores", name: "Product_id", newName: "Product_id1");
            AddColumn("dbo.Stores", "Product_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Stores", "Product_id1");
        }
    }
}
