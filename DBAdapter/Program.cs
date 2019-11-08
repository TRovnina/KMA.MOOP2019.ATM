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
            using (var context = new ATMDbContext())
            {
                ATM atm01 = new ATM("1111111111111111", "1111111111111111", "Kyiv, Ukraine");
                context.ATMs.Add(atm01);
                context.SaveChanges();

                foreach (var atm in context.ATMs)
                {
                    Console.WriteLine(atm.ToString());
                }

                Console.WriteLine("Finishing . . .");
                Console.ReadKey();
            }
        }
    }
}
