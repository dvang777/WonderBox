namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigrationAdduid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserID");
        }
    }
}
