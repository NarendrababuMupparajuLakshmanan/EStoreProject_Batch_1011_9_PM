using EstoreAdminModel.Models.Types;
using Microsoft.EntityFrameworkCore;

namespace EStoreAdminRepository
{
    public class TypeRepository : DbContext
    {

        public TypeRepository(DbContextOptions<TypeRepository> options) 
            : base(options)
        {
            
        }

        public DbSet<TypeModel> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<TypeModel>(entity =>
            //{
            //    entity.ToTable("Types");
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(100);
            //});

            //modelBuilder.Entity<TypeModel>().HasData(
            //    new TypeModel { Id = Guid.NewGuid(), Name = "TV" },
            //    new TypeModel { Id = Guid.NewGuid(), Name = "Mobile" },
            //    new TypeModel { Id = Guid.NewGuid() , Name = "Tab" }
            //);
        }
    }
}
