namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productsfixed4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "latitude", c => c.String());
            DropColumn("dbo.Stores", "latitdue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "latitdue", c => c.String());
            DropColumn("dbo.Stores", "latitude");
        }
    }
}
