namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetail2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrderDetails", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductOrderDetails", "OrderDetail_OrderId", "dbo.OrderDetails");
            DropIndex("dbo.ProductOrderDetails", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductOrderDetails", new[] { "OrderDetail_OrderId" });
            DropTable("dbo.ProductOrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductOrderDetails",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        OrderDetail_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.OrderDetail_OrderId });
            
            CreateIndex("dbo.ProductOrderDetails", "OrderDetail_OrderId");
            CreateIndex("dbo.ProductOrderDetails", "Product_ProductId");
            AddForeignKey("dbo.ProductOrderDetails", "OrderDetail_OrderId", "dbo.OrderDetails", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrderDetails", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
