namespace JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Categories", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Posts", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Posts", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Tags", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Tags", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "UpdatedOn");
            DropColumn("dbo.Tags", "CreatedOn");
            DropColumn("dbo.Tags", "Status");
            DropColumn("dbo.Posts", "UpdatedOn");
            DropColumn("dbo.Posts", "CreatedOn");
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.Categories", "UpdatedOn");
            DropColumn("dbo.Categories", "CreatedOn");
            DropColumn("dbo.Categories", "Status");
        }
    }
}
