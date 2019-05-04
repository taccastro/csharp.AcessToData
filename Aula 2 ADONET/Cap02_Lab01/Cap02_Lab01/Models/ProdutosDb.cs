using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Cap02_Lab01.Models
{
    public class ProdutosDb
    {

        //
        // Categorias Lista
        // Retorna a lista de categorias de Produtos        
        public DataTable CategoriasLista()
        {
            string sql = @"SELECT CategoryId, CategoryName FROM Categories";
            var da = new SqlDataAdapter(sql, NorthwindDb.Conexao);
            var tb = new DataTable();
            da.Fill(tb);
            return tb;
        }


        //Obter Fornecedores
        public DataTable ObterFornec()
        {
            string sql = @"SELECT SupplierId, CompanyName FROM Suppliers";
            var da = new SqlDataAdapter(sql, NorthwindDb.Conexao);
            var tb = new DataTable();
            da.Fill(tb);
            return tb;
        }



        //produtos por fornecedores
        public DataTable ProdutosPorFornecedores(int categoriaId)
        {
            string sql = @"SELECT ProductName, UnitPrice, UnitsInStock FROM Products WHERE SupplierId=@SupplierId";
            var da = new SqlDataAdapter(sql, NorthwindDb.Conexao);
            da.SelectCommand
            .Parameters
            .AddWithValue("@SupplierId", categoriaId);
            var tb = new DataTable();
            da.Fill(tb);
            return tb;
        }



        //método que retorne a lista de produtos de uma categoria
        public DataTable ProdutosPorCategoria(int categoriaId)
        {
            string sql = @"SELECT ProductName, UnitPrice, UnitsInStock FROM Products WHERE CategoryId=@CategoryId";
            var da = new SqlDataAdapter(sql, NorthwindDb.Conexao);
            da.SelectCommand
            .Parameters
            .AddWithValue("@CategoryId", categoriaId);
            var tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

    }
}