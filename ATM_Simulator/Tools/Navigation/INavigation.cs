using System;
namespace ATM_Simulator.Tools.Navigation
{
    internal enum ViewType
    {
        ActivateAtm
    }

    interface INavigation
    {
        void Navigate(ViewType viewType);
    }
}
