namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        areaID = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.areaID);
            
            CreateTable(
                "dbo.Locales",
                c => new
                    {
                        localeID = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        Area_areaID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.localeID)
                .ForeignKey("dbo.Areas", t => t.Area_areaID)
                .Index(t => t.Area_areaID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        postNumber = c.Int(nullable: false),
                        postTimestamp = c.DateTime(nullable: false),
                        postExpiration = c.DateTime(nullable: false),
                        ownerID = c.String(nullable: false),
                        title = c.String(nullable: false),
                        body = c.String(),
                        area = c.String(nullable: false),
                        locale = c.String(),
                        category = c.String(nullable: false),
                        subcategory = c.String(),
                        isDeletedOrHidden = c.Boolean(nullable: false),
                        canBeModified = c.Boolean(nullable: false),
                        Locale_localeID = c.String(maxLength: 128),
                        Subcategory_subCategoryID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locales", t => t.Locale_localeID)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_subCategoryID)
                .Index(t => t.Locale_localeID)
                .Index(t => t.Subcategory_subCategoryID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        messageID = c.Int(nullable: false, identity: true),
                        messageTimestamp = c.DateTime(nullable: false),
                        senderID = c.String(nullable: false),
                        receiverID = c.String(nullable: false),
                        body = c.String(nullable: false),
                        Post_ID = c.Int(),
                        User_userID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.messageID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .ForeignKey("dbo.Users", t => t.User_userID)
                .Index(t => t.Post_ID)
                .Index(t => t.User_userID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryID = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.categoryID);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        subCategoryID = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        Category_categoryID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.subCategoryID)
                .ForeignKey("dbo.Categories", t => t.Category_categoryID)
                .Index(t => t.Category_categoryID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.String(nullable: false, maxLength: 128),
                        userRole = c.String(nullable: false),
                        phoneNumber = c.Int(nullable: false),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.userID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "User_userID", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Subcategories", "Category_categoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Subcategory_subCategoryID", "dbo.Subcategories");
            DropForeignKey("dbo.Locales", "Area_areaID", "dbo.Areas");
            DropForeignKey("dbo.Posts", "Locale_localeID", "dbo.Locales");
            DropForeignKey("dbo.Messages", "Post_ID", "dbo.Posts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Subcategories", new[] { "Category_categoryID" });
            DropIndex("dbo.Messages", new[] { "User_userID" });
            DropIndex("dbo.Messages", new[] { "Post_ID" });
            DropIndex("dbo.Posts", new[] { "Subcategory_subCategoryID" });
            DropIndex("dbo.Posts", new[] { "Locale_localeID" });
            DropIndex("dbo.Locales", new[] { "Area_areaID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Messages");
            DropTable("dbo.Posts");
            DropTable("dbo.Locales");
            DropTable("dbo.Areas");
        }
    }
}
