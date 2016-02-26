namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterBoxes",
                c => new
                    {
                        BoxId = c.Int(nullable: false, identity: true),
                        BoxName = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BoxId);
            

        }
        

    }
}
