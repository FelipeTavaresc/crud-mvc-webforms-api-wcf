using Core.Enums;
using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ClienteService;

namespace WebForm
{
    public partial class _Default : Page
    {
        private List<Cliente> listaClientes = new List<Cliente>();
        private ClienteServiceClient clienteService = new ClienteServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarClientes();

        }

        protected void btnNovoCliente_Click(object sender, EventArgs e)
        {
            hfClienteId.Value = "0";
            ShowModal();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var clienteId = string.IsNullOrWhiteSpace(hfClienteId.Value) ? 0 : int.Parse(hfClienteId.Value);
                //Cria um cliente novo
                if (clienteId == 0)
                {
                    var cliente = ViewToModel();
                    clienteService.AddCliente(cliente);
                }
                else
                {
                    //Atualiza um cliente já existente
                    var clienteExistente = clienteService.GetClienteById(clienteId);
                    if (clienteExistente != null)
                    {
                        var cliente = ViewToModel(clienteExistente);
                        clienteService.UpdateCliente(cliente);
                    }
                }

                // Limpar os campos do modal
                LimparCampos();

                // Recarregar os clientes no GridView
                CarregarClientes();

                // Fechar o modal
                HideModal();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            string clienteId = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(clienteId))
            {
                var cliente = clienteService.GetClienteById(int.Parse(clienteId));
                if (cliente != null)
                {
                    clienteService.DeleteCliente(cliente.Id);
                }
            }
            CarregarClientes();
        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            string clienteId = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(clienteId))
            {
                var cliente = clienteService.GetClienteById(int.Parse(clienteId));
                if (cliente != null)
                {
                    hfClienteId.Value = cliente.Id.ToString();
                    txtCPF.Text = cliente.CPF;
                    txtNome.Text = cliente.Nome;
                    txtRG.Text = cliente.RG;
                    txtDataExpedicao.Text = cliente.DataExpedicao?.ToString("yyyy-MM-dd");
                    txtOrgaoExpedicao.Text = cliente.OrgaoExpedicao;
                    ddlUFExpedicao.SelectedValue = cliente.UFExpedicao;
                    txtDataNascimento.Text = cliente.DataNascimento.ToString("yyyy-MM-dd");
                    ddlSexo.Text = cliente.TipoSexo;
                    ddlEstadoCivil.Text = cliente.TipoEstadoCivil;
                    txtCEP.Text = cliente.EnderecoCliente.CEP;
                    txtRua.Text = cliente.EnderecoCliente.Logradouro;
                    txtNumero.Text = cliente.EnderecoCliente.Numero;
                    txtComplemento.Text = cliente.EnderecoCliente.Complemento;
                    txtBairro.Text = cliente.EnderecoCliente.Bairro;
                    txtCidade.Text = cliente.EnderecoCliente.Cidade;
                    ddlUF.Text = cliente.EnderecoCliente.UF;
                    ShowModal();
                }
            }
        }

        #region Privates
        private Cliente ViewToModel(Cliente clienteExistente = null)
        {
            Cliente cliente = new Cliente();

            if (clienteExistente != null)
                cliente = clienteExistente;

            cliente.CPF = txtCPF.Text;
            cliente.Nome = txtNome.Text;
            cliente.RG = txtRG.Text;

            if (!string.IsNullOrEmpty(txtDataExpedicao.Text))
                cliente.DataExpedicao = DateTime.Parse(txtDataExpedicao.Text);
            
            cliente.OrgaoExpedicao = txtOrgaoExpedicao.Text;
            cliente.UFExpedicao = ddlUFExpedicao.Text;
            cliente.DataNascimento = DateTime.Parse(txtDataNascimento.Text);
            cliente.TipoSexo = ddlSexo.Text;
            cliente.TipoEstadoCivil = ddlEstadoCivil.Text;
            cliente.EnderecoCliente = new EnderecoCliente
            {
                CEP = txtCEP.Text,
                Logradouro = txtRua.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                UF = ddlUF.Text
            };
            return cliente;
        }

        private void LimparCampos()
        {
            txtCPF.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtDataExpedicao.Text = string.Empty;
            txtOrgaoExpedicao.Text = string.Empty;
            ddlUF.SelectedValue = "Selecione";
            txtDataNascimento.Text = string.Empty;
            ddlSexo.SelectedValue = "Selecione";
            ddlEstadoCivil.SelectedValue = "Selecione";
        }

        private void CarregarClientes()
        {
            var clientes = clienteService.GetClientes();
            repeater.DataSource = clientes;
            repeater.DataBind();
        }

        private void ShowModal()
        {
            var script = "$('#modal').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        private void HideModal()
        {
            var script = "$('#modal').modal('hide')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }
        #endregion
    }
}