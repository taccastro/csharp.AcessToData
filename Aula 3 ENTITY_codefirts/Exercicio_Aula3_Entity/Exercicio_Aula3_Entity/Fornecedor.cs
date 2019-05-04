using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exercicio_Aula3_Entity
{
    //Criar a classe de modelo Fornecedor;
    [Table ("Suppliers", Schema = "dbo")]
    public class Fornecedor
    {

        [Key]
        [Column("SupplierID")]
        public int FornecedorId { get; set; }
        [Column("CompanyName")]
        public string nome { get; set; }


    }
}