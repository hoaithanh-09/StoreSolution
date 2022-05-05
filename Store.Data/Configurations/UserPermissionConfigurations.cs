using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class UserPermissionConfigurations : BaseConfigurations<UserPermission>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<UserPermission> builder)
		{
		}
	}
}
