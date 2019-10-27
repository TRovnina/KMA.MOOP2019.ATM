using System;
using ATM_Simulator.View;

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
        private ActivateATM_View _activateAtmView;

        internal NavigationModel(IContent contentWindow)
        {
            _content = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.ActivateAtm:
                    _content.ContentControl.Content = _activateAtmView ?? (_activateAtmView = new ActivateATM_View());
                    break;
                //case ViewType.CheckCard:
                //    ViewsDictionary.Add(viewType, new CheckCard_View());
                //    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}
