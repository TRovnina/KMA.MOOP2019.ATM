
namespace ATM_Simulator.Models
{
    internal class RegularPayment
    {
        #region Properties

        internal string Card
        {
            get;
            set;
        }

        internal string Name
        {
            get;
            set;
        }

        internal int Amount
        {
            get;
            set;
        }

        internal string Period
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


        public RegularPayment(string name, string card, int amount, string period, string description)
        {
            Card = card;
            Name = name;
            Amount = amount;
            Description = description;
            Period = period;
        }
    }
}
