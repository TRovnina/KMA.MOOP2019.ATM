using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class ATM
    {
        #region Fields

        [DataMember]
        private string _atmCode;
        [DataMember]
        private string _password;
        [DataMember]
        private bool _status;
        [DataMember]
        private string _atmAddress;

        [DataMember]
        private List<Action> _actions;
        [DataMember]
        private List<ATMManagerAction> _atmManagerActions;

        #endregion

        #region constructors
        
        private ATM()
        {
            _actions = new List<Action>();
            _atmManagerActions = new List<ATMManagerAction>();
        }

        public ATM(string atmCode, string password, string atmAddress) : this()
        {
            _atmCode = atmCode;
            _password = password;
            _status = false;
            _atmAddress = atmAddress;
        }

        #endregion

        #region Properties

        public string ATMCode
        {
            get { return _atmCode; }
            set { _atmCode = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string ATMAddress
        {
            get { return _atmAddress; }
            set { _atmAddress = value; }
        }

        #endregion

        public override string ToString()
        {
            return "ATM number: " + _atmCode + "; Address: " + _atmAddress + "; ATM Status: " + _status;
        }
    }
}