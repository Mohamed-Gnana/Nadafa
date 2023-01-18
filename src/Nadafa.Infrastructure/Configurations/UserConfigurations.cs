using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Infrastructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "UserSchema");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Phones);
            builder.HasMany(x => x.Audits);
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
