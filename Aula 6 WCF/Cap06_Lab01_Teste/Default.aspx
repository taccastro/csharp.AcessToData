<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cap06_Lab01_Teste.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Adventure Works</h1>
        <h2>Clientes</h2>
        <section>
            Escolha um país:<br />
            <asp:DropDownList ID="paisesDropDownList" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="paisesDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
        </section>
        <asp:Panel runat="server" ID="estadoPanel" Visible="false">
            <section>
                Escolha um Estado:<br />
                <asp:DropDownList ID="estadoDropDownList" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="estadoDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </section>
        </asp:Panel>
        <asp:Panel runat="server" ID="gridPanel" Visible="false">
            <section>
                <asp:GridView ID="clientesGridView" runat="server"
                    AllowPaging="True" CssClass="tabela" OnPageIndexChanging="clientesGridView_PageIndexChanging">
                </asp:GridView>
            </section>
        </asp:Panel>
    </form>
</body>
</html>
