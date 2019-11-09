
using System;
using System.Collections.Generic;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.CashWithdrawal
{
    internal abstract class CashModel : BasicViewModel
    {
        protected readonly Dictionary<int, int> Banknotes;

        protected CashModel()
        {
            Banknotes = CountBanknotes();
        }

        protected void RemoveBanknotes(int[] money)
        {
            foreach (var m in money)
            {
                if (m == 500)
                    StaticManager.CurrentAtm.Banknote500 = StaticManager.CurrentAtm.Banknote500 - 1;
                else if (m == 200)
                    StaticManager.CurrentAtm.Banknote200 = StaticManager.CurrentAtm.Banknote200 - 1;
                else if (m == 100)
                    StaticManager.CurrentAtm.Banknote100 = StaticManager.CurrentAtm.Banknote100 - 1;
                else
                    StaticManager.CurrentAtm.Banknote50 = StaticManager.CurrentAtm.Banknote50 - 1;
            }
        }

        //collection with available banknotes and their quantity
        protected Dictionary<int, int> CountBanknotes()
        {
            Dictionary<int, int> banknotes = new Dictionary<int, int>();
            if (StaticManager.CurrentAtm.Banknote500 > 0)
                banknotes.Add(500, StaticManager.CurrentAtm.Banknote500);
            if (StaticManager.CurrentAtm.Banknote200 > 0)
                banknotes.Add(200, StaticManager.CurrentAtm.Banknote200);
            if (StaticManager.CurrentAtm.Banknote100 > 0)
                banknotes.Add(100, StaticManager.CurrentAtm.Banknote100);
            if (StaticManager.CurrentAtm.Banknote50 > 0)
                banknotes.Add(50, StaticManager.CurrentAtm.Banknote50);
            return banknotes;
        }

        //array of banknotes for the nobility in ATM
        protected int[] Multiplicity(int sum, Dictionary<int, int> banknotes)
        {
            List<int> res = new List<int>();
            while (true)
            {
                int key;
                if (banknotes.ContainsKey(500) && sum >= 500)
                    key = 500;
                else if (banknotes.ContainsKey(200) && sum >= 200)
                    key = 200;
                else if (banknotes.ContainsKey(100) && sum >= 100)
                    key = 100;
                else if (banknotes.ContainsKey(50) && sum >= 50)
                    key = 50;
                else
                    break;

                var x = banknotes[key] - 1;
                if (x > 0)
                    banknotes.Add(key, x);
                else
                    banknotes.Remove(key);
                sum -= key;
                res.Add(key);
            }

            if (sum != 0)
                return null;
            return res.ToArray();
        }

        protected int AllCash()
        {
            return 500 * StaticManager.CurrentAtm.Banknote500 + 200 * StaticManager.CurrentAtm.Banknote200 +
                   100 * StaticManager.CurrentAtm.Banknote100 + 50 * StaticManager.CurrentAtm.Banknote50;
        }

        protected int CheckMultiplicity()
        {
            int[] list = {50, 100, 200, 500};
            foreach (var v in list)
            {
                if (Multiplicity(v, Banknotes) != null)
                    return v;
            }

            return 0;
        }
    }
}
