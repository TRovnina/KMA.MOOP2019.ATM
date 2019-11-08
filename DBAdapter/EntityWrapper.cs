using System.Data.Entity;
using System.Linq;
using DBModels;

namespace DBAdapter
{
    public static class EntityWrapper
    {
        public static ATM GetATMByCode(string atmCode)
        {
            using (var context = new ATMDbContext())
            {
                return context.ATMs.Include(u => u.Actions)
                    .Include(u => u.AtmManagerActions)
                    .FirstOrDefault(u => u.ATMCode == atmCode);
            }
        }

        public static Manager GetManagerById(string managerId)
        {
            using (var context = new ATMDbContext())
            {
                return context.Managers
                    .Include(u => u.ATMManagerActions)
                    .FirstOrDefault(u => u.ManagerId == managerId);
            }
        }

        public static Account GetAccountByNum(string accountNum)
        {
            using (var context = new ATMDbContext())
            {
                return context.Accounts
                    .Include(u => u.Actions)
                    .FirstOrDefault(u => u.CardNumber == accountNum);
            }
        }

        public static bool AccountExist(string accountNum)
        {
            using (var context = new ATMDbContext())
            {
                return context.Accounts.Any(u => u.CardNumber == accountNum);
            }
        }

        public static Client GetClientByItn(string clientItn)
        {
            using (var context = new ATMDbContext())
            {
                return context.Clients
                    .Include(u => u.Accounts)
                    .FirstOrDefault(u => u.ITN == clientItn);
            }
        }

        public static void AddAction(Action action)
        {
            using (var context = new ATMDbContext())
            {
                action.DeleteDatabaseValues();
                context.Actions.Add(action);
                context.SaveChanges();
            }
        }

        public static void AddATMManagerAction(ATMManagerAction atmManagerAction)
        {
            using (var context = new ATMDbContext())
            {
                atmManagerAction.DeleteDatabaseValues();
                context.ATMManagerActions.Add(atmManagerAction);
                context.SaveChanges();
            }
        }

        public static void AddRegularPayment(RegularPayment regularPayment)
        {
            using (var context = new ATMDbContext())
            {
                regularPayment.DeleteDatabaseValues();
                context.RegularPayments.Add(regularPayment);
                context.SaveChanges();
            }
        }

        public static void SaveATM(ATM atm)
        {
            using (var context = new ATMDbContext())
            {
                context.Entry(atm).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void SaveAccount(Account account)
        {
            using (var context = new ATMDbContext())
            {
                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}