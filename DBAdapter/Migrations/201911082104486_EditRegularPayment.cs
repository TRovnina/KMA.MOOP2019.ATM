namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRegularPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegularPayment", "Sum", c => c.Double(nullable: false));
            AddColumn("dbo.RegularPayment", "DestinationAccount", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegularPayment", "DestinationAccount");
            DropColumn("dbo.RegularPayment", "Sum");
        }
    }
}
