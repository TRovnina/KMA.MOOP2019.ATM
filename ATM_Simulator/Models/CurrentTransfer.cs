using ATM_Simulator.Managers;
using DBModels;

namespace ATM_Simulator.Models
{
    internal class CurrentTransfer
    {
        #region Properties

        internal Account RecipientCard { get; set; }

        internal string RecipientName { get; set; }

        internal double Amount { get; set; }

        internal double Commission { get; set; }

        internal string Description { get; set; }

        #endregion


        public CurrentTransfer(Account recipient, int amount, string description)
        {
            RecipientCard = recipient;
            Description = description;
            Client client = recipient.Client; // DbManager.GetClientByItn(recipient.ClientITN);
            RecipientName = client.FirstName + " " + client.LastName;
            Commission = (client.ITN == StaticManager.CurrentClient.ITN ? 0 : 1);
            Amount = amount + Commission/100 * amount;
        }
    }
}
