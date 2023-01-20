using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nadafa.Requests.Domain.Entities;

namespace Nadafa.Requests.Infrastructure.EntityFramework.Configurations
{
    public class RequestItemConfigurations : IEntityTypeConfiguration<RequestItem>
    {
        public void Configure(EntityTypeBuilder<RequestItem> builder)
        {
            builder.ToTable("RequestItems", "RequestSchema");
            builder.HasKey(x => x.Id);
        }
    }
}
