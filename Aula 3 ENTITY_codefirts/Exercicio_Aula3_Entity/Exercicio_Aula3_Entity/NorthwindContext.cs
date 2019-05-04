using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exercicio_Aula3_Entity
{
    public class NorthwindContext : DbContext
    {

        private const string Conexao = @"Data Source=DESKTOP-TACCAST; Initial Catalog=northwind; Integrated Security=True";

        public NorthwindContext() : base(Conexao) { }



        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //Incluir uma propriedade na classe NorthwindContext, retornando o
        //conjunto de fornecedores (DbSet);
        public DbSet<Fornecedor> Fornecedor { get; set; }



    }
}