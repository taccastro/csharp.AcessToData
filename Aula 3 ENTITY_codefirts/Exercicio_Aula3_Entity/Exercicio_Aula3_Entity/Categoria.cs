using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exercicio_Aula3_Entity
{
    [Table("Categories", Schema = "dbo")]
    public class Categoria
    {
        [Column("CategoryId")]
        public int CategoriaId { get; set; }

        [Column("CategoryName")]
        public string Nome { get; set; }

    }
}