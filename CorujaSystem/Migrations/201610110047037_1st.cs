namespace CorujaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Especialists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        EspecName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pontuacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdQuestion = c.Int(nullable: false),
                        Correct = c.Boolean(nullable: false),
                        Attempt = c.Int(nullable: false),
                        TimeForQest = c.String(),
                        Mouse = c.String(),
                        Clicks = c.String(),
                        DtTime = c.DateTime(),
                        idPerson = c.Int(nullable: false),
                        PersonTested_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.PersonTested_Id)
                .Index(t => t.PersonTested_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                        BirthDate = c.DateTime(),
                        Gender = c.String(),
                        DtRegister = c.String(),
                        idEspec = c.Int(nullable: false),
                        Espec_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especialists", t => t.Espec_Id)
                .Index(t => t.Espec_Id);
            
            CreateTable(
                "dbo.ReportKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyCode = c.String(),
                        ReportNumber = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ActivationDate = c.DateTime(),
                        KeyType = c.String(),
                        UserMapK_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserMapKeys", t => t.UserMapK_Id)
                .Index(t => t.UserMapK_Id);
            
            CreateTable(
                "dbo.UserMapKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RptName = c.String(),
                        RptType = c.String(),
                        DtCreated = c.DateTime(nullable: false),
                        IdFile = c.Int(nullable: false),
                        RptFileResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserFiles", t => t.RptFileResult_Id)
                .Index(t => t.RptFileResult_Id);
            
            CreateTable(
                "dbo.UserFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        FileType = c.String(),
                        Name = c.String(),
                        Local = c.String(),
                        Extension = c.String(),
                        Size = c.String(),
                        Desc = c.String(),
                        DtUpload = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestName = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        EvtType = c.String(),
                        Desc = c.String(),
                        EvtDt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdUser = c.Int(nullable: false),
                        RegisterDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        LastLogin = c.DateTime(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(),
                        Cpf = c.String(),
                        Rg = c.String(),
                        Graduation = c.String(),
                        Cep = c.String(),
                        Address = c.String(),
                        AddressNumber = c.String(),
                        AddressDetail = c.String(),
                        Nhood = c.String(),
                        City = c.String(),
                        State = c.String(),
                        NewsLetter = c.Boolean(nullable: false),
                        CellPhoneNumber = c.String(),
                        UsedReport = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reports", "RptFileResult_Id", "dbo.UserFiles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ReportKeys", "UserMapK_Id", "dbo.UserMapKeys");
            DropForeignKey("dbo.Pontuacaos", "PersonTested_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Espec_Id", "dbo.Especialists");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Reports", new[] { "RptFileResult_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ReportKeys", new[] { "UserMapK_Id" });
            DropIndex("dbo.Students", new[] { "Espec_Id" });
            DropIndex("dbo.Pontuacaos", new[] { "PersonTested_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserActions");
            DropTable("dbo.Tests");
            DropTable("dbo.UserFiles");
            DropTable("dbo.Reports");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserMapKeys");
            DropTable("dbo.ReportKeys");
            DropTable("dbo.Students");
            DropTable("dbo.Pontuacaos");
            DropTable("dbo.Especialists");
        }
    }
}
