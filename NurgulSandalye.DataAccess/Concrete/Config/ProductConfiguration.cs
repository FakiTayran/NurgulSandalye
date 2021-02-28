using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.DataAccess.Concrete.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100);

            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);

            //builder.Property(x => x.Price).IsRequired(true);

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SubCategory).WithMany().HasForeignKey(x => x.SubCategoryId);

            builder.HasOne(x => x.Material).WithMany().HasForeignKey(x => x.MaterialId);
        }
    }
}
