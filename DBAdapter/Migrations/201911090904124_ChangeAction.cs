namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAction : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Action", newName: "ATMAccountAction");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ATMAccountAction", newName: "Action");
        }
    }
}
