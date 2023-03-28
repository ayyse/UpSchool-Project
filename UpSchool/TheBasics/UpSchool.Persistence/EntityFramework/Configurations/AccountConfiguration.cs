using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpSchool.Domain.Entities;

namespace UpSchool.Persistence.EntityFramework.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            //builder.HasIndex(x => x.Title);
            builder.HasIndex(x => new { x.Title, x.UserName });
            builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Url).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.IsFavourite).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.LastModifiedOn).IsRequired(false);
            builder.ToTable("Accounts");
        }
    }
}
