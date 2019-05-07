namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locales", "Area_areaID", "dbo.Areas");
            DropForeignKey("dbo.Posts", "Locale_localeID", "dbo.Locales");
            DropForeignKey("dbo.Subcategories", "Category_categoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Subcategory_subCategoryID", "dbo.Subcategories");
            DropPrimaryKey("dbo.Areas");
            DropPrimaryKey("dbo.Locales");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Subcategories");
            AlterColumn("dbo.Areas", "areaID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Locales", "localeID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "categoryID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Subcategories", "subCategoryID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Areas", "areaID");
            AddPrimaryKey("dbo.Locales", "localeID");
            AddPrimaryKey("dbo.Categories", "categoryID");
            AddPrimaryKey("dbo.Subcategories", "subCategoryID");
            AddForeignKey("dbo.Locales", "Area_areaID", "dbo.Areas", "areaID");
            AddForeignKey("dbo.Posts", "Locale_localeID", "dbo.Locales", "localeID");
            AddForeignKey("dbo.Subcategories", "Category_categoryID", "dbo.Categories", "categoryID");
            AddForeignKey("dbo.Posts", "Subcategory_subCategoryID", "dbo.Subcategories", "subCategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Subcategory_subCategoryID", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "Category_categoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Locale_localeID", "dbo.Locales");
            DropForeignKey("dbo.Locales", "Area_areaID", "dbo.Areas");
            DropPrimaryKey("dbo.Subcategories");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Locales");
            DropPrimaryKey("dbo.Areas");
            AlterColumn("dbo.Subcategories", "subCategoryID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "categoryID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Locales", "localeID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Areas", "areaID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Subcategories", "subCategoryID");
            AddPrimaryKey("dbo.Categories", "categoryID");
            AddPrimaryKey("dbo.Locales", "localeID");
            AddPrimaryKey("dbo.Areas", "areaID");
            AddForeignKey("dbo.Posts", "Subcategory_subCategoryID", "dbo.Subcategories", "subCategoryID");
            AddForeignKey("dbo.Subcategories", "Category_categoryID", "dbo.Categories", "categoryID");
            AddForeignKey("dbo.Posts", "Locale_localeID", "dbo.Locales", "localeID");
            AddForeignKey("dbo.Locales", "Area_areaID", "dbo.Areas", "areaID");
        }
    }
}
