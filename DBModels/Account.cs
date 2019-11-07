using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Account
    {
        #region Fields

        [DataMember]
        protected string _cardNumber;
        [DataMember]
        protected string _cardPassword;
        [DataMember]
        protected bool _isActive;
        [DataMember]
        protected double _availableSum;

        [DataMember]
        protected Client _client;
        [DataMember]
        protected string _clientITN;

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

        #endregion


        public override  string ToString()
        {
            return _cardNumber;
        }
    }
}