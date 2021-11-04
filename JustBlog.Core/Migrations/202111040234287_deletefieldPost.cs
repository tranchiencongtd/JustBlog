namespace JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletefieldPost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Meta");
            DropColumn("dbo.Posts", "Published");
            DropColumn("dbo.Posts", "RateCount");
            DropColumn("dbo.Posts", "TotalRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "TotalRate", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "RateCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Published", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "Meta", c => c.String(maxLength: 255));
        }
    }
}
