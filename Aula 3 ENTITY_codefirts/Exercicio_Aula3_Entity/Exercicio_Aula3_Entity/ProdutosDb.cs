using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercicio_Aula3_Entity
{
    public class ProdutosDb
    {
        //
        // CategoriasLista
        // Retorna a lista de Categorias
        //
        //
        public List<Categoria> CategoriasLista()
        {
            using (var db = new NorthwindContext())
            {
                return db.Categorias.ToList();
            }
        }


        //
        //Produtos por Categoria
        // retorna uma lista de produtos de uma categoria
        //
        public List<Produto> ProdutosPorCategoria(int categoriaId)
        {
            using (var db = new NorthwindContext())
            {
                var query = from c in db.Produtos
                            where c.CategoriaId == categoriaId
                            select c;
                var lista = query.ToList();
                return lista;
            }
        }




        //•• Incluir um método para obter a lista de fornecedores na classe ProdutosDb;
        public List<Fornecedor> FornecedorLista()
        {
            using (var db = new NorthwindContext())
            {
                return db.Fornecedor.ToList();
            }
        }

        //•• Incluir um método para obter a lista de produtos de um fornecedor na
        //classe ProdutosDb;
        public List<Produto> ProdutosPorFornecedor(int SupplierID)
        {
            using (var db = new NorthwindContext())
            {
                var query = from c in db.Produtos
                            where c.SupplierID == SupplierID
                            select c;
                var lista2 = query.ToList();
                return lista2;
            }
        }




    }
}