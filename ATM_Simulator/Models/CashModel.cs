using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.Models
{
    public abstract class CashModel : BasicViewModel
    {
        protected int[] _result100;
        protected int[] _result200;
        protected int[] _result500;


        protected CashModel()
        {
            _result100 = Multiplicity(100, CountBanknotes());
            _result200 = Multiplicity(200, CountBanknotes());
            _result500 = Multiplicity(500, CountBanknotes());
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
        public int[] Multiplicity(int sum, Dictionary<int, int> banknotes)
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
                banknotes.Remove(key);
                if (x > 0)
                    banknotes.Add(key, x);

                sum -= key;
                res.Add(key);
            }

            if (sum != 0)
                return null;
            int[] rr = res.ToArray();
            return rr;
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
                if (Multiplicity(v, CountBanknotes()) != null)
                    return v;
            }

            return 0;
        }

        protected async void GetMoney(int n, int[] res)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                string txt = "";
                int commission = 0;

                CreditAccount account = StaticManager.CurrentCard as CreditAccount;
                if (account != null)
                {
                    commission = (int) (n * 0.03);
                    txt = "\nСommission = 3% (" + commission + " points)";
                }
                
                //if (sum >= (n + commission))
                //{
                //    if(account == null)
                //        StaticManager.CurrentCard.AvailableSum = sum - (n + commission);
                //    //else
                //    //    account.CreditSum = account.CreditSum + (n + commission);

                //    RemoveBanknotes(res);
                //    DbManager.SaveAccount(StaticManager.CurrentCard);
                //    MessageBox.Show("You have successfully been issued " + n + " points!" + txt + "\nBanknotes " +
                //                    string.Join(",", res));
                //}
                //else
                //    MessageBox.Show("There is not enough money in your account!", "Refusal!", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                ATMAccountAction action = new ATMAccountAction(StaticManager.CurrentAtm, StaticManager.CurrentCard,
                    "CashWithdrawal");
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();

            NavigationManager.Instance.Navigate(ModesEnum.AskContinue);
        }
    }
}
