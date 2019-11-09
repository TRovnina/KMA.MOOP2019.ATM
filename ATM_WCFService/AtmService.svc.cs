using System;
using DBAdapter;
using DBModels;

namespace ATM_WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AtmService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AtmService.svc or AtmService.svc.cs at the Solution Explorer and start debugging.
    public class AtmService : IAtmService
    {
        public ATM GetATMByCode(string atmCode)
        {
            return EntityWrapper.GetATMByCode(atmCode);
        }

        public Manager GetManagerById(string managerId)
        {
            return EntityWrapper.GetManagerById(managerId);
        }

        public Account GetAccountByNum(string accountNum)
        {
            return EntityWrapper.GetAccountByNum(accountNum);
        }

        public bool AccountExist(string accountNum)
        {
            return EntityWrapper.AccountExist(accountNum);
        }

        public Client GetClientByItn(string clientItn)
        {
            return EntityWrapper.GetClientByItn(clientItn);
        }
        
        public void AddATMAccountAction(ATMAccountAction action)
        {
            EntityWrapper.AddATMAccountAction(action);
        }
        
        public void AddATMManagerAction(ATMManagerAction atmManagerAction)
        {
            EntityWrapper.AddATMManagerAction(atmManagerAction);
        }
        
        public void AddRegularPayment(RegularTransfer regularTransfer)
        {
           EntityWrapper.AddRegularTransfer(regularTransfer);
        }
        
        public void SaveATM(ATM atm)
        {
            EntityWrapper.SaveATM(atm);
        }
        
        public void SaveAccount(Account account)
        {
            EntityWrapper.SaveAccount(account);
        }
        
    }
}
