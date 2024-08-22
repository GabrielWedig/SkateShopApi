using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkateShop.Domain.Entities;

namespace SkateShop.Infrastructure.Mappings
{
    internal sealed class TopBarMessageMapping : Mapping<TopBarMessage>
    {
        public override void Configure(EntityTypeBuilder<TopBarMessage> builder)
        {
            builder.ToTable("top_bar_messages");

            builder.Property(m => m.Message)
               .HasColumnName("message")
               .IsRequired();

            base.Configure(builder);
        }
    }
}
