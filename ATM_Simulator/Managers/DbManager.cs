using System.Collections.Generic;
using System.Linq;
using ATM_Simulator.ServiceReference1;
using DBModels;

namespace ATM_Simulator.Managers
{
    public class DbManager
    {
        //
        public static ATM GetATMByCode(string atmCode)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetATMByCode(atmCode);
        }
        //
        public static void AddATM(ATM atm)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.AddATM(atm);
        }
        //
        public static Manager GetManagerById(string managerId)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetManagerById(managerId);
        }
        //
        public static void AddManager(Manager manager)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.AddManager(manager);
        }
        //
        public static Account GetAccountByNum(string accountNum)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetAccountByNum(accountNum);
        }
        //
        public static void AddClient(Client client)
        {
            ServiceATMClient clientS = new ServiceATMClient();
            clientS.AddClient(client);
        }
        //
        public static bool AccountExist(string accountNum)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.AccountExist(accountNum);
        }
        //
        public static Client GetClientByItn(string clientItn)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetClientByItn(clientItn);
        }

        public static void AddATMAccountAction(ATMAccountAction action)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.AddATMAccountAction(action);
        }

        public static void AddATMManagerAction(ATMManagerAction atmManagerAction)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.AddATMManagerAction(atmManagerAction);
        }
        //
        public static void AddRegularPayment(RegularPayment regularPayment)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.AddRegularPayment(regularPayment);
        }
        //
        public static void SaveATM(ATM atm)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.SaveATM(atm);
        }
        //
        public static void SaveAccount(Account account)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.SaveAccount(account);
        }
        //
        public static List<RegularPayment> GetRegularPayments(string accountNum)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetRegularPayments(accountNum).ToList();
        }

        public static List<Account> GetAllBlockedAccounts()
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetAllBlockedAccounts().ToList();
        }

        public static void DeleteRegularPayment(RegularPayment regularPayment)
        {
            ServiceATMClient client = new ServiceATMClient();
            client.DeleteRegularPayment(regularPayment);
        }

        public static List<Client> GetAllClients()
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetAllClients().ToList();
        }

        public static List<ATM> GetAllATMs()
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetAllATMs().ToList();
        }

        public static List<Manager> GetAllManagers()
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.GetAllManagers().ToList();
        }

        public static int TransferMoney(Account sourceAccount, Account destinationAccount, int sum)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.TransferMoney(sourceAccount, destinationAccount, sum);
        }

        public static int WithdrawMoney(Account account, int sum)
        {
            ServiceATMClient client = new ServiceATMClient();
            return client.WithdrawMoney(account, sum);
        }
    }
}
