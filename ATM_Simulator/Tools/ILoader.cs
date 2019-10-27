using System.ComponentModel;
using System.Windows;

namespace ATM_Simulator.Tools
{
    internal interface ILoader : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsEnabled { get; set; }
    }
}
