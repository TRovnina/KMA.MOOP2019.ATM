using System;

namespace ATM_Simulator.Models
{
    internal class ATM
    {
        #region Fields

        private string _code;
        private string _password;

        #endregion

        #region Properties

        internal string Code
        {
            get { return _code; }
            set
            {
                _code = value;
            }
        }

        internal string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        #endregion
        

        public ATM(string code, string password)
        {
            Code = code;
            Password = password;
        }
    }
}
