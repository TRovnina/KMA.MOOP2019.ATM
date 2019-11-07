namespace ATM_Simulator.Models
{
    internal class Transfer
    {
        #region Properties

        internal string RecipientCard
        {
            get;
            set;
        }

        internal string RecipientName
        {
            get;
            set;
        }

        internal double Amount
        {
            get;
            set;
        }

        internal double Commission
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
            RecipientCard = recipient;
            Amount = amount;
            Description = description;
            RecipientName = "Petrov Petr";
            Commission = 0.05;
        } 
    }
}
