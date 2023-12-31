﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebForm.ClienteService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ClienteService.IClienteService")]
    public interface IClienteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetClientes", ReplyAction="http://tempuri.org/IClienteService/GetClientesResponse")]
        Core.Modelos.Cliente[] GetClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetClientes", ReplyAction="http://tempuri.org/IClienteService/GetClientesResponse")]
        System.Threading.Tasks.Task<Core.Modelos.Cliente[]> GetClientesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetClienteById", ReplyAction="http://tempuri.org/IClienteService/GetClienteByIdResponse")]
        Core.Modelos.Cliente GetClienteById(int clienteId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/GetClienteById", ReplyAction="http://tempuri.org/IClienteService/GetClienteByIdResponse")]
        System.Threading.Tasks.Task<Core.Modelos.Cliente> GetClienteByIdAsync(int clienteId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/AddCliente", ReplyAction="http://tempuri.org/IClienteService/AddClienteResponse")]
        void AddCliente(Core.Modelos.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/AddCliente", ReplyAction="http://tempuri.org/IClienteService/AddClienteResponse")]
        System.Threading.Tasks.Task AddClienteAsync(Core.Modelos.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/UpdateCliente", ReplyAction="http://tempuri.org/IClienteService/UpdateClienteResponse")]
        void UpdateCliente(Core.Modelos.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/UpdateCliente", ReplyAction="http://tempuri.org/IClienteService/UpdateClienteResponse")]
        System.Threading.Tasks.Task UpdateClienteAsync(Core.Modelos.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/DeleteCliente", ReplyAction="http://tempuri.org/IClienteService/DeleteClienteResponse")]
        void DeleteCliente(int clienteId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClienteService/DeleteCliente", ReplyAction="http://tempuri.org/IClienteService/DeleteClienteResponse")]
        System.Threading.Tasks.Task DeleteClienteAsync(int clienteId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClienteServiceChannel : WebForm.ClienteService.IClienteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClienteServiceClient : System.ServiceModel.ClientBase<WebForm.ClienteService.IClienteService>, WebForm.ClienteService.IClienteService {
        
        public ClienteServiceClient() {
        }
        
        public ClienteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Core.Modelos.Cliente[] GetClientes() {
            return base.Channel.GetClientes();
        }
        
        public System.Threading.Tasks.Task<Core.Modelos.Cliente[]> GetClientesAsync() {
            return base.Channel.GetClientesAsync();
        }
        
        public Core.Modelos.Cliente GetClienteById(int clienteId) {
            return base.Channel.GetClienteById(clienteId);
        }
        
        public System.Threading.Tasks.Task<Core.Modelos.Cliente> GetClienteByIdAsync(int clienteId) {
            return base.Channel.GetClienteByIdAsync(clienteId);
        }
        
        public void AddCliente(Core.Modelos.Cliente cliente) {
            base.Channel.AddCliente(cliente);
        }
        
        public System.Threading.Tasks.Task AddClienteAsync(Core.Modelos.Cliente cliente) {
            return base.Channel.AddClienteAsync(cliente);
        }
        
        public void UpdateCliente(Core.Modelos.Cliente cliente) {
            base.Channel.UpdateCliente(cliente);
        }
        
        public System.Threading.Tasks.Task UpdateClienteAsync(Core.Modelos.Cliente cliente) {
            return base.Channel.UpdateClienteAsync(cliente);
        }
        
        public void DeleteCliente(int clienteId) {
            base.Channel.DeleteCliente(clienteId);
        }
        
        public System.Threading.Tasks.Task DeleteClienteAsync(int clienteId) {
            return base.Channel.DeleteClienteAsync(clienteId);
        }
    }
}
