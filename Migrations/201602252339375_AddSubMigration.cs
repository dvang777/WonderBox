namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubName = c.String(),
                        SubLength = c.Int(nullable: false),
                        MonthlyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearlyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscriptions");
        }
    }
}
