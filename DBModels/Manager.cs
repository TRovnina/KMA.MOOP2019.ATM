using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
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
            SetPassword(password);
        }

        #endregion

        #region Properties

        public string ManagerId
        {
            get => _managerId;
            private set => _managerId = value;
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

        public string Password
        {
            get => _password;
            private set => _password = value;
        }

        public List<ATMManagerAction> ATMManagerActions
        {
            get => _atmManagerActions;
            private set => _atmManagerActions = value;
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
            return "Manager " + FirstName + " " + LastName + "; ID: " + ManagerId;
        }

        #region EntityConfiguration

        public class ManagerEntityConfiguration : EntityTypeConfiguration<Manager>
        {
            public ManagerEntityConfiguration()
            {
                ToTable("Manager");
                HasKey(m => m.ManagerId);

                Property(m => m.ManagerId)
                    .HasColumnName("ManagerId")
                    .IsRequired();
                Property(a => a.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(a => a.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(a => a.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();

                HasMany(m => m.ATMManagerActions)
                    .WithRequired(act => act.Manager)
                    .HasForeignKey(act => act.ManagerId)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}