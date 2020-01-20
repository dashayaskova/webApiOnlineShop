namespace DbProvides.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_category",
                c => new
                    {
                        product_id = c.Long(nullable: false),
                        category_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.product_id, t.category_id })
                .ForeignKey("dbo.Categories", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.product", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product_category", "product_id", "dbo.product");
            DropForeignKey("dbo.product_category", "category_id", "dbo.Categories");
            DropIndex("dbo.product_category", new[] { "category_id" });
            DropIndex("dbo.product_category", new[] { "product_id" });
            DropTable("dbo.Categories");
            DropTable("dbo.product_category");
        }
    }
}
