using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotorCyclePoland.Database.Tables;
using System.Reflection.Emit;

namespace MotorCyclePoland.Database
{
    public class BrandModelConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(f => f.Id)
            .ValueGeneratedOnAdd();

            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(u => u.Name)
                    .IsUnique();
            builder.HasMany(x => x.Motorcycles)
                .WithOne(m => m.Brand).HasForeignKey(c=>c.BrandId);
        }
    }
}
