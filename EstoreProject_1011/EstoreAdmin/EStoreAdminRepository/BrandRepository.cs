using EstoreAdminModel.Models.Brands;
using Microsoft.EntityFrameworkCore;

namespace EStoreAdminRepository
{
    public class BrandRepository : DbContext
    {

        public BrandRepository(DbContextOptions<BrandRepository> options) 
            : base(options)
        {
        }

        public DbSet<BrandModel> Brands { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //  //  modelBuilder.Entity<BrandModel>(entity =>
        //  //  {
        //  //      entity.ToTable("Brands");
        //  //      entity.HasKey(e => e.Id);
        //  //      entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        //  //  });

        //  //modelBuilder.Entity<BrandModel>().HasData(
        //  //      new BrandModel { Id = Guid.NewGuid(), Name = "SamSung" },
        //  //      new BrandModel { Id = Guid.NewGuid(), Name = "Reliance" },
        //  //      new BrandModel { Id = Guid.NewGuid(), Name = "Vivo" }
        //  //  );
        //}
    }
}
