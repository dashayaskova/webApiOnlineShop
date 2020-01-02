using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProvides.Configurations
{
	class OrderConfiguration : EntityTypeConfiguration<Order>
	{
		public OrderConfiguration()
		{
			ToTable("order");
			HasKey(order => order.Id);
			Property(order => order.Id).HasColumnName("order_id").IsRequired();
			Property(order => order.UserId).HasColumnName("user_id").IsRequired();
			HasRequired<User>(o => o.User).WithMany(u => u.Orders).HasForeignKey<string>(o => o.UserId);
		}
	}
}
