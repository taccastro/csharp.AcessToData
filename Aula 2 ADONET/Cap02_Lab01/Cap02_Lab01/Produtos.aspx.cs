using Cap02_Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cap02_Lab01
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void categoriaButton_Click(object sender, EventArgs e)
        {
            var db = new ProdutosDb();
            categoriaDropDownList.DataValueField = "CategoryId";
            categoriaDropDownList.DataTextField = "CategoryName";
            categoriaDropDownList.DataSource = db.CategoriasLista();
            categoriaDropDownList.DataBind();
            categoriaDropDownList.Items.Insert(0, string.Empty);
            MultiView1.ActiveViewIndex = 0;
        }

        protected void fornecedorButton_Click(object sender, EventArgs e)
        {
            var db = new ProdutosDb();
            fornecedorDropDownList.DataValueField = "SupplierId";
            fornecedorDropDownList.DataTextField = "CompanyName";
            fornecedorDropDownList.DataSource = db.ObterFornec();
            fornecedorDropDownList.DataBind();
            fornecedorDropDownList.Items.Insert(0, string.Empty);
            MultiView1.ActiveViewIndex = 1;
        }
        

        protected void categoriaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoriaDropDownList.SelectedIndex == 0)
            {
                categoriasGridView.DataSource = null;
            }
            else
            {
                int categoriaId =
                Convert.ToInt32(categoriaDropDownList.SelectedValue);
                var db = new ProdutosDb();
                var tb = db.ProdutosPorCategoria(categoriaId);
                categoriasGridView.DataSource = tb;
            }
            categoriasGridView.DataBind();
        }



        protected void fornecedorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fornecedorDropDownList.SelectedIndex == 0)
            {
                categoriasGridView.DataSource = null;
            }
            else
            {
                int categoriaId =
                Convert.ToInt32(fornecedorDropDownList.SelectedValue);
                var db = new ProdutosDb();
                var tb = db.ProdutosPorFornecedores(categoriaId);
                categoriasGridView.DataSource = tb;
            }
            categoriasGridView.DataBind();
        }




    }
}