using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class ATMManagerAction
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _atmManagerActionId;
        [DataMember]
        private DateTime _actionDate;
        [DataMember]
        private Manager _manager;
        [DataMember]
        private string _managerId;
        [DataMember]
        private ATM _atm;
        [DataMember]
        private string _atmCode;

        #endregion

        #region Constructors
        
        public ATMManagerAction(Manager manager, ATM atm) : this()
        {
            _manager = manager;
            _managerId = manager.ManagerId;
            _atm = atm;
            _atmCode = atm.ATMCode;
        }

        private ATMManagerAction()
        {
            _actionDate = DateTime.Now;
        }

        #endregion

        #region Properties

        public int ATMManagerActionId
        {
            get { return _atmManagerActionId; }
            private set { _atmManagerActionId = value; }
        }

        public DateTime ActionDate
        {
            get { return _actionDate;}
            private set { _actionDate = value; }
        }

        public Manager Manager
        {
            get { return _manager; }
            private set { _manager = value; }
        }

        public string ManagerId
        {
            get { return _managerId; }
            private set { _managerId = value; }
        }

        public ATM ATM
        {
            get { return _atm; }
            private set { _atm = value; }
        }

        public string ATMCode
        {
            get { return _atmCode; }
            private set { _atmCode = value; }
        }

        #endregion
    }
}