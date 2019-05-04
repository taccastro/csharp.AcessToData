<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Exercicio_Aula3_Entity.Produtos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Northwind - Produtos</title>
    <link href="Estilos.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <h1>Northwind - Produtos </h1>
        <section>
            <span>Pesquisar por: </span>
            <asp:Button ID="categoriaButton" runat="server"
                Text="Categoria" OnClick="categoriaButton_Click" />
            <asp:Button ID="fornecedorButton" runat="server"
                Text="Fornecedor" OnClick="FornecedorButton_Click" />
        </section>
        <section>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div>
                        <asp:Label ID="categoriaLabel"
                            runat="server"
                            Text="Escolha uma categoria: ">
                        </asp:Label>
                        <asp:DropDownList ID="categoriaDropDownList"
                            AutoPostBack="true" runat="server" OnSelectedIndexChanged="categoriaDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">

                    <div>
                        <asp:Label ID="Label1"
                            runat="server"
                            Text="Escolha um Fornecedor: ">
                        </asp:Label>
                        <asp:DropDownList ID="DropDownFornecedor"
                            AutoPostBack="true" runat="server" OnSelectedIndexChanged="produtoDropDownList_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </div>

                </asp:View>
            </asp:MultiView>
        </section>

        <section>
            <asp:GridView ID="produtosGridView" runat="server"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Produto"
                        DataField="Nome" />
                    <asp:BoundField HeaderText="Preço de Venda"
                        DataField="Preco"
                        DataFormatString="{0:C}">
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Unidades em Estoque"
                        DataField="Estoque"
                        DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </section>
    </form>

</body>
</html>
