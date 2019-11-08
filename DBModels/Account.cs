using System.Collections.Generic;

namespace DBModels
{
    public class Account
    {
        #region Fields
        
        protected string _cardNumber;
        protected string _cardPassword;
        protected bool _isActive;
        protected double _availableSum;
        
        protected Client _client;
        protected string _clientITN;
        
        private List<Action> _actions;

        #endregion

        #region Constructors

        public Account(string cardNumber, string cardPassword, Client client) : this()
        {
            _cardNumber = cardNumber;
            _cardPassword = cardPassword;
            _client = client;
        }

        public Account()
        {
            _isActive = true;
            _availableSum = 0;
            _actions = new List<Action>();
        }

        #endregion


        #region Properties

        public string CardNumber
        {
            get => _cardNumber;
            set => _cardNumber = value;
        }

        public string CardPassword
        {
            get => _cardPassword;
            set => _cardPassword = value;
        }

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public double AvailableSum
        {
            get => _availableSum;
            set => _availableSum = value;
        }

        public Client Client
        {
            get => _client;
            protected set => _client = value;
        }

        public string ClientITN
        {
            get => _clientITN;
            protected set => _clientITN = value;
        }

        public List<Action> Actions
        {
            get => _actions;
            private set => _actions = value;
        }

        #endregion


        public override  string ToString()
        {
            return _cardNumber;
        }
    }
}