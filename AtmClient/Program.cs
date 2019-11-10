﻿using System;
using System.Collections.Generic;
using DBModels;
using AtmClient.ServiceReference1;
using ATM_Simulator.ViewModel.ClientServices.CashWithdrawal;

namespace AtmClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //Dictionary<int, int> dic = new Dictionary<int, int>();
            //dic.Add(50,2);
            //CashWithdrawalViewModel m = new CashWithdrawalViewModel();
            //int[] mm = m.Multiplicity(100, dic);
            //foreach (var v in mm)
            //{
            //    Console.WriteLine(v);
            //}

            ATM atm1 = new ATM("1", "1", "Kyiv");
            atm1.Banknote50 = 2;
            atm1.Banknote100 = 4;
            atm1.Banknote200 = 10;
            atm1.Banknote500 = 2;
            DbManager.AddATM(atm1);

            Manager manager0 = new Manager("0", "Anatoly", "Mironov", "0");
            DbManager.AddManager(manager0);

            Console.WriteLine(DbManager.GetAllBlockedAccounts().Count);

            ATM atm2 = new ATM("9820635500077891", "dfRes092nde33@ie", "Kyiv");
            atm2.Banknote50 = 2;
            //atm2.Banknote100 = 4;
            //atm2.Banknote200 = 10;
            //atm2.Banknote500 = 2;

            DbManager.AddATM(atm2);

            Manager manager1 = new Manager("2004999932830009", "Anatoly", "Mironov", "2305");
            Manager manager2 = new Manager("1234900131230010", "Ivan", "Drozdov", "8403");
            DbManager.AddManager(manager1);
            DbManager.AddManager(manager2);

            //Client A
            Client client1 = new Client("5", "Petro", "Petrenko");
            CurrentAccount currentAccount1 = new CurrentAccount("5467329813430003",
                "2395", client1, 0, PeriodHandingCashSurplus.None);
            currentAccount1.AvailableSum = 12000;

            CreditAccount creditAccount1 = new CreditAccount("5467329856000003",
                "1603", client1, DateTime.Today, 12000, 0, 0);
            creditAccount1.AvailableSum = 238;

            DepositAccount depositAccount1 = new DepositAccount("5467320856000003",
                "0423", client1, new DateTime(2016, 10, 12),
                new DateTime(2017, 10, 12), 10);
            depositAccount1.AvailableSum = 134500;

            DbManager.AddClient(client1);
            Account account = DbManager.GetAccountByNum("5467329813430003");
            Console.WriteLine(account.CardPassword);
            Console.WriteLine(Encrypting.GetMd5HashForString("2395"));
            Console.WriteLine(account.CheckPassword("2395"));

            // Client B
            Client client2 = new Client("3548507816", "Petro", "Sidorenko");
            CurrentAccount currentAccount2 = new CurrentAccount("5467009812345643",
                "0225", client2, 0, PeriodHandingCashSurplus.None);
            currentAccount2.AvailableSum = 1200;
            currentAccount2.IsActive = false;

            CreditAccount creditAccount2 = new CreditAccount("5467009812345987",
                "7643", client2, new DateTime(2019, 12, 3), 12000, 1000, 5);
            creditAccount2.AvailableSum = 0;

            DepositAccount depositAccount2 = new DepositAccount("5467009810045643",
                "1350", client2, new DateTime(2019, 10, 12),
                new DateTime(2019, 11, 30), 10);
            depositAccount2.AvailableSum = 1000;
            depositAccount2.IsActive = false;

            DbManager.AddClient(client2);

            // Client C
            Client client3 = new Client("3489702389", "Alina", "Ivanova");
            CurrentAccount currentAccount3 = new CurrentAccount("5337139866345666",
                "2220", client3, 0, PeriodHandingCashSurplus.None);
            currentAccount3.AvailableSum = 12000;

            CreditAccount creditAccount3 = new CreditAccount("5337132546545987",
                "4043", client3, new DateTime(2019, 12, 3), 12000,
                0, 0);
            creditAccount3.AvailableSum = 1200;

            DepositAccount depositAccount3 = new DepositAccount("5337025618945600",
                "3335", client3, new DateTime(2018, 10, 12),
                new DateTime(2019, 12, 30), 10);
            depositAccount3.AvailableSum = 100000;

            DbManager.AddClient(client3);

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