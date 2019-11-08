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
                                            // Якщо значення  _periodCashSurplus не None, тоді True, інакше Fasle

        [DataMember]
        private List<RegularPayment> _regularPayments;
        #endregion

        #region Constructors

        public CurrentAccount(string cardNumber, string cardPassword, Client client,
            double thresholdAmount, PeriodHandingCashSurplus periodCashSurplus) : base(cardNumber, cardPassword, client)
        {
            _thresholdAmount = thresholdAmount;
            _periodCashSurplus = periodCashSurplus;
            _isHandingCashSurplus = _periodCashSurplus != PeriodHandingCashSurplus.None;
            _regularPayments = new List<RegularPayment>();

            client.Accounts.Add(this);
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
            get { return _isHandingCashSurplus = PeriodCashSurplus != PeriodHandingCashSurplus.None; }
            set => _isHandingCashSurplus = value;
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

                HasMany(a => a.RegularPayments)
                    .WithRequired(act => act.CurrentAccount)
                    .HasForeignKey(act => act.CardNumber)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}