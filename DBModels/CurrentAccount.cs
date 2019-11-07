namespace DBModels
{
    public class CurrentAccount : Account
    {
        private double _thresholdAmount;
        private PeriodHandingCashSurplus? _periodCashSurplus;
        private CreditAccount _creditAccount;
        private string _creditAccountNum;
        private bool _isHadingCashSurplus; // похідний атрибут
        // Якщо значення _thresholdAmount, _periodCashSurplus і _creditAccountNum не NULL, тоді True, інакше Fasle



    }
}