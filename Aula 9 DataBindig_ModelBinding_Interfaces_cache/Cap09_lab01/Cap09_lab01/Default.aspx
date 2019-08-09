<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cap09_lab01.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Estilos.css" rel="stylesheet" />
</head>
<body>

    <%--VERSÃO OLD--%>
    <%--<form id="form1" runat="server">
        <div>
            <asp:DataList
                runat="server"
                ID="categoriasDataList"
                ItemType="CAP09_LAB01.Models.Categories"
                OnItemDataBound="categoriasDataList_ItemDataBound">


                <ItemTemplate>
                    <asp:Label CssClass="categoria"
                        runat="server"
                        ID="categoriaLabel"
                        Text="<%# Item.CategoryName %>">
                    </asp:Label>

                    <asp:DataList ItemStyle-VerticalAlign="Top"
                        runat="server" ID="fornecedorDataList"
                        ItemType="ASPII_CAP09_LAB01.Models.Suppliers"
                        RepeatColumns="3">


                        <ItemTemplate>
                            <div class="fornecedor">
                                <div class="fornecedor-item">
                                    <asp:Label
                                        CssClass="fornecedor-nome"
                                        runat="server"
                                        ID="fornecedorNome"
                                        Text="<%# Item.CompanyName %>"> 
                                    </asp:Label>
                                    <asp:Label CssClass="fornecedor-endereco"
                                        runat="server"
                                        ID="Label2" Text="<%# Item.Address %>">  
                                    </asp:Label>
                                    <asp:Label CssClass="fornecedor-cidade"
                                        runat="server"
                                        ID="Label3" Text="<%# Item.City %>"> 
                                    </asp:Label>
                                    <asp:Label CssClass="fornecedor-pais"
                                        runat="server"
                                        ID="Label4" Text="<%# Item.Country %>">  
                                    </asp:Label>
                                </div>
                                <div class="fornecedor-produtos">
                                    <asp:BulletedList
                                        CssClass="produtos-lista"
                                        runat="server"
                                        ID="produtosBulletList"
                                        ItemType="CAP09_LAB01.Models.Products"
                                        DataTextField="ProductName">
                                    </asp:BulletedList>

                                </div>
                        </ItemTemplate>
                    </asp:DataList>
                </ItemTemplate>
            </asp:DataList>
        </div>--%>


    <%--        PG 566    De acordo com a apostila de acesso a dados da impacta a forma que era pra ser feita era de acordo com o código acima comentado
            só que não rolou sendo assim fui atrás de uma alternativa e codei conforme código abaixo.--%>


    <%--VERSÃO NOVA --%>
    <form>
        <asp:DataList runat="server" ID="categoriasDataList">
            <ItemTemplate>
                <asp:Label
                    CssClass="categoria"
                    runat="server">
                        <%# Eval("CategoryName") %>
                </asp:Label>
            </ItemTemplate>
        </asp:DataList>
    </form>
</body>
</html>


