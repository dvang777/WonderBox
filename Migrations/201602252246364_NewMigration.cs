namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Zipcode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Zipcode", c => c.Int(nullable: false));
        }
    }
}
