using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exercicio_Aula3_Entity
{
    [Table("Products", Schema = "dbo")]
    public class Produto
    {
        [Column("ProductId")]
        public int ProdutoId { get; set; }

        [Column("SupplierID")]
        public int SupplierID { get; set; }



        [Column("ProductName")]
        public string Nome { get; set; }
        [Column("UnitPrice")]
        public decimal Preco { get; set; }
        [Column("UnitsInStock")]
        public Int16 Estoque { get; set; }
        [ForeignKey("Categoria")]
        [Column("CategoryId")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}