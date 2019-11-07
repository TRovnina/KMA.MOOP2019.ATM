namespace DBModels
{
    public enum PeriodHandingCashSurplus
    {
        OnChanged, // при зміні коштів на карточці
        OnceWeek, // раз в тиждень
        OnceMount, // раз в місяць
        OnceYear // раз в рік
    }
}