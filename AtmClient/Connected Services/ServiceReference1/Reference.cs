﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AtmClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAtmService")]
    public interface IAtmService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetATMByCode", ReplyAction="http://tempuri.org/IAtmService/GetATMByCodeResponse")]
        DBModels.ATM GetATMByCode(string atmCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetATMByCode", ReplyAction="http://tempuri.org/IAtmService/GetATMByCodeResponse")]
        System.Threading.Tasks.Task<DBModels.ATM> GetATMByCodeAsync(string atmCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetManagerById", ReplyAction="http://tempuri.org/IAtmService/GetManagerByIdResponse")]
        DBModels.Manager GetManagerById(string managerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetManagerById", ReplyAction="http://tempuri.org/IAtmService/GetManagerByIdResponse")]
        System.Threading.Tasks.Task<DBModels.Manager> GetManagerByIdAsync(string managerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetAccountByNum", ReplyAction="http://tempuri.org/IAtmService/GetAccountByNumResponse")]
        DBModels.Account GetAccountByNum(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetAccountByNum", ReplyAction="http://tempuri.org/IAtmService/GetAccountByNumResponse")]
        System.Threading.Tasks.Task<DBModels.Account> GetAccountByNumAsync(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/AccountExist", ReplyAction="http://tempuri.org/IAtmService/AccountExistResponse")]
        bool AccountExist(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/AccountExist", ReplyAction="http://tempuri.org/IAtmService/AccountExistResponse")]
        System.Threading.Tasks.Task<bool> AccountExistAsync(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetClientByItn", ReplyAction="http://tempuri.org/IAtmService/GetClientByItnResponse")]
        DBModels.Client GetClientByItn(string clientItn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/GetClientByItn", ReplyAction="http://tempuri.org/IAtmService/GetClientByItnResponse")]
        System.Threading.Tasks.Task<DBModels.Client> GetClientByItnAsync(string clientItn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/AddATMAccountAction", ReplyAction="http://tempuri.org/IAtmService/AddATMAccountActionResponse")]
        void AddATMAccountAction(DBModels.ATMAccountAction action);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/AddATMAccountAction", ReplyAction="http://tempuri.org/IAtmService/AddATMAccountActionResponse")]
        System.Threading.Tasks.Task AddATMAccountActionAsync(DBModels.ATMAccountAction action);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/AddATMManagerAction", ReplyAction="http://tempuri.org/IAtmService/AddATMManagerActionResponse")]
        void AddATMManagerAction(DBModels.ATMManagerAction atmManagerAction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/AddATMManagerAction", ReplyAction="http://tempuri.org/IAtmService/AddATMManagerActionResponse")]
        System.Threading.Tasks.Task AddATMManagerActionAsync(DBModels.ATMManagerAction atmManagerAction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/SaveATM", ReplyAction="http://tempuri.org/IAtmService/SaveATMResponse")]
        void SaveATM(DBModels.ATM atm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/SaveATM", ReplyAction="http://tempuri.org/IAtmService/SaveATMResponse")]
        System.Threading.Tasks.Task SaveATMAsync(DBModels.ATM atm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/SaveAccount", ReplyAction="http://tempuri.org/IAtmService/SaveAccountResponse")]
        void SaveAccount(DBModels.Account account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtmService/SaveAccount", ReplyAction="http://tempuri.org/IAtmService/SaveAccountResponse")]
        System.Threading.Tasks.Task SaveAccountAsync(DBModels.Account account);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAtmServiceChannel : AtmClient.ServiceReference1.IAtmService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AtmServiceClient : System.ServiceModel.ClientBase<AtmClient.ServiceReference1.IAtmService>, AtmClient.ServiceReference1.IAtmService {
        
        public AtmServiceClient() {
        }
        
        public AtmServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AtmServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AtmServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AtmServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DBModels.ATM GetATMByCode(string atmCode) {
            return base.Channel.GetATMByCode(atmCode);
        }
        
        public System.Threading.Tasks.Task<DBModels.ATM> GetATMByCodeAsync(string atmCode) {
            return base.Channel.GetATMByCodeAsync(atmCode);
        }
        
        public DBModels.Manager GetManagerById(string managerId) {
            return base.Channel.GetManagerById(managerId);
        }
        
        public System.Threading.Tasks.Task<DBModels.Manager> GetManagerByIdAsync(string managerId) {
            return base.Channel.GetManagerByIdAsync(managerId);
        }
        
        public DBModels.Account GetAccountByNum(string accountNum) {
            return base.Channel.GetAccountByNum(accountNum);
        }
        
        public System.Threading.Tasks.Task<DBModels.Account> GetAccountByNumAsync(string accountNum) {
            return base.Channel.GetAccountByNumAsync(accountNum);
        }
        
        public bool AccountExist(string accountNum) {
            return base.Channel.AccountExist(accountNum);
        }
        
        public System.Threading.Tasks.Task<bool> AccountExistAsync(string accountNum) {
            return base.Channel.AccountExistAsync(accountNum);
        }
        
        public DBModels.Client GetClientByItn(string clientItn) {
            return base.Channel.GetClientByItn(clientItn);
        }
        
        public System.Threading.Tasks.Task<DBModels.Client> GetClientByItnAsync(string clientItn) {
            return base.Channel.GetClientByItnAsync(clientItn);
        }
        
        public void AddATMAccountAction(DBModels.ATMAccountAction action) {
            base.Channel.AddATMAccountAction(action);
        }
        
        public System.Threading.Tasks.Task AddATMAccountActionAsync(DBModels.ATMAccountAction action) {
            return base.Channel.AddATMAccountActionAsync(action);
        }
        
        public void AddATMManagerAction(DBModels.ATMManagerAction atmManagerAction) {
            base.Channel.AddATMManagerAction(atmManagerAction);
        }
        
        public System.Threading.Tasks.Task AddATMManagerActionAsync(DBModels.ATMManagerAction atmManagerAction) {
            return base.Channel.AddATMManagerActionAsync(atmManagerAction);
        }
        
        public void SaveATM(DBModels.ATM atm) {
            base.Channel.SaveATM(atm);
        }
        
        public System.Threading.Tasks.Task SaveATMAsync(DBModels.ATM atm) {
            return base.Channel.SaveATMAsync(atm);
        }
        
        public void SaveAccount(DBModels.Account account) {
            base.Channel.SaveAccount(account);
        }
        
        public System.Threading.Tasks.Task SaveAccountAsync(DBModels.Account account) {
            return base.Channel.SaveAccountAsync(account);
        }
    }
}
