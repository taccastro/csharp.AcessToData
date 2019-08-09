using System.Collections.Generic;
using System.Linq;

namespace Cap09_lab01.Models
{
    public static class NorthwindDb
    {
        public static List<Categories> CategoriasLista()
        {
            using (var db = new NorthwindEntities()) { return db.Categories.ToList(); }
        }

        public static List<Suppliers> FornecedoresPorCategoria(int categoriaId)
        {
            using (var db = new NorthwindEntities())

            {
                var queryProd = from p in db.Products
                                where p.CategoryID == categoriaId
                                select p.SupplierID;

                var query = from s in db.Suppliers
                            where queryProd.ToList().Contains(s.SupplierID)
                            select s;

                return query.ToList();
            }
        }

        public static List<Products> ProdutosPorFornecedor(int fornecedorId)
        {
            using (var db = new NorthwindEntities())
            {
                var query = from p in db.Products
                            where p.SupplierID == fornecedorId
                            select p;

                return query.ToList();
            }
        }

    }
}