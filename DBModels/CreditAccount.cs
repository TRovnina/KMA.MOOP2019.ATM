using System;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class CreditAccount : Account
    {
        #region Fields

        [DataMember]
        private DateTime _endOfGracePeriod;
        [DataMember]
        private double _maxCreditSum; // максимальна кредитна сума
        [DataMember]
        private double _creditSum; // вже використана клієнтом кредитна сума
        [DataMember]
        private int _percentageCredit;
        [DataMember]
        private double _debt; // Борг банку = _creditSum + _creditSum* _percentage
        
        #endregion


        #region Constructors

        public CreditAccount(string cardNumber, string cardPassword, Client client,
            DateTime endOfGracePeriod, double maxCreditSum, double creditSum, int percentage)
            : base(cardNumber, cardPassword, client)
        {
            _endOfGracePeriod = endOfGracePeriod;
            _maxCreditSum = maxCreditSum;
            _creditSum = creditSum;
            _percentageCredit = percentage;
            _debt = CalculateDebt();
            client.Accounts.Add(this);
        }

        private CreditAccount()
        {
            
        }

        #endregion

        #region Properties

        public DateTime EndOfGracePeriod
        {
            get => _endOfGracePeriod;
            set => _endOfGracePeriod = value;
        }

        public double MaxCreditSum
        {
            get => _maxCreditSum;
            set => _maxCreditSum = value;
        }

        public double CreditSum
        {
            get => _creditSum;
            set => _creditSum = value;
        }

        public int PercentageCredit
        {
            get => _percentageCredit;
            set => _percentageCredit = value;
        }

        public double Debt
        {
            get { return _debt = CalculateDebt(); }
            private set => _debt = value;
        }

        #endregion

        private double CalculateDebt()
        {
            return CreditSum + CreditSum * PercentageCredit;
        }

        #region EntityConfiguration

        public class CreditAccountEntityConfiguration : EntityTypeConfiguration<CreditAccount>
        {
            public CreditAccountEntityConfiguration()
            {
                
                ToTable("CreditAccount");

                Property(c => c.EndOfGracePeriod)
                    .HasColumnName("EndOfGracePeriod")
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(c => c.MaxCreditSum)
                    .HasColumnName("MaxCreditSum")
                    .IsRequired();
                Property(c => c.CreditSum)
                    .HasColumnName("CreditSum")
                    .IsRequired();
                Property(c => c.PercentageCredit)
                    .HasColumnName("PercentageCredit")
                    .IsRequired();
                Property(c => c.Debt)
                    .HasColumnName("Debt")
                    .IsRequired();
                
            }
        }
        #endregion
    }
}