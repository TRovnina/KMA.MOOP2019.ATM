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
        private int _percentage;
        [DataMember]
        private DateTime _availableDate; // Дата коли гроші будуть доступні = Deposit_Date + Storage_Date

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
            }
        }
        #endregion
    }
}