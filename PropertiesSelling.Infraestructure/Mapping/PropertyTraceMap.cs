using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertiesSelling.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Infraestructure.Mapping
{
    class PropertyTraceMap : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> modelBuilder)
        {
            modelBuilder.ToTable("PropertyTrace");
            modelBuilder.HasKey(i => i.IdPropertyTrace);
            modelBuilder.Property(p => p.DateSale).HasColumnType("Date").IsRequired(true);
            modelBuilder.Property(p => p.Name).HasMaxLength(50).IsRequired(true);
            modelBuilder.Property(p => p.Value).IsRequired(true);
            modelBuilder.Property(p => p.Tax).IsRequired(true);

            modelBuilder.HasOne(i => i.Property)
               .WithMany(i => i.Traces)
               .HasForeignKey(i => i.IdProperty).OnDelete(DeleteBehavior.NoAction)
               .HasPrincipalKey(i => i.IdProperty);

        }
    }
}
