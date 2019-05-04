<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FuncionarioWebForm.aspx.cs" Inherits="Cap05_Lab01.FuncionarioWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="conteudoContentPlaceHolder" runat="server">

    <h2>Funcionários</h2>

    <asp:Label runat="server"
        ID="mensagemLabel"
        CssClass="mensagem">
    </asp:Label>

    <asp:MultiView runat="server"
        ID="formMultiView"
        ActiveViewIndex="0">

        <asp:View ID="listagemView" runat="server">

            <asp:Button CssClass="botao margem-inferior"
                runat="server"
                ID="novoButton"
                Text="Novo" OnClick="novoButton_Click" />

            <asp:GridView CssClass="tabela"
                DataKeyNames="funcionarioId"
                runat="server"
                AllowPaging="True"
                PageSize="6"
                ID="funcionariosGridView"
                AutoGenerateColumns="False" OnRowCommand="funcionariosGridView_RowCommand" >

                <Columns>
                    <asp:ButtonField DataTextField="Nome" CommandName="detalhes" HeaderText="Funcionário" />
                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                    <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="Pais" HeaderText="Pais" />
                    <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                </Columns>
            </asp:GridView>

        </asp:View>

        <asp:View ID="alteracaoView" runat="server">
            <fieldset>                
  
                <div class="coluna-imagem">
                    <!-- Foto (imagem) -->
                    <asp:Image runat="server" ID="fotoUrlImage"
                        CssClass="campo-imagem" />

                    <!-- Observações -->
                    <div class="form-grupo">
                        <asp:TextBox runat="server" ID="observacoesTextBox"
                            TextMode="MultiLine"
                            CssClass="campo campo-obs">
                        </asp:TextBox>
                    </div>
                </div>
                
                <div class="form-campos">
                    <!-- Tratamento -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="tratamentoLabel"
                            Text="Tratamento:"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="tratamentoTextBox"
                            CssClass="campo campo-medio"
                            MaxLength="5" >
                        </asp:TextBox>
                    </div>

                    <!-- Nome -->
                    <div class="form-grupo form-inline">
                        <asp:Label runat="server" id="nomeLabel"
                            Text="Nome" CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="nomeTextBox"
                            CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- Sobrenome -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="sobrenomeLabel"
                            Text="Sobrenome:" CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="sobrenomeTextBox"
                            CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- Endereco -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="enderecoLabel"
                            Text="Endereço:" CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="enderecoTextBox"
                            CssClass="campo campo-grande">
                        </asp:TextBox>
                    </div>

                    <!-- Cidade -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="cidadeLabel"
                            Text="Cidade:" CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="cidadeTextBox"
                            CssClass="campo campo-grande">
                        </asp:TextBox>
                    </div>

                    <!-- Estado -->
                    <div class="form-grupo form-inline">
                        <asp:Label runat="server" id="estadoLabel"
                            Text="Estado:" CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="estadoTextBox"
                            CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- CEP -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="cepLabel" Text="CEP:"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="cepTextBox"
                            CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- Pais -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="paisLabel" Text="Pais:"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="paisTextBox"
                            CssClass="campo campo-grande">
                        </asp:TextBox>
                    </div>

                    <!-- Telefone residencial -->
                    <div class="form-grupo form-inline">
                        <asp:Label runat="server"
                            id="telefoneResidencialLabel"
                            Text="TelefoneResidencial"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server"
                            ID="telefoneResidencialTextBox"
                            CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- Ramal -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="ramalLabel"
                            Text="Ramal"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="ramalTextBox"
                          CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- Cargo -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="cargoLabel"
                            Text="Cargo:"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="cargoTextBox"
                            CssClass="campo campo-grande">
                        </asp:TextBox>
                    </div>

                    <!-- DataAdmissao -->
                    <div class="form-grupo form-inline">
                        <asp:Label runat="server" id="dataAdmisssaoLabel"
                           Text="Data de Admissão:"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server" ID="dataAdmissaoTextBox"
                            CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- DataNascimento -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="dataNascimentoLabel"
                            Text="Data de Nascimento:"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:TextBox runat="server"
                            ID="dataNascimentoTextBox"
                            CssClass="campo campo-medio">
                        </asp:TextBox>
                    </div>

                    <!-- Reportar Para -->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="reportarParaLabel"
                            Text="Reportar para"
                            CssClass="legenda">
                        </asp:Label>
                        <asp:DropDownList runat="server"
                            id="reportarParaDropDownList"
                            CssClass="campo-grande">
                        </asp:DropDownList>
                    </div>

                    <!-- Foto (Upload)-->
                    <div class="form-grupo">
                        <asp:Label runat="server" id="fotoUrlLabel"
                            Text="Foto:" CssClass="legenda">
                        </asp:Label>

                        <asp:FileUpload runat="server"
                            ID="fotoUrlFileUpload"
                            CssClass="campo-upload" />
                    </div>

                    <div class="botao-grupo">
                        <asp:Button CssClass="botao" runat="server"
                            Text="Incluir" OnClick="incluirButton_Click"
                            id="incluirButton" />
                        
                        <asp:Button CssClass="botao" runat="server"
                            Text="Alterar"
                            id="alterarButton" OnClick="alterarButton_Click" />
                        
                        <asp:Button CssClass="botao" runat="server"
                            Text="Excluir"
                            id="excluirButton" OnClick="excluirButton_Click"/>
                        
                        <asp:Button CssClass="botao" runat="server"
                            Text="Voltar"
                            id="voltarButton" />
                    </div>

                </div>
            </fieldset>
        </asp:View>
    </asp:MultiView>
</asp:Content>
