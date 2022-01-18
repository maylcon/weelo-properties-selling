using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertiesSelling.Core.Models;

namespace PropertiesSelling.Infraestructure.Mapping
{
    class PropertyImageMap : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> modelBuilder)
        {
            modelBuilder.ToTable("PropertyImage");
            modelBuilder.HasKey(i => i.IdPropertyImage);
            modelBuilder.Property(p => p.Enable).HasDefaultValue(true).IsRequired(true);
            modelBuilder.Property(p => p.File).IsRequired(true);

            modelBuilder.HasOne(i => i.Property)
               .WithMany(i => i.Images)
               .HasForeignKey(i => i.IdProperty).OnDelete(DeleteBehavior.NoAction)
               .HasPrincipalKey(i => i.IdProperty);

        }
    }
}
