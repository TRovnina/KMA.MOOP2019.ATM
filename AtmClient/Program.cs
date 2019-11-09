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

           ATM atm = DbManager.GetATMByCode("q");
           if(atm == null)
               Console.WriteLine("null");
           else
           {
               Console.WriteLine(atm.ToString());
           }

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
