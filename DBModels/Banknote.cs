using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Banknote
    {
        #region Fields

        [DataMember]
        private int _banknoteValue; // PPK
        [DataMember]
        private int _banknoteAmount;

        [DataMember]
        private ATM _atm;
        [DataMember]
        private string _atmCode; // PPK, FK

        #endregion

        #region Constructors

        public Banknote(int banknoteValue, int banknoteAmount, ATM atm) : this()
        {
            _banknoteValue = banknoteValue;
            _banknoteAmount = banknoteAmount;
            _atm = atm;
            _atmCode = atm.ATMCode;
        }

        private Banknote()
        {
            
        }

        #endregion

        #region Properties

        public int BanknoteValue
        {
            get { return _banknoteValue; }
            private set { _banknoteValue = value; }
        }

        public int BanknoteAmount
        {
            get { return _banknoteAmount; }
            set { _banknoteAmount = value; }
        }

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        public string ATMCode
        {
            get { return _atmCode; }
            set { _atmCode = value; }
        }

        #endregion

    }
}