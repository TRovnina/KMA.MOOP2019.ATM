using System;
using ATM_Simulator.View.Authentication;

namespace ATM_Simulator.Tools
{
    internal enum ModesEnum
    {
        ActivateAtm,
        CheckCard,
        AtmView
    }

    internal class NavigationModel
    {
        private readonly IContent _content;
        private ActivateAtmView _activateAtmView;

        internal NavigationModel(IContent contentWindow)
        {
            _content = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.ActivateAtm:
                    _content.ContentControl.Content = _activateAtmView ?? (_activateAtmView = new ActivateAtmView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}
