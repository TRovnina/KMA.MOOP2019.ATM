﻿using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
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
        private List<Account> _accounts;

        #endregion

        #region Constructors

        public Client()
        {

            _accounts = new List<Account>();
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

        public List<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        #endregion

        public CurrentAccount CurrentAccount()
        {
            return Accounts.OfType<CurrentAccount>().FirstOrDefault();
        }

        public CreditAccount CreditAccount()
        {
            return Accounts.OfType<CreditAccount>().FirstOrDefault();
        }

        public DepositAccount DepositAccount()
        {
            return Accounts.OfType<DepositAccount>().FirstOrDefault();
        }

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

                HasMany(a => a.Accounts)
                    .WithRequired(act => act.Client)
                    .HasForeignKey(act => act.ClientITN)
                    .WillCascadeOnDelete(true);

            }
        }
        #endregion
    }
}