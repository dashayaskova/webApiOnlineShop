namespace DbProvides.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderAndUserTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.product", name: "id", newName: "product_id");
            CreateTable(
                "dbo.order",
                c => new
                    {
                        order_id = c.Long(nullable: false, identity: true),
                        user_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        phonenumber = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.order", "user_id", "dbo.user");
            DropIndex("dbo.order", new[] { "user_id" });
            DropTable("dbo.user");
            DropTable("dbo.order");
            RenameColumn(table: "dbo.product", name: "product_id", newName: "id");
        }
    }
}
