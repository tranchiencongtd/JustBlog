using JustBlog.Models.EnityBase;
using JustBlog.Models.Entities;
using JustBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base("name=connectionString")
        {
            // Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
            // Database.SetInitializer<AppDbContext>(new DropCreateDatabaseAlways<AppDbContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }


        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Post>()
            //           .HasMany<Tag>(t => t.Tags)
            //           .WithMany(p => p.Posts)
            //           .Map(pt => {
            //               pt.MapLeftKey("PostId");
            //               pt.MapRightKey("TagId");
            //               pt.ToTable("PostTagMap");
            //           });
        }

        public override int SaveChanges()
        {
            BeforSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            BeforSaveChanges();
            return base.SaveChangesAsync();
        }

        private void BeforSaveChanges()
        {
            var entities = ChangeTracker.Entries();
            var now = DateTime.UtcNow;

            foreach (var entity in entities)
            {
                if (entity.Entity is IBaseEntity baseEntity)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            baseEntity.Status = Status.Active;
                            baseEntity.CreatedOn = now;
                            baseEntity.UpdatedOn = now;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedOn = now;
                            break;
                    }
                }

            }
        }


    }
}
