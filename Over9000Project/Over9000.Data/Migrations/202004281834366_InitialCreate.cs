namespace Over9000.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountHistory",
                c => new
                    {
                        AccountHistoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountHistoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductDescription = c.String(nullable: false),
                        ProductReviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductReview", t => t.ProductReviewId, cascadeDelete: true)
                .ForeignKey("dbo.AccountHistory", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductReviewId);
            
            CreateTable(
                "dbo.ProductReview",
                c => new
                    {
                        ProductReviewId = c.Int(nullable: false, identity: true),
                        ReviewTitle = c.String(nullable: false),
                        ReviewText = c.String(nullable: false),
                        ReviewStars = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductReviewId);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        SavedPaymentInformationId = c.Int(nullable: false),
                        AccountHistoryId = c.Int(nullable: false),
                        ProductReviewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.AccountHistory", t => t.AccountHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductReview", t => t.ProductReviewsId, cascadeDelete: true)
                .ForeignKey("dbo.SavedPaymentInformation", t => t.SavedPaymentInformationId, cascadeDelete: true)
                .Index(t => t.SavedPaymentInformationId)
                .Index(t => t.AccountHistoryId)
                .Index(t => t.ProductReviewsId);
            
            CreateTable(
                "dbo.SavedPaymentInformation",
                c => new
                    {
                        SavedPaymentInformationId = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        SavedPaymentInformationName = c.String(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CVV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SavedPaymentInformationId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Account", "SavedPaymentInformationId", "dbo.SavedPaymentInformation");
            DropForeignKey("dbo.Account", "ProductReviewsId", "dbo.ProductReview");
            DropForeignKey("dbo.Account", "AccountHistoryId", "dbo.AccountHistory");
            DropForeignKey("dbo.Product", "ProductId", "dbo.AccountHistory");
            DropForeignKey("dbo.Product", "ProductReviewId", "dbo.ProductReview");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Account", new[] { "ProductReviewsId" });
            DropIndex("dbo.Account", new[] { "AccountHistoryId" });
            DropIndex("dbo.Account", new[] { "SavedPaymentInformationId" });
            DropIndex("dbo.Product", new[] { "ProductReviewId" });
            DropIndex("dbo.Product", new[] { "ProductId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.SavedPaymentInformation");
            DropTable("dbo.Account");
            DropTable("dbo.ProductReview");
            DropTable("dbo.Product");
            DropTable("dbo.AccountHistory");
        }
    }
}
