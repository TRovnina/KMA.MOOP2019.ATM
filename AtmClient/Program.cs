using System;
using DBModels;
using AtmClient.ServiceReference1;

namespace AtmClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ATM atm = new ATM("q","q","Kyiv");
             DbManager.AddATM(atm);*/



            /*if(atm == null)
                Console.WriteLine("null");
            else
            {
                Console.WriteLine(atm.ToString());
            }*/

            /*
            Client client01 = new Client("0", "0", "0");
            DepositAccount deposit = new DepositAccount("01", "01", client01, DateTime.Today,
                DateTime.Today, 0);
            CreditAccount credit = new CreditAccount("02", "02", client01, DateTime.Today,
                2000, 0, 0);
            CurrentAccount current = new CurrentAccount("03", "03", client01,
                0, PeriodHandingCashSurplus.None);

            DbManager.AddClient(client01);
            */

            /* Client client = DbManager.GetClientByItn("0");
             Console.WriteLine(client.CurrentAccount().ToString());

             RegularPayment regularPayment = new RegularPayment(PeriodRegularPayment.OnceMount, "regular 1",
                 client.CurrentAccount(), 200, client.DepositAccount().CardNumber);

             DbManager.AddRegularPayment(regularPayment);
             */

            /*foreach (var regularPayment in DbManager.GetRegularPayments("03"))
            {
                Console.WriteLine(regularPayment.ToString());
            }*/

            /* ATM atm = DbManager.GetATMByCode("q");
             Console.WriteLine(atm.Banknote50);
            atm.Banknote50 = 100;
            DbManager.SaveATM(atm);
            Console.WriteLine(atm.Banknote50);

            Account account = DbManager.GetAccountByNum("03");
            Console.WriteLine(account.IsActive);
            */
            /* account.IsActive = !account.IsActive;
             DbManager.SaveAccount(account);
             Console.WriteLine(account.IsActive);
             */

            /*Console.WriteLine(DbManager.AccountExist("01"));
            Console.WriteLine(DbManager.AccountExist("02"));
            Console.WriteLine(DbManager.AccountExist("03"));
            Console.WriteLine(DbManager.AccountExist("04"));*/

            //Manager manager = new Manager("00", "00", "00", "00");
            //DbManager.AddManager(manager);
            /*
                        Manager manager = DbManager.GetManagerById("0");
                        //Console.WriteLine(manager.ToString());
                        Console.WriteLine(manager == null);
                        */

            
           // Manager manager = DbManager.GetManagerById("00");
       //     ATM atm = DbManager.GetATMByCode("q");
            // DbManager.AddATMManagerAction(new ATMManagerAction(manager, atm));

     /*       Account account = DbManager.GetAccountByNum("03");
            DbManager.AddATMAccountAction(new ATMAccountAction(ActionType.CashWithdrawal, atm, account));
            DbManager.AddATMAccountAction(new ATMAccountAction(ActionType.Transfer, atm, account, DbManager.GetAccountByNum("02")));
*/
            Console.WriteLine("-----");
            Console.ReadKey();
            /*Console.WriteLine("Start");
            ATM atm = DbManager.GetATMByCode("1111111111111111");
            if(atm == null)
                Console.WriteLine("NULL");
            else
                Console.WriteLine(atm.ToString());

            Console.WriteLine("Finish");
            Console.ReadKey();
            */
        }
    }
}
