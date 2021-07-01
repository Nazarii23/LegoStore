namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OrderAdress = c.String(nullable: false),
                        OrderEmail = c.String(nullable: false),
                        OrderCity = c.String(nullable: false),
                        OrderCountry = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        GiftWrap = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderDetails");
        }
    }
}
