using System;
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
        private int _percentage;
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
            _percentage = percentage;
            _debt = CalculateDebt();
        }

        #endregion

        #region Properties

        public DateTime EndOfGracePeriod
        {
            get { return _endOfGracePeriod; }
            set { _endOfGracePeriod = value; }
        }

        public double MaxCreditSum
        {
            get { return _maxCreditSum; }
            set { _maxCreditSum = value; }
        }

        public double CreditSum
        {
            get { return _creditSum; }
            set { _creditSum = value; }
        }

        public int Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }

        public double Debt
        {
            get { return _debt = CalculateDebt(); }
            private set { _debt = value; }
        }

        #endregion

        private double CalculateDebt()
        {
            return CreditSum + CreditSum * Percentage;
        }
    }
}