using ATM_Simulator.Managers;
using DBModels;

namespace ATM_Simulator.Models
{
    internal class CurrentTransfer
    {
        #region Properties

        internal Account RecipientCard { get; set; }

        internal string RecipientName { get; set; }

        internal int Amount { get; set; }

        internal int AmountCommission { get; set; }

        internal double Commission { get; set; }

        internal string Description { get; set; }

        #endregion


        public CurrentTransfer(Account recipient, int amount, string description)
        {
            RecipientCard = recipient;
            Description = description;
            Client client = recipient.Client; // DbManager.GetClientByItn(recipient.ClientITN);
            RecipientName = client.FirstName + " " + client.LastName;
            Amount = amount;
            Commission = (client.ITN == StaticManager.CurrentClient.ITN ? 0 : 1);
            AmountCommission = amount + (int)(Commission / 100 * amount);

            CreditAccount ca = StaticManager.CurrentCard as CreditAccount;
            if (ca != null && ca.AvailableSum < amount)
            {
                Commission = 3;
                int rest = (int)(Amount - ca.AvailableSum);
                AmountCommission = (int)(ca.AvailableSum + (Commission / 100 * ca.AvailableSum)) + (int)(rest + (0.03 * rest));
            }
        } 
    }
}