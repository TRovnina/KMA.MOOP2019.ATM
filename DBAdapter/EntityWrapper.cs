using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DBModels;

namespace DBAdapter
{
    public static class EntityWrapper
    {
        //
        public static ATM GetATMByCode(string atmCode)
        {
            using (var context = new ATMDbContext())
            {
                return context.ATMs.Include(u => u.ATMAccountAction)
                     .Include(u => u.AtmManagerActions)
                     .FirstOrDefault(u => u.ATMCode == atmCode);
            }
        }
        //
        public static void AddATM(ATM atm)
        {
            using (var context = new ATMDbContext())
            {
                context.ATMs.Add(atm);
                context.SaveChanges();
            }
        }
        // 
        public static Manager GetManagerById(string managerId)
        {
            using (var context = new ATMDbContext())
            {
                return context.Managers
                    .Include(u => u.ATMManagerActions)
                    .FirstOrDefault(u => u.ManagerId == managerId);
            }
        }
        //
        public static void AddManager(Manager manager)
        {
            using (var context = new ATMDbContext())
            {
                context.Managers.Add(manager);
                context.SaveChanges();
            }
        }
        //
        public static Account GetAccountByNum(string accountNum)
        {
            using (var context = new ATMDbContext())
            {
                return context.Accounts
                    .Include(u => u.ATMAccountAction)
                    .Include(u => u.Client)
                    .Include(u => u.Client.Accounts)
                    .FirstOrDefault(u => u.CardNumber == accountNum);
            }
        }
        //
        public static void AddClient(Client client)
        {
            using (var context = new ATMDbContext())
            {
                context.Clients.Add(client);
                foreach (var clientAccount in client.Accounts.ToArray())
                {
                    context.Accounts.Add(clientAccount);
                }
                context.SaveChanges();
            }
        }
        //
        public static bool AccountExist(string accountNum)
        {
            using (var context = new ATMDbContext())
            {
                return context.Accounts.Any(u => u.CardNumber == accountNum);
            }
        }
        //
        public static Client GetClientByItn(string clientItn)
        {
            using (var context = new ATMDbContext())
            {
                return context.Clients
                    .Include(u => u.Accounts)
                    .FirstOrDefault(u => u.ITN == clientItn);
            }
        }
        //
        public static void AddATMAccountAction(ATMAccountAction action)
        {
            using (var context = new ATMDbContext())
            {
                action.DeleteDatabaseValues();
                context.ATMAccountActions.Add(action);
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
        //
        public static void AddRegularPayment(RegularPayment regularPayment)
        {
            using (var context = new ATMDbContext())
            {
                regularPayment.DeleteDatabaseValues();
                context.RegularPayments.Add(regularPayment);
                context.SaveChanges();
            }
        }
        //
        public static void SaveATM(ATM atm)
        {
            using (var context = new ATMDbContext())
            {
                context.Entry(atm).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        //
        public static void SaveAccount(Account account)
        {
            using (var context = new ATMDbContext())
            {
                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        //
        public static List<RegularPayment> GetRegularPayments(string accountNum)
        {
            using (var context = new ATMDbContext())
            {
                return context.RegularPayments.Include(p => p.CurrentAccount).Where(r => r.CardNumber == accountNum).ToList();
            }
        }

        public static List<Account> GetAllBlockedAccounts()
        {
            using (var context = new ATMDbContext())
            {
                return context.Accounts.Include(a => a.Client).Where(r => r.IsActive == false).ToList();
            }
        }

        public static void DeleteRegularPayment(RegularPayment regularPayment)
        {
            using (var context = new ATMDbContext())
            {
                regularPayment.DeleteDatabaseValues();
                context.RegularPayments.Attach(regularPayment);
                context.RegularPayments.Remove(regularPayment);
                context.SaveChanges();
            }
        }

        public static List<Client> GetAllClients()
        {
            using (var context = new ATMDbContext())
            {
                return context.Clients
                    .Include(u => u.Accounts).ToList();
            }
        }

        public static List<ATM> GetAllATMs()
        {
            using (var context = new ATMDbContext())
            {
                return context.ATMs.
                    Include(u => u.AtmManagerActions)
                    .Include(u => u.ATMAccountAction).ToList();
            }
        }

        public static List<Manager> GetAllManagers()
        {
            using (var context = new ATMDbContext())
            {
                return context.Managers.Include(u => u.ATMManagerActions).ToList();
            }
        }

        public static int WithdrawMoney(Account account, int sum)
        {
            return CardOperations.WithdrawMoney(account, sum);
        }

        public static int TransferMoney(Account sourceAccount,
            Account destinationAccount, int sum)
        {
            return CardOperations.TransferMoney(sourceAccount, destinationAccount, sum);
        }
    }
}