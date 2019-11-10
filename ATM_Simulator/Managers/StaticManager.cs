using System;
using System.Windows;
using ATM_Simulator.Models;
using DBModels;

namespace ATM_Simulator.Managers
{
    internal static class StaticManager
    {
        internal static ATM CurrentAtm { get; set; }
        internal static CurrentTransfer CurrentTransfer { get; set; }
        internal static RegularPayment CurrentPayment { get; set; }
        internal static Account CurrentCard { get; set; }
        internal static Client CurrentClient { get; set; }
        internal static Manager CurrentManager { get; set; }
        internal static int Attempts { get; set; }

        internal static void Initialize()
        {
        }

        internal static void CloseApp()
        {
            MessageBox.Show("Do you want to close ATM?");
            if (CurrentAtm != null)
            {
                CurrentAtm.Status = false;
                DbManager.SaveATM(CurrentAtm);
            }
            Environment.Exit(1);
        }
    }
}
