using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Client
    {
        #region Fields

        [DataMember]
        private string _itn;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;

        [DataMember]
        private CurrentAccount _currentAccount;
        [DataMember]
        private CreditAccount _creditAccount;
        [DataMember]
        private DepositAccount _depositAccount;

        [DataMember]
        private string _currentAccountNum;
        [DataMember]
        private string _creditAccountNum;
        [DataMember]
        private string _depositAccountNum;

        #endregion

        #region Constructors

        public Client()
        {
            
        }

        public Client(string itm, string firstName, string lastName) : this()
        {
            _itn = itm;
            _firstName = firstName;
            _lastName = lastName;
            
        }

        #endregion

        #region Properties

        public string ITN
        {
            get => _itn;
            set => _itn = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public CurrentAccount CurrentAccount
        {
            get => _currentAccount;
            set => _currentAccount = value;
        }

        public CreditAccount CreditAccount
        {
            get => _creditAccount;
            set => _creditAccount = value;
        }

        public DepositAccount DepositAccount
        {
            get => _depositAccount;
            set => _depositAccount = value;
        }

        public string CurrentAccountNum
        {
            get => _currentAccountNum;
            set => _currentAccountNum = value;
        }

        public string CreditAccountNum
        {
            get => _creditAccountNum;
            set => _creditAccountNum = value;
        }

        public string DepositAccountNum
        {
            get => _depositAccountNum;
            set => _depositAccountNum = value;
        }

        #endregion

        public override string ToString()
        {
            return FirstName + " " + LastName + "; ITN: " + ITN;
        }

        #region EntityConfiguration

        public class ClientEntityConfiguration : EntityTypeConfiguration<Client>
        {
            public ClientEntityConfiguration()
            {
                ToTable("Client");
                HasKey(a => a.ITN);

                Property(a => a.ITN)
                    .HasColumnName("ITN")
                    .IsRequired();
                Property(a => a.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(a => a.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();

            }
        }
        #endregion
    }
}