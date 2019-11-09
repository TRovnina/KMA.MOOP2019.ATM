namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreviousTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RegularTransfer", newName: "RegularPayment");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RegularPayment", newName: "RegularTransfer");
        }
    }
}
