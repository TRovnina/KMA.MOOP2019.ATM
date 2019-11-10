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
        private DateTime _storegedDate;
        [DataMember]
        private int _percentageDeposit;
        [DataMember]
        private DateTime _availableDate; 

        #endregion

        #region Constructors

        public DepositAccount(string cardNumber, string cardPassword, Client client,
            DateTime depositDate, DateTime storegedDate, int percentage)
            : base(cardNumber, cardPassword, client)
        {
            _depositDate = depositDate;
            _storegedDate = storegedDate;
            _percentageDeposit = percentage;
            _availableDate = storegedDate;

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

        public DateTime AvailableDate
        {
            get => _availableDate; 
            private set => _availableDate = value;
        }

        #endregion

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