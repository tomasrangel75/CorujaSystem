namespace CorujaPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        FileType = c.String(),
                        Name = c.String(),
                        Local = c.String(),
                        Extensao = c.String(),
                        Tamanho = c.String(),
                        Descricao = c.String(),
                        DtUpload = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserFiles");
        }
    }
}
