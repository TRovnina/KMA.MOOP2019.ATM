namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        CardNumber = c.String(nullable: false, maxLength: 128),
                        CardPassword = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AvailableSum = c.Double(nullable: false),
                        ClientITN = c.String(nullable: false, maxLength: 128),
                        EndOfGracePeriod = c.DateTime(),
                        MaxCreditSum = c.Double(),
                        CreditSum = c.Double(),
                        PercentageCredit = c.Int(),
                        Debt = c.Double(),
                        ThresholdAmount = c.Double(),
                        PeriodCashSurplus = c.Int(),
                        PeriodCashSurplusId = c.Int(),
                        IsHandingCashSurplus = c.Boolean(),
                        DepositDate = c.DateTime(),
                        StoregedDate = c.DateTime(),
                        PercentageDeposit = c.Int(),
                        AvailableDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CardNumber)
                .ForeignKey("dbo.Client", t => t.ClientITN, cascadeDelete: true)
                .Index(t => t.ClientITN);
            
            CreateTable(
                "dbo.ATMAccountAction",
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
                .ForeignKey("dbo.Account", t => t.AccountNum, cascadeDelete: true)
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
                        Banknote50 = c.Int(nullable: false),
                        Banknote100 = c.Int(nullable: false),
                        Banknote200 = c.Int(nullable: false),
                        Banknote500 = c.Int(nullable: false),
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
                "dbo.Client",
                c => new
                    {
                        ITN = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ITN);
            
            CreateTable(
                "dbo.RegularPayment",
                c => new
                    {
                        RegularPaymentId = c.Int(nullable: false, identity: true),
                        FirstRegularPaymentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PeriodRegularPaymentId = c.Int(nullable: false),
                        RegularPaymentName = c.String(nullable: false),
                        Sum = c.Double(nullable: false),
                        DestinationAccount = c.String(nullable: false),
                        CardNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RegularPaymentId)
                .ForeignKey("dbo.Account", t => t.CardNumber)
                .Index(t => t.CardNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegularPayment", "CardNumber", "dbo.Account");
            DropForeignKey("dbo.Account", "ClientITN", "dbo.Client");
            DropForeignKey("dbo.ATMAccountAction", "AccountNum", "dbo.Account");
            DropForeignKey("dbo.ATMManagerAction", "ATMCode", "dbo.ATM");
            DropForeignKey("dbo.ATMManagerAction", "ManagerId", "dbo.Manager");
            DropForeignKey("dbo.ATMAccountAction", "ATMCode", "dbo.ATM");
            DropIndex("dbo.RegularPayment", new[] { "CardNumber" });
            DropIndex("dbo.ATMManagerAction", new[] { "ATMCode" });
            DropIndex("dbo.ATMManagerAction", new[] { "ManagerId" });
            DropIndex("dbo.ATMAccountAction", new[] { "AccountNum" });
            DropIndex("dbo.ATMAccountAction", new[] { "ATMCode" });
            DropIndex("dbo.Account", new[] { "ClientITN" });
            DropTable("dbo.RegularPayment");
            DropTable("dbo.Client");
            DropTable("dbo.Manager");
            DropTable("dbo.ATMManagerAction");
            DropTable("dbo.ATM");
            DropTable("dbo.ATMAccountAction");
            DropTable("dbo.Account");
        }
    }
}
