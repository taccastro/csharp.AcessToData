<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Cap02_Lab01.Produtos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">


        <h1>Northwind - Produtos </h1>


        <div>
            <section>
                <span>Pesquisar por: </span>
                <asp:Button ID="categoriaButton"
                    runat="server"
                    Text="Categoria" OnClick="categoriaButton_Click" />
                <asp:Button ID="fornecedorButton"
                    runat="server"
                    Text="Fornecedor" OnClick="fornecedorButton_Click" />
            </section>
        </div>

        <section>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:Label ID="categoriaLabel"
                        runat="server"
                        Text="Escolha uma categoria:">
                    </asp:Label>
                    <asp:DropDownList ID="categoriaDropDownList"
                        AutoPostBack="true"
                        runat="server" OnSelectedIndexChanged="categoriaDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </asp:View>
                <asp:View ID="View2" runat="server">

                    <asp:DropDownList ID="fornecedorDropDownList"
                        AutoPostBack="true"
                        runat="server" OnSelectedIndexChanged="fornecedorDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>

                </asp:View>


            </asp:MultiView>
        </section>

        <asp:GridView ID="categoriasGridView"
            runat="server">
        </asp:GridView>

        <asp:GridView ID="produtosGridView"
            runat="server"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Produto"
                    DataField="ProductName" />
                <asp:BoundField HeaderText="Preço de Venda"
                    DataField="UnitPrice"
                    DataFormatString="{0:C}">
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Unidades em Estoque"
                    DataField="UnitsInStock"
                    DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
