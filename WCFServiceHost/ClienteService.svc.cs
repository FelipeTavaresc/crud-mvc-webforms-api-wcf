using Core;
using Core.Modelos;
using Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.
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
