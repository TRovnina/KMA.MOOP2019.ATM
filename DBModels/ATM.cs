using System;
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
        private List<ATMAccountAction> _atmAccountAction;
        [DataMember]
        private List<ATMManagerAction> _atmManagerActions;

        [DataMember]
        private int _banknote50;
        [DataMember]
        private int _banknote100;
        [DataMember]
        private int _banknote200;
        [DataMember]
        private int _banknote500;

        #endregion

        #region constructors

        private ATM()
        {
            _atmAccountAction = new List<ATMAccountAction>();
            _atmManagerActions = new List<ATMManagerAction>();
            _banknote50 = 0;
            _banknote100 = 0;
            _banknote200 = 0;
            _banknote500 = 0;
        }

        public ATM(string atmCode, string password, string atmAddress) : this()
        {
            _atmCode = atmCode;
            _status = false;
            _atmAddress = atmAddress;

            SetPassword(password);
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

        public List<ATMAccountAction> ATMAccountAction
        {
            get => _atmAccountAction;
            private set => _atmAccountAction = value;
        }

        public List<ATMManagerAction> AtmManagerActions
        {
            get => _atmManagerActions;
            private set => _atmManagerActions = value;
        }

        public int Banknote50
        {
            get => _banknote50;
            set => _banknote50 = value;
        }

        public int Banknote100
        {
            get => _banknote100;
            set => _banknote100 = value;
        }

        public int Banknote200
        {
            get => _banknote200;
            set => _banknote200 = value;
        }

        public int Banknote500
        {
            get => _banknote500;
            set => _banknote500 = value;
        }

        #endregion

        private void SetPassword(string password)
        {
            _password = password; //Encrypting.GetMd5HashForString(password);
        }

        public bool CheckPassword(string password)
        {
            try
            {
                string res2 = Encrypting.GetMd5HashForString(password);
                return _password == res2;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

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
                Property(a => a.Banknote50)
                    .HasColumnName("Banknote50")
                    .IsRequired();
                Property(a => a.Banknote100)
                    .HasColumnName("Banknote100")
                    .IsRequired();
                Property(a => a.Banknote200)
                    .HasColumnName("Banknote200")
                    .IsRequired();
                Property(a => a.Banknote500)
                    .HasColumnName("Banknote500")
                    .IsRequired();


                HasMany(a => a.ATMAccountAction)
                    .WithRequired(act => act.ATM)
                    .HasForeignKey(act => act.ATMCode)
                    .WillCascadeOnDelete(true);

                HasMany(a => a.AtmManagerActions)
                    .WithRequired(act => act.ATM)
                    .HasForeignKey(act => act.ATMCode)
                    .WillCascadeOnDelete(true);

            }
        }
        #endregion
    }
}