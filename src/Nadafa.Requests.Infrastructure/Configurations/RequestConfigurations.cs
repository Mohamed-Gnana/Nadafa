using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nadafa.Requests.Domain.Entities;

namespace Nadafa.Requests.Infrastructure.EntityFramework.Configurations
{
    public class RequestConfigurations : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Requests", "RequestSchema");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Items);
            builder.HasMany(x => x.Audits);
        }
    }
}
