using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transportadora
{
    public partial class Transportadoras : Form
    {
        public Transportadoras()
        {
            InitializeComponent();
        }
        // Obtem uma instância de HttpCliente
        // já configurado com o formato e a url do servidor
        //
        private HttpClient ObterHttClient()
        {
            var formato =
            new MediaTypeWithQualityHeaderValue("application/json");
            var client = new HttpClient();
            client.BaseAddress =
            new Uri("http://localhost:49542/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders
            .Accept
            .Add(formato);
            return client;
        }
        // Analisa se o comando foi bem sucedido
        //
        private void verificarResposta(HttpResponseMessage resposta)
        {
            if (!resposta.IsSuccessStatusCode)
            {
                MessageBox.Show("Erro no servidor:" + resposta.StatusCode);
            }
        }
        // GET:Obtem todas as transportadoras
        //
        private async void CarregarGrid()
        {
            using (var client = ObterHttClient())
            {
                var resposta = await client
                .GetAsync("api/Transportadoras");
                var conteudo = await resposta
                .Content
                .ReadAsAsync<Transportadora[]>();
                dataGridView1.DataSource = conteudo;
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // POST:Adiciona uma nota Transportadora
        private async void IncluirTransportadora(Transportadora t)
        {
            using (var client = ObterHttClient())
            {
                var resposta =
                await client.PostAsJsonAsync<Transportadora>
                ("api/Transportadoras", t);
                verificarResposta(resposta);

            }
            CarregarGrid();
        }

        private void Transportadoras_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void novobutton_Click(object sender, EventArgs e)
        {
            var f = new TransportadoraForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                var t = f.ObterTransportadora();
                IncluirTransportadora(t);
            }
        }
        // Obter a transportadora selecionada da Grid
        private Transportadora ObterTransportadoraSelecionada()
        {
            if (dataGridView1.DataSource != null &&
            dataGridView1.CurrentRow != null &&
            dataGridView1.CurrentRow.DataBoundItem is
            Transportadora)
            {
                return (Transportadora)dataGridView1
                .CurrentRow.DataBoundItem;
            }
            else
            {
                return null;
            }
        }
        // PUT: Alterar
        private async void Alterar(Transportadora t)
        {
            using (var client = ObterHttClient())
            {
                var resposta =
                await client.PutAsJsonAsync<Transportadora>(
                "api/Transportadoras/" +
                t.TransportadoraId, t);
            }
            CarregarGrid();
        }

        private void alterarButton_Click(object sender, EventArgs e)
        {
            var t = ObterTransportadoraSelecionada();
            if (t == null) return;
            var f = new TransportadoraForm();
            f.ExibirTransportadora(t);
            if (f.ShowDialog() == DialogResult.OK)
            {
                t = f.ObterTransportadora();
                Alterar(t);
            }
        }
        // Retorna true ou false
        private bool Pergunta(string msg)
        {
            var result = MessageBox.Show(
            msg,
            "Confirmação",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }
        // DEL:Excluir uma transportadora
        //
        private async void Excluir(int id)
        {
            using (var client = ObterHttClient())
            {
                var resposta =
                await client.DeleteAsync(
                "api/Transportadoras/" + id);
                verificarResposta(resposta);
            }
            CarregarGrid();
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            var t = ObterTransportadoraSelecionada();
            if (t != null)
            {
                if (Pergunta("Confirma a exclusão"))
                {
                    Excluir(t.TransportadoraId);
                }
            }
        }

        private void atualizarButton_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
