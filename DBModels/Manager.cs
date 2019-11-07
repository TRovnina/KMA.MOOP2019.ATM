using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Manager
    {
        #region Fields

        [DataMember]
        private string _managerId;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _password;

        [DataMember]
        private List<ATMManagerAction> _atmManagerActions;

        #endregion

        #region Constructors

        private Manager()
        {
            _atmManagerActions = new List<ATMManagerAction>();
        }

        public Manager(string managerId, string firstName, string lastName, string password) : this()
        {
            _managerId = managerId;
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
        }

        #endregion

        #region Properties

        public string ManagerId
        {
            get { return _managerId; }
            private set { _managerId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Password
        {
            get { return _password; }
            private set { _password = value; }
        }

        public List<ATMManagerAction> ATMManagerActions
        {
            get { return _atmManagerActions; }
            private set { _atmManagerActions = value; }
        }

        #endregion

        public override string ToString()
        {
            return "Manager " + FirstName + " " + LastName + "; ID: " + ManagerId;
        }
    }
}