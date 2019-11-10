using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class ATMAccountAction
    {
        #region Fields
        [DataMember]
        private int _actionId;
        [DataMember]
        private DateTime _actionDate;
        [DataMember]
        private string _notes;

        [DataMember]
        private ATM _atm;
        [DataMember]
        private string _atmCode;
        [DataMember]
        private Account _account;
        [DataMember]
        private string _accountNum;

        [DataMember]
        private string _destinationAccountNum;

        #endregion


        #region Constructors

        private ATMAccountAction()
        {
            _actionDate = DateTime.Now;
        }

        public ATMAccountAction(ATM atm, Account account, string notes, Account destinationAccount = null) : this()
        {
            _atm = atm;
            _atmCode = atm.ATMCode;
            _account = account;
            _accountNum = account.CardNumber;
            _notes = notes;
            if (destinationAccount != null)
                _destinationAccountNum = destinationAccount.CardNumber;
            else
                _destinationAccountNum = null;
        }

        #endregion

        #region Properties

        public int ActionId
        {
            get => _actionId;
            private set => _actionId = value;
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

        public Account Account
        {
            get => _account;
            private set => _account = value;
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

        public string Notes
        {
            get => _notes;
            private set => _notes = value;
        }

        #endregion

        public void DeleteDatabaseValues()
        {
            _atm = null;
            _account = null;
        }

        public override string ToString()
        {
            return "ACTION between ATM: " + ATMCode + " and account " + AccountNum + "; Additional information: " + Notes;
        }

        #region EntityConfiguration

        public class ATMAccountActionEntityConfiguration : EntityTypeConfiguration<ATMAccountAction>
        {
            public ATMAccountActionEntityConfiguration()
            {
                ToTable("ATMAccountAction");
                HasKey(a => a.ActionId);

                Property(a => a.ActionId)
                    .HasColumnName("ActionId")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();
                Property(a => a.ActionDate)
                    .HasColumnName("ActionDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                Property(a => a.Notes)
                    .HasColumnName("Notes")
                    .IsRequired();
                Property(a => a.DestinationAccountNum)
                    .HasColumnName("DestinationAccountNum")
                    .IsOptional();

            }
        }
        #endregion
    }
}