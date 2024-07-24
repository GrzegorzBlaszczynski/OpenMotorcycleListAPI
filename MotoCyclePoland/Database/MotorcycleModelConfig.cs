using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotorCyclePoland.Database.Tables;

namespace MotorCyclePoland.Database
{
    public class MotorcycleModelConfig : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
