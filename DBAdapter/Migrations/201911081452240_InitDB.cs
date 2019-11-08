namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Action",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        ActionTypeId = c.Int(nullable: false),
                        ActionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ATMCode = c.String(nullable: false, maxLength: 128),
                        AccountNum = c.String(nullable: false, maxLength: 128),
                        DestinationAccountNum = c.String(),
                    })
                .PrimaryKey(t => t.ActionId)
                .ForeignKey("dbo.ATM", t => t.ATMCode, cascadeDelete: true)
                .ForeignKey("dbo.CreditAccount", t => t.AccountNum, cascadeDelete: true)
                .ForeignKey("dbo.CurrentAccount", t => t.AccountNum, cascadeDelete: true)
                .ForeignKey("dbo.DepositAccount", t => t.AccountNum, cascadeDelete: true)
                .Index(t => t.ATMCode)
                .Index(t => t.AccountNum);
            
            CreateTable(
                "dbo.ATM",
                c => new
                    {
                        ATMCode = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ATMAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ATMCode);
            
            CreateTable(
                "dbo.ATMManagerAction",
                c => new
                    {
                        ATMManagerActionId = c.Int(nullable: false, identity: true),
                        ActionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ManagerId = c.String(nullable: false, maxLength: 128),
                        ATMCode = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ATMManagerActionId)
                .ForeignKey("dbo.Manager", t => t.ManagerId, cascadeDelete: true)
                .ForeignKey("dbo.ATM", t => t.ATMCode, cascadeDelete: true)
                .Index(t => t.ManagerId)
                .Index(t => t.ATMCode);
            
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        ManagerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerId);
            
            CreateTable(
                "dbo.Banknote",
                c => new
                    {
                        BanknoteValue = c.Int(nullable: false),
                        ATMCode = c.String(nullable: false, maxLength: 128),
                        BanknoteAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BanknoteValue, t.ATMCode })
                .ForeignKey("dbo.ATM", t => t.ATMCode, cascadeDelete: true)
                .Index(t => t.ATMCode);
            
            CreateTable(
                "dbo.CreditAccount",
                c => new
                    {
                        CardNumber = c.String(nullable: false, maxLength: 128),
                        EndOfGracePeriod = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MaxCreditSum = c.Double(nullable: false),
                        CreditSum = c.Double(nullable: false),
                        Percentage = c.Int(nullable: false),
                        Debt = c.Double(nullable: false),
                        CardPassword = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AvailableSum = c.Double(nullable: false),
                        ClientITN = c.String(),
                    })
                .PrimaryKey(t => t.CardNumber);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ITN = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CurrentAccountNum = c.String(),
                        CreditAccountNum = c.String(),
                        DepositAccountNum = c.String(),
                    })
                .PrimaryKey(t => t.ITN)
                .ForeignKey("dbo.CurrentAccount", t => t.ITN)
                .ForeignKey("dbo.DepositAccount", t => t.ITN)
                .ForeignKey("dbo.CreditAccount", t => t.ITN)
                .Index(t => t.ITN);
            
            CreateTable(
                "dbo.CurrentAccount",
                c => new
                    {
                        CardNumber = c.String(nullable: false, maxLength: 128),
                        ThresholdAmount = c.Double(),
                        PeriodCashSurplusId = c.Int(),
                        IsHandingCashSurplus = c.Boolean(nullable: false),
                        DepositAccountNum = c.String(),
                        CardPassword = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AvailableSum = c.Double(nullable: false),
                        ClientITN = c.String(),
                    })
                .PrimaryKey(t => t.CardNumber);
            
            CreateTable(
                "dbo.DepositAccount",
                c => new
                    {
                        CardNumber = c.String(nullable: false, maxLength: 128),
                        DepositDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StoregedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Percentage = c.Int(nullable: false),
                        AvailableDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CurrentAccountNum = c.String(),
                        CardPassword = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AvailableSum = c.Double(nullable: false),
                        ClientITN = c.String(),
                        CurrentAccount_CardNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CardNumber)
                .ForeignKey("dbo.CurrentAccount", t => t.CurrentAccount_CardNumber)
                .Index(t => t.CurrentAccount_CardNumber);
            
            CreateTable(
                "dbo.RegularPayment",
                c => new
                    {
                        RegularPaymentId = c.Int(nullable: false, identity: true),
                        FirstRegularPaymentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PeriodRegularPaymentId = c.Int(nullable: false),
                        RegularPaymentName = c.String(nullable: false),
                        CurrentAccountNum = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RegularPaymentId)
                .ForeignKey("dbo.CurrentAccount", t => t.CurrentAccountNum, cascadeDelete: true)
                .Index(t => t.CurrentAccountNum);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "ITN", "dbo.CreditAccount");
            DropForeignKey("dbo.RegularPayment", "CurrentAccountNum", "dbo.CurrentAccount");
            DropForeignKey("dbo.DepositAccount", "CurrentAccount_CardNumber", "dbo.CurrentAccount");
            DropForeignKey("dbo.Client", "ITN", "dbo.DepositAccount");
            DropForeignKey("dbo.Action", "AccountNum", "dbo.DepositAccount");
            DropForeignKey("dbo.Client", "ITN", "dbo.CurrentAccount");
            DropForeignKey("dbo.Action", "AccountNum", "dbo.CurrentAccount");
            DropForeignKey("dbo.Action", "AccountNum", "dbo.CreditAccount");
            DropForeignKey("dbo.Banknote", "ATMCode", "dbo.ATM");
            DropForeignKey("dbo.ATMManagerAction", "ATMCode", "dbo.ATM");
            DropForeignKey("dbo.ATMManagerAction", "ManagerId", "dbo.Manager");
            DropForeignKey("dbo.Action", "ATMCode", "dbo.ATM");
            DropIndex("dbo.RegularPayment", new[] { "CurrentAccountNum" });
            DropIndex("dbo.DepositAccount", new[] { "CurrentAccount_CardNumber" });
            DropIndex("dbo.Client", new[] { "ITN" });
            DropIndex("dbo.Banknote", new[] { "ATMCode" });
            DropIndex("dbo.ATMManagerAction", new[] { "ATMCode" });
            DropIndex("dbo.ATMManagerAction", new[] { "ManagerId" });
            DropIndex("dbo.Action", new[] { "AccountNum" });
            DropIndex("dbo.Action", new[] { "ATMCode" });
            DropTable("dbo.RegularPayment");
            DropTable("dbo.DepositAccount");
            DropTable("dbo.CurrentAccount");
            DropTable("dbo.Client");
            DropTable("dbo.CreditAccount");
            DropTable("dbo.Banknote");
            DropTable("dbo.Manager");
            DropTable("dbo.ATMManagerAction");
            DropTable("dbo.ATM");
            DropTable("dbo.Action");
        }
    }
}
