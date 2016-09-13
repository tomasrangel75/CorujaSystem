namespace CorujaPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8th : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastLogin");
        }
    }
}
