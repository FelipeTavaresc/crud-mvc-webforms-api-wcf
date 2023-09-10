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
            catch (Exception)
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
        public HttpResponseMessage PutCliente(int id, Cliente clienteEdt)
        {
            var cliente = ClienteRepositorio.Instance().GetClienteById(id);
            if (cliente != null)
            {
                clienteEdt.CPF = cliente.CPF;
                clienteEdt.Nome = cliente.Nome;
                clienteEdt.RG = cliente.RG;
                clienteEdt.DataExpedicao = cliente.DataExpedicao;
                clienteEdt.OrgaoExpedicao = cliente.OrgaoExpedicao;
                clienteEdt.UFExpedicao = cliente.UFExpedicao;
                clienteEdt.DataNascimento = cliente.DataNascimento;
                clienteEdt.TipoSexo = cliente.TipoSexo;
                clienteEdt.TipoEstadoCivil = cliente.TipoEstadoCivil;
                clienteEdt.EnderecoCliente.CEP = cliente.EnderecoCliente.CEP;
                clienteEdt.EnderecoCliente.Logradouro = cliente.EnderecoCliente.Logradouro;
                clienteEdt.EnderecoCliente.Numero = cliente.EnderecoCliente.Numero;
                clienteEdt.EnderecoCliente.Complemento = cliente.EnderecoCliente.Complemento;
                clienteEdt.EnderecoCliente.Bairro = cliente.EnderecoCliente.Bairro;
                clienteEdt.EnderecoCliente.Cidade = cliente.EnderecoCliente.Cidade;
                clienteEdt.EnderecoCliente.UF = cliente.EnderecoCliente.UF;
                ClienteRepositorio.Instance().UpdateCliente(clienteEdt);
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
