using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercicio_Aula3_Entity
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void categoriaButton_Click(object sender, EventArgs e)
        {
            var db = new ProdutosDb();
            categoriaDropDownList.DataValueField = "CategoriaId";
            categoriaDropDownList.DataTextField = "Nome";
            categoriaDropDownList.DataSource = db.CategoriasLista();
            categoriaDropDownList.DataBind();
            categoriaDropDownList.Items.Insert(0, string.Empty);
            MultiView1.ActiveViewIndex = 0;
        }


        protected void categoriaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoriaDropDownList.SelectedIndex == 0)
            {
                produtosGridView.DataSource = null;
            }
            else
            {
                int categoriaId = Convert.ToInt32(categoriaDropDownList
                .SelectedValue);
                var db = new ProdutosDb();
                var tb = db.ProdutosPorCategoria(categoriaId);
                produtosGridView.DataSource = tb;
            }
            produtosGridView.DataBind();
        }

        //Fornedor
        protected void FornecedorButton_Click(object sender, EventArgs e)
        {
            var db = new ProdutosDb();
            DropDownFornecedor.DataValueField = "FornecedorId";
            DropDownFornecedor.DataTextField = "nome";
            DropDownFornecedor.DataSource = db.FornecedorLista();
            DropDownFornecedor.DataBind();
            DropDownFornecedor.Items.Insert(0, string.Empty);
            MultiView1.ActiveViewIndex = 1;
        }


        protected void produtoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownFornecedor.SelectedIndex == 0)
            {
                produtosGridView.DataSource = null;
            }
            else
            {
                int categoriaId = Convert.ToInt32(DropDownFornecedor
                .SelectedValue);
                var db = new ProdutosDb();
                var tb = db.ProdutosPorFornecedor(categoriaId);
                produtosGridView.DataSource = tb;
            }
            produtosGridView.DataBind();
        }



    }
}