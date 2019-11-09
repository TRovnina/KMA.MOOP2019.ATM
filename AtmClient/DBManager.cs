using AtmClient.ServiceReference1;
using DBModels;

namespace AtmClient
{
    public class DbManager
    {
        public static ATM GetATMByCode(string atmCode)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            return client.GetATMByCode(atmCode);
        }

        public static void AddATM(ATM atm)
        {
            ServiceReference1.ServiceATMClient client = new ServiceATMClient();
            client.AddATM(atm);
        }
    }
}