namespace DbProvides.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductInstances : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.product");
            CreateTable(
                "dbo.product_instance",
                c => new
                    {
                        code = c.Long(nullable: false, identity: true),
                        product_id = c.Long(nullable: false),
                        OrderId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.code)
                .ForeignKey("dbo.order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.product", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.OrderId);
            
            AlterColumn("dbo.product", "product_id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.product", "product_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product_instance", "product_id", "dbo.product");
            DropForeignKey("dbo.product_instance", "OrderId", "dbo.order");
            DropIndex("dbo.product_instance", new[] { "OrderId" });
            DropIndex("dbo.product_instance", new[] { "product_id" });
            DropPrimaryKey("dbo.product");
            AlterColumn("dbo.product", "product_id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.product_instance");
            AddPrimaryKey("dbo.product", "product_id");
        }
    }
}
