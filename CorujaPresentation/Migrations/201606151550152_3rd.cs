namespace CorujaPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Rg", c => c.String());
            AddColumn("dbo.AspNetUsers", "Graduation", c => c.String());
            AddColumn("dbo.AspNetUsers", "Cep", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nhood", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "NewsLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "CellPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CellPhoneNumber");
            DropColumn("dbo.AspNetUsers", "NewsLetter");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Nhood");
            DropColumn("dbo.AspNetUsers", "AddressNumber");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Cep");
            DropColumn("dbo.AspNetUsers", "Graduation");
            DropColumn("dbo.AspNetUsers", "Rg");
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
