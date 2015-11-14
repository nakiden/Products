namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "brand", c => c.String());
            AddColumn("dbo.Products", "publisher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "publisher");
            DropColumn("dbo.Products", "brand");
        }
    }
}
