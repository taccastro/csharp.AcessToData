using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cap04Lab01
{
    public partial class EditoraWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            editorasGridView.DataSource = BibliotecaDb.EditorasLista();
            editorasGridView.DataBind();
        }
    }
}