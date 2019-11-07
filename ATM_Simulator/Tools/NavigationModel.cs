using System;
using ATM_Simulator.View.Authentication;
using ATM_Simulator.View.ClientServices;
using ATM_Simulator.View.ClientServices.CashWithdrawal;
using ATM_Simulator.View.ClientServices.Transfer;

namespace ATM_Simulator.Tools
{
    internal enum ModesEnum
    {
        ActivateAtm,
        CardNumber,
        CardPin,
        ClientMenu,
        ManagerMenu,
        CashWithdrawal,
        OtherWithdrawal,
        BalanceInquiry,
        Transfer,
        RegularPayment,
        CashSurplus,
        ChangePin,
        AskContinue,
        CheckTransferInfo
    }

    internal class NavigationModel
    {
        private readonly IContent _content;
        private ClientServicesView _clientServicesView;
        private CashWithdrawalView _cashWithdrawalView;
        private ContinueView _continueView;

        internal NavigationModel(IContent contentWindow)
        {
            _content = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.ActivateAtm:
                    _content.ContentControl.Content = new ActivateAtmView();
                    break;
                case ModesEnum.CardNumber:
                    _content.ContentControl.Content = new CardNumberView();
                    break;
                case ModesEnum.CardPin:
                    _content.ContentControl.Content = new CardPinView();
                    break;
                case ModesEnum.ClientMenu:
                    _content.ContentControl.Content = _clientServicesView ?? (_clientServicesView = new ClientServicesView());
                    break;
                case ModesEnum.AskContinue:
                    _content.ContentControl.Content = _continueView ?? (_continueView = new ContinueView());
                    break;
                case ModesEnum.CashWithdrawal:
                    _content.ContentControl.Content = _cashWithdrawalView ?? (_cashWithdrawalView = new CashWithdrawalView());
                    break;
                case ModesEnum.OtherWithdrawal:
                    _content.ContentControl.Content = new OtherWithdrawalView();
                    break;
                case ModesEnum.Transfer:
                    _content.ContentControl.Content = new TransferView();
                    break;
                case ModesEnum.CheckTransferInfo:
                    _content.ContentControl.Content = new CheckTransferView();
                    break;
                case ModesEnum.ChangePin:
                    _content.ContentControl.Content = new ChangePinView();
                    break;
                case ModesEnum.BalanceInquiry:
                    _content.ContentControl.Content = new BalanceInquiryView();
                    break;
                case ModesEnum.CashSurplus:
                    _content.ContentControl.Content = new CashSurplusView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}
