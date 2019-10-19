using System;
namespace ATM_Simulator.Tools.Navigation
{
    internal enum ViewType
    {
        ActivateAtm,
        CheckCard,
        AtmView
    }

    interface INavigation
    {
        void Navigate(ViewType viewType);
    }
}
