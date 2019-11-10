namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeATMActions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ATMAccountAction", "Notes", c => c.String(nullable: false));
            AddColumn("dbo.ATMManagerAction", "Notes", c => c.String());
            DropColumn("dbo.ATMAccountAction", "ActionTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ATMAccountAction", "ActionTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.ATMManagerAction", "Notes");
            DropColumn("dbo.ATMAccountAction", "Notes");
        }
    }
}
