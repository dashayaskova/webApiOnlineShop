namespace DbProvides.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.product_instance", "OrderId", "dbo.order");
            DropIndex("dbo.product_instance", new[] { "OrderId" });
            AlterColumn("dbo.product_instance", "OrderId", c => c.Long());
            CreateIndex("dbo.product_instance", "OrderId");
            AddForeignKey("dbo.product_instance", "OrderId", "dbo.order", "order_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product_instance", "OrderId", "dbo.order");
            DropIndex("dbo.product_instance", new[] { "OrderId" });
            AlterColumn("dbo.product_instance", "OrderId", c => c.Long(nullable: false));
            CreateIndex("dbo.product_instance", "OrderId");
            AddForeignKey("dbo.product_instance", "OrderId", "dbo.order", "order_id", cascadeDelete: true);
        }
    }
}
