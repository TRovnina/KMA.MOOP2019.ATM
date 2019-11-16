using System;
using DBModels;

namespace DBAdapter
{
    public static class CardOperations
    {
        private const double CommissionWithdrawCredit = 0.03;
        private const double CommissionTransferNotOwn = 0.01;

        public static int TransferMoney(Account sourceAccount,
            Account destinationAccount, int sum)
        {
            if (!(sourceAccount is CreditAccount))
                return TransferCurrentDeposit(sourceAccount, destinationAccount, sum);
            return TransferCredit(sourceAccount as CreditAccount, destinationAccount, sum);
        }

        public static int WithdrawMoney(Account account, int sum)
        {
            if (account is CreditAccount credit)
                return WithdrawFromCredit(credit, sum);
            return WithdrawFromNotCredit(account, sum);
        }

        private static int WithdrawFromCredit(CreditAccount account, int sum)
        {
            if ((account.AvailableSum -= sum) < 0)
            {
                int sumCommission = (int)Math.Round(-account.AvailableSum * CommissionWithdrawCredit);
                if (sumCommission - account.AvailableSum + account.CreditSum > account.MaxCreditSum)
                {
                    account.AvailableSum += sum;
                    return -1;
                }
                if (account.CreditSum == 0)
                    account.EndOfGracePeriod = DateTime.Today.AddDays(28);
                account.CreditSum += sumCommission - account.AvailableSum;
                account.AvailableSum = 0;
                //account.ShowInfo();
                EntityWrapper.SaveAccount(account);
                return sumCommission;
            }
            EntityWrapper.SaveAccount(account);
            //account.ShowInfo();
            return 0;
        }

        private static int WithdrawFromNotCredit(Account account, double sum)
        {
            if (account.AvailableSum < sum)
                return -1;
            account.AvailableSum -= sum;
            EntityWrapper.SaveAccount(account);
            //account.ShowInfo();
            return 0;
        }

        private static int TransferCurrentDeposit(Account sourceAccount,
            Account destinationAccount, int sum)
        {
            if (sourceAccount.Client == destinationAccount.Client)
            {
                if (WithdrawFromNotCredit(sourceAccount, sum) == -1)
                    return -1;
                AddMoneyToAccount(destinationAccount, sum);
                return 0;
            }

            int sumCommission = (int)Math.Round(sum + sum * CommissionTransferNotOwn);
            if (WithdrawFromNotCredit(sourceAccount, sumCommission) == -1)
                return -1;
            AddMoneyToAccount(destinationAccount, sum);
            return sumCommission - sum;
        }

        private static int TransferCredit(CreditAccount sourceAccount,
            Account destinationAccount, int sum)
        {
            int sumCommission = (int)Math.Round(sum + sum * CommissionTransferNotOwn);
            int commissionCredit = WithdrawFromCredit(sourceAccount, sumCommission);
            if (commissionCredit == -1)
                return -1;
            AddMoneyToAccount(destinationAccount, sum);
            return sumCommission + commissionCredit - sum;
        }

        private static void AddMoneyToAccount(Account account, int sum)
        {
            CreditAccount credit = account as CreditAccount;
            if (credit == null)
            {
                account.AvailableSum += sum;
                //account.ShowInfo();
                CheckHandingCashSurplus(account);
                EntityWrapper.SaveAccount(account);
                return;
            }

            int debtSum = sum - (int)credit.Debt;
            if (debtSum < 0)
            {
                int days = (int)(sum / (credit.CreditSum / 100 * credit.PercentageCredit));
                credit.EndOfGracePeriod = credit.EndOfGracePeriod.AddDays(days);
                EntityWrapper.SaveAccount(credit);
                //account.ShowInfo();
                return;
            }

            credit.CreditSum -= debtSum;
            credit.EndOfGracePeriod = DateTime.Today;
            if (credit.CreditSum < 0)
            {
                credit.AvailableSum -= credit.CreditSum;
                credit.CreditSum = 0;
            }
            EntityWrapper.SaveAccount(credit);
            //account.ShowInfo();
        }

        private static void CheckHandingCashSurplus(Account account)
        {
            CurrentAccount current = account as CurrentAccount;
            if (current == null)
                return;
            if (!current.IsHandingCashSurplus || current.PeriodCashSurplus != PeriodHandingCashSurplus.OnChanged)
                return;
            if (current.AvailableSum <= current.ThresholdAmount)
                return;
            TransferCurrentDeposit(account, account.Client.DepositAccount(),
                (int)(current.AvailableSum - current.ThresholdAmount));
        }

    }
}