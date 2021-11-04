namespace JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PostTagMap", newName: "TagPosts");
            RenameColumn(table: "dbo.TagPosts", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.TagPosts", name: "TagId", newName: "Tag_Id");
            RenameIndex(table: "dbo.TagPosts", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.TagPosts", name: "IX_PostId", newName: "IX_Post_Id");
            DropPrimaryKey("dbo.TagPosts");
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            AddPrimaryKey("dbo.TagPosts", new[] { "Tag_Id", "Post_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostId", "dbo.Posts");
            DropIndex("dbo.PostTags", new[] { "TagId" });
            DropIndex("dbo.PostTags", new[] { "PostId" });
            DropPrimaryKey("dbo.TagPosts");
            DropTable("dbo.PostTags");
            AddPrimaryKey("dbo.TagPosts", new[] { "PostId", "TagId" });
            RenameIndex(table: "dbo.TagPosts", name: "IX_Post_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.TagPosts", name: "IX_Tag_Id", newName: "IX_TagId");
            RenameColumn(table: "dbo.TagPosts", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.TagPosts", name: "Post_Id", newName: "PostId");
            RenameTable(name: "dbo.TagPosts", newName: "PostTagMap");
        }
    }
}
