using AtmClient.ServiceReference1;
using DBModels;

namespace AtmClient
{
    public class DbManager
    {
        public static ATM GetATMByCode(string atmCode)
        {
            ServiceReference1.AtmServiceClient client = new AtmServiceClient();
            return client.GetATMByCode(atmCode);
        }
    }
}