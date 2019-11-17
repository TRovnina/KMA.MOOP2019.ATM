namespace DBModels
{
    public enum PeriodHandingCashSurplus
    {
        OnChanged, // при зміні коштів на карточці
        OnceWeek, // раз в тиждень
        OnceMonth, // раз в місяць
        OnceYear, // раз в рік
        None
    }
}