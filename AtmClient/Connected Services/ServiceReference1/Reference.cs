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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServiceATM")]
    public interface IServiceATM {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetATMByCode", ReplyAction="http://tempuri.org/IServiceATM/GetATMByCodeResponse")]
        DBModels.ATM GetATMByCode(string atmCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetATMByCode", ReplyAction="http://tempuri.org/IServiceATM/GetATMByCodeResponse")]
        System.Threading.Tasks.Task<DBModels.ATM> GetATMByCodeAsync(string atmCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddATM", ReplyAction="http://tempuri.org/IServiceATM/AddATMResponse")]
        void AddATM(DBModels.ATM atm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddATM", ReplyAction="http://tempuri.org/IServiceATM/AddATMResponse")]
        System.Threading.Tasks.Task AddATMAsync(DBModels.ATM atm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetManagerById", ReplyAction="http://tempuri.org/IServiceATM/GetManagerByIdResponse")]
        DBModels.Manager GetManagerById(string managerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetManagerById", ReplyAction="http://tempuri.org/IServiceATM/GetManagerByIdResponse")]
        System.Threading.Tasks.Task<DBModels.Manager> GetManagerByIdAsync(string managerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddManager", ReplyAction="http://tempuri.org/IServiceATM/AddManagerResponse")]
        void AddManager(DBModels.Manager manager);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddManager", ReplyAction="http://tempuri.org/IServiceATM/AddManagerResponse")]
        System.Threading.Tasks.Task AddManagerAsync(DBModels.Manager manager);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetAccountByNum", ReplyAction="http://tempuri.org/IServiceATM/GetAccountByNumResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.CurrentAccount))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.DepositAccount))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.CreditAccount))]
        DBModels.Account GetAccountByNum(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetAccountByNum", ReplyAction="http://tempuri.org/IServiceATM/GetAccountByNumResponse")]
        System.Threading.Tasks.Task<DBModels.Account> GetAccountByNumAsync(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddClient", ReplyAction="http://tempuri.org/IServiceATM/AddClientResponse")]
        void AddClient(DBModels.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddClient", ReplyAction="http://tempuri.org/IServiceATM/AddClientResponse")]
        System.Threading.Tasks.Task AddClientAsync(DBModels.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AccountExist", ReplyAction="http://tempuri.org/IServiceATM/AccountExistResponse")]
        bool AccountExist(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AccountExist", ReplyAction="http://tempuri.org/IServiceATM/AccountExistResponse")]
        System.Threading.Tasks.Task<bool> AccountExistAsync(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetClientByItn", ReplyAction="http://tempuri.org/IServiceATM/GetClientByItnResponse")]
        DBModels.Client GetClientByItn(string clientItn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetClientByItn", ReplyAction="http://tempuri.org/IServiceATM/GetClientByItnResponse")]
        System.Threading.Tasks.Task<DBModels.Client> GetClientByItnAsync(string clientItn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddATMAccountAction", ReplyAction="http://tempuri.org/IServiceATM/AddATMAccountActionResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.CurrentAccount))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.DepositAccount))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.CreditAccount))]
        void AddATMAccountAction(DBModels.ATMAccountAction action);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddATMAccountAction", ReplyAction="http://tempuri.org/IServiceATM/AddATMAccountActionResponse")]
        System.Threading.Tasks.Task AddATMAccountActionAsync(DBModels.ATMAccountAction action);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddATMManagerAction", ReplyAction="http://tempuri.org/IServiceATM/AddATMManagerActionResponse")]
        void AddATMManagerAction(DBModels.ATMManagerAction atmManagerAction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddATMManagerAction", ReplyAction="http://tempuri.org/IServiceATM/AddATMManagerActionResponse")]
        System.Threading.Tasks.Task AddATMManagerActionAsync(DBModels.ATMManagerAction atmManagerAction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddRegularPayment", ReplyAction="http://tempuri.org/IServiceATM/AddRegularPaymentResponse")]
        void AddRegularPayment(DBModels.RegularPayment regularPayment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/AddRegularPayment", ReplyAction="http://tempuri.org/IServiceATM/AddRegularPaymentResponse")]
        System.Threading.Tasks.Task AddRegularPaymentAsync(DBModels.RegularPayment regularPayment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/SaveATM", ReplyAction="http://tempuri.org/IServiceATM/SaveATMResponse")]
        void SaveATM(DBModels.ATM atm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/SaveATM", ReplyAction="http://tempuri.org/IServiceATM/SaveATMResponse")]
        System.Threading.Tasks.Task SaveATMAsync(DBModels.ATM atm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/SaveAccount", ReplyAction="http://tempuri.org/IServiceATM/SaveAccountResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.CurrentAccount))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.DepositAccount))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DBModels.CreditAccount))]
        void SaveAccount(DBModels.Account account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/SaveAccount", ReplyAction="http://tempuri.org/IServiceATM/SaveAccountResponse")]
        System.Threading.Tasks.Task SaveAccountAsync(DBModels.Account account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetRegularPayments", ReplyAction="http://tempuri.org/IServiceATM/GetRegularPaymentsResponse")]
        DBModels.RegularPayment[] GetRegularPayments(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetRegularPayments", ReplyAction="http://tempuri.org/IServiceATM/GetRegularPaymentsResponse")]
        System.Threading.Tasks.Task<DBModels.RegularPayment[]> GetRegularPaymentsAsync(string accountNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetAllBlockedAccounts", ReplyAction="http://tempuri.org/IServiceATM/GetAllBlockedAccountsResponse")]
        DBModels.Account[] GetAllBlockedAccounts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/GetAllBlockedAccounts", ReplyAction="http://tempuri.org/IServiceATM/GetAllBlockedAccountsResponse")]
        System.Threading.Tasks.Task<DBModels.Account[]> GetAllBlockedAccountsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/DeleteRegularPayment", ReplyAction="http://tempuri.org/IServiceATM/DeleteRegularPaymentResponse")]
        void DeleteRegularPayment(DBModels.RegularPayment regularPayment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceATM/DeleteRegularPayment", ReplyAction="http://tempuri.org/IServiceATM/DeleteRegularPaymentResponse")]
        System.Threading.Tasks.Task DeleteRegularPaymentAsync(DBModels.RegularPayment regularPayment);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceATMChannel : AtmClient.ServiceReference1.IServiceATM, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceATMClient : System.ServiceModel.ClientBase<AtmClient.ServiceReference1.IServiceATM>, AtmClient.ServiceReference1.IServiceATM {
        
        public ServiceATMClient() {
        }
        
        public ServiceATMClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceATMClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceATMClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceATMClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DBModels.ATM GetATMByCode(string atmCode) {
            return base.Channel.GetATMByCode(atmCode);
        }
        
        public System.Threading.Tasks.Task<DBModels.ATM> GetATMByCodeAsync(string atmCode) {
            return base.Channel.GetATMByCodeAsync(atmCode);
        }
        
        public void AddATM(DBModels.ATM atm) {
            base.Channel.AddATM(atm);
        }
        
        public System.Threading.Tasks.Task AddATMAsync(DBModels.ATM atm) {
            return base.Channel.AddATMAsync(atm);
        }
        
        public DBModels.Manager GetManagerById(string managerId) {
            return base.Channel.GetManagerById(managerId);
        }
        
        public System.Threading.Tasks.Task<DBModels.Manager> GetManagerByIdAsync(string managerId) {
            return base.Channel.GetManagerByIdAsync(managerId);
        }
        
        public void AddManager(DBModels.Manager manager) {
            base.Channel.AddManager(manager);
        }
        
        public System.Threading.Tasks.Task AddManagerAsync(DBModels.Manager manager) {
            return base.Channel.AddManagerAsync(manager);
        }
        
        public DBModels.Account GetAccountByNum(string accountNum) {
            return base.Channel.GetAccountByNum(accountNum);
        }
        
        public System.Threading.Tasks.Task<DBModels.Account> GetAccountByNumAsync(string accountNum) {
            return base.Channel.GetAccountByNumAsync(accountNum);
        }
        
        public void AddClient(DBModels.Client client) {
            base.Channel.AddClient(client);
        }
        
        public System.Threading.Tasks.Task AddClientAsync(DBModels.Client client) {
            return base.Channel.AddClientAsync(client);
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
        
        public void AddRegularPayment(DBModels.RegularPayment regularPayment) {
            base.Channel.AddRegularPayment(regularPayment);
        }
        
        public System.Threading.Tasks.Task AddRegularPaymentAsync(DBModels.RegularPayment regularPayment) {
            return base.Channel.AddRegularPaymentAsync(regularPayment);
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
        
        public DBModels.RegularPayment[] GetRegularPayments(string accountNum) {
            return base.Channel.GetRegularPayments(accountNum);
        }
        
        public System.Threading.Tasks.Task<DBModels.RegularPayment[]> GetRegularPaymentsAsync(string accountNum) {
            return base.Channel.GetRegularPaymentsAsync(accountNum);
        }
        
        public DBModels.Account[] GetAllBlockedAccounts() {
            return base.Channel.GetAllBlockedAccounts();
        }
        
        public System.Threading.Tasks.Task<DBModels.Account[]> GetAllBlockedAccountsAsync() {
            return base.Channel.GetAllBlockedAccountsAsync();
        }
        
        public void DeleteRegularPayment(DBModels.RegularPayment regularPayment) {
            base.Channel.DeleteRegularPayment(regularPayment);
        }
        
        public System.Threading.Tasks.Task DeleteRegularPaymentAsync(DBModels.RegularPayment regularPayment) {
            return base.Channel.DeleteRegularPaymentAsync(regularPayment);
        }
    }
}
