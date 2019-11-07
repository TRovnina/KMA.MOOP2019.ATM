namespace DBModels
{
    public enum ActionType
    {
        Authentication,
        AddMoney, // for manager
        UnBlockCard, // for manager
        CashWithdrawal, 
        Transfer,
        ChangePin,
        HandingCashSurplus,
        RegularPayment

    }
}