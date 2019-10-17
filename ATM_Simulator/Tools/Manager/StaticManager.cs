using System;
using System.Windows;

namespace ATM_Simulator.Tools.Manager
{
    internal static class StaticManager
    {

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
