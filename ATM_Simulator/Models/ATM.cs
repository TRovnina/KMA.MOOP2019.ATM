namespace ATM_Simulator.Models
{
    internal class Atm
    {
        #region Properties

        internal string Code
        {
            get;
            set;
        }

        internal string Password
        {
            get;
            set;
        }

        #endregion
        

        public Atm(string code, string password)
        {
            Code = code;
            Password = password;
        }
    }
}
