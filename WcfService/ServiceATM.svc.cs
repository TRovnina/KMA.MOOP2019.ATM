using System;
using System.Collections.Generic;
using System.Linq;
using DBAdapter;
using DBModels;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceATM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceATM.svc or ServiceATM.svc.cs at the Solution Explorer and start debugging.
    public class ServiceATM : IServiceATM
    {
        public ATM GetATMByCode(string atmCode)
        {
            return EntityWrapper.GetATMByCode(atmCode);
        }

        public Manager GetManagerById(string managerId)
        {
            return EntityWrapper.GetManagerById(managerId);
        }

        public void AddManager(Manager manager)
        {
            EntityWrapper.AddManager(manager);
        }

        public Account GetAccountByNum(string accountNum)
        {
            return EntityWrapper.GetAccountByNum(accountNum);
        }

        public void AddClient(Client client)
        {
            EntityWrapper.AddClient(client);
        }

        public bool AccountExist(string accountNum)
        {
            return EntityWrapper.AccountExist(accountNum);
        }

        public Client GetClientByItn(string clientItn)
        {
            return EntityWrapper.GetClientByItn(clientItn);
        }

        public void AddATMAccountAction(ATMAccountAction action)
        {
            EntityWrapper.AddATMAccountAction(action);
        }

        public void AddATMManagerAction(ATMManagerAction atmManagerAction)
        {
            EntityWrapper.AddATMManagerAction(atmManagerAction);
        }

        public void AddRegularPayment(RegularPayment regularPayment)
        {
            /*RegularPayment rp = regularPayment as RegularPayment;
            if (rp == null)
                return false;*/
            EntityWrapper.AddRegularPayment(regularPayment);
        }

        public void SaveATM(ATM atm)
        {
            EntityWrapper.SaveATM(atm);
        }

        public void SaveAccount(Account account)
        {
            EntityWrapper.SaveAccount(account);
        }

        public List<RegularPayment> GetRegularPayments(string accountNum)
        {
            return EntityWrapper.GetRegularPayments(accountNum);
        }

        public List<Account> GetAllBlockedAccounts()
        {
            return EntityWrapper.GetAllBlockedAccounts();
        }

        public void DeleteRegularPayment(RegularPayment regularPayment)
        {
            EntityWrapper.DeleteRegularPayment(regularPayment);
        }

        public List<Client> GetAllClients()
        {
            return EntityWrapper.GetAllClients();
        }

        public List<ATM> GetAllATMs()
        {
            return EntityWrapper.GetAllATMs();
        }

        public List<Manager> GetAllManagers()
        {
            return EntityWrapper.GetAllManagers();
        }

        public int WithdrawMoney(Account account, int sum)
        {
            return EntityWrapper.WithdrawMoney(account, sum);
        }

        public int TransferMoney(Account sourceAccount, Account destinationAccount, int sum)
        {
            return EntityWrapper.TransferMoney(sourceAccount, destinationAccount, sum);
        }

        public void AddATM(ATM atm)
        {
            EntityWrapper.AddATM(atm);
        }
    }
}
