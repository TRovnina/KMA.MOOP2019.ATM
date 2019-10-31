using System.ServiceModel;

namespace ATM_WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IATMService" in both code and config file together.
    [ServiceContract]
    public interface IATMService
    {
        [OperationContract]
        void DoWork();
    }
}
