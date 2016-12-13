namespace sistemaLojasPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasIniciais : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avaliacao",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        LojaID = c.Int(nullable: false),
                        Avalicao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID)
                .ForeignKey("dbo.Loja", t => t.LojaID)
                .Index(t => t.ClienteID)
                .Index(t => t.LojaID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Loja",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        HorarioFuncionamento = c.String(maxLength: 100, unicode: false),
                        EnderecoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(maxLength: 100, unicode: false),
                        Cep = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Loja_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Loja", t => t.Loja_ID)
                .Index(t => t.Loja_ID);
            
            CreateTable(
                "dbo.LojaProduto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LojaID = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Loja", t => t.LojaID)
                .ForeignKey("dbo.Produto", t => t.ProdutoID)
                .Index(t => t.LojaID)
                .Index(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        CategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LojaProduto", "ProdutoID", "dbo.Produto");
            DropForeignKey("dbo.Produto", "CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.LojaProduto", "LojaID", "dbo.Loja");
            DropForeignKey("dbo.Endereco", "Loja_ID", "dbo.Loja");
            DropForeignKey("dbo.Avaliacao", "LojaID", "dbo.Loja");
            DropForeignKey("dbo.Avaliacao", "ClienteID", "dbo.Cliente");
            DropIndex("dbo.Produto", new[] { "CategoriaID" });
            DropIndex("dbo.LojaProduto", new[] { "ProdutoID" });
            DropIndex("dbo.LojaProduto", new[] { "LojaID" });
            DropIndex("dbo.Endereco", new[] { "Loja_ID" });
            DropIndex("dbo.Avaliacao", new[] { "LojaID" });
            DropIndex("dbo.Avaliacao", new[] { "ClienteID" });
            DropTable("dbo.Categoria");
            DropTable("dbo.Produto");
            DropTable("dbo.LojaProduto");
            DropTable("dbo.Endereco");
            DropTable("dbo.Loja");
            DropTable("dbo.Cliente");
            DropTable("dbo.Avaliacao");
        }
    }
}
