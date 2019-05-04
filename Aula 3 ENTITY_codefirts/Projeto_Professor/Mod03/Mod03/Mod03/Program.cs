using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Mod03
{
    [Table("Produtos")]
    public class Produto
    {
        public int ProdutoID { get; set; }
        
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public bool Ativo { get; set; }
        public DateTime DataValidade { get; set; }

        public Categoria Categoria { get; set; }

        //public string TipoProd { get; set; }
    }

    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }

        public List<Produto> Produtos { get; set; }
    }

    public class LojaContext : DbContext
    {
        public LojaContext()
        {

        }

        public LojaContext(string conexao):base(conexao)
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Produto>()
        //        .Property(d => d.Nome)
        //        .IsRequired();
        //}  

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stringConexao = @"Data Source=DESKTOP-TACCAST; Initial Catalog=EF; Integrated Security=true;";

            
            var db = new LojaContext(stringConexao);            

            //foreach (var item in db.Categorias)
            //{
            //    Console.WriteLine(@"Categoria = {0}", item.Nome);
                
            //    item.Nome = "Livros";
            //}

            //db.SaveChanges(); 

            //Console.ReadKey();

            // Criar nova categoria
            var NovaCategoria = new Categoria() { Nome = "Eletrodomésticos 02" };

            db.Categorias.Add(NovaCategoria);

            db.SaveChanges(); 
        }
    }
}
