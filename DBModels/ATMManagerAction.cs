using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class ATMManagerAction
    {
        #region Fields
        [DataMember]
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
            get => _atmManagerActionId;
            private set => _atmManagerActionId = value;
        }

        public DateTime ActionDate
        {
            get => _actionDate;
            private set => _actionDate = value;
        }

        public Manager Manager
        {
            get => _manager;
            private set => _manager = value;
        }

        public string ManagerId
        {
            get => _managerId;
            private set => _managerId = value;
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

        #endregion

        #region EntityConfiguration

        public class ATMManagerActionEntityConfiguration : EntityTypeConfiguration<ATMManagerAction>
        {
            public ATMManagerActionEntityConfiguration()
            {
                ToTable("ATMManagerAction");
                HasKey(a => a.ATMManagerActionId);

                Property(a => a.ATMManagerActionId)
                    .HasColumnName("ATMManagerActionId")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();
                Property(a => a.ActionDate)
                    .HasColumnName("ActionDate")
                    .HasColumnType("datetime2")
                    .IsRequired();

            }
        }
        #endregion
    }
}