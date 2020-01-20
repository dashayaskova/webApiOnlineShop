using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProvides.Configurations
{
	class CategoryConfiguration : EntityTypeConfiguration<Category>
	{
		public CategoryConfiguration()
		{
			ToTable("category");
			HasKey(category => category.Id);
			Property(category => category.Id).HasColumnName("category_id").IsRequired();
			Property(category => category.Name).HasMaxLength(50).HasColumnName("title").IsRequired();
		}
	}
}
