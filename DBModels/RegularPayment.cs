using System;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class RegularPayment
    {
        #region Fields
        
        [DataMember]
        private int _regularPaymentId;
        [DataMember]
        private DateTime _firstRegularPaymentDate;
        [DataMember]
        private PeriodRegularPayment _periodRegularPayment;
        [DataMember]
        private int _periodRegularPaymentId;
        [DataMember]
        private string _regularPaymentName;

        [DataMember]
        private CurrentAccount _currentAccount;
        [DataMember]
        private string _currentAccountNum;

        #endregion

        #region Constructors

        private RegularPayment()
        {
            _firstRegularPaymentDate = DateTime.Now;
        }

        public RegularPayment(PeriodRegularPayment periodRegularPayment, string regularPaymentName, 
            CurrentAccount currentAccount) : this()
        {
            _periodRegularPayment = periodRegularPayment;
            _regularPaymentName = regularPaymentName;
            _currentAccount = currentAccount;
            _currentAccountNum = currentAccount.CardNumber;
        }

        #endregion

        #region Properties

        public int RegularPaymentId
        {
            get => _regularPaymentId;
            private set => _regularPaymentId = value;
        }

        public DateTime FirstRegularPaymentDate
        {
            get => _firstRegularPaymentDate;
            private set => _firstRegularPaymentDate = value;
        }

        public PeriodRegularPayment PeriodRegularPayment
        {
            get => _periodRegularPayment;
            private set => _periodRegularPayment = value;
        }

        public int PeriodRegularPaymentId
        {
            get => (int)_periodRegularPayment;
            private set => _periodRegularPayment = (PeriodRegularPayment)value;
        }

        public string RegularPaymentName
        {
            get => _regularPaymentName;
            private set => _regularPaymentName = value;
        }

        public CurrentAccount CurrentAccount
        {
            get => _currentAccount;
            private set => _currentAccount = value;
        }

        public string CurrentAccountNum
        {
            get => _currentAccountNum;
            private set => _currentAccountNum = value;
        }

        #endregion

        #region EntityConfiguration

        public class RegularPaymentEntityConfiguration : EntityTypeConfiguration<RegularPayment>
        {
            public RegularPaymentEntityConfiguration()
            {
                ToTable("RegularPayment");
                HasKey(a => a.RegularPaymentId);

                Property(a => a.RegularPaymentId)
                    .HasColumnName("RegularPaymentId")
                    .IsRequired();
                Property(a => a.FirstRegularPaymentDate)
                    .HasColumnName("FirstRegularPaymentDate")
                    .IsRequired();
                Property(a => a.PeriodRegularPaymentId)
                    .HasColumnName("PeriodRegularPaymentId")
                    .IsRequired();
                Ignore(a => a.PeriodRegularPayment);
                Property(a => a.RegularPaymentName)
                    .HasColumnName("RegularPaymentName")
                    .IsRequired();
            }
        }
        #endregion
    }
}