using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class CurrentAccount : Account
    {
        #region Fields

        [DataMember]
        private double _thresholdAmount;
        [DataMember]
        private PeriodHandingCashSurplus _periodCashSurplus;
        [DataMember]
        private int _periodCashSurplusId;
        [DataMember]
        private bool _isHandingCashSurplus; // похідний атрибут
                                            // Якщо значення _thresholdAmount, _periodCashSurplus і _depositAccountNum не NULL, тоді True, інакше Fasle

        [DataMember]
        private DepositAccount _depositAccount;
        [DataMember]
        private string _depositAccountNum;
        [DataMember]
        private List<RegularPayment> _regularPayments;
        #endregion

        #region Constructors

        public CurrentAccount(string cardNumber, string cardPassword, Client client,
            double thresholdAmount, PeriodHandingCashSurplus periodCashSurplus) : base(cardNumber, cardPassword, client)
        {
            _thresholdAmount = thresholdAmount;
            _periodCashSurplus = periodCashSurplus;
            _isHandingCashSurplus = _depositAccount != null;
            _regularPayments = new List<RegularPayment>();

            client.CurrentAccount = this;
            client.CurrentAccountNum = cardNumber;
        }

        private CurrentAccount()
        {
            
        }

        #endregion

        #region Properties

        public double ThresholdAmount
        {
            get => _thresholdAmount;
            set => _thresholdAmount = value;
        }

        public PeriodHandingCashSurplus PeriodCashSurplus
        {
            get => _periodCashSurplus;
            set => _periodCashSurplus = value;
        }

        public int PeriodCashSurplusId
        {
            get => (int)_periodCashSurplus;
            set => _periodCashSurplus = (PeriodHandingCashSurplus)value;
        }

        public bool IsHandingCashSurplus
        {
            get { return _isHandingCashSurplus = DepositAccount != null; }
            set => _isHandingCashSurplus = value;
        }

        public DepositAccount DepositAccount
        {
            get => _depositAccount;
            set => _depositAccount = value;
        }

        public string DepositAccountNum
        {
            get => _depositAccountNum;
            set => _depositAccountNum = value;
        }

        public List<RegularPayment> RegularPayments
        {
            get => _regularPayments;
            set => _regularPayments = value;
        }

        #endregion

        #region EntityConfiguration

        public class CurrentAccountEntityConfiguration : EntityTypeConfiguration<CurrentAccount>
        {
            public CurrentAccountEntityConfiguration()
            {
                ToTable("CurrentAccount");
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

                Property(c => c.ThresholdAmount)
                    .HasColumnName("ThresholdAmount")
                    .IsOptional();
                Property(c => c.PeriodCashSurplusId)
                    .HasColumnName("PeriodCashSurplusId")
                    .IsOptional();
                Property(c => c.IsHandingCashSurplus)
                    .HasColumnName("IsHandingCashSurplus")
                    .IsRequired();

                Ignore(c => c.PeriodCashSurplus);

                HasRequired(c => c.Client)
                    .WithRequiredPrincipal(c => c.CurrentAccount);

                HasOptional(c => c.DepositAccount)
                    .WithOptionalPrincipal(c => c.CurrentAccount);

                HasMany(a => a.Actions)
                    .WithRequired(act => act.CurrentAccount)
                    .HasForeignKey(act => act.AccountNum)
                    .WillCascadeOnDelete(true);

                HasMany(a => a.RegularPayments)
                    .WithRequired(act => act.CurrentAccount)
                    .HasForeignKey(act => act.CurrentAccountNum)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}