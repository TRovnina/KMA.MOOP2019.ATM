namespace ATM_Simulator.Models
{
    internal class Transfer
    {
        #region Properties

        internal string Recipient
        {
            get;
            set;
        }

        internal double Amount
        {
            get;
            set;
        }

        internal string Description
        {
            get;
            set;
        }

        #endregion


        public Transfer(string recipient, double amount, string description)
        {
            Recipient = recipient;
            Amount = amount;
            Description = description;
        }
    }
}
