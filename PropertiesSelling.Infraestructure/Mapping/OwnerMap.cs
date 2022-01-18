using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertiesSelling.Core.Models;

namespace PropertiesSelling.Infraestructure.Mapping
{
    class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> modelBuilder)
        {
            modelBuilder.ToTable("Owner");
            modelBuilder.HasKey(i => i.IdOwner);
            modelBuilder.Property(p => p.Name).HasMaxLength(50).IsRequired(true);
            modelBuilder.Property(p => p.Address).HasMaxLength(100).IsRequired(true);
            modelBuilder.Property(p => p.Photo).IsRequired(false);
            modelBuilder.Property(p => p.Birthday).IsRequired(true);

            modelBuilder.HasMany(i => i.Properties)
                .WithOne(i => i.Owner)
                .HasForeignKey(i => i.IdOwner).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(i => i.IdOwner);

        }
    }
}
