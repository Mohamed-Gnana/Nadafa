using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nadafa.Requests.Domain.Entities;

namespace Nadafa.Requests.Infrastructure.EntityFramework.Configurations
{
    public class RequestAuditConfiguratiions : IEntityTypeConfiguration<RequestAudit>
    {
        public void Configure(EntityTypeBuilder<RequestAudit> builder)
        {
            builder.ToTable("RequestAudits", "RequestSchema");
            builder.HasKey(x => x.Id);
        }
    }
}
