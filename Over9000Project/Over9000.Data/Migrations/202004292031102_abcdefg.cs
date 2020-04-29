namespace Over9000.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcdefg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductReview", "ReviewOwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductReview", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.ProductReview", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Product", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Product", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Product", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SavedPaymentInformation", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.SavedPaymentInformation", "CardNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SavedPaymentInformation", "CardNumber");
            DropColumn("dbo.SavedPaymentInformation", "OwnerId");
            DropColumn("dbo.Product", "ModifiedUtc");
            DropColumn("dbo.Product", "CreatedUtc");
            DropColumn("dbo.Product", "OwnerId");
            DropColumn("dbo.ProductReview", "ModifiedUtc");
            DropColumn("dbo.ProductReview", "CreatedUtc");
            DropColumn("dbo.ProductReview", "ReviewOwnerId");
        }
    }
}
