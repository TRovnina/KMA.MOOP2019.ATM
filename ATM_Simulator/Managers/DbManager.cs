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
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetATMByCode(atmCode);
        }
        //
        public static void AddATM(ATM atm)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.AddATM(atm);
        }
        //
        public static Manager GetManagerById(string managerId)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetManagerById(managerId);
        }
        //
        public static void AddManager(Manager manager)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.AddManager(manager);
        }
        //
        public static Account GetAccountByNum(string accountNum)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetAccountByNum(accountNum);
        }
        //
        public static void AddClient(Client client)
        {
            ServiceReference1.ServiceATMClient clientS = new ServiceATMClient();
            clientS.AddClient(client);
        }
        //
        public static bool AccountExist(string accountNum)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.AccountExist(accountNum);
        }
        //
        public static Client GetClientByItn(string clientItn)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetClientByItn(clientItn);
        }

        public static void AddATMAccountAction(ATMAccountAction action)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.AddATMAccountAction(action);
        }

        public static void AddATMManagerAction(ATMManagerAction atmManagerAction)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.AddATMManagerAction(atmManagerAction);
        }
        //
        public static void AddRegularPayment(RegularPayment regularPayment)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.AddRegularPayment(regularPayment);
        }
        //
        public static void SaveATM(ATM atm)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.SaveATM(atm);
        }
        //
        public static void SaveAccount(Account account)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.SaveAccount(account);
        }
        //
        public static List<RegularPayment> GetRegularPayments(string accountNum)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetRegularPayments(accountNum).ToList();
        }

        public static List<Account> GetAllBlockedAccounts()
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetAllBlockedAccounts().ToList();
        }

        public static void DeleteRegularPayment(RegularPayment regularPayment)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.DeleteRegularPayment(regularPayment);
        }

        public static List<Client> GetAllClients()
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetAllClients().ToList();
        }

        public static List<ATM> GetAllATMs()
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetAllATMs().ToList();
        }

        public static List<Manager> GetAllManagers()
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetAllManagers().ToList();
        }
    }
}
