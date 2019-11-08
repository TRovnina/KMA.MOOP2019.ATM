using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class Banknote
    {
        #region Fields

        [DataMember]
        private int _banknoteValue; // PPK
        [DataMember]
        private int _banknoteAmount;

        [DataMember]
        private ATM _atm;
        [DataMember]
        private string _atmCode; // PPK, FK

        #endregion

        #region Constructors

        public Banknote(int banknoteValue, int banknoteAmount, ATM atm) : this()
        {
            _banknoteValue = banknoteValue;
            _banknoteAmount = banknoteAmount;
            _atm = atm;
            _atmCode = atm.ATMCode;
        }

        private Banknote()
        {
            
        }

        #endregion

        #region Properties

        public int BanknoteValue
        {
            get => _banknoteValue;
            private set => _banknoteValue = value;
        }

        public int BanknoteAmount
        {
            get => _banknoteAmount;
            set => _banknoteAmount = value;
        }

        public ATM ATM
        {
            get => _atm;
            set => _atm = value;
        }

        public string ATMCode
        {
            get => _atmCode;
            set => _atmCode = value;
        }

        #endregion

        #region EntityConfiguration

        public class BanknoteEntityConfiguration : EntityTypeConfiguration<Banknote>
        {
            public BanknoteEntityConfiguration()
            {
                ToTable("Banknote");
                HasKey(b => new { b.BanknoteValue, b.ATMCode});

                Property(b => b.BanknoteValue)
                    .HasColumnName("BanknoteValue")
                    .IsRequired();
                Property(b => b.BanknoteAmount)
                    .HasColumnName("BanknoteAmount")
                    .IsRequired();
                
            }
        }
        #endregion
    }
}