using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProvides.Configurations
{
	class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			ToTable("user");
			HasKey(user => user.Username);
			Property(user => user.Username).HasColumnName("username").IsRequired();
			Property(user => user.Email).HasMaxLength(50).HasColumnName("email").IsRequired();
			Property(user => user.Password).HasMaxLength(50).HasColumnName("password").IsRequired();
			Property(user => user.PhoneNumber).HasMaxLength(50).HasColumnName("phonenumber").IsRequired();
		}
	}
}
