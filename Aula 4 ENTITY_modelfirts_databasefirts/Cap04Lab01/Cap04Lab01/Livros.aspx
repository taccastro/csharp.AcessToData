<%@ Page Title="Livros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Livros.aspx.cs" Inherits="Cap04Lab01.LivroWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Livros</h2>
    <asp:GridView runat="server"
        ID="livrosGridView"
        CssClass="table"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Titulo"
                HeaderText="Livro" />
            <asp:BoundField DataField="Tipo"
                HeaderText="Tipo" />
            <asp:BoundField DataField="Preco"
                DataFormatString="{0:c}"
                HeaderText="Preço"
                ItemStyle-HorizontalAlign="Right"
                ItemStyle-Wrap="false" />
            <asp:BoundField DataField="DataPublicacao"
                HeaderText="Publicado Em"
                DataFormatString="{0:d}" />
            <asp:BoundField DataField="Observacoes"
                HeaderText="Observações" />
        </Columns>
        <EmptyDataTemplate>
            <p>Nenhum resultado encontrado</p>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Label ID="mensagemLabel" runat="server" ></asp:Label>
</asp:Content>
