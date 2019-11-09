using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [KnownType(typeof(DepositAccount))]
    [KnownType(typeof(CreditAccount))]
    [KnownType(typeof(CurrentAccount))]
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

        [DataMember]
        private List<ATMAccountAction> _atmAccountAction;

        #endregion

        #region Constructors

        public Account(string cardNumber, string cardPassword, Client client) : this()
        {
            _cardNumber = cardNumber;
            _client = client;
            SetPassword(cardPassword);
        }

        public Account()
        {
            _isActive = true;
            _availableSum = 0;
            _atmAccountAction = new List<ATMAccountAction>();
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
            set => SetPassword(value);
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

        public List<ATMAccountAction> ATMAccountAction
        {
            get => _atmAccountAction;
            private set => _atmAccountAction = value;
        }

        #endregion

        private void SetPassword(string password)
        {
            _cardPassword = Encrypting.GetMd5HashForString(password);
        }

        public bool CheckPassword(string password)
        {
            try
            {
                string res2 = Encrypting.GetMd5HashForString(password);
                return _cardPassword == res2;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteDatabaseValues()
        {
            _client = null;
        }

        public override  string ToString()
        {
            return _cardNumber;
        }

        #region EntityConfiguration

        public class AccountEntityConfiguration : EntityTypeConfiguration<Account>
        {
            public AccountEntityConfiguration()
            {
                ToTable("Account");
                HasKey(c => c.CardNumber);

                Property(c => c.CardNumber)
                    .HasColumnName("CardNumber")
                    .IsRequired();
                Property(c => c.CardPassword)
                    .HasColumnName("CardPassword")
                    .IsRequired();
                Property(c => c.IsActive)
                    .HasColumnName("IsActive")
                    .IsRequired();
                Property(c => c.AvailableSum)
                    .HasColumnName("AvailableSum")
                    .IsRequired();

                HasMany(a => a.ATMAccountAction)
                    .WithRequired(act => act.Account)
                    .HasForeignKey(act => act.AccountNum)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}