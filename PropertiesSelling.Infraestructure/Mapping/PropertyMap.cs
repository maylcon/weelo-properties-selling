using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertiesSelling.Core.Models;

namespace PropertiesSelling.Infraestructure.Mapping
{
    class PropertyMap : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> modelBuilder)
        {
            modelBuilder.ToTable("Property");
            modelBuilder.HasKey(i => i.IdProperty);
            modelBuilder.Property(i => i.IdOwner).HasMaxLength(50).IsRequired(true);
            modelBuilder.Property(i => i.Address).HasMaxLength(100).IsRequired(true);
            modelBuilder.Property(i => i.Price).HasPrecision(18, 5).IsRequired(false);
            modelBuilder.Property(i => i.CodeInternal).HasMaxLength(25).IsRequired(false);
            modelBuilder.Property(i => i.Year).IsRequired(false);

            modelBuilder.HasOne(i => i.Owner)
                .WithMany(i => i.Properties)
                .HasForeignKey(i => i.IdOwner).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(i => i.IdOwner);

            modelBuilder.HasMany(i => i.Images)
                .WithOne(i => i.Property)
                .HasForeignKey(i => i.IdProperty).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(i => i.IdProperty);

            modelBuilder.HasMany(i => i.Traces)
                .WithOne(i => i.Property)
                .HasForeignKey(i => i.IdProperty).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(i => i.IdProperty);
        }
    }
}
