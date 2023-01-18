using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Infrastructure.Configurations
{
    public class UserAuditConfigurations : IEntityTypeConfiguration<UserAudit>
    {
        public void Configure(EntityTypeBuilder<UserAudit> builder)
        {
            builder.ToTable("UserAudits", "UserSchema");
            builder.HasKey(t => t.Id);
        }
    }
}
