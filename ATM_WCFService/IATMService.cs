using System.ServiceModel;
using DBModels;

namespace ATM_WCFService
{
    [ServiceContract]
    public interface IATMService
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
        void AddAction(DBModels.Action action);
        [OperationContract]
        void AddATMManagerAction(ATMManagerAction atmManagerAction);
        [OperationContract]
        void AddRegularPayment(RegularPayment regularPayment);
        [OperationContract]
        void SaveATM(ATM atm);
        [OperationContract]
        void SaveAccount(Account account);
    }
}
