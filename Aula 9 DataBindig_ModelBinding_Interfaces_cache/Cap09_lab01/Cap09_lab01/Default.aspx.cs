using Cap09_lab01.Models;
using System;
using System.Web.UI.WebControls;

namespace Cap09_lab01
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarCategorias();
            }

        }

        private void CarregarCategorias()
        {
            categoriasDataList.DataSource = Models.NorthwindDb.CategoriasLista(); categoriasDataList.DataBind();
        }

       
        //PG581
        //protected void categoriasDataList_ItemDataBound(object sender, DataListItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        var categoria = (Categories)e.Item.DataItem; var fornecedorDataList = (DataList)e.Item.FindControl("fornecedorDataList"); fornecedorDataList.DataSource = NorthwindDb.FornecedoresPorCategoria(categoria.CategoryID);
        //        fornecedorDataList.DataBind();
        //    }
        //}

        //protected void fornecedorDataList_ItemDataBound(object sender, DataListItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item ||
        //        e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        var fornecedor = (Suppliers)e.Item.DataItem;
        //        var produtos = (BulletedList)e.Item.FindControl("produtosBulletList");

        //        produtos.DataSource = NorthwindDb.ProdutosPorFornecedor(
        //                             fornecedor.SupplierID);

        //        produtos.DataBind();
        //    }
        //}
    }
}