using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class UserRoleConfigurations : BaseConfigurations<UserRole>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<UserRole> builder)
		{
		}
	}
}
