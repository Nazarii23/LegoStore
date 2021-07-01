namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetail_Time : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "OrderDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
