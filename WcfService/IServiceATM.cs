﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DBModels;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceATM" in both code and config file together.
    [ServiceKnownType(typeof(RegularPayment))]
    [ServiceContract]
    public interface IServiceATM
    {
        [OperationContract]
        ATM GetATMByCode(string atmCode);

        [OperationContract]
        void AddATM(ATM atm);

        [OperationContract]
        Manager GetManagerById(string managerId);

        [OperationContract]
        void AddManager(Manager manager);

        [OperationContract]
        Account GetAccountByNum(string accountNum);

        [OperationContract]
        void AddClient(Client client);

        [OperationContract]
        bool AccountExist(string accountNum);

        [OperationContract]
        Client GetClientByItn(string clientItn);

        [OperationContract]
        void AddATMAccountAction(ATMAccountAction action);

        [OperationContract]
        void AddATMManagerAction(ATMManagerAction atmManagerAction);

        [OperationContract]
        void AddRegularPayment(RegularPayment regularPayment);

        [OperationContract]
        void SaveATM(ATM atm);

        [OperationContract]
        void SaveAccount(Account account);

        [OperationContract]
        List<RegularPayment> GetRegularPayments(string accountNum);

        [OperationContract]
        List<Account> GetAllBlockedAccounts();

        [OperationContract]
        void DeleteRegularPayment(RegularPayment regularPayment);

        [OperationContract]
        List<Client> GetAllClients();

        [OperationContract]
        List<ATM> GetAllATMs();

        [OperationContract]
        List<Manager> GetAllManagers();

        [OperationContract]
        int WithdrawMoney(Account account, int sum);

        [OperationContract]
        int TransferMoney(Account sourceAccount, Account destinationAccount, int sum);
    }
}
