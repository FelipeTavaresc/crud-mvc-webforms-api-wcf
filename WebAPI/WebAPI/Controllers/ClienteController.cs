using Core.Modelos;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Repositorio;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Returns all clientes
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAllClientes()
        {
            List<Cliente> clientes = ClienteRepositorio.Instance().GetClientes();
            return Request.CreateResponse<List<Cliente>>(HttpStatusCode.OK, clientes);
        }

        /// <summary>
        /// Returns cliente by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetCliente(int id)
        {
            Cliente cliente = ClienteRepositorio.Instance().GetClienteById(id);
            if(cliente == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Cliente {id} não encontrado");
            else
                return Request.CreateResponse<Cliente>(HttpStatusCode.OK, cliente);
        }

        /// <summary>
        /// Post cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public HttpResponseMessage PostCliente(Cliente cliente)
        {
            try
            {
                ClienteRepositorio.Instance().AddCliente(cliente);
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, cliente);
                string uri = Url.Link("DefaultApi", new { id = cliente.Id });
                response.Headers.Location = new Uri(uri);
                return response;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao cadastrar cliente");
            }
        }

        /// <summary>
        /// Update cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clienteEdt"></param>
        /// <returns></returns>
        public HttpResponseMessage PutCliente(Cliente clienteEdt)
        {
            var cliente = ClienteRepositorio.Instance().GetClienteById(clienteEdt.Id);
            if (cliente != null)
            {
                cliente.CPF = clienteEdt.CPF;
                cliente.Nome = clienteEdt.Nome;
                cliente.RG = clienteEdt.RG;
                cliente.DataExpedicao = clienteEdt.DataExpedicao;
                cliente.OrgaoExpedicao = clienteEdt.OrgaoExpedicao;
                cliente.UFExpedicao = clienteEdt.UFExpedicao;
                cliente.DataNascimento = clienteEdt.DataNascimento;
                cliente.TipoSexo = clienteEdt.TipoSexo;
                cliente.TipoEstadoCivil = clienteEdt.TipoEstadoCivil;
                cliente.EnderecoCliente.CEP = clienteEdt.EnderecoCliente.CEP;
                cliente.EnderecoCliente.Logradouro = clienteEdt.EnderecoCliente.Logradouro;
                cliente.EnderecoCliente.Numero = clienteEdt.EnderecoCliente.Numero;
                cliente.EnderecoCliente.Complemento = clienteEdt.EnderecoCliente.Complemento;
                cliente.EnderecoCliente.Bairro = clienteEdt.EnderecoCliente.Bairro;
                cliente.EnderecoCliente.Cidade = clienteEdt.EnderecoCliente.Cidade;
                cliente.EnderecoCliente.UF = clienteEdt.EnderecoCliente.UF;
                ClienteRepositorio.Instance().UpdateCliente(cliente);
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Cliente atualizado com sucesso");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao atualizar cliente");
            }
        }

        /// <summary>
        /// Delete cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteCliente(int id)
        {
            ClienteRepositorio.Instance().DeleteCliente(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
