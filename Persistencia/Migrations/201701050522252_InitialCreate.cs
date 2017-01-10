namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Long(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Sobrenome = c.String(unicode: false),
                        Cpf = c.String(unicode: false),
                        Rg = c.String(unicode: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        CompraId = c.Long(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                        DataAquisicao = c.DateTime(nullable: false, precision: 0),
                        ClienteId = c.Long(),
                        PacoteId = c.Long(),
                    })
                .PrimaryKey(t => t.CompraId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Pacote", t => t.PacoteId)
                .Index(t => t.ClienteId)
                .Index(t => t.PacoteId);
            
            CreateTable(
                "dbo.Pacote",
                c => new
                    {
                        PacoteId = c.Long(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Descricao = c.String(unicode: false),
                        QuantidadeDias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PacoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compra", "PacoteId", "dbo.Pacote");
            DropForeignKey("dbo.Compra", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Compra", new[] { "PacoteId" });
            DropIndex("dbo.Compra", new[] { "ClienteId" });
            DropTable("dbo.Pacote");
            DropTable("dbo.Compra");
            DropTable("dbo.Cliente");
        }
    }
}
