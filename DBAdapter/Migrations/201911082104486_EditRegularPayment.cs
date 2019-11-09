namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRegularPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegularTransfer", "Sum", c => c.Double(nullable: false));
            AddColumn("dbo.RegularTransfer", "DestinationAccount", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegularTransfer", "DestinationAccount");
            DropColumn("dbo.RegularTransfer", "Sum");
        }
    }
}
