using System;
using ATM_Simulator.View.Authentication;

namespace ATM_Simulator.Tools
{
    internal enum ModesEnum
    {
        ActivateAtm,
        CardNumber,
        CardPassword,
        ClientMenu,
        ManagerMenu
    }

    internal class NavigationModel
    {
        private readonly IContent _content;
        private ActivateAtmView _activateAtmView;
        private CardNumberView _cardNumberView;
        private CardPasswordView _cardPasswordView;

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
                case ModesEnum.CardNumber:
                    _content.ContentControl.Content = _cardNumberView ?? (_cardNumberView = new CardNumberView());
                    break;
                case ModesEnum.CardPassword:
                    _content.ContentControl.Content = _cardPasswordView ?? (_cardPasswordView = new CardPasswordView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}
