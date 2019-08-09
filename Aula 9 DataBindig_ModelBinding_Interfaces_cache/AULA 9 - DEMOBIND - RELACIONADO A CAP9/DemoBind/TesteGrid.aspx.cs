using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoBind
{
    public class Pagamento
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
    }

    public class PagamentoRepository
    {
        public static Pagamento[] ListaCompleta()
        {            
            return new Pagamento[]
            {
                new Pagamento() {
                    Data=new DateTime(2016, 11, 09),
                    Descricao = "Conta de Luz",
                    Valor = 159.25m
                },

                new Pagamento() {
                    Data=new DateTime(2016, 10, 05),
                    Descricao="Férias",
                    Valor = 3000
                },

                new Pagamento() {
                    Data=new DateTime(2016, 11, 08),
                    Descricao = "Conta de água",
                    Valor = 200m
                },

                new Pagamento() {
                    Data=new DateTime(2016, 06, 14),
                    Descricao="Viagem",
                    Valor = 2345.56m
                }

                ,

                new Pagamento() {
                    Data=new DateTime(2016, 02, 28),
                    Descricao="Carnaval",
                    Valor = 12300m
                }
            };
        }
    }

    enum ColunasGrid
    {
        Data = 0,
        Descricao = 1,
        Valor = 2
    }

    public partial class TesteGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarDadosGrid();
        }

        protected void MinhaGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var pagto = (Pagamento) e.Row.DataItem;

                if (pagto.Valor > 1000)
                    e.Row.Cells[(int) ColunasGrid.Valor].ForeColor = Color.Red; 
            }
        }

        protected void MinhaGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MinhaGrid.PageIndex = e.NewPageIndex;
            CarregarDadosGrid();
        }

        private void CarregarDadosGrid()
        {
            var Dados = (PagamentoRepository.ListaCompleta()).OrderBy(x => x.Descricao);
            MinhaGrid.DataSource = Dados.ToList<Pagamento>();
            MinhaGrid.DataBind();
        }
    }
}