namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBanknotes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Banknote", "ATMCode", "dbo.ATM");
            DropIndex("dbo.Banknote", new[] { "ATMCode" });
            RenameColumn(table: "dbo.RegularPayment", name: "CurrentAccount_CardNumber", newName: "CardNumber");
            RenameIndex(table: "dbo.RegularPayment", name: "IX_CurrentAccount_CardNumber", newName: "IX_CardNumber");
            AddColumn("dbo.Account", "PercentageCredit", c => c.Int());
            AddColumn("dbo.Account", "PercentageDeposit", c => c.Int());
            AddColumn("dbo.ATM", "Banknote50", c => c.Int(nullable: false));
            AddColumn("dbo.ATM", "Banknote100", c => c.Int(nullable: false));
            AddColumn("dbo.ATM", "Banknote200", c => c.Int(nullable: false));
            AddColumn("dbo.ATM", "Banknote500", c => c.Int(nullable: false));
            DropColumn("dbo.Account", "Percentage");
            DropColumn("dbo.Account", "Percentage1");
            DropColumn("dbo.RegularPayment", "CurrentAccountNum");
            DropTable("dbo.Banknote");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Banknote",
                c => new
                    {
                        BanknoteValue = c.Int(nullable: false),
                        ATMCode = c.String(nullable: false, maxLength: 128),
                        BanknoteAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BanknoteValue, t.ATMCode });
            
            AddColumn("dbo.RegularPayment", "CurrentAccountNum", c => c.String());
            AddColumn("dbo.Account", "Percentage1", c => c.Int());
            AddColumn("dbo.Account", "Percentage", c => c.Int());
            DropColumn("dbo.ATM", "Banknote500");
            DropColumn("dbo.ATM", "Banknote200");
            DropColumn("dbo.ATM", "Banknote100");
            DropColumn("dbo.ATM", "Banknote50");
            DropColumn("dbo.Account", "PercentageDeposit");
            DropColumn("dbo.Account", "PercentageCredit");
            RenameIndex(table: "dbo.RegularPayment", name: "IX_CardNumber", newName: "IX_CurrentAccount_CardNumber");
            RenameColumn(table: "dbo.RegularPayment", name: "CardNumber", newName: "CurrentAccount_CardNumber");
            CreateIndex("dbo.Banknote", "ATMCode");
            AddForeignKey("dbo.Banknote", "ATMCode", "dbo.ATM", "ATMCode", cascadeDelete: true);
        }
    }
}
