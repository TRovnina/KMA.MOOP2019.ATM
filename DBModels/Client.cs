namespace DBModels
{
    public class Client
    {
        #region Fields

        private string _itn;
        private string _firstName;
        private string _lastName;

        private CurrentAccount _currentAccount;
        private CreditAccount _creditAccount;
        private DepositAccount _depositAccount;

        // TODO if i need key of this accounts here

        #endregion

        #region Constructors

        public Client()
        {
            
        }

        public Client(string itm, string firstName, string lastName,
            CurrentAccount currentAccount, CreditAccount creditAccount, DepositAccount depositAccount) : this()
        {
            _itn = itm;
            _firstName = firstName;
            _lastName = lastName;

            _currentAccount = currentAccount;
            _creditAccount = creditAccount;
            _depositAccount = depositAccount;
        }

        #endregion

        #region Properties

        public string ITN
        {
            get { return _itn;}
            set { _itn = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public CurrentAccount CurrentAccount
        {
            get { return _currentAccount; }
            set { _currentAccount = value; }
        }

        public CreditAccount CreditAccount
        {
            get { return _creditAccount; }
            set { _creditAccount = value; }
        }

        public DepositAccount DepositAccount
        {
            get { return _depositAccount; }
            set { _depositAccount = value; }
        }

        #endregion

        public override string ToString()
        {
            return FirstName + " " + LastName + "; ITN: " + ITN;
        }
    }
}