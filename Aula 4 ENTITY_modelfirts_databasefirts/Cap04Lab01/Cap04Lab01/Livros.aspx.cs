using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cap04Lab01.Models;

namespace Cap04Lab01
{
    public partial class LivroWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Livro> listaDeLivros = null;
            string editoraId = Request.QueryString["editoraId"];
            if (!string.IsNullOrEmpty(editoraId))
            {
                listaDeLivros =
                BibliotecaDb.LivrosPorEditora(editoraId);
                var editora = BibliotecaDb.EditoraPorId(editoraId);
                mensagemLabel.Text = " da Editora " + editora.EditoraNome;
            }
            else
            {
                string autorId = Request.QueryString["autorId"];
                if (!string.IsNullOrEmpty(autorId))
                {
                    listaDeLivros = BibliotecaDb.LivrosPorAutor(autorId);
                    var autor = BibliotecaDb.AutorPorId(autorId);
                    mensagemLabel.Text =
                    " do autor " + autor.NomeCompleto;
                }
                else
                {
                    listaDeLivros = BibliotecaDb.LivrosLista();
                }
            }
            livrosGridView.DataSource = listaDeLivros;
            livrosGridView.DataBind();

        }
    }
}