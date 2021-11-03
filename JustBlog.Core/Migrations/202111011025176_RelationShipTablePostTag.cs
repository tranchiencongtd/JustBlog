namespace JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationShipTablePostTag : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagPosts", newName: "PostTagMap");
            RenameColumn(table: "dbo.PostTagMap", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.PostTagMap", name: "Post_Id", newName: "PostId");
            RenameIndex(table: "dbo.PostTagMap", name: "IX_Post_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.PostTagMap", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.PostTagMap");
            AddPrimaryKey("dbo.PostTagMap", new[] { "PostId", "TagId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PostTagMap");
            AddPrimaryKey("dbo.PostTagMap", new[] { "Tag_Id", "Post_Id" });
            RenameIndex(table: "dbo.PostTagMap", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.PostTagMap", name: "IX_PostId", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.PostTagMap", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.PostTagMap", name: "TagId", newName: "Tag_Id");
            RenameTable(name: "dbo.PostTagMap", newName: "TagPosts");
        }
    }
}
