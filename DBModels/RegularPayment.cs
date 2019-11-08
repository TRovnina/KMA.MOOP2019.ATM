﻿using System;
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
        private double _sum;
        [DataMember]
        private string _destinationAccount;

        [DataMember]
        private CurrentAccount _currentAccount;
        [DataMember]
        private string _cardNumber;

        #endregion

        #region Constructors

        private RegularPayment()
        {
            _firstRegularPaymentDate = DateTime.Now;
        }

        public RegularPayment(PeriodRegularPayment periodRegularPayment, string regularPaymentName, 
            CurrentAccount currentAccount, double sum, string destinationAccount) : this()
        {
            _periodRegularPayment = periodRegularPayment;
            _regularPaymentName = regularPaymentName;
            _currentAccount = currentAccount;
            _cardNumber = currentAccount.CardNumber;
            _sum = sum;
            _destinationAccount = destinationAccount;
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

        public double Sum
        {
            get => _sum;
            private set => _sum = value;
        }

        public string DestinationAccount
        {
            get => _destinationAccount;
            private set => _destinationAccount = value;
        }

        public CurrentAccount CurrentAccount
        {
            get => _currentAccount;
            private set => _currentAccount = value;
        }

        public string CardNumber
        {
            get => _cardNumber;
            private set => _cardNumber = value;
        }

        #endregion

        public void DeleteDatabaseValues()
        {
            _currentAccount = null;
        }

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
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(a => a.PeriodRegularPaymentId)
                    .HasColumnName("PeriodRegularPaymentId")
                    .IsRequired();
                Ignore(a => a.PeriodRegularPayment);
                Property(a => a.RegularPaymentName)
                    .HasColumnName("RegularPaymentName")
                    .IsRequired();
                Property(a => a.Sum)
                    .HasColumnName("Sum")
                    .IsRequired();
                Property(a => a.DestinationAccount)
                    .HasColumnName("DestinationAccount")
                    .IsRequired();
            }
        }
        #endregion
    }
}