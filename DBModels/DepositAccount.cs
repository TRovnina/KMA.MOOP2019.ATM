using System;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class DepositAccount : Account
    {
        #region Fields

        [DataMember]
        private DateTime _depositDate;
        [DataMember]
        private DateTime _storegedDate;
        [DataMember]
        private int _percentage;
        [DataMember]
        private DateTime _availableDate; // Дата коли гроші будуть доступні = Deposit_Date + Storage_Date

        [DataMember]
        private CurrentAccount _currentAccount;
        [DataMember]
        private string _currentAccountNum;

        #endregion

        #region Constructors

        public DepositAccount(string cardNumber, string cardPassword, Client client,
            DateTime depositDate, DateTime storegedDate, int percentage)
            : base(cardNumber, cardPassword, client)
        {
            _depositDate = depositDate;
            _storegedDate = storegedDate;
            _percentage = percentage;
            _availableDate = CalculateAvailableDate();

            client.DepositAccount = this;
            client.DepositAccountNum = cardNumber;
        }

        private DepositAccount()
        {

        }

        #endregion

        #region Properties

        public DateTime DepositDate
        {
            get => _depositDate;
            set => _depositDate = value;
        }

        public DateTime StoregedDate
        {
            get => _storegedDate;
            set => _storegedDate = value;
        }

        public int Percentage
        {
            get => _percentage;
            set => _percentage = value;
        }

        public DateTime AvailableDate
        {
            get { return _availableDate = CalculateAvailableDate(); }
            private set => _availableDate = value;
        }

        public CurrentAccount CurrentAccount
        {
            get => _currentAccount;
            set => _currentAccount = value;
        }

        public string CurrentAccountNum
        {
            get => _currentAccountNum;
            set => _currentAccountNum = value;
        }

        #endregion

        private DateTime CalculateAvailableDate()
        {
            return DepositDate.AddSeconds(StoregedDate.Second);
        }

        #region EntityConfiguration

        public class DepositAccountEntityConfiguration : EntityTypeConfiguration<DepositAccount>
        {
            public DepositAccountEntityConfiguration()
            {
                ToTable("DepositAccount");
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

                Property(c => c.DepositDate)
                    .HasColumnName("DepositDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(c => c.StoregedDate)
                    .HasColumnName("StoregedDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(c => c.Percentage)
                    .HasColumnName("Percentage")
                    .IsRequired();
                Property(c => c.AvailableDate)
                    .HasColumnName("AvailableDate")
                    .HasColumnType("datetime2")
                    .IsRequired();

                HasRequired(c => c.Client)
                    .WithRequiredPrincipal(c => c.DepositAccount);

                HasMany(a => a.Actions)
                    .WithRequired(act => act.DepositAccount)
                    .HasForeignKey(act => act.AccountNum)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}