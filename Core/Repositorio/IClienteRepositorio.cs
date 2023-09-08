using Core.Modelos;
using System.Collections.Generic;

namespace Core.Repositorio
{
    public interface IClienteRepositorio
    {
        Cliente GetClienteById(int id);
        List<Cliente> GetClientes();
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
    }
}
