using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProvides.Configurations
{
	class ProductInstanceConfiguration : EntityTypeConfiguration<ProductInstance>
	{
		public ProductInstanceConfiguration()
		{
			ToTable("product_instance");
			HasKey(productInst => productInst.Code);
			Property(productInst => productInst.Code).HasColumnName("code").IsRequired();
			Property(productInst => productInst.ProductId).HasColumnName("product_id").IsRequired();
			HasRequired<Product>(p => p.Product).WithMany(p => p.ProductInstances)
				.HasForeignKey<long>(p => p.ProductId);
			HasOptional<Order>(p => p.Order).WithMany(o => o.ProductInstances)
				.HasForeignKey(p => p.OrderId);
		}
	}
}
