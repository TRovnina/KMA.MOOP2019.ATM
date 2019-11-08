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
            Client cl01 = new Client("123456", "Paule", "Jons");

            CreditAccount credit01 = new CreditAccount("", "", cl01, 
                DateTime.Today, 2000, 0, 0);
            CurrentAccount current01 = new CurrentAccount("", "", cl01, 
                0, PeriodHandingCashSurplus.None);
            DepositAccount deposit01 = new DepositAccount("", "", cl01,
                DateTime.Today, DateTime.Today, 0);

            TryCast(deposit01);

            Console.WriteLine("Finishing . . .");
            Console.ReadKey();
        }

        private static void TryCast(Account account)
        {
            CreditAccount cr02 = account as CreditAccount;
            CurrentAccount c02 = account as CurrentAccount;
            DepositAccount d02 = account as DepositAccount;

            if(cr02 != null)
                Console.WriteLine("credit");

            if (c02 != null)
                Console.WriteLine("current");

            if (d02 != null)
                Console.WriteLine("deposit");
        }
    }
}
