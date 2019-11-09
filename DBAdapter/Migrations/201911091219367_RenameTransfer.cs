namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTransfer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RegularPayment", newName: "RegularTransfer");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RegularTransfer", newName: "RegularPayment");
        }
    }
}
