namespace DbProvides.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryConfig : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "category");
            RenameColumn(table: "dbo.category", name: "Id", newName: "category_id");
            RenameColumn(table: "dbo.category", name: "Name", newName: "title");
            AlterColumn("dbo.category", "title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.category", "title", c => c.String());
            RenameColumn(table: "dbo.category", name: "title", newName: "Name");
            RenameColumn(table: "dbo.category", name: "category_id", newName: "Id");
            RenameTable(name: "dbo.category", newName: "Categories");
        }
    }
}
