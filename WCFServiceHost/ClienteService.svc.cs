using Core.Modelos;
using Core.Repositorio;
using System.Collections.Generic;

namespace WCFServiceHost
{
    public class ClienteService : IClienteService
    {
        public List<Cliente> GetClientes()
        {
            return ClienteRepositorio.Instance().GetClientes();
        }

        public Cliente GetClienteById(int clienteId)
        {
            return ClienteRepositorio.Instance().GetClienteById(clienteId);
        }

        public void AddCliente(Cliente cliente)
        {
            ClienteRepositorio.Instance().AddCliente(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            ClienteRepositorio.Instance().UpdateCliente(cliente);
        }

        public void DeleteCliente(int clienteId)
        {
            ClienteRepositorio.Instance().DeleteCliente(clienteId);
        }
    }
}
