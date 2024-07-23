using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotoCyclePoland.Database.Tables;
using System.Reflection.Emit;

namespace MotoCyclePoland.Database
{
    public class BrandModelConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            // Configuration for TodoItem
            builder.HasKey(t => t.Id);
            builder.Property(f => f.Id)
            .ValueGeneratedOnAdd();

            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(u => u.Name)
                    .IsUnique();
            builder.HasMany(x => x.Motocycles)
                .WithOne(m => m.Brand).HasForeignKey(c=>c.BrandId);
        }
    }

    public class BMotocycleModelConfig : IEntityTypeConfiguration<Motocycle>
    {
        public void Configure(EntityTypeBuilder<Motocycle> builder)
        {
            // Configuration for TodoItem
            builder.HasKey(t => t.Id);
        }
    }
}
