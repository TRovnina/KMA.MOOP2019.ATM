using System;

namespace DBModels
{
    public class RegularPayment
    {
        #region Fields

        private int _regularPaymentId;
        private DateTime _firstRegularPaymentDate;
        private PeriodRegularPayment _periodRegularPayment;
        private string _regularPaymentName;

        #endregion

        #region Constructors

        public RegularPayment()
        {
            
        }

        public RegularPayment(int regularPaymentId, PeriodRegularPayment periodRegularPayment, string regularPaymentName)
        {
            _regularPaymentId = regularPaymentId;
            _firstRegularPaymentDate = DateTime.Now;
            _periodRegularPayment = periodRegularPayment;
            _regularPaymentName = regularPaymentName;
        }

        #endregion

        #region Properties

        public int RegularPaymentId
        {
            get { return _regularPaymentId; }
            set { _regularPaymentId = value; }
        }

        public DateTime FirstRegularPaymentDate
        {
            get { return _firstRegularPaymentDate; }
            private set { _firstRegularPaymentDate = value; }
        }

        public PeriodRegularPayment PeriodRegularPayment
        {
            get { return _periodRegularPayment; }
            set { _periodRegularPayment = value; }
        }

        public string RegularPaymentName
        {
            get { return _regularPaymentName; }
            set { _regularPaymentName = value; }
        }

        #endregion

    }
}