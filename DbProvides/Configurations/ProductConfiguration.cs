using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProvides.Configurations
{
	class ProductConfiguration : EntityTypeConfiguration<Product>
	{
		public ProductConfiguration()
		{
			ToTable("product");
			HasKey(product => product.Id);
			Property(product => product.Id).HasColumnName("product_id").IsRequired();
			Property(product => product.Name).HasMaxLength(50).HasColumnName("name").IsRequired();
			Property(product => product.Description).HasColumnName("description");
		}
	}
}
