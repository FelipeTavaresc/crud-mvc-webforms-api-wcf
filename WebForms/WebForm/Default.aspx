<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            padding: 8px;
        }

        th {
            background-color: #4CAF50;
            color: white;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        tr.separator {
            border-top: 1px solid #ddd;
            border-bottom: 1px solid #ddd;
        }

        .error {
            border: 1px solid #C73D3F;
            background-color: #F4E6E6
        }
    </style>
    <script>
        $(document).ready(function () {
            debugger;
            $('#<%=txtCEP.ClientID%>').focusout(function () {
                var cep = $('#<%=txtCEP.ClientID%>').val();
                cep = cep.replace("-", "");
                var urlStr = "https://viacep.com.br/ws/" + cep + "/json";
                $.ajax({
                    url: urlStr,
                    type: "get",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        $('#<%=txtRua.ClientID%>').val(data.logradouro);
                        $('#<%=txtBairro.ClientID%>').val(data.bairro);
                        $('#<%=txtCidade.ClientID%>').val(data.localidade);
                        $('#<%=ddlUF.ClientID%>').val(data.uf);
                    }
                });
            });
        });


        function validate() {
            //CPF
            if (document.getElementById("<%=txtCPF.ClientID%>").value == "") {
                document.getElementById("<%=txtCPF.ClientID%>").className = 'form-control error';
                return false;
            }

            //Nome
            if (document.getElementById("<%=txtNome.ClientID%>").value == "") {
                document.getElementById("<%=txtNome.ClientID%>").className = 'form-control error';
                return false;
            }

            //Data Nascimento
            if (document.getElementById("<%=txtDataNascimento.ClientID%>").value == "") {
                document.getElementById("<%=txtDataNascimento.ClientID%>").className = 'form-control error';
                return false;
            }

            //Sexo
            debugger;
            if (document.getElementById("<%=ddlSexo.ClientID%>").value == "Selecione") {
                document.getElementById("<%=ddlSexo.ClientID%>").className = 'form-control error';
                return false;
            }

            //Estado Cívil
            if (document.getElementById("<%=ddlEstadoCivil.ClientID%>").value == "Selecione") {
                document.getElementById("<%=ddlEstadoCivil.ClientID%>").className = 'form-control error';
                return false;
            }

            //CEP
            if (document.getElementById("<%=txtCEP.ClientID%>").value == "") {
                document.getElementById("<%=txtCEP.ClientID%>").className = 'form-control error';
                return false;
            }

            //Rua
            if (document.getElementById("<%=txtRua.ClientID%>").value == "") {
                document.getElementById("<%=txtRua.ClientID%>").className = 'form-control error';
                return false;
            }

            //Numero
            if (document.getElementById("<%=txtNumero.ClientID%>").value == "") {
                document.getElementById("<%=txtNumero.ClientID%>").className = 'form-control error';
                return false;
            }

            //Bairro
            if (document.getElementById("<%=txtBairro.ClientID%>").value == "") {
                document.getElementById("<%=txtBairro.ClientID%>").className = 'form-control error';
                return false;
            }

            //Cidade
            if (document.getElementById("<%=txtCidade.ClientID%>").value == "") {
                document.getElementById("<%=txtCidade.ClientID%>").className = 'form-control error';
                return false;
            }

            //UF Endereço
            if (document.getElementById("<%=ddlUF.ClientID%>").value == "") {
                document.getElementById("<%=ddlUF.ClientID%>").className = 'form-control error';
                return false;
            }
            return true;
        }

        function onlyNumbers(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>
    <div>
        <h2>CRUD de Clientes</h2>
        <asp:Button ID="btnNovoCliente" runat="server" CssClass="btn btn-primary" Text="Novo Cliente" OnClick="btnNovoCliente_Click" /><br />

    </div>
    <div class="container">
        <asp:HiddenField ID="hfClienteId" Value="" runat="server" />
        <div class="modal fade" id="modal" data-backdrop="false" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title">Novo Cliente</h3>
                    </div>
                    <div class="modal-body">
                        <h4>Cliente</h4>
                        <div class="row ">
                            <div class="form-group col-md-3">
                                <label>CPF</label>
                                <asp:TextBox ID="txtCPF" onkeypress="return onlyNumbers(event)" MaxLength="11" runat="server" CssClass="form-control" placeholder="CPF" />
                            </div>

                            <div class="form-group col-md-9">
                                <label>Nome</label>
                                <asp:TextBox ID="txtNome" MaxLength="150" runat="server" CssClass="form-control" placeholder="Nome" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-md-3">
                                <label>RG</label>
                                <asp:TextBox ID="txtRG" MaxLength="10" runat="server" CssClass="form-control" placeholder="RG" />
                            </div>

                            <div class="form-group col-md-3">
                                <label>Data Expedição</label>
                                <asp:TextBox ID="txtDataExpedicao" type="date" runat="server" CssClass="form-control" placeholder="Data de Expedição" />
                            </div>

                            <div class="form-group col-md-3">
                                <label>Orgão Expedição</label>
                                <asp:TextBox ID="txtOrgaoExpedicao" runat="server" CssClass="form-control" placeholder="Órgão de Expedição" />
                            </div>

                            <div class="form-group col-md-2">
                                <label>UF Expedição</label>
                                <asp:DropDownList ID="ddlUFExpedicao" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Selecione" Value="" />
                                    <asp:ListItem Text="AC" Value="AC" />
                                    <asp:ListItem Text="AL" Value="AL" />
                                    <asp:ListItem Text="AM" Value="AM" />
                                    <asp:ListItem Text="AP" Value="AP" />
                                    <asp:ListItem Text="BA" Value="BA" />
                                    <asp:ListItem Text="CE" Value="CE" />
                                    <asp:ListItem Text="DF" Value="DF" />
                                    <asp:ListItem Text="ES" Value="ES" />
                                    <asp:ListItem Text="GO" Value="GO" />
                                    <asp:ListItem Text="MA" Value="MA" />
                                    <asp:ListItem Text="MG" Value="MG" />
                                    <asp:ListItem Text="MS" Value="MS" />
                                    <asp:ListItem Text="MT" Value="MT" />
                                    <asp:ListItem Text="PA" Value="PA" />
                                    <asp:ListItem Text="PB" Value="PB" />
                                    <asp:ListItem Text="PE" Value="PE" />
                                    <asp:ListItem Text="PI" Value="PI" />
                                    <asp:ListItem Text="PR" Value="PR" />
                                    <asp:ListItem Text="RJ" Value="RJ" />
                                    <asp:ListItem Text="RN" Value="RN" />
                                    <asp:ListItem Text="RO" Value="RO" />
                                    <asp:ListItem Text="RR" Value="RR" />
                                    <asp:ListItem Text="RS" Value="RS" />
                                    <asp:ListItem Text="SC" Value="SC" />
                                    <asp:ListItem Text="SE" Value="SE" />
                                    <asp:ListItem Text="SP" Value="SP" />
                                    <asp:ListItem Text="TO" Value="TO" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-md-3">
                                <label>Data Nascimento</label>
                                <asp:TextBox ID="txtDataNascimento" type="date" runat="server" CssClass="form-control" placeholder="Data de Nascimento" />
                            </div>

                            <div class="form-group col-md-3">
                                <label>Sexo</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlSexo" runat="server">
                                    <asp:ListItem Value="Selecione"></asp:ListItem>
                                    <asp:ListItem Value="Masculino" Text="Masculino" />
                                    <asp:ListItem Value="Feminino" Text="Feminino" />
                                    <asp:ListItem Value="Não declarar" Text="Não declarar" />
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-3">
                                <label>Estado Cívil</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlEstadoCivil" runat="server">
                                    <asp:ListItem Value="Selecione"></asp:ListItem>
                                    <asp:ListItem Value="Casado" Text="Casado" />
                                    <asp:ListItem Value="Solteiro" Text="Solteiro" />
                                    <asp:ListItem Value="Divorciado" Text="Divorciado" />
                                    <asp:ListItem Value="Víuvo" Text="Víuvo" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <h4>Endereço</h4>
                        <div class="row">
                            <div class="form-group col-md-2">
                                <label>CEP</label>
                                <asp:TextBox ID="txtCEP" onkeypress="return onlyNumbers(event)" runat="server" MaxLength="9" CssClass="form-control" placeholder="CEP" />
                            </div>

                            <div class="form-group col-md-4">
                                <label>Rua</label>
                                <asp:TextBox ID="txtRua" runat="server" MaxLength="100" CssClass="form-control" placeholder="Rua" />
                            </div>

                            <div class="form-group col-md-2">
                                <label>Número</label>
                                <asp:TextBox ID="txtNumero" onkeypress="return onlyNumbers(event)" runat="server" MaxLength="5" CssClass="form-control" placeholder="Número" />
                            </div>

                            <div class="form-group col-md-3">
                                <label>Complemento</label>
                                <asp:TextBox ID="txtComplemento" runat="server" MaxLength="50" CssClass="form-control" placeholder="Complemento" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-md-4">
                                <label>Bairro</label>
                                <asp:TextBox ID="txtBairro" runat="server" MaxLength="50" CssClass="form-control" placeholder="Bairro" />
                            </div>

                            <div class="form-group col-md-4">
                                <label>Cidade</label>
                                <asp:TextBox ID="txtCidade" runat="server" MaxLength="100" CssClass="form-control" placeholder="Cidade" />
                            </div>

                            <div class="form-group col-md-2">
                                <label>UF</label>
                                <asp:DropDownList ID="ddlUF" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Selecione" Value="" />
                                    <asp:ListItem Text="AC" Value="AC" />
                                    <asp:ListItem Text="AL" Value="AL" />
                                    <asp:ListItem Text="AM" Value="AM" />
                                    <asp:ListItem Text="AP" Value="AP" />
                                    <asp:ListItem Text="BA" Value="BA" />
                                    <asp:ListItem Text="CE" Value="CE" />
                                    <asp:ListItem Text="DF" Value="DF" />
                                    <asp:ListItem Text="ES" Value="ES" />
                                    <asp:ListItem Text="GO" Value="GO" />
                                    <asp:ListItem Text="MA" Value="MA" />
                                    <asp:ListItem Text="MG" Value="MG" />
                                    <asp:ListItem Text="MS" Value="MS" />
                                    <asp:ListItem Text="MT" Value="MT" />
                                    <asp:ListItem Text="PA" Value="PA" />
                                    <asp:ListItem Text="PB" Value="PB" />
                                    <asp:ListItem Text="PE" Value="PE" />
                                    <asp:ListItem Text="PI" Value="PI" />
                                    <asp:ListItem Text="PR" Value="PR" />
                                    <asp:ListItem Text="RJ" Value="RJ" />
                                    <asp:ListItem Text="RN" Value="RN" />
                                    <asp:ListItem Text="RO" Value="RO" />
                                    <asp:ListItem Text="RR" Value="RR" />
                                    <asp:ListItem Text="RS" Value="RS" />
                                    <asp:ListItem Text="SC" Value="SC" />
                                    <asp:ListItem Text="SE" Value="SE" />
                                    <asp:ListItem Text="SP" Value="SP" />
                                    <asp:ListItem Text="TO" Value="TO" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                        <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClientClick="return validate();" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />
    <section id="section">
        <div class="row-match-height">
            <div class="col-12">
                <div class="card">
                    <div class="card-number">
                    </div>
                    <div class="card-content">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12 col-12">

                                    <table>
                                        <asp:Repeater ID="repeater" runat="server">
                                            <HeaderTemplate>
                                                <tr>
                                                    <th>ID</th>
                                                    <th>CPF</th>
                                                    <th>Nome</th>
                                                    <th>RG</th>
                                                    <th>Data Nascimento</th>
                                                    <th>Sexo</th>
                                                    <th>Ações</th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="separator">
                                                    <td><%# Eval("Id") %></td>
                                                    <td><%# Eval("CPF") %></td>
                                                    <td><%# Eval("Nome") %></td>
                                                    <td><%# Eval("RG") %></td>
                                                    <td><%# Eval("DataNascimento", "{0:dd/MM/yyyy}") %> </td>
                                                    <td><%# Eval("TipoSexo") %></td>

                                                    <td>
                                                        <asp:LinkButton runat="server" ID="btnUpdate" CommandName="Update" CommandArgument='<%# Eval("Id") %>'
                                                            CssClass="btn btn-sm btn-primary" OnCommand="btnUpdate_Command">
                                                            Editar
                                                        </asp:LinkButton>

                                                        <asp:LinkButton runat="server" ID="btnDelete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                                            OnClientClick="return confirm('Confirma a exclusão?');" CssClass="btn btn-sm btn-danger" OnCommand="btnDelete_Command">
                                                            Excluir
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
