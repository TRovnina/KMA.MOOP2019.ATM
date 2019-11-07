using System;
using System.Windows;
using ATM_Simulator.Models;

namespace ATM_Simulator.Managers
{
    internal static class StaticManager
    {
        internal static Atm CurrentAtm { get; set; }
        internal static Transfer CurrentTransfer { get; set; }
        internal static RegularPayment CurrentPayment { get; set; }

        internal static void Initialize()
        {
        }

        internal static void CloseApp()
        {
            MessageBox.Show("Do you want to close program?");
            Environment.Exit(1);
        }
    }
}
