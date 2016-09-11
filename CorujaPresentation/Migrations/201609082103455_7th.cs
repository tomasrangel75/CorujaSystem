namespace CorujaPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7th : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RegisterDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UpdateDate");
            DropColumn("dbo.AspNetUsers", "RegisterDate");
        }
    }
}
