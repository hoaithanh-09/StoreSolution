using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class RolePermissionConfigurations: BaseConfigurations<RolePermission>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<RolePermission> builder)
		{
		}
	}
}