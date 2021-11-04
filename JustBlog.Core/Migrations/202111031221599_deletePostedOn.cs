namespace JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletePostedOn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "PostedOn");
            DropColumn("dbo.Posts", "Modified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Modified", c => c.DateTime());
            AddColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false));
        }
    }
}
