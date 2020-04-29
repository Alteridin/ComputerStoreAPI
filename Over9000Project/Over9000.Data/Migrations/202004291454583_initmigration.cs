namespace Over9000.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Account", "SavedPaymentInformationId", "dbo.SavedPaymentInformation");
            DropIndex("dbo.Account", new[] { "SavedPaymentInformationId" });
            AddColumn("dbo.SavedPaymentInformation", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Account", "SavedPaymentInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "SavedPaymentInformationId", c => c.Int(nullable: false));
            DropColumn("dbo.SavedPaymentInformation", "OwnerId");
            CreateIndex("dbo.Account", "SavedPaymentInformationId");
            AddForeignKey("dbo.Account", "SavedPaymentInformationId", "dbo.SavedPaymentInformation", "SavedPaymentInformationId", cascadeDelete: true);
        }
    }
}
