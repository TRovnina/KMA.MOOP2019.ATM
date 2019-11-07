namespace DBModels
{
    public class CurrentAccount : Account
    {
        #region Fields

        private double _thresholdAmount;
        private PeriodHandingCashSurplus? _periodCashSurplus;
        private bool _isHandingCashSurplus; // похідний атрибут
                                           // Якщо значення _thresholdAmount, _periodCashSurplus і _creditAccountNum не NULL, тоді True, інакше Fasle

        private CreditAccount _creditAccount;
        private string _creditAccountNum;
        #endregion

        #region Constructors

        public CurrentAccount(string cardNumber, string cardPassword, Client client,
            double thresholdAmount, PeriodHandingCashSurplus? periodCashSurplus) : base(cardNumber, cardPassword, client)
        {
            _thresholdAmount = thresholdAmount;
            _periodCashSurplus = periodCashSurplus;
            _isHandingCashSurplus = _periodCashSurplus != null;
        }

        private CurrentAccount()
        {
            
        }

        #endregion

        #region Properties

        public double ThresholdAmount
        {
            get { return _thresholdAmount; }
            set { _thresholdAmount = value; }
        }

        public PeriodHandingCashSurplus? PeriodCashSurplus
        {
            get { return _periodCashSurplus; }
            set { _periodCashSurplus = value; }
        }

        public bool IsHandingCashSurplus
        {
            get { return _isHandingCashSurplus = PeriodCashSurplus != null; }
            set { _isHandingCashSurplus = value; }
        }

        public CreditAccount CreditAccount
        {
            get { return _creditAccount; }
            set { _creditAccount = value; }
        }

        public string CreditAccountNum
        {
            get { return _creditAccountNum; }
            set { _creditAccountNum = value; }
        }

        #endregion
    }
}