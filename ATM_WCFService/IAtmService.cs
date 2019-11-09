using System.ServiceModel;
using DBModels;

namespace ATM_WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAtmService" in both code and config file together.
    [ServiceContract]
    public interface IAtmService
    {
        [OperationContract]
        ATM GetATMByCode(string atmCode);

        [OperationContract]
        Manager GetManagerById(string managerId);

        [OperationContract]
        Account GetAccountByNum(string accountNum);

        [OperationContract]
        bool AccountExist(string accountNum);

        [OperationContract]
        Client GetClientByItn(string clientItn);

        [OperationContract]
        void AddATMAccountAction(ATMAccountAction action);
        
        [OperationContract]
        void AddATMManagerAction(ATMManagerAction atmManagerAction);
        
        //[OperationContract]
        //void AddRegularPayment(RegularPayment regularPayment);
        
        [OperationContract]
        void SaveATM(ATM atm);
        
        [OperationContract]
        void SaveAccount(Account account);
        
    }
}
