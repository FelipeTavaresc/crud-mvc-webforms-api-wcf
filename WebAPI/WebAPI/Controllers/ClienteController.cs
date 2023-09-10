using Core.Modelos;
using Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        // GET: api/Cliente/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var cliente = ClienteRepositorio.Instance().GetClienteById(id);
            return Ok(cliente);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var cliente = ClienteRepositorio.Instance().GetClientes();
            return Ok(cliente);
        }

        // POST: api/Cliente
        [HttpPost]
        public IHttpActionResult Post([FromBody] Cliente cliente)
        {
            ClienteRepositorio.Instance().AddCliente(cliente);
            return Created($"{ControllerContext.RequestContext.Url.Request.RequestUri.OriginalString}", cliente);
        }

        // PUT: api/Cliente/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Cliente clienteEdt)
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
            }
            else
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Cliente/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Cliente cliente = ClienteRepositorio.Instance().GetClienteById(id);
            if (cliente == null)
                return NotFound();
            ClienteRepositorio.Instance().DeleteCliente(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
