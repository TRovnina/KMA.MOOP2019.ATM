﻿using System.Data.Entity;
using DBAdapter.Migrations;
using DBModels;

namespace DBAdapter
{
    internal class ATMDbContext : DbContext
    {
        public ATMDbContext() : base("ATMdb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMDbContext, Configuration>(true));
        }

        public DbSet<Action> Actions { get; set; }
        public DbSet<ATM> ATMs { get; set; }
        public DbSet<ATMManagerAction> ATMManagerActions { get; set; }
        public DbSet<Banknote> Banknotes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<RegularPayment> RegularPayments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Action.ActionEntityConfiguration());
            modelBuilder.Configurations.Add(new ATM.ATMEntityConfiguration());
            modelBuilder.Configurations.Add(new ATMManagerAction.ATMManagerActionEntityConfiguration());
            modelBuilder.Configurations.Add(new Banknote.BanknoteEntityConfiguration());
            modelBuilder.Configurations.Add(new Client.ClientEntityConfiguration());
            modelBuilder.Configurations.Add(new Account.AccountEntityConfiguration());
            modelBuilder.Configurations.Add(new Manager.ManagerEntityConfiguration());
            modelBuilder.Configurations.Add(new RegularPayment.RegularPaymentEntityConfiguration());

        }
    }
}