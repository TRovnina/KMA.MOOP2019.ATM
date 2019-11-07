using System;

namespace DBModels
{
    public class Account
    {
        protected string _cardNumber;
        protected string _cardPassword;
        protected bool _isActive;
        protected double _availableSum;
        protected Client _client;
        protected string _clientITN;

        public Account(string cardNumber, string cardPassword, Client client) : this()
        {
            _cardNumber = cardNumber;
            _cardPassword = cardPassword;
            _isActive = true;
            _availableSum = 0;
            _client = client;
        }

        public Account()
        {
            
        }

        protected string CardNumber
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

        public override  string ToString()
        {
            return _cardNumber;
        }
    }
}