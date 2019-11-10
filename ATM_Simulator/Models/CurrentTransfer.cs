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
            Client client = DbManager.GetClientByItn(recipient.CardNumber);
            RecipientName = client.FirstName + " " + client.LastName;
            Commission = (client == StaticManager.CurrentClient ? 0 : 1);
            Amount = amount + Commission/100 * amount;
        }
    }
}
