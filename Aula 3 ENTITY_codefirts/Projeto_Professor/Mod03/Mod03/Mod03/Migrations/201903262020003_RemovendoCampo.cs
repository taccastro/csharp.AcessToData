namespace Mod03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoCampo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estoque = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataValidade = c.DateTime(nullable: false),
                        Categoria_CategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaID)
                .Index(t => t.Categoria_CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaID" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Categorias");
        }
    }
}
