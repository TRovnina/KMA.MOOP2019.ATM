using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
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
        [DataMember]
        private List<Banknote> _banknotes;

        #endregion

        #region constructors

        private ATM()
        {
            _actions = new List<Action>();
            _atmManagerActions = new List<ATMManagerAction>();
            _banknotes = new List<Banknote>();
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
            get => _atmCode;
            set => _atmCode = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public bool Status
        {
            get => _status;
            set => _status = value;
        }

        public string ATMAddress
        {
            get => _atmAddress;
            set => _atmAddress = value;
        }

        public List<Action> Actions
        {
            get => _actions;
            private set => _actions = value;
        }

        public List<ATMManagerAction> AtmManagerActions
        {
            get => _atmManagerActions;
            private set => _atmManagerActions = value;
        }

        public List<Banknote> Banknotes
        {
            get => _banknotes;
            private set => _banknotes = value;
        }

        #endregion

        public override string ToString()
        {
            return "ATM number: " + _atmCode + "; Address: " + _atmAddress + "; ATM Status: " + _status;
        }

        #region EntityConfiguration

        public class ATMEntityConfiguration : EntityTypeConfiguration<ATM>
        {
            public ATMEntityConfiguration()
            {
                ToTable("ATM");
                HasKey(a => a.ATMCode);

                Property(a => a.ATMCode)
                    .HasColumnName("ATMCode")
                    .IsRequired();
                Property(a => a.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(a => a.Status)
                    .HasColumnName("Status")
                    .IsRequired();
                Property(a => a.ATMAddress)
                    .HasColumnName("ATMAddress")
                    .IsRequired();


                HasMany(a => a.Actions)
                    .WithRequired(act => act.ATM)
                    .HasForeignKey(act => act.ATMCode)
                    .WillCascadeOnDelete(true);

                HasMany(a => a.AtmManagerActions)
                    .WithRequired(act => act.ATM)
                    .HasForeignKey(act => act.ATMCode)
                    .WillCascadeOnDelete(true);

                HasMany(a => a.Banknotes)
                    .WithRequired(act => act.ATM)
                    .HasForeignKey(act => act.ATMCode)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}