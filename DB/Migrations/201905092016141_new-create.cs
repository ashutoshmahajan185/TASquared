namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "isDeletedOrHidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Locales", "isDeletedOrHidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "isDeletedOrHidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subcategories", "isDeletedOrHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subcategories", "isDeletedOrHidden");
            DropColumn("dbo.Categories", "isDeletedOrHidden");
            DropColumn("dbo.Locales", "isDeletedOrHidden");
            DropColumn("dbo.Areas", "isDeletedOrHidden");
        }
    }
}
