namespace CorujaPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6th : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IdUser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IdUser");
        }
    }
}
