namespace CorujaPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4th : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AddressDetail", c => c.String());
            DropColumn("dbo.AspNetUsers", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            DropColumn("dbo.AspNetUsers", "AddressDetail");
        }
    }
}
