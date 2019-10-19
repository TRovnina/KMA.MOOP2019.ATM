using System;
using System.Windows;
using ATM_Simulator.Models;

namespace ATM_Simulator.Tools.Manager
{
    internal static class StaticManager
    {
        internal static ATM CurrentATM { get; set; }

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
