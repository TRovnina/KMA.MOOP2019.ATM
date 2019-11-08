using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Action
    {
        #region Fields
        [DataMember]
        private int _actionId;
        [DataMember]
        private ActionType _actionType;
        [DataMember]
        private int _actionTypeId;
        [DataMember]
        private DateTime _actionDate;

        [DataMember]
        private ATM _atm;
        [DataMember]
        private string _atmCode;
        [DataMember]
        private CreditAccount _creditAccount;
        [DataMember]
        private CurrentAccount _currentAccount;
        [DataMember]
        private DepositAccount _depositAccount;
        [DataMember]
        private string _accountNum;

        [DataMember]
        private string _destinationAccountNum; // if ActionType != ActionType.Transfer then null

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
            _creditAccount = account as CreditAccount;
            _currentAccount = account as CurrentAccount;
            _depositAccount = account as DepositAccount;
            _accountNum = account.CardNumber;
        }

        public Action(ATM atm, Account account, Account destinationAccount) : this(ActionType.Transfer, atm, account)
        {
            _destinationAccountNum = destinationAccount.CardNumber;
        }

        #endregion

        #region Properties

        public int ActionId
        {
            get => _actionId;
            private set => _actionId = value;
        }

        public ActionType ActionType
        {
            get => _actionType;
            private set => _actionType = value;
        }

        public int ActionTypeId
        {
            get => (int)_actionType;
            private set => _actionType = (ActionType)value;
        }

        public DateTime ActionDate
        {
            get => _actionDate;
            private set => _actionDate = value;
        }

        public ATM ATM
        {
            get => _atm;
            private set => _atm = value;
        }

        public string ATMCode
        {
            get => _atmCode;
            private set => _atmCode = value;
        }

        public CreditAccount CreditAccount
        {
            get => _creditAccount;
            private set => _creditAccount = value;
        }

        public CurrentAccount CurrentAccount
        {
            get => _currentAccount;
            private set => _currentAccount = value;
        }

        public DepositAccount DepositAccount
        {
            get => _depositAccount;
            private set => _depositAccount = value;
        }

        public string AccountNum
        {
            get => _accountNum;
            private set => _accountNum = value;
        }

        public string DestinationAccountNum
        {
            get => _destinationAccountNum;
            private set => _destinationAccountNum = value;
        }

        #endregion

        #region EntityConfiguration

        public class ActionEntityConfiguration : EntityTypeConfiguration<Action>
        {
            public ActionEntityConfiguration()
            {
                ToTable("Action");
                HasKey(a => a.ActionId);

                Property(a => a.ActionId)
                    .HasColumnName("ActionId")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();
                Property(a => a.ActionDate)
                    .HasColumnName("ActionDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(a => a.ActionTypeId)
                    .HasColumnName("ActionTypeId")
                    .IsRequired();
                Property(a => a.DestinationAccountNum)
                    .HasColumnName("DestinationAccountNum")
                    .IsOptional();

                Ignore(a => a.ActionType);

            }
        }
        #endregion
    }
}