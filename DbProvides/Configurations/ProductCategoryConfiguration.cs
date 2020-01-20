using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProvides.Configurations
{
	class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
	{
		public ProductCategoryConfiguration()
		{
			ToTable("product_category");
			HasKey(pc =>  new { pc.ProductId, pc.CategoryId });
			Property(pc => pc.ProductId).HasColumnName("product_id").IsRequired();
			Property(pc => pc.CategoryId).HasColumnName("category_id").IsRequired();
			HasRequired(sc => sc.Category).WithMany(c => c.Products)
				.HasForeignKey(pc => pc.CategoryId);
			HasRequired(sc => sc.Product).WithMany(p => p.Categories)
				.HasForeignKey(pc => pc.ProductId);
		}
	}
}
