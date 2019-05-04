using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cap06_Lab01_Teste
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarPaises();
            }
        }
        private void CarregarPaises()
        {
            var wcf = new AwWebRef.AdvWorksWcfClient();
            paisesDropDownList.DataSource =
            wcf.ClientePaisLista();
            paisesDropDownList.DataBind();
            paisesDropDownList.Items.Insert(0, string.Empty);
        }

        protected void paisesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridPanel.Visible = false;
            estadoPanel.Visible = false;
            if (paisesDropDownList.SelectedIndex > 0)
            {
                string pais = paisesDropDownList.SelectedValue;
                CarregarEstadosDeUmPais(pais);
            }
        }
        private void CarregarEstadosDeUmPais(string pais)
        {
            var wcf = new AwWebRef.AdvWorksWcfClient();
            estadoPanel.Visible = true;
            estadoDropDownList.DataSource =
            wcf.ClienteEstadoLista(pais);
            estadoDropDownList.DataBind();
            estadoDropDownList.Items.Insert(0, string.Empty);
        }

        protected void estadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estadoDropDownList.SelectedIndex > 0)
            {
                string pais = paisesDropDownList.SelectedValue;
                string estado = estadoDropDownList.SelectedValue;
                CarregarClientesDeUmEstado(pais, estado);
            }
        }
        private void CarregarClientesDeUmEstado(
        string pais, string estado)
        {
            var wcf = new AwWebRef.AdvWorksWcfClient();
            var lista = wcf.ClientesAvulsosPorPaisEstado(
            pais, estado);
            clientesGridView.DataSource = lista;
            clientesGridView.DataBind();
            gridPanel.Visible = true;
        }

        protected void clientesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            clientesGridView.PageIndex = e.NewPageIndex;
            string pais = paisesDropDownList.SelectedValue;
            string estado = estadoDropDownList.SelectedValue;
            CarregarClientesDeUmEstado(pais, estado);
        }

     

       


    }
}