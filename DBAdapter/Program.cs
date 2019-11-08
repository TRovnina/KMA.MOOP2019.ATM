using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;

namespace DBAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm01 = EntityWrapper.GetATMByCode("1111111111111111");
            Manager manager01 = EntityWrapper.GetManagerById("m");
            
            Client client01 = new Client("1111", "Kate", "Joly");
            DepositAccount depositAccount01 = new DepositAccount("111", "111", 
                client01, DateTime.Today, DateTime.Today, 0);
            CreditAccount creditAccount01 = new CreditAccount("112", "112", client01,
                DateTime.Today, 2000, 0, 0);
            CurrentAccount currentAccount01 = new CurrentAccount("113", "113", client01,
                0, PeriodHandingCashSurplus.None);
            

            using (var context = new ATMDbContext())
            {
                context.Clients.Add(client01);
                context.Accounts.Add(depositAccount01);
                context.Accounts.Add(creditAccount01);
                context.Accounts.Add(currentAccount01);
                context.SaveChanges();

                Console.WriteLine("ATMs: ");
                foreach (var atm in context.ATMs)
                {
                    Console.WriteLine(atm.ToString());
                    Console.WriteLine(atm.Banknote50);
                    Console.WriteLine(atm.Banknote100);
                    Console.WriteLine(atm.Banknote200);
                    Console.WriteLine(atm.Banknote500);
                    Console.WriteLine();
                }

                Console.WriteLine("Managers: ");
                foreach (var contextManager in context.Managers)
                {
                    Console.WriteLine(contextManager.ToString());
                    Console.WriteLine();
                }

                Console.WriteLine("ATMManagerActions: ");
                foreach (var atmManagerAction in context.ATMManagerActions)
                {
                    Console.WriteLine(atmManagerAction.ATMManagerActionId);
                    Console.WriteLine(atmManagerAction.ATMCode + " " + atmManagerAction.ManagerId);
                    Console.WriteLine(atmManagerAction.ActionDate);
                    Console.WriteLine();
                }

                Console.WriteLine("Clients: ");
                foreach (var client in context.Clients)
                {
                    Console.WriteLine(client.ToString());
                    foreach (var clientAccount in client.Accounts)
                    {
                        Console.WriteLine(clientAccount.ToString());
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Deposit Accounts: ");
                foreach (var depositAccount in context.Accounts.OfType<DepositAccount>())
                {
                    Console.WriteLine(depositAccount.ToString());
                    Console.WriteLine();
                }

                Console.WriteLine("Finishing . . .");
                Console.ReadKey();
            }
        }
    }
}
