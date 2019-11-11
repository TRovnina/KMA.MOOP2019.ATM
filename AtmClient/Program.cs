using System;
using System.Collections.Generic;
using DBModels;

using ATM_Simulator.Managers;

namespace AtmClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Clients::");
            List<Client> clients = DbManager.GetAllClients();
            foreach (var cl in clients)
            {
                Console.WriteLine("Clients::");
                Console.WriteLine(cl.ToString());
                List<Account> acc = cl.Accounts;
                foreach (var a in acc)
                {
                    Console.WriteLine(a.ToString());
                    Console.WriteLine(a.CardPassword);
                }
            }
            Console.WriteLine("ATM:: ");
            List<ATM> atmL = DbManager.GetAllATMs();
            foreach (var atm in atmL)
            {
                Console.Write("ATM:: ");
                Console.WriteLine(atm.ToString());
            }
            Console.WriteLine("Managers::");
            List<Manager> man = DbManager.GetAllManagers();
            foreach (var m in man)
            {
                Console.Write("Managers: ");
                Console.WriteLine(m.ToString());
                Console.WriteLine(m.Password);
            }

            //DbManager.AddATM(new ATM("0", "0", "s"));

            ////Dictionary<int, int> dic = new Dictionary<int, int>();
            ////dic.Add(50,2);
            ////CashWithdrawalViewModel m = new CashWithdrawalViewModel();
            ////int[] mm = m.Multiplicity(100, dic);
            ////foreach (var v in mm)
            ////{
            ////    Console.WriteLine(v);
            ////}

            //ATM atm1 = new ATM("1", Encrypting.GetMd5HashForString("1"), "Kyiv");
            //atm1.Banknote50 = 2;
            //atm1.Banknote100 = 4;
            //atm1.Banknote200 = 10;
            //atm1.Banknote500 = 2;
            //DbManager.AddATM(atm1);

            //Manager manager0 = new Manager("0", "Anatoly", "Mironov", Encrypting.GetMd5HashForString("0"));
            //DbManager.AddManager(manager0);

            //Console.WriteLine(DbManager.GetAllBlockedAccounts().Count);

            //ATM atm2 = new ATM("9820635500077890", Encrypting.GetMd5HashForString("wq23fk42@u23iWr0"), "Kyiv");
            //atm2.Banknote50 = 2;
            //atm2.Banknote100 = 4;
            //atm2.Banknote200 = 10;
            //atm2.Banknote500 = 2;

            //DbManager.AddATM(atm2);
            //Console.WriteLine("TTT");
            //Manager manager1 = new Manager("2004999932830009", "Anatoly", "Mironov", Encrypting.GetMd5HashForString("2305"));
            //Manager manager2 = new Manager("1234900131230010", "Ivan", "Drozdov", Encrypting.GetMd5HashForString("8403"));
            //DbManager.AddManager(manager1);
            //DbManager.AddManager(manager2);

            ////Client A
            //Client client1 = new Client("5", "Petro", "Petrenko");
            //CurrentAccount currentAccount1 = new CurrentAccount("5467329813430003",
            //    Encrypting.GetMd5HashForString("2395"), client1, 0, PeriodHandingCashSurplus.None);
            //currentAccount1.AvailableSum = 12000;

            //CreditAccount creditAccount1 = new CreditAccount("5467329856000003",
            //    Encrypting.GetMd5HashForString("1603"), client1, DateTime.Today, 12000, 0, 0);
            //creditAccount1.AvailableSum = 238;

            //DepositAccount depositAccount1 = new DepositAccount("5467320856000003",
            //    Encrypting.GetMd5HashForString("0423"), client1, new DateTime(2016, 10, 12),
            //    new DateTime(2017, 10, 12), 10);
            //depositAccount1.AvailableSum = 134500;
            //DbManager.AddClient(client1);
            /*DbManager.AddClient(client1);
            Account account = DbManager.GetAccountByNum("5467329813430003");
            Console.WriteLine(account.CardPassword);
            Console.WriteLine(Encrypting.GetMd5HashForString("2395"));
            Console.WriteLine(account.CheckPassword("2395"));
            */
            ////Client B
            //Client client2 = new Client("3548507816", "Petro", "Sidorenko");
            //CurrentAccount currentAccount2 = new CurrentAccount("5467009812345643",
            //    Encrypting.GetMd5HashForString("0225"), client2, 0, PeriodHandingCashSurplus.None);
            //currentAccount2.AvailableSum = 1200;
            //currentAccount2.IsActive = false;

            //CreditAccount creditAccount2 = new CreditAccount("5467009812345987",
            //    Encrypting.GetMd5HashForString("7643"), client2, new DateTime(2019, 12, 3), 12000, 1000, 5);
            //creditAccount2.AvailableSum = 0;

            //DepositAccount depositAccount2 = new DepositAccount("5467009810045643",
            //    Encrypting.GetMd5HashForString("1350"), client2, new DateTime(2019, 10, 12),
            //    new DateTime(2019, 11, 30), 10);
            //depositAccount2.AvailableSum = 1000;
            //depositAccount2.IsActive = false;

            //DbManager.AddClient(client2);

            ////// Client C
            //Client client3 = new Client("3489702389", "Alina", "Ivanova");
            //CurrentAccount currentAccount3 = new CurrentAccount("5337139866345666",
            //    Encrypting.GetMd5HashForString("2220"), client3, 0, PeriodHandingCashSurplus.None);
            //currentAccount3.AvailableSum = 12000;

            //CreditAccount creditAccount3 = new CreditAccount("5337132546545987",
            //    Encrypting.GetMd5HashForString("4043"), client3, new DateTime(2019, 12, 3), 12000,
            //    0, 0);
            //creditAccount3.AvailableSum = 1200;

            //DepositAccount depositAccount3 = new DepositAccount("5337025618945600",
            //    Encrypting.GetMd5HashForString("3335"), client3, new DateTime(2018, 10, 12),
            //    new DateTime(2019, 12, 30), 10);
            //depositAccount3.AvailableSum = 100000;

            //DbManager.AddClient(client3);
            /////CLient D
            // Client client = new Client("3489702366", "Kateryna", "Ivanova");
            //CurrentAccount currentAccount1 = new CurrentAccount("5337130098741356",
            //    Encrypting.GetMd5HashForString("2944"), client, 0, PeriodHandingCashSurplus.None);
            //currentAccount1.AvailableSum = 12000;

            //CreditAccount creditAccount = new CreditAccount("5337130098745787",
            //    Encrypting.GetMd5HashForString("8349"), client, new DateTime(2019, 12, 12), 12000,
            //    1000, 5);
            //creditAccount.AvailableSum = 0;

            //DepositAccount depositAccount = new DepositAccount("5337130089745600",
            //    Encrypting.GetMd5HashForString("1345"), client, new DateTime(2018, 10, 12),
            //    new DateTime(2019, 9, 30), 10);
            //depositAccount.AvailableSum = 1000;

            //DbManager.AddClient(client);

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

            //       foreach (var blockedAccount in DbManager.GetAllBlockedAccounts())
            //{
            //    Console.WriteLine(blockedAccount.ToString());
            //}

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
