namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetail1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductOrderDetails",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        OrderDetail_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.OrderDetail_OrderId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_OrderId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.OrderDetail_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrderDetails", "OrderDetail_OrderId", "dbo.OrderDetails");
            DropForeignKey("dbo.ProductOrderDetails", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductOrderDetails", new[] { "OrderDetail_OrderId" });
            DropIndex("dbo.ProductOrderDetails", new[] { "Product_ProductId" });
            DropTable("dbo.ProductOrderDetails");
        }
    }
}
