using System;

namespace DBModels
{
    public class CreditAccount : Account
    {
        private DateTime _endOfGracePeriod;
        private double _creditSum;
        private int _percentage;
        private double _debt; // Борг банку = _creditSum + _creditSum* _percentage


    }
}