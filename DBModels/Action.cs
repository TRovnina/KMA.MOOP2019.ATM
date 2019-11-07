using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Action
    {
        #region Fields
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _actionId;
        [DataMember]
        private ActionType _actionType;
        [DataMember]
        private DateTime _actionDate;

        [DataMember]
        private ATM _atm;
        [DataMember]
        private string _atmCode;
        [DataMember]
        private Account _account;
        [DataMember]
        private string _accountNum;

        [DataMember]
        private Account _destinationAccount; // if ActionType != ActionType.Transfer then null

        #endregion


        #region Constructors

        private Action()
        {
            _actionDate = DateTime.Now;
        }

        public Action(ActionType actionType, ATM atm, Account account) : this()
        {
            _actionType = actionType;
            _atm = atm;
            _atmCode = atm.ATMCode;
            _account = account;
            _accountNum = account.CardNumber;
        }

        public Action(ATM atm, Account account, Account destinationAccount) : this(ActionType.Transfer, atm, account)
        {
            _destinationAccount = destinationAccount;
        }

        #endregion

        #region Properties

        public int ActionId
        {
            get { return _actionId;}
            private set { _actionId = value; }
        }

        public ActionType ActionType
        {
            get { return _actionType; }
            private set { _actionType = value; }
        }

        public DateTime ActionDate
        {
            get { return _actionDate; }
            private set { _actionDate = value; }
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

        public Account Account
        {
            get { return _account; }
            private set { _account = value; }
        }

        public string AccountNum
        {
            get { return _accountNum; }
            private set { _accountNum = value; }
        }

        public Account DestinationAccount
        {
            get { return _destinationAccount; }
            private set { _destinationAccount = value; }
        }

        #endregion

    }
}