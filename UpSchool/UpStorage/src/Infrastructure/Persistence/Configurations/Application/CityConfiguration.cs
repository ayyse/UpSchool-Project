using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            // RelationShips
            //builder.HasOne<Country>(x => x.Country)
            //    .WithMany(x => x.Cities)
            //    .HasForeignKey(x => x.Country);
        }
    }
}
