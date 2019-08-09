<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesteGrid.aspx.cs" Inherits="DemoBind.TesteGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <%= DateTime.Now.ToLongDateString() %>

        <br />

        <asp:GridView ID="MinhaGrid" runat="server" 
             AllowPaging ="true" PageSize="2" 
             AutoGenerateColumns="false"
             OnRowDataBound="MinhaGrid_RowDataBound" 
             OnPageIndexChanging="MinhaGrid_PageIndexChanging" >
            <Columns>
                <asp:BoundField DataField="Data"
                    DataFormatString="{0:d}"
                    HeaderText="Vencimento" />

                <asp:BoundField DataField="Descricao"
                    HeaderText="Descrição" />

                <asp:BoundField DataField="Valor"
                    DataFormatString="{0:C}"
                    HeaderText="Valor da despesa" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <%# DateTime.Now %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <strong>
                        <%# (Convert.ToDouble(Eval("Valor")) * 1.1).ToString("C") %>
                            </strong>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
