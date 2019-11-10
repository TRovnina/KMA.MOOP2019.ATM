using System;
using System.ComponentModel.DataAnnotations.Schema;
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
        private DateTime _storegedDate; // обрахунку
        [DataMember]
        private int _percentageDeposit;
        [DataMember]
        private DateTime _availableDate; // дата, коли гроші доступні

        #endregion

        #region Constructors

        public DepositAccount(string cardNumber, string cardPassword, Client client,
            DateTime depositDate, DateTime availableDate, int percentage)
            : base(cardNumber, cardPassword, client)
        {
            _depositDate = depositDate;
            _storegedDate = depositDate;
            _percentageDeposit = percentage;
            _availableDate = availableDate;

            client.Accounts.Add(this);
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

        public int PercentageDeposit
        {
            get => _percentageDeposit;
            set => _percentageDeposit = value;
        }

        public double AvailableSum
        {
            get => _availableSum = Math.Round(CalculateSum());
            set => _availableSum = Math.Round(value);
        }

        public DateTime AvailableDate
        {
            get => _availableDate;
            private set => _availableDate = value;
        }

        public double CalculateSum()
        {
            int month = (DateTime.Today - StoregedDate).Days / 28;
            if (month <= 0)
                return _availableSum;
            StoregedDate = DateTime.Today;
            return _availableSum * Math.Pow((1 + (double)_percentageDeposit / 100.0), month);
        }

        #endregion

        public override string ToString()
        {
            return "Account: " + CardNumber + "; Status(is active): "
                   + IsActive + "; Available sum: " + AvailableSum
                   + " (Deposit account) percentage: " + PercentageDeposit;
        }

        #region EntityConfiguration

        public class DepositAccountEntityConfiguration : EntityTypeConfiguration<DepositAccount>
        {
            public DepositAccountEntityConfiguration()
            {
                ToTable("DepositAccount");

                Property(c => c.DepositDate)
                    .HasColumnName("DepositDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(c => c.StoregedDate)
                    .HasColumnName("StoregedDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(c => c.PercentageDeposit)
                    .HasColumnName("PercentageDeposit")
                    .IsRequired();
                Property(c => c.AvailableDate)
                    .HasColumnName("AvailableDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
            }
        }
        #endregion
    }
}