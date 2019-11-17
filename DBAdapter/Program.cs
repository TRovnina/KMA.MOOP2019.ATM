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
            List<Manager> managers = new List<Manager>();
            managers.Add(new Manager("1", "1", "1", "1"));
            managers.Add(new Manager("2", "2", "2", "2"));

            List<Object> objs = new List<object>(managers);

            List<Manager> managers2 = new List<Manager>();
            foreach (var o in objs)
            {
                managers2.Add(o as Manager);
            }

            foreach (var manager in managers2)
            {
                Console.WriteLine(manager.ToString());
            }

            /*Client client01 = new Client("0", "0", "0");
            DepositAccount deposit = new DepositAccount("01","01",client01,DateTime.Today, 
                DateTime.Today, 0);
            CreditAccount credit = new CreditAccount("02", "02", client01, DateTime.Today, 
                2000, 0, 0);
            CurrentAccount current = new CurrentAccount("03", "03",client01, 
                0, PeriodHandingCashSurplus.None);

            EntityWrapper.AddClient(client01);
            */

            /*Client client01 = EntityWrapper.GetClientByItn("0");
            foreach (var account in client01.Accounts)
            {
                Console.WriteLine(account.ToString());
            }
            

            RegularPayment regularPayment01 = new RegularPayment(PeriodRegularPayment.OnceMonth, "regular 2",
                client01.CurrentAccount(), 200, client01.DepositAccount().CardNumber);
            
            EntityWrapper.SaveAccount(client01.CurrentAccount());
            EntityWrapper.AddRegularPayment(regularPayment01);
            */

            /*CurrentAccount account1 = EntityWrapper.GetAccountByNum("03") as CurrentAccount;*/
            //ATM atm = EntityWrapper.GetATMByCode("111");

            /*ATMAccountAction atmAccountAction = new ATMAccountAction(ActionType.CashWithdrawal, atm, account1);
            EntityWrapper.AddATMAccountAction(atmAccountAction);
            */

            //Manager manager = new Manager("1","1","1","1");
            //EntityWrapper.AddManager(manager);

            // Manager manager = EntityWrapper.GetManagerById("1");

            //EntityWrapper.AddATMManagerAction(new ATMManagerAction(manager, atm));

            /* using (var context = new ATMDbContext())
             {
                 foreach (var atM in context.ATMManagerActions)
                 {
                     Console.WriteLine(atM.ManagerId);
                     Console.WriteLine(atM.ATMCode);
                 }
             }*/

            Console.WriteLine("------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
