namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRegularPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegularPayments", "Sum", c => c.Double(nullable: false));
            AddColumn("dbo.RegularPayments", "DestinationAccount", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegularPayments", "DestinationAccount");
            DropColumn("dbo.RegularPayments", "Sum");
        }
    }
}
