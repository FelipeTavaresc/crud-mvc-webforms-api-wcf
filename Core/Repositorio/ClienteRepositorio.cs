using System;
using System.Collections.Generic;
using System.Linq;
using Core.Context;
using Core.Enums;
using Core.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private static ClienteRepositorio _instance = new ClienteRepositorio();
        private GtiContext _gtiContext;

        public static ClienteRepositorio Instance()
        {
            if (_instance == null)
                _instance = new ClienteRepositorio();
            return _instance;
        }

        private ClienteRepositorio()
        {
            _gtiContext = new GtiContext();
        }

        public void UpdateCliente(Cliente obj)
        {
            try
            {
                //TO DO - testar sem fazer o new GtiContext
                _gtiContext = new GtiContext();
                bool existeCliente = _gtiContext.Cliente.Any(x => x.Id == obj.Id);
                if (existeCliente)
                {
                    _gtiContext.Update(obj);
                    _gtiContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCliente(int id)
        {
            try
            {
                var obj = _gtiContext.Cliente.Include(x => x.EnderecoCliente).Where(x => x.Id == id).FirstOrDefault();
                if (obj != null)
                {
                    _gtiContext.RemoveRange(obj.EnderecoCliente);
                    _gtiContext.Cliente.Remove(obj);
                    _gtiContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Cliente GetClienteById(int id)
        {
            try
            {
                return _gtiContext.Cliente.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cliente> GetClientes()
        {
            try
            {
                return _gtiContext.Cliente.OrderBy(x => x.Id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddCliente(Cliente obj)
        {
            try
            {
                _gtiContext.Add(obj);
                _gtiContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
