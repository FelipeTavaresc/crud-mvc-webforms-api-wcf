using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClienteService" in both code and config file together.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        List<Cliente> GetClientes();

        [OperationContract]
        Cliente GetClienteById(int clienteId);

        [OperationContract]
        void AddCliente(Cliente cliente);

        [OperationContract]
        void UpdateCliente(Cliente cliente);

        [OperationContract]
        void DeleteCliente(int clienteId);
    }
}
