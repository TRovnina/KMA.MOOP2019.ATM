using System;
using ATM_Simulator.View;

namespace ATM_Simulator.Tools.Navigation
{
    internal class NavigationInitialization : NavigationModel
    {
        public NavigationInitialization(IContent content) : base(content)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.ActivateAtm:
                    ViewsDictionary.Add(viewType, new ActivateATM_View());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
